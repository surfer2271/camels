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
using System.Net.Http;
using Microsoft.WindowsAzure.Storage;
using System.Net;

namespace EhticsCapitialServices.CAMEL
{
    public static class UpsertCapitalAdequacyAssessment
    {
        [FunctionName("UpsertCapitalAdequacyAssessment")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<CapitalAdequacyAssessment>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            Guid? AssessmentID = data?.AssessmentID;
            int? CapitalAdequacyRating = data?.CapitalAdequacyRating;
            int? Tier1CapitalRatio = data?.Tier1CapitalRatio;
            int? TotalCapitalRatio = data?.TotalCapitalRatio;
            int? CapitalAdequacyQuestion1 = data?.CapitalAdequacyQuestion1;
            int? CapitalAdequacyQuestion2 = data?.CapitalAdequacyQuestion2;
            int? CapitalAdequacyQuestion3 = data?.CapitalAdequacyQuestion3;
            int? CompositeAverage = data?.CompositeAverage;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null && AssessmentID == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("CapitalAdequacyAssessment");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<CapitalAdequacyAssessment>(CompanyId.Value.ToString(), AssessmentID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            CapitalAdequacyAssessment capitalAdequacy = tableResult.Result as CapitalAdequacyAssessment;


            if (capitalAdequacy == null)
            {

                try
                {

                    var capitalAdequacyAssessment = new CapitalAdequacyAssessment()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = AssessmentID.Value.ToString(),
                        CompanyId = CompanyId,
                        AssessmentID = AssessmentID,
                        CapitalAdequacyRating = CapitalAdequacyRating,
                        Tier1CapitalRatio = Tier1CapitalRatio,
                        TotalCapitalRatio = TotalCapitalRatio,
                        CapitalAdequacyQuestion1 = CapitalAdequacyQuestion1,
                        CapitalAdequacyQuestion2 = CapitalAdequacyQuestion2,
                        CapitalAdequacyQuestion3 = CapitalAdequacyQuestion3,
                        CompositeAverage = CompositeAverage
                    };

                    TableOperation insertOperation = TableOperation.Insert(capitalAdequacyAssessment);
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
        class CapitalAdequacyAssessment : TableEntity
        {
            public Guid? CompanyId { get; set; }
            public Guid? AssessmentID { get; set; }
            public int? CapitalAdequacyRating { get; set; }
            public int? Tier1CapitalRatio { get; set; }
            public int? TotalCapitalRatio { get; set; }
            public int? CapitalAdequacyQuestion1 { get; set; }
            public int? CapitalAdequacyQuestion2 { get; set; }
            public int? CapitalAdequacyQuestion3 { get; set; }
            public int? CompositeAverage { get; set; }
        }
    }
}
