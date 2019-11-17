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
using static EhticsCapitialServices.UpsertCompany;

namespace EhticsCapitialServices
{
    public static class UpsertLogin
    {
        [FunctionName("UpsertLogin")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<LoginRepsonse>(body as string);

            // parse query parameter
            Guid? CompanyId = data?.CompanyId;
            string oldUserName = null, oldPassword = null, UserName = null, Password = null;

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            if (data?.UserName == null && data?.Password == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a username and password");
            }

            if (data?.newUserName != null || data?.newPassword != null)
            {
                 oldUserName = data?.UserName;
                 oldPassword = data?.Password;
                 UserName = data?.newUserName;
                 Password = data?.newPassword;
            }
            else
            {
                 UserName = data?.UserName;
                 Password = data?.Password;
                 oldUserName = UserName;
                 oldPassword = Password;
            }
          
          
            Login login;
            try
            {

                //this code will do a insert and do a check for the id
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();


                //first call to get the login and verify
                CloudTable cloudTable = tableClient.GetTableReference("Login");

                TableOperation tableOperation = TableOperation.Retrieve<Login>(oldUserName, oldPassword);

                TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
                 login = tableResult.Result as Login;

                if (login == null)
                {

                 

                        var newLogin = new Login()
                        {
                            PartitionKey = UserName,
                            RowKey = Password,
                            CompanyId = UpsertCompany.GenerateCompanyId(),
                            UserName = UserName,
                            Password = Password,
                            oldUserName = oldUserName,
                            oldPassword = oldPassword


                        };

                        TableOperation insertOperation = TableOperation.Insert(newLogin);
                        TableResult insertResult = await cloudTable.ExecuteAsync(insertOperation);

                        return req.CreateResponse(HttpStatusCode.Created, "successful");
                }
                else
                {
                    var updateLogin = new Login()
                    {
                        PartitionKey = UserName,
                        RowKey = Password,
                        CompanyId = login.CompanyId,
                        UserName = UserName,
                        Password = Password,
                        oldUserName = oldUserName,
                        oldPassword = oldPassword,
                        ETag = "*"

                    };

                    var operation = TableOperation.Replace(updateLogin);
                    await cloudTable.ExecuteAsync(operation);

                    return req.CreateResponse(HttpStatusCode.Created, "successful");
                }

            }
            catch (StorageException se)
            {
                log.LogTrace(se.Message);

            }
            catch (Exception ex)
            {
                log.LogTrace(ex.Message);
            }
           

            return req.CreateResponse(HttpStatusCode.Created, "successful");
        }

        public class LoginRepsonse
        {
            public long? Id { get; set; }
            public Guid? CompanyId { get; set; }
            // public Guid? CompanyName { get; set; }
            //public Guid? AssessmentId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

            public string newUserName { get; set; }

            public string newPassword { get; set; }

        }
        public class Login : TableEntity
        {
            public Guid? CompanyId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string oldUserName { get; set; }

            public string oldPassword { get; set; }
       
        }
    }
}
