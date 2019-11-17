using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EthicsCap2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;


namespace EthicsCap2.Controllers
{
    public class LoginController : Controller
    {
     
            string REMOTE_GET_LOGIN = "https://spassessservices20190608094418.azurewebsites.net/api/GetLogin?code=IX0lSyyEHqxHPEDEFQfg7t1CM/uK3gwaYWataBPTcrxbmr2Nj9/BJQ==";
            string REMOTE_UPSERT_LOGIN = "https://spassessservices20190608094418.azurewebsites.net/api/UpserLogin?code=5vgN/JB/iJhFIEulask7H3CPpZpFigVLcy/3wC/OB8TksbdxC1hc7g==";
            string REMOTE_URL_GETLOGINS = "https://spassessservices20190608094418.azurewebsites.net/api/GetLogins?code=9gBEwD1Bl99stBtBD0tWo/H2LQsYZLwejpD5eG4osbiCs2V7sYaXjA==";
            string REMOTE_URL_GETEDITLOGINS = "https://spassessservices20190608094418.azurewebsites.net/api/GetEditLogin?code=sa1Hz1RTbsDEzE2umCrCVm9e7KAPEowYNoqiW2ftjFynClayaOyRAg==";
            string REMOTE_URL_DELETELOGIN = "https://spassessservices20190608094418.azurewebsites.net/api/DeleteLogin?code=Cl/zsMOL2/R0f7QU2l7S8ce7ZUmQ3WpBPgvdeMhQxMZ8BUowuMpBgg==";

            string BASE_URL = "http://localhost:7071/api/GetLogin/";
            string BASE_URL_GETLOGINS = "http://localhost:7071/api/GetLogins/";
            string BASE_URL_GETEDITLOGINS = "http://localhost:7071/api/GetEditLogin/";
            string BASE_URL_DELETELOGIN = "http://localhost:7071/api/DeleteLogin/";
            string BASE_URL_UPSERTLOGIN = "http://localhost:7071/api/UpsertLogin/";

            string BASE_URL_GETCOMPANIES = "http://localhost:7071/api/GetCompanies/";
            string REMOTE_URL_GETCOMPANIES = "https://spassessservices20190608094418.azurewebsites.net/api/GetCompanies?code=VMObwbRsaODGBo85AgmeiSWesVOrJZycjWvhJxQOpSoP6RPBWwvvdg==";



            //Registration
            string BASE_UPSERT_REGISTRATION = "http://localhost:7071/api/UpsertRegistration/";
            string REMOTE_UPSERT_REGISTRATION = "https://spassessservices20190608094418.azurewebsites.net/api/UpsertRegistration?code=NdIrm6Nr94sTmbhiUYQpkF3cXtmDK68cHBW/ZaYYZCzq/x5Gon5HTQ==";

            public ActionResult Login(Login login)
            {
                if (login.UserName != null && login.UserName == "admin" && login.Password == "test123")
                {
                   return RedirectToAction("Index", "Home");

                }


            //if (login.UserName != null)
            //    {
            //        using (HttpClient client = new HttpClient())
            //        {

            //            var payload = JsonConvert.SerializeObject(login);

            //            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

            //            //POST
            //            HttpRequestMessage request = new HttpRequestMessage
            //            {
            //                Method = HttpMethod.Post,
            //                RequestUri = new Uri(REMOTE_GET_LOGIN),
            //                Content = c
            //            };

            //            // HttpResponseMessage result = await client.SendAsync(request);


            //            //Response
            //            using (Task<HttpResponseMessage> res = client.SendAsync(request))
            //            {
            //                using (HttpContent content = res.Result.Content)
            //                {

            //                    //TODO figure out how to seriazle the object
            //                    Task<string> data = content.ReadAsStringAsync();

            //                    var result = JsonConvert.DeserializeObject<string>(data.Result);

            //                    if (data.Result != null)
            //                    {
            //                        if (result.Equals("successful"))
            //                        {
            //                            var sessionkey = new byte[256];
            //                            HttpContext.Session.TryGetValue("CompanyId", out sessionkey);
            //                            login.CompanyId = new Guid();
            //                            return RedirectToAction("Index", "Home");
            //                        }
            //                        else
            //                        {
            //                            ViewBag.Companies = GetCompanies();
            //                            ModelState.AddModelError("", "Login details are wrong.");
            //                            return View();
            //                        }

            //                    }

            //                }
            //            }
            //        }


            //    }
            //    else
            //    {
            //        ViewBag.Companies = GetCompanies();
            //    }


                return View();
            }

            public ActionResult Lists(List<Login> logins)
            {

                List<Login> listLogins = TempData["LoginList"] as List<Login>;

                return View(listLogins);

            }

