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

namespace EhticsCapitialServices
{
    public static class UpsertMgmtDisc
    {
        [FunctionName("UpsertMgmtDisc")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<MgmtDisc>(body as string);

            // parse query parameter
            //int? Id = data?.Id;
            Guid? CompanyID = data?.CompanyID;
           

            string StrategyMgmtMFO = data?.StrategyMgmtMFO;
            string StrategyMgmtMFOmetric = data?.StrategyMgmtMFOmetric;

            string StrategyMgmtMRO = data?.StrategyMgmtMRO;
            string StrategyMgmtMROmetric = data?.StrategyMgmtMROmetric;


            string StakeholderMgmtMFO = data?.StakeholderMgmtMFO;
            string StakeholderMgmtMFOmetric = data?.StakeholderMgmtMFOmetric;

            string StakeholderMgmtMRO = data?.StakeholderMgmtMRO;
            string StakeholderMgmtMROmetric = data?.StakeholderMgmtMROmetric;


            string OperationMgmtMFO = data?.OperationMgmtMFO;
            string OperationMgmtMFOmetric = data?.OperationMgmtMFOmetric;

            string OperationMgmtMRO = data?.OperationMgmtMRO;
            string OperationMgmtMROmetric = data?.OperationMgmtMROmetric;


            string RiskMgmtMFO = data?.RiskMgmtMFO;
            string RiskMgmtMFOmetric = data?.RiskMgmtMFOmetric;

            string RiskMgmtMRO = data?.RiskMgmtMRO;
            string RiskMgmtMROmetric = data?.RiskMgmtMROmetric;



            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            if (StrategyMgmtMFO == null && StrategyMgmtMFOmetric == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a Id in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("MgmtDisc");

            TableOperation tableOperation = TableOperation.Retrieve<MgmtDisc>(CompanyID.Value.ToString(), CompanyID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            MgmtDisc person = tableResult.Result as MgmtDisc;


            if (person == null)
            {

                try
                {

                    var mgmtDisc = new MgmtDisc()
                    {
                        //Id = Id.Value,
                        PartitionKey = CompanyID.Value.ToString(),
                        RowKey = CompanyID.Value.ToString(),

                        CompanyID = CompanyID,
                        StrategyMgmtMFO = StrategyMgmtMFO,
                        StrategyMgmtMFOmetric = StrategyMgmtMFOmetric,


                        StrategyMgmtMRO = StrategyMgmtMRO,
                        StrategyMgmtMROmetric = StrategyMgmtMROmetric,


                        StakeholderMgmtMFO = StakeholderMgmtMFO,
                        StakeholderMgmtMFOmetric = StakeholderMgmtMFOmetric,

                        StakeholderMgmtMRO = StakeholderMgmtMRO,
                        StakeholderMgmtMROmetric = StakeholderMgmtMROmetric,


                        OperationMgmtMFO = OperationMgmtMFO,
                        OperationMgmtMFOmetric = OperationMgmtMFOmetric,

                        OperationMgmtMRO = OperationMgmtMRO,
                        OperationMgmtMROmetric = OperationMgmtMROmetric,


                        RiskMgmtMFO = RiskMgmtMFO,
                        RiskMgmtMFOmetric = RiskMgmtMFOmetric,

                        RiskMgmtMRO = RiskMgmtMRO,
                        RiskMgmtMROmetric = RiskMgmtMROmetric

                    };

                    TableOperation insertOperation = TableOperation.Insert(mgmtDisc);
                    TableResult insertResult = await cloudTable.ExecuteAsync(insertOperation);
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



            return req.CreateResponse(HttpStatusCode.Created, "successful");
        }

        public class MgmtDisc : TableEntity
        {
            public Guid? CompanyID { get; set; }
         
            public string StrategyMgmtMFO { get; set; }
            public string StrategyMgmtMFOmetric { get; set; }

            public string StrategyMgmtMRO { get; set; }
            public string StrategyMgmtMROmetric { get; set; }

            public string StakeholderMgmtMFO { get; set; }
            public string StakeholderMgmtMFOmetric { get; set; }

            public string StakeholderMgmtMRO { get; set; }
            public string StakeholderMgmtMROmetric { get; set; }

            public string OperationMgmtMFO { get; set; }
            public string OperationMgmtMFOmetric { get; set; }

            public string OperationMgmtMRO { get; set; }
            public string OperationMgmtMROmetric { get; set; }

            public string RiskMgmtMFO { get; set; }
            public string RiskMgmtMFOmetric { get; set; }

            public string RiskMgmtMRO { get; set; }
            public string RiskMgmtMROmetric { get; set; }


        }
    }
}