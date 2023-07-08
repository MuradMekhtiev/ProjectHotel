using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUserController : Controller
    {
        //private readonly UserManager<AppUser> _userManager;

        //public AdminUserController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //    var values = _userManager.Users.ToList();
        //    return View(values);
        //}

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5173/api/AppUser");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
