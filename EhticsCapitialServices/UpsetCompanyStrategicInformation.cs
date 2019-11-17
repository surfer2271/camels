using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using System.Net;
using System.Net.Http;

namespace EhticsCapitialServices
{
    public static class UpsetCompanyStrategicInformation
    {
        [FunctionName("UpsetCompanyStrategicInformation")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<CompanyStrategicInfo>(body as string);

            //name = name ?? data?.name;

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            string Vision = data?.Vision;
            string Values = data?.Values;
            string Mission = data?.Mission;
            string MissionOutComes = data?.MissionOutComes;
            string CompetitiveStrategy = data?.CompetitiveStrategy;
            string StrategyOutComes = data?.StrategyOutComes;
            string RegulatoryOutComes = data?.RegulatoryOutComes;


            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("Registration");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<CompanyStrategicInfo>(CompanyId.Value.ToString(), CompanyId.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            CompanyStrategicInfo person = tableResult.Result as CompanyStrategicInfo;


            if (person == null)
            {

                try
                {

                    var registration = new CompanyStrategicInfo()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = CompanyId.Value.ToString(),
                        CompanyId = CompanyId,
                        Vision = Vision,
                        Values = Values,
                        Mission = Mission,
                        MissionOutComes = MissionOutComes,
                        CompetitiveStrategy = CompetitiveStrategy,
                        StrategyOutComes = StrategyOutComes,
                        RegulatoryOutComes = RegulatoryOutComes

                    };

                    TableOperation insertOperation = TableOperation.Insert(registration);
                    TableResult insertResult = await cloudTable.ExecuteAsync(insertOperation);


                    var login = new CompanyStrategicInfo()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = CompanyId.Value.ToString(),
                        CompanyId = CompanyId,
                        Vision  = Vision,
                        Values = Values,
                        Mission  = Mission,
                        MissionOutComes  = MissionOutComes,
                        CompetitiveStrategy = CompetitiveStrategy,
                        StrategyOutComes  = StrategyOutComes,
                        RegulatoryOutComes = RegulatoryOutComes

    };

                    CloudTable cloudTable1 = tableClient.GetTableReference("Login");
                    TableOperation insertOperation1 = TableOperation.Insert(login);
                    TableResult insertResult1 = await cloudTable1.ExecuteAsync(insertOperation1);
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
            else
            {
                //do the update
            }



            return req.CreateResponse(HttpStatusCode.Created, "successful");


        }

        public class CompanyStrategicInfo: TableEntity
        {
            public Guid? CompanyId { get; set; }
            public string Vision { get; set; }
            public string Values { get; set; }
            public string Mission { get; set; }
            public string MissionOutComes { get; set; }
            public string CompetitiveStrategy { get; set; }
            public string StrategyOutComes { get; set; }
            public string RegulatoryOutComes { get; set; }

        }
    }
}