            private Dictionary<Guid, string> GetCompanies()
            {
                using (HttpClient client = new HttpClient())
                {

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(REMOTE_URL_GETEDITLOGINS),
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
                                {
                                    Dictionary<Guid, string> listCompanies = new Dictionary<Guid, string>();
                                    foreach (Company c in entities)
                                    {
                                        listCompanies.Add(c.CompanyId.Value, c.CompanyName);
                                    }

                                    return listCompanies;
                                }
                            }


                        }

                    }
                }

                return null;
            }


            public ActionResult Edit(Login login)
            {
                if (login.newUserName == null && login.newPassword == null)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        //send the parameteres HARDCODED ID
                        //var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\", \"UserName\": \"admin\",\"Password\": \"test\"}";

                        //used to test edit for now
                        login.CompanyId = new Guid("b6945f9f-7025-4ef5-ac6d-07c48f851ff8");



                        var payload = JsonConvert.SerializeObject(login);

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                        //POST
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(REMOTE_URL_GETEDITLOGINS),
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

                                Login result = JsonConvert.DeserializeObject<Login>(data.Result);

                                if (data.Result != null)
                                {
                                    return View(result);

                                }

                            }
                        }
                    }
                }
                else
                {

                    using (HttpClient client = new HttpClient())
                    {
                        //send the parameteres HARDCODED ID
                        //var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\", \"UserName\": \"admin\",\"Password\": \"test\"}";

                        //used to test edit for now
                        login.CompanyId = new Guid("b6945f9f-7025-4ef5-ac6d-07c48f851ff8");

                        var payload = JsonConvert.SerializeObject(login);

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                        //POST
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(REMOTE_UPSERT_LOGIN),
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
                                        return RedirectToAction("ListLogins", "Login");

                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", "Login details are wrong.");
                                        return View();
                                    }

                                }


                            }
                        }
                    }

                }


                return View();

            }

            public ActionResult ListLogins(Login model)
            {

                using (HttpClient client = new HttpClient())
                {
                    //send the parameteres HARDCODED ID
                    // var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\",\"CompanyName\": \"test\"}";


                    // HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(REMOTE_URL_GETLOGINS),
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

                                List<Login> entities = JsonConvert.DeserializeObject<List<Login>>(data.Result);
                                // Set global object to the stuff from empList
                                if (entities != null)

                                    TempData["LoginList"] = entities;

                                return RedirectToAction("Lists", "Login");
                            }


                        }

                    }
                }

                return View();

            }

            public ActionResult Delete(Login login)
            {
                if (login.UserName != null)
                {
                    using (HttpClient client = new HttpClient())
                    {

                        var payload = JsonConvert.SerializeObject(login);

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                        //POST
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(REMOTE_URL_DELETELOGIN),
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
                                        return RedirectToAction("ListLogins", "Login");
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", "Delete failed.");
                                        return View();
                                    }

                                }
                            }
                        }
                    }


                }

                return View();
            }



            [HttpGet]
            public ActionResult Register()
            {
                //List all the companies

                using (HttpClient client = new HttpClient())
                {

                    //POST
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(REMOTE_URL_GETCOMPANIES),
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
                                {
                                    Dictionary<Guid, string> listCompanies = new Dictionary<Guid, string>();
                                    foreach (Company c in entities)
                                    {
                                        listCompanies.Add(c.CompanyId.Value, c.CompanyName);
                                    }

                                    ViewBag.Companies = listCompanies;
                                }



                                //return RedirectToAction("Lists", "Company");
                            }


                        }

                    }
                }


                return View();
            }

            [HttpPost]
            public ActionResult Registration(Registration user)
            {

                using (var webClient = new WebClient())
                {

                    var transaction = new Registration()
                    {
                        //var crypto = new SimpleCrypto.PBKDF2();
                        // var encrypPass = crypto.Compute(user.Password);
                        Email = user.Email,
                        UserName = user.UserName,
                        Password = user.Password,
                        //PasswordSalt = crypto.Salt;
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserType = "User",
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        IPAddress = "642 White Hague Avenue",
                        CompanyId = user.CompanyId


                    };

                    //make sure you change local azure api connection to production azure connection parameter
                    var dataString = JsonConvert.SerializeObject(transaction);
                    webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    webClient.UploadString(new Uri("https://spassessservices20190608094418.azurewebsites.net/api/UpsertRegistration?code=Ap6eiQr09Oyo76L7k/O7Z0VxsamjvR7ekdrXWJCRoUY48XUABFvW/A=="), "POST", dataString);
                    // webClient.UploadString(new Uri(REMOTE_UPSERT_REGISTRATION), "POST", dataString);


                    return RedirectToAction("Index", "Home");
                }

                /* foreach (var eve in e.EntityValidationErrors)
                 {
                     Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                         eve.Entry.Entity.GetType().Name, eve.Entry.State);
                     foreach (var ve in eve.ValidationErrors)
                     {
                         Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                             ve.PropertyName, ve.ErrorMessage);
                     }
                 }*/


            }

            public ActionResult LogOut()
            {
                //FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Login");
            }

            public ActionResult Create(Login login)
            {

                if (login.UserName != null && login.Password != null && login.CompanyId != null)
                {
                    using (HttpClient client = new HttpClient())
                    {


                        var payload = JsonConvert.SerializeObject(login);

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                        //POST
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(REMOTE_UPSERT_LOGIN),
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

                                ////used to return messages ignore code for now
                                //int index = data.Result.IndexOf(',');
                                //// string success = data.Result.Substring(0, index);
                                //string json = data.Result.Substring(0, index);

                                if (result != null)
                                {
                                    if (result.Equals("successful"))
                                    {
                                        return RedirectToAction("ListLogins", "Login");

                                    }
                                    else
                                    {
                                        ModelState.AddModelError("", "Login details are wrong.");
                                        return View();
                                    }

                                }

                            }
                        }
                    }



                    using (HttpClient client = new HttpClient())
                    {
                        //send the parameteres HARDCODED ID
                        //var payload = "{\"CompanyId\": \"b6945f9f-7025-4ef5-ac6d-07c48f851ff8\", \"UserName\": \"admin\",\"Password\": \"test\"}";

                        //used to test edit for now
                        login.CompanyId = new Guid("b6945f9f-7025-4ef5-ac6d-07c48f851ff8");



                        var payload = JsonConvert.SerializeObject(login);

                        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                        //POST
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(REMOTE_UPSERT_LOGIN),
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
                                        return RedirectToAction("ListLogins", "Login");
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

            private bool IsValid(string email, string password)
            {
                //var crypto = new SimpleCrypto.PBKDF2();
                bool IsValid = false;


                return IsValid;
            }

        }

    
}