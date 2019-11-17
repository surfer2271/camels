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
    public static class GetLogin
    {
        [FunctionName("GetLogin")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            string UserName, Password;
            Guid? CompanyID;
            try
            {
                var data = JsonConvert.DeserializeObject<Login>(body as string);
                UserName = data?.UserName;
                Password = data?.Password;
                CompanyID = data?.CompanyId;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            // parse query parameter

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";
           
            if (Password == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a password");
            }

            try
            {
                //this code will do a insert and do a check for the id
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                CloudTable cloudTable = tableClient.GetTableReference("Login");

                TableOperation tableOperation = TableOperation.Retrieve<Login>(UserName, Password);

                TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
                Login person = tableResult.Result as Login;


                if (person != null && CompanyID == person.CompanyId)
                {

                    //change this to return the companyid
                    //return new HttpResponseMessage(HttpStatusCode.OK);
                    return req.CreateResponse(HttpStatusCode.OK, "successful");
                }
                else
                     return req.CreateResponse(HttpStatusCode.BadRequest, "failed");

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
