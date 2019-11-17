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
    public static class UpsertEarningsSustainKnowledgeAssessment
    {
        [FunctionName("UpsertEarningsSustainKnowledgeAssessment")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<EarningsStabilityAssessment>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            Guid? AssessmentID = data?.AssessmentID;
            int? EarningsStabilityRating = data?.EarningsStabilityRating;
            int? ROAA = data?.ROAA;
            int? EarningsStabilityQuestion1 = data?.EarningsStabilityQuestion1;
            int? EarningsStabilityQuestion2 = data?.EarningsStabilityQuestion2;
            int? EarningsStabilityQuestion3 = data?.EarningsStabilityQuestion3;
            int? CompositeAverage = data?.CompositeAverage;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null && AssessmentID == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("EarningsStabilityAssessment");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<EarningsStabilityAssessment>(CompanyId.Value.ToString(), AssessmentID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            EarningsStabilityAssessment capitalAdequacy = tableResult.Result as EarningsStabilityAssessment;


            if (capitalAdequacy == null)
            {

                try
                {

                    var earningsStabilityAssessment = new EarningsStabilityAssessment()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = AssessmentID.Value.ToString(),
                        CompanyId = CompanyId,
                        AssessmentID = AssessmentID,
                        EarningsStabilityRating = EarningsStabilityRating,
                        ROAA = ROAA,
                        EarningsStabilityQuestion1 = EarningsStabilityQuestion1,
                        EarningsStabilityQuestion2 = EarningsStabilityQuestion2,
                        EarningsStabilityQuestion3 = EarningsStabilityQuestion3,
                        CompositeAverage = CompositeAverage
                    };

                    TableOperation insertOperation = TableOperation.Insert(earningsStabilityAssessment);
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
    class EarningsStabilityAssessment : TableEntity
    {
        public Guid? CompanyId { get; set; }
        public Guid? AssessmentID { get; set; }
        public int? EarningsStabilityRating { get; set; }
        public int? ROAA { get; set; }
        public int? EarningsStabilityQuestion1 { get; set; }
        public int? EarningsStabilityQuestion2 { get; set; }
        public int? EarningsStabilityQuestion3 { get; set; }
        public int? CompositeAverage { get; set; }
    }
}
