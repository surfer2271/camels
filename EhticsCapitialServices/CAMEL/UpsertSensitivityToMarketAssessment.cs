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

namespace EhticsCapitialServices.CAMEL
{
    public static class UpsertSensitivityToMarketAssessment
    {
        [FunctionName("UpsertSensitivityToMarketAssessment")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<SensitivityToMarketRiskAssessment>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            Guid? AssessmentID = data?.AssessmentID;
            int? SensitivityToMarketRiskRating = data?.SensitivityToMarketRiskRating;
            int? AdverselyStressedNIM = data?.AdverselyStressedNIM;
            int? SensitivityToMarketQuestion1 = data?.SensitivityToMarketQuestion1;
            int? SensitivityToMarketQuestion2 = data?.SensitivityToMarketQuestion2;
            int? SensitivityToMarketQuestion3 = data?.SensitivityToMarketQuestion3;
            int? CompositeAverage = data?.CompositeAverage;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null && AssessmentID == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("SensitivityToMarketRiskAssessment");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<SensitivityToMarketRiskAssessment>(CompanyId.Value.ToString(), AssessmentID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            SensitivityToMarketRiskAssessment capitalAdequacy = tableResult.Result as SensitivityToMarketRiskAssessment;


            if (capitalAdequacy == null)
            {

                try
                {

                    var liquidityRiskAssessment = new SensitivityToMarketRiskAssessment()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = AssessmentID.Value.ToString(),
                        CompanyId = CompanyId,
                        AssessmentID = AssessmentID,
                        SensitivityToMarketRiskRating = SensitivityToMarketRiskRating,
                        AdverselyStressedNIM = AdverselyStressedNIM,
                        SensitivityToMarketQuestion1 = SensitivityToMarketQuestion1,
                        SensitivityToMarketQuestion2 = SensitivityToMarketQuestion2,
                        SensitivityToMarketQuestion3 = SensitivityToMarketQuestion3,
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


    class SensitivityToMarketRiskAssessment : TableEntity
    {
         public Guid? CompanyId { get; set; }
         public Guid? AssessmentID { get; set; }
         public int? SensitivityToMarketRiskRating { get; set; }
         public int? AdverselyStressedNIM { get; set; }
         public int? SensitivityToMarketQuestion1 { get; set; }
         public int? SensitivityToMarketQuestion2 { get; set; }
         public int? SensitivityToMarketQuestion3 { get; set; }
         public int? CompositeAverage { get; set; }
    }
}
