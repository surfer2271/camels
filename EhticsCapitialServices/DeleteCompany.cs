using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using static EhticsCapitialServices.UpsertCompany;
using static EhticsCapitialServices.UpsertLogin;

namespace EhticsCapitialServices
{
    public static class DeleteCompany
    {
        [FunctionName("DeleteCompany")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
           
            log.LogTrace("C# HTTP trigger function processed a request.");

            // parse query parameter

            dynamic body = await req.Content.ReadAsStringAsync();

            Guid? CompanyId;
            string ComanyName;
            try
            {
                var data = JsonConvert.DeserializeObject<Company>(body as string);
                CompanyId = data?.CompanyId ;
                ComanyName = data?.CompanyName;
                

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
                CloudTable cloudTable = tableClient.GetTableReference("Company");

                TableOperation tableOperation = TableOperation.Retrieve<Login>(CompanyId.Value.ToString(), ComanyName);

                TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
                Company comany = tableResult.Result as Company;
                
                TableOperation deleteOperation = TableOperation.Delete(comany);
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
