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

namespace EhticsCapitialServices
{
    public static class GetCompanies
    {
        [FunctionName("GetCompanies")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            // parse query parameter

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            try
            {
                //this code will do a insert and do a check for the id
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                CloudTable cloudTable = tableClient.GetTableReference("company");

                TableContinuationToken token = null;
                var entities = new List<Company>();
                do
                {
                    Task<TableQuerySegment<Company>> queryResult = cloudTable.ExecuteQuerySegmentedAsync(new TableQuery<Company>(), token);
                    entities.AddRange(queryResult.Result);
                    token = queryResult.Result.ContinuationToken;
                } while (token != null);

                //  TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);

                var json = JsonConvert.SerializeObject(entities);

                if (entities != null)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };

                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

            }
            catch (StorageException se)
            {
                log.LogTrace(se.Message);

            }
            catch (Exception ex)
            {
                log.LogTrace(ex.Message);
            }


            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
