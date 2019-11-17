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
    public static class UpsertMgmtEffectivnessAssessment
    {
        [FunctionName("UpsertMgmtEffectivnessAssessment")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ManagementEffectivenessAssessment>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            Guid? AssessmentID = data?.AssessmentID;
            int? CapitalAdequacyRating = data?.CapitalAdequacyRating;
            int? CRARating = data?.CRARating;
            int? EfficeincyRatio = data?.EfficeincyRatio;
            int? ManagementEffectivenessQuestion1 = data?.ManagementEffectivenessQuestion1;
            int? ManagementEffectivenessQuestion2 = data?.ManagementEffectivenessQuestion2;
            int? ManagementEffectivenessQuestion3 = data?.ManagementEffectivenessQuestion3;
            int? CompositeAverage = data?.CompositeAverage;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (CompanyId == null && AssessmentID == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("ManagementEffectivenessAssessment");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<ManagementEffectivenessAssessment>(CompanyId.Value.ToString(), AssessmentID.Value.ToString());

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            ManagementEffectivenessAssessment capitalAdequacy = tableResult.Result as ManagementEffectivenessAssessment;


            if (capitalAdequacy == null)
            {

                try
                {

                    var managementEffectivenessAssessment = new ManagementEffectivenessAssessment()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = AssessmentID.Value.ToString(),
                        CompanyId = CompanyId,
                        AssessmentID = AssessmentID,
                        CapitalAdequacyRating = CapitalAdequacyRating,
                        CRARating = CRARating,
                        EfficeincyRatio = EfficeincyRatio,
                        ManagementEffectivenessQuestion1 = ManagementEffectivenessQuestion1,
                        ManagementEffectivenessQuestion2 = ManagementEffectivenessQuestion2,
                        ManagementEffectivenessQuestion3 = ManagementEffectivenessQuestion3,
                        CompositeAverage = CompositeAverage
                    };

                    TableOperation insertOperation = TableOperation.Insert(managementEffectivenessAssessment);
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

    class ManagementEffectivenessAssessment : TableEntity
    {
        public Guid? CompanyId { get; set; }
        public Guid? AssessmentID { get; set; }
        public int? CapitalAdequacyRating { get; set; }
        public int? CRARating { get; set; }
        public int? EfficeincyRatio { get; set; }
         public int? ManagementEffectivenessQuestion1 { get; set; }
        public int? ManagementEffectivenessQuestion2 { get; set; }
         public int? ManagementEffectivenessQuestion3 { get; set; }
        public int? CompositeAverage { get; set; }
    }
}
