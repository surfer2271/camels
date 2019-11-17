using System;
using System.Collections.Generic;
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
    public static class UpsertCompany
    {
        [FunctionName("UpsertCompany")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<CompanyRepsonse>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            string CompanyName = data?.CompanyName;
            string Address = data?.Address;
            string GroupAdminToken = data?.GroupAdminToken;
            string AssessmentToken = data?.AssessmentToken;
            // Contact Contact = data?.Contact;

            string oldComanyName = null, oldCompanyAddress = null;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            if (data?.CompanyId == null && data?.CompanyName == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a Company Id and Company Name");
            }

            if (data?.newCompanyName != null || data?.newAddress != null)
            {
                CompanyId = data?.CompanyId;
                CompanyName = data?.newCompanyName;
                Address = data?.newAddress;
                oldComanyName = data?.CompanyName;
                oldCompanyAddress = data?.Address;
                GroupAdminToken = data?.GroupAdminToken;
                AssessmentToken = data?.AssessmentToken;
            }
            else
            {

                CompanyId = data?.CompanyId;
                CompanyName = data?.CompanyName;
                Address = data?.Address;
                oldComanyName = data?.CompanyName;
                oldCompanyAddress = data?.Address;
                GroupAdminToken = data?.GroupAdminToken;
                AssessmentToken = data?.AssessmentToken; 
            }

            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("Company");

            TableOperation tableOperation = TableOperation.Retrieve<Company>(CompanyId.Value.ToString(), CompanyName);

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            Company person = tableResult.Result as Company;
                                 
            if (person == null)
            {

                try
                {
                    if(CompanyId == null)
                    {
                        CompanyId = GenerateCompanyId();

                    }


                    var company = new Company()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = CompanyName,
                        CompanyId = CompanyId,
                        CompanyName = CompanyName,
                        Address = Address,
                        GroupAdminToken = GroupAdminToken,
                        //Contact = Contact

                    };

                    TableOperation insertOperation = TableOperation.Insert(company);
                    TableResult insertResult = await cloudTable.ExecuteAsync(insertOperation);

                }
                catch (StorageException se)
                {
                    log.LogTrace(se.Message);
                    return req.CreateResponse(HttpStatusCode.BadRequest, "failed");

                }
                catch (Exception ex)
                {
                    log.LogTrace(ex.Message);
                    return req.CreateResponse(HttpStatusCode.BadRequest, "failed");
                }
                
            }
            else
            {
                try
                {
                    


                    var updateCompany = new Company()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = CompanyName,
                        CompanyId = CompanyId,
                        CompanyName = CompanyName,
                        Address = Address,
                        GroupAdminToken = GroupAdminToken,
                        AssessmentToken = AssessmentToken
                        //Contact = Contact

                    };

                    TableOperation updateOperation = TableOperation.Replace(updateCompany);
                    TableResult insertResult = await cloudTable.ExecuteAsync(updateOperation);

                }
                catch (StorageException se)
                {
                    log.LogTrace(se.Message);
                    return req.CreateResponse(HttpStatusCode.BadRequest, "failed");

                }
                catch (Exception ex)
                {
                    log.LogTrace(ex.Message);
                    return req.CreateResponse(HttpStatusCode.BadRequest, "failed");
                }
               
            }



            return req.CreateResponse(HttpStatusCode.Created, "successful");
        }

        public class CompanyRepsonse
        {   
            public Guid? CompanyId { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string GroupAdminToken { get; set; }
            public string AssessmentToken { get; set; }
            //  public Contact Contact { get; set; }

            public string newCompanyName { get; set; }
            public string newAddress { get; set; }


        }

        public class Company : TableEntity
        {
            public Guid? CompanyId { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string GroupAdminToken { get; set; }
            public string AssessmentToken { get; set; }
            //  public Contact Contact { get; set; }

            public Company() { }


        }

        public class Contact
        {
            public Guid CompanyId { get; set; }
            public string CompanyName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; }
        }

        //generate CompanyId
        public static Guid GenerateCompanyId()
        {
            Guid guid = new Guid();
            return guid;
        }
    }
}
