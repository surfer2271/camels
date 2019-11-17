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
using System.Net;
using Microsoft.WindowsAzure.Storage;

namespace EhticsCapitialServices.CAMEL
{
    public static class UpsertAssetKnowldegeAssessment
    {
        [FunctionName("UpsertAssetKnowldegeAssessment")]
         public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<AssetQualityAssessment>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            Guid? AssessmentID = data?.AssessmentID;
            int? CapitalAdequacyRating = data?.CapitalAdequacyRating;
            int? AdverselyClassifiedItemsRatio = data?.AdverselyClassifiedItemsRatio;
            int? AssetQualityQuestion1 = data?.AssetQualityQuestion1;
            int? AssetQualityQuestion2 = data?.AssetQualityQuestion2;
            int? AssetQualityQuestion3 = data?.AssetQualityQuestion3;
            int? CompositeAverage = data?.CompositeAverage;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null && AssessmentID == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("AssetQualityAssessment");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<AssetQualityAssessment>(CompanyId.Value.ToString(), AssessmentID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            AssetQualityAssessment capitalAdequacy = tableResult.Result as AssetQualityAssessment;


            if (capitalAdequacy == null)
            {

                try
                {

                    var assetQualityAssessment = new AssetQualityAssessment()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = AssessmentID.Value.ToString(),
                        CompanyId = CompanyId,
                        AssessmentID = AssessmentID,
                        CapitalAdequacyRating = CapitalAdequacyRating,
                        AdverselyClassifiedItemsRatio = AdverselyClassifiedItemsRatio,
                        AssetQualityQuestion1 = AssetQualityQuestion1,
                        AssetQualityQuestion2 = AssetQualityQuestion2,
                        AssetQualityQuestion3 = AssetQualityQuestion3,
                        CompositeAverage = CompositeAverage
                    };

                    TableOperation insertOperation = TableOperation.Insert(assetQualityAssessment);
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
        class AssetQualityAssessment : TableEntity
        {
            public Guid? CompanyId { get; set; }
            public Guid? AssessmentID { get; set; }
            public int? CapitalAdequacyRating { get; set; }
            public int? AdverselyClassifiedItemsRatio { get; set; }
            public int? AssetQualityQuestion1 { get; set; }
            public int? AssetQualityQuestion2 { get; set; }
            public int? AssetQualityQuestion3 { get; set; }
            public int? CompositeAverage { get; set; }
        }
    }
}
   

