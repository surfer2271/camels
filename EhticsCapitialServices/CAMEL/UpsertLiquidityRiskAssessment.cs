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
using System.Net;
using Microsoft.WindowsAzure.Storage;
using System.Net.Http;

namespace EhticsCapitialServices.CAMEL
{
    public static class UpsertLiquidityRiskAssessment
    {
        [FunctionName("UpsertLiquidityRiskAssessment")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<LiquidityRiskAssessment>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            Guid? AssessmentID = data?.AssessmentID;
            int? LiquidityRiskRating = data?.LiquidityRiskRating;
            int? AdverselyStressedLiquidityRating = data?.AdverselyStressedLiquidityRating;
            int? LiquidityRiskQuestion1 = data?.LiquidityRiskQuestion1;
            int? LiquidityRiskQuestion2 = data?.LiquidityRiskQuestion2;
            int? LiquidityRiskQuestion3 = data?.LiquidityRiskQuestion3;
            int? CompositeAverage = data?.CompositeAverage;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null && AssessmentID == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("LiquidityRiskAssessment");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<LiquidityRiskAssessment>(CompanyId.Value.ToString(), AssessmentID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            LiquidityRiskAssessment capitalAdequacy = tableResult.Result as LiquidityRiskAssessment;


            if (capitalAdequacy == null)
            {

                try
                {

                    var liquidityRiskAssessment = new LiquidityRiskAssessment()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = AssessmentID.Value.ToString(),
                        CompanyId = CompanyId,
                        AssessmentID = AssessmentID,
                        LiquidityRiskRating = LiquidityRiskRating,
                        AdverselyStressedLiquidityRating = AdverselyStressedLiquidityRating,
                        LiquidityRiskQuestion1 = LiquidityRiskQuestion1,
                        LiquidityRiskQuestion2 = LiquidityRiskQuestion2,
                        LiquidityRiskQuestion3 = LiquidityRiskQuestion3,
                        CompositeAverage = CompositeAverage

                    };

                    TableOperation insertOperation = TableOperation.Insert(liquidityRiskAssessment);
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
            else
            {
                //do the update

            }

            return req.CreateResponse(HttpStatusCode.Created, "successful");

        }
    }

    class LiquidityRiskAssessment : TableEntity
    {
        public Guid? CompanyId { get; set; }
        public Guid? AssessmentID { get; set; }
        public int? LiquidityRiskRating { get; set; }
         public int? AdverselyStressedLiquidityRating { get; set; }
        public int? LiquidityRiskQuestion1 { get; set; }
        public int? LiquidityRiskQuestion2 { get; set; }
         public int? LiquidityRiskQuestion3 { get; set; }
        public int? CompositeAverage { get; set; }
    }
}
