using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using static EhticsCapitialServices.UpsertLogin;

namespace EhticsCapitialServices
{
    public static class DeleteLogin
    {
        [FunctionName("DeleteLogin")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            // parse query parameter

            dynamic body = await req.Content.ReadAsStringAsync();

            string UserName;
            string Password;
            try
            {
                var data = JsonConvert.DeserializeObject<Login>(body as string);
                UserName = data?.UserName;
                Password = data?.Password;


            }
            catch (Exception ex)
            {
                throw ex;
            }


            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            try
            {

                //this code will do a insert and do a check for the id
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();


                //first call to get the login and verify
                CloudTable cloudTable = tableClient.GetTableReference("Login");

                TableOperation tableOperation = TableOperation.Retrieve<Login>(UserName, Password);

                TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
                Login login = tableResult.Result as Login;                 

                TableOperation deleteOperation = TableOperation.Delete(login);
                TableResult comanyResult = await cloudTable.ExecuteAsync(deleteOperation);

                return req.CreateResponse(HttpStatusCode.OK, "successful");
            }
            catch (StorageException se)
            {
                log.LogTrace(se.Message);

            }
            catch (Exception ex)
            {
                log.LogTrace(ex.Message);
            }


            return req.CreateResponse(HttpStatusCode.BadRequest, "failed");
        }
    }
}
