using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
    public static class GetCompanyEdit
    {
        [FunctionName("GetCompanyEdit")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, ILogger log)
        {
            log.LogTrace("C# HTTP trigger function processed a request.");

            dynamic body = await req.Content.ReadAsStringAsync();

            string CompanyName;
            Guid? CompanyId;
            string json = null;

            try
            {
                var data = JsonConvert.DeserializeObject<Company>(body as string);
                CompanyId = data?.CompanyId;
                CompanyName = data?.CompanyName;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            // parse query parameter

            string connectionstring2 = "DefaultEndpointsProtocol=https;AccountName=spassessservices20190227;AccountKey=KLx/VDJ279oOZ2Z2wELr90GauiVlEN4pr8r2ss2xAiokZJGAi4PF6eGz0nI0Vz0IieEwtKxqkgoM+ukeVoWxMw==;EndpointSuffix=core.windows.net";

            if (CompanyId == null)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a company id");
            }

            try
            {
                //this code will do a insert and do a check for the id
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstring2);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                CloudTable cloudTable = tableClient.GetTableReference("company");

                TableOperation tableOperation = TableOperation.Retrieve<Company>(CompanyId.Value.ToString(), CompanyName);

                TableResult tableResult = await cloudTable.ExecuteAsync(tableOperation);
                Company company = tableResult.Result as Company;



                if (company != null)
                {


                    // add the code here to pass the id back to the client
                    json = JsonConvert.SerializeObject(company, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }); ;

                    //change this to return the companyid
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };


                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

            }
            catch (StorageException se)
            {
                log.LogTrace(se.Message);

            }
            catch (Exception ex)
            {
                log.LogTrace(ex.Message);
            }


            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
