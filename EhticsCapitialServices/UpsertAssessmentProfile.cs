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
    public static class UpsertAssessmentProfile
    {
        [FunctionName("UpsertAssessmentProfile")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<AssessmentProfile>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            string CompanyName = data?.CompanyName;
            Guid? AssessmentId = data?.AssessmentId;
            string GroupAdminToken = data?.GroupAdminToken;
            string AssessmentToken = data?.AssessmentToken;
            // Contact Contact = data?.Contact;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            if (CompanyName == null && CompanyId == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a CompanyId in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("AssessmentProfile");

            TableOperation tableOperation = TableOperation.Retrieve<AssessmentProfile>(CompanyId.Value.ToString(), CompanyName);

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            AssessmentProfile person = tableResult.Result as AssessmentProfile;

            if (person == null)
            {

                try
                {
                    if (AssessmentId == null)
                    {
                        AssessmentId = GenerateAssessmentId();

                    }


                    var assessment = new AssessmentProfile()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = CompanyName,
                        CompanyId = CompanyId,
                        AssessmentId = AssessmentId,
                        CompanyName = CompanyName,
                        GroupAdminToken = GroupAdminToken,
                        //Contact = Contact

                    };

                    TableOperation insertOperation = TableOperation.Insert(assessment);
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

        public class AssessmentProfile : TableEntity
        {
            public Guid? CompanyId { get; set; }
            public string CompanyName { get; set; }

            public Guid? AssessmentId { get; set; }
            public string GroupAdminToken { get; set; }
            public string AssessmentToken { get; set; }
            //  public Contact Contact { get; set; }

            public AssessmentProfile() { }


        }


        //generate CompanyId
        private static Guid GenerateAssessmentId()
        {
            Guid guid = new Guid();
            return guid;
        }
    }
}

