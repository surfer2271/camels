using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EthicsCap2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EthicsCap2.Controllers
{
    public class CompanyController : Controller
    {
        //string BASE_URL = "https://spassessservices20190608094418.azurewebsites.net/api/GetLogin?code=IsgjWLWQu9/qZJ4JbiUaeJ11/DSIi7GMAgBTS4HNJTIxYHYka7iOaQ==";

        string BASE_URL_GETCOMPANY = "http://localhost:7071/api/GetCompany/";
        string BASE_URL_GETCOMPANIES = "http://localhost:7071/api/GetCompanies/";
        string BASE_URL_GETEDITCOMPANY = "http://localhost:7071/api/GetEditCompany/";
        string BASE_URL_DELETECOMPANY = "http://localhost:7071/api/DeleteCompany/";
        string BASE_URL_UPSERT_COMPANY = "http://localhost:7071/api/UpsertCompany/";

        string REMOTE_URL_GETCOMPANIES = "https://spassessservices20190608094418.azurewebsites.net/api/GetCompanies?code=VMObwbRsaODGBo85AgmeiSWesVOrJZycjWvhJxQOpSoP6RPBWwvvdg==";
        string REMOTE_URL_GETEDITCOMPANY = " https://spassessservices20190608094418.azurewebsites.net/api/GetCompanyEdit?code=uofcm3stxI7t8s6UoYGjyg1ka/zfUdktXzj7T4mTq4VL22hRBrvZ4A==";
        string REMOTE_URL_DELETECOMPANY = "  https://spassessservices20190608094418.azurewebsites.net/api/DeleteCompany?code=oVI1NNEsxbljXz7PagjAvIr12jS4RlRfFp1rGoJZowR9dlaiNum4oQ==";
        string REMOTE_URL_GET_COMPANY = "https://spassessservices20190608094418.azurewebsites.net/api/GetCompany?code=IX0lSyyEHqxHPEDEFQfg7t1CM/uK3gwaYWataBPTcrxbmr2Nj9/BJQ==";
        string REMOTE_URL_UPSERT_COMPANY = "https://spassessservices20190608094418.azurewebsites.net/api/UpserComapny?code=J8jBahrlwJmJiOxKBVYC3iQvaY2B0536vthnfznOa/PfHKn7bY8vWQ==";

        public ActionResult Company(Company model)
        {
            if (model.CompanyName != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    //send the parameteres HARDCODED ID
                    //var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\", \"UserName\": \"admin\",\"Password\": \"test\"}";

                    var payload = JsonConvert.SerializeObject(model);

                    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(BASE_URL_GETCOMPANY),
                        Content = c
                    };

                    // HttpResponseMessage result = await client.SendAsync(request);


                    //Response
                    using (Task<HttpResponseMessage> res = client.SendAsync(request))
                    {
                        using (HttpContent content = res.Result.Content)
                        {

                            //TODO figure out how to seriazle the object
                            Task<string> data = content.ReadAsStringAsync();

                            var result = JsonConvert.DeserializeObject<string>(data.Result);

                            if (data.Result != null)
                            {
                                if (result.Equals("successful"))
                                {
                                    return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Company details are wrong.");
                                    return View();
                                }

                            }

                        }
                    }
                }


            }

            return View();
        }

        public ActionResult Lists(List<Company> companies)
        {

            List<Company> listCompanies = TempData["CompanyList"] as List<Company>;

            return View(listCompanies);

        }


        public ActionResult Edit(Company company)
        {
            if (company.CompanyName != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    //send the parameteres HARDCODED ID
                    //var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\", \"UserName\": \"admin\",\"Password\": \"test\"}";

                    if (company.CompanyName != company.CompanyName)
                    {
                        company.CompanyName = company.newCompanyName;

                    }
                    else if (company.GroupAdminToken != company.newGroupAdminToken)
                    {
                        company.GroupAdminToken = company.newGroupAdminToken;
                    }
                    else if (company.Address != company.newAddress)
                    {
                        company.Address = company.newAddress;


                    }
                    else if (company.AssessmentToken != company.newAssessmentToken)
                    {
                        company.AssessmentToken = company.newAssessmentToken;
                    }


                    var newCompany = new Company
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        Address = company.Address,
                        AssessmentToken = company.AssessmentToken,
                        GroupAdminToken = company.GroupAdminToken
                    };

                    var payload = JsonConvert.SerializeObject(newCompany);

                    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(BASE_URL_UPSERT_COMPANY),
                        Content = c
                    };

                    // HttpResponseMessage result = await client.SendAsync(request);


                    //Response
                    using (Task<HttpResponseMessage> res = client.SendAsync(request))
                    {
                        using (HttpContent content = res.Result.Content)
                        {

                            //TODO figure out how to seriazle the object
                            Task<string> data = content.ReadAsStringAsync();

                            ////used to return messages ignore code for now
                            //int index = data.Result.IndexOf(',');
                            //// string success = data.Result.Substring(0, index);
                            //string json = data.Result.Substring(0, index);
                            var result = JsonConvert.DeserializeObject<string>(data.Result);

                            if (data.Result != null)
                            {
                                if (result.Equals("successful"))
                                {
                                    return RedirectToAction("ListCompanies", "Company");

                                }
                                else
                                {
                                    ModelState.AddModelError("", "Company details are wrong.");
                                    return View();
                                }

                            }


                        }
                    }


                }
            }

            return View();

        }

        public ActionResult ListCompanies(Company company)
        {

            using (HttpClient client = new HttpClient())
            {

                //POST
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(BASE_URL_GETCOMPANIES),
                    // Content = c
                };

                //Response
                using (Task<HttpResponseMessage> res = client.SendAsync(request))
                {
                    using (HttpContent content = res.Result.Content)
                    {

                        //TODO figure out how to seriazle the object
                        Task<string> data = content.ReadAsStringAsync();
                        if (data.Result != null)
                        {

                            List<Company> entities = JsonConvert.DeserializeObject<List<Company>>(data.Result);
                            // Set global object to the stuff from empList
                            if (entities != null)

                                TempData["CompanyList"] = entities;

                            return RedirectToAction("Lists", "Company");
                        }


                    }

                }
            }

            return View();

        }

        public ActionResult Delete(Company company)
        {
            if (company.CompanyName != null)
            {
                using (HttpClient client = new HttpClient())
                {

                    var payload = JsonConvert.SerializeObject(company);

                    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(BASE_URL_DELETECOMPANY),
                        Content = c
                    };

                    // HttpResponseMessage result = await client.SendAsync(request);

                    //Response
                    using (Task<HttpResponseMessage> res = client.SendAsync(request))
                    {
                        using (HttpContent content = res.Result.Content)
                        {

                            //TODO figure out how to seriazle the object
                            Task<string> data = content.ReadAsStringAsync();

                            var result = JsonConvert.DeserializeObject<string>(data.Result);

                            if (data.Result != null)
                            {
                                if (result.Equals("successful"))
                                {
                                    return RedirectToAction("ListCompanies", "Company");
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Delete Failed.");
                                    return View();
                                }

                            }

                        }
                    }
                }


            }

            return View();
        }

        public ActionResult Create(Company company)
        {
            Company companyExists = null;


            if (company.CompanyId != null && company.CompanyName != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    //send the parameteres HARDCODED ID
                    // var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\",\"CompanyName\": \"test\"}";

                    var payload = JsonConvert.SerializeObject(company);

                    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(REMOTE_URL_GET_COMPANY),
                        Content = c
                    };

                    // HttpResponseMessage result = await client.SendAsync(request);

                    //Response
                    using (Task<HttpResponseMessage> res = client.SendAsync(request))
                    {
                        using (HttpContent content = res.Result.Content)
                        {

                            //TODO figure out how to seriazle the object
                            Task<string> data = content.ReadAsStringAsync();
                            if (data.Result != null)
                            {
                                //used to return messages ignore code for now
                                int index = data.Result.IndexOf(',');
                                // string success = data.Result.Substring(0, index);
                                string json = data.Result.Substring(0, index);

                                companyExists = JsonConvert.DeserializeObject<Company>(data.Result);

                            }

                        }
                    }
                }

                //Create new company
                if (companyExists.CompanyId == null)
                {
                    using (HttpClient client = new HttpClient())
                    {

                        var payload = JsonConvert.SerializeObject(company);

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                        //POST
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(REMOTE_URL_UPSERT_COMPANY),
                            Content = c
                        };

                        //Response
                        using (Task<HttpResponseMessage> res = client.SendAsync(request))
                        {
                            using (HttpContent content = res.Result.Content)
                            {

                                //TODO figure out how to seriazle the object
                                Task<string> data = content.ReadAsStringAsync();

                                var result = JsonConvert.DeserializeObject<string>(data.Result);

                                if (data.Result != null)
                                {
                                    if (result.Equals("successful"))
                                    {
                                        return RedirectToAction("ListCompanies", "Company");
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", "Create Failed.");
                                        return View();
                                    }

                                }

                            }
                        }
                    }
                }
                else
                {
                    return RedirectToAction("ListCompanies", "Company");
                }



            }


            //first time pass 
            Company comapny = new Company();
            company.CompanyId = GenerateCompanyId();
            company.AssessmentToken = GenerateCompanyId().ToString();
            company.GroupAdminToken = GenerateCompanyId().ToString();
            return View(company);

        }

        //generate CompanyId
        private Guid GenerateCompanyId()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
    }
}
