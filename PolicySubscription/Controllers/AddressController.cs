using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PolicySubscription.Models;
using AutoMapper;
namespace PolicySubscription.Controllers
{
    public class AddressController : Controller
    {
        
       

        HttpClient httpcon;
        string url = "http://localhost:63378/Service.svc/";
        public AddressController()
        {
            httpcon = new HttpClient();
            httpcon.BaseAddress = new Uri(url);
            httpcon.DefaultRequestHeaders.Accept.Clear();
            httpcon.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> GetCountryData()
        {

            HttpResponseMessage responseMessage = await httpcon.GetAsync("rest/Countries");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Countries = JsonConvert.DeserializeObject<List<string>>(responseData);
                ViewBag.lstcountry = Countries;

                return View();
            }
            return View("Error");
        }
        public async Task<ActionResult> GetPersonData()
        {
            //Create a Map
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Person, Employee>(); });
            IMapper mapper = config.CreateMapper();
            Person person = new Person();
            Employee emp = mapper.Map<Person, Employee>(person);

            HttpResponseMessage responseMessage = await httpcon.GetAsync("rest/Person");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                 var LstPerson = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseData);

                return View(LstPerson);
            }
            return View("Error");
        }

        //GET: Address
        public ActionResult GetData()
        {
            return View();
        }
        public JsonResult GetCountries()
        {
            List<string> Lstcountry = new List<string>() { "India", "USA", "Canada", "France" };

            return Json(Lstcountry, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStates(string cname)
        {
            List<string> LstState = new List<string>();

            switch (cname)
            {
                case "India":
                    {
                        LstState.Add("TS");
                        LstState.Add("AP");
                        LstState.Add("MP");
                        break;
                    }
                case "USA":
                    {
                        LstState.Add("Ohio");
                        LstState.Add("MA");
                        LstState.Add("Illinious");
                        break;
                    }

                case "Canada":
                    {
                        LstState.Add("Ontario");
                        LstState.Add("Markram");
                        LstState.Add("Toronto");
                        break;
                    }

                case "France":
                    {
                        LstState.Add("Paris");
                        LstState.Add("Kohe");
                        LstState.Add("Vendry");
                        break;

                    }

                default:
                    {
                        break;
                    }
            }
            return Json(LstState);

        }
    }
}