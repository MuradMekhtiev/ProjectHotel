using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SentMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5173/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5173/api/SentMessage/GetSentMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sentMessageCount = jsonData3;
                return View(values);
            }

            //if (responseMessage2.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage2.Content.ReadAsStringAsync();
            //    ViewBag.data = jsonData;
            //    return View();
            //}
            return View();
        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/SentMessage");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSentMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSentMessage(CreateSentMessage createSentMessage)
        {
            createSentMessage.SenderMail = "admin@gmail.com";
            createSentMessage.SenderName = "admin";
            createSentMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSentMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "Application/json");
            var responseMessage = await client.PostAsync("http://localhost:5173/api/SentMessage", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }

            return View();
        }
        public PartialViewResult SideBarPartialAdminContact()
        {
            return PartialView();
        }
        public PartialViewResult SideBarCategoryPartialAdminContact()
        {
            return PartialView();
        }
        public async Task<IActionResult> OutgoingMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/SentMessage/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> IncomingMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5173/api/Contact/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        //public async Task<IActionResult> GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:5173/api/Contact/GetContactCount");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        //var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
        //        ViewBag.data = jsonData;
        //        return View();
        //    }
        //    return View();
        //}
    }
}
