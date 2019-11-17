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
using static EhticsCapitialServices.UpsertLogin;

namespace EhticsCapitialServices
{
    public static class UpsertRegistration
    {
        [FunctionName("UpsertRegistration")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Registration>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            string UserName = data?.UserName;
            string Email = data?.Email;
            string Password = data?.Password;
            string PasswordSalt = data?.PasswordSalt;
            string FirstName = data?.FirstName;
            string LastName = data?.LastName;
            string UserType = data?.UserType;
            DateTime? CreatedDate = data?.CreatedDate;
            bool? IsActive = data?.IsActive;
            string IPAddress = data?.IPAddress;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";


            if (Email == null && Password == null && FirstName == null && LastName == null && CompanyId == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a full Regisration in the request body");
            }


            //this code will do a insert and do a check for the id
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable cloudTable = tableClient.GetTableReference("Registration");

            //Email is the unique data
            TableOperation tableOperation = TableOperation.Retrieve<Registration>(CompanyId.Value.ToString(), UserName);

            TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
            Registration person = tableResult.Result as Registration;


            if (person == null)
            {

                try
                {

                    var registration = new Registration()
                    {
                        PartitionKey = CompanyId.Value.ToString(),
                        RowKey = Email,
                        CompanyId = CompanyId ,
                        Email =  Email ,
                        Password= Password  ,
                        PasswordSalt= PasswordSalt ,
                        FirstName = FirstName ,
                        LastName= LastName ,
                        UserType =  UserType ,
                        CreatedDate = CreatedDate.Value  ,
                        IsActive =  IsActive.Value  ,
                        IPAddress = IPAddress

                    };

                    TableOperation insertOperation = TableOperation.Insert(registration);
                    TableResult insertResult = await cloudTable.ExecuteAsync(insertOperation);


                    var login = new Login()
                    {
                        PartitionKey =UserName,
                        RowKey = Password,
                        Password = Password,
                        CompanyId = CompanyId

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

        public class Registration : TableEntity
        {
            public Guid? CompanyId { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PasswordSalt { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserType { get; set; }
            public System.DateTime CreatedDate { get; set; }
            public bool IsActive { get; set; }
            public string IPAddress { get; set; }


        }
    }
}
