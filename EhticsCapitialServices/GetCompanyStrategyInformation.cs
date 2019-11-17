using System;
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
using static EhticsCapitialServices.UpsetCompanyStrategicInformation;

namespace EhticsCapitialServices
{
    public static class GetCompanyStrategyInformation
    {
        [FunctionName("GetCompanyStrategyInformation")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {

            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<CompanyStrategicInfo> (body as string);

            // parse query parameter
            Guid? CompanyId = data.CompanyId;
           
            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=workconnectuser;AccountKey=Kv56s3lKZhE9WriAvDMubc5pmenB+NF1vkv6rINS0wlEOJfQVvRIrntpuKaqgpomqkF/4M99pMtmo7Egjq9MvQ==;EndpointSuffix=core.windows.net";


            if (CompanyId == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a company name");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("companyvisionsurvey");

            TableOperation tableOperation = TableOperation.Retrieve<CompanyStrategicInfo>(CompanyId.Value.ToString(), CompanyId.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            CompanyStrategicInfo person = tableResult.Result as CompanyStrategicInfo;

            string json = null;

            if (person == null)
            {

                try
                {
                    // add the code here to pass the id back to the client
                    json = JsonConvert.SerializeObject(person);

                }
                catch (StorageException se)
                {
                    log.LogTrace(se.Message);

                }
                catch (Exception ex)
                {
                    log.LogTrace(ex.Message);
                }
            }


            //change this to return the companyid
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }
    }
}
