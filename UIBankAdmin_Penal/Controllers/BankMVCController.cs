using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankMVC.Controllers
{
    [Route("BankAdmin/[action]")]
    public class BankMVCController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://localhost:7138/api/BankAdmin/";

        // ❗ LOGIN untouched hai (nahi change kiya)

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View("~/Views/BankAdmin/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(string userName, string password)
        {
            string url = baseUrl + "AdminLogin?userName=" + userName + "&password=" + password;
            Console.WriteLine("API HITTING → " + url);

            var response = await client.PostAsync(url, null);
            string result = await response.Content.ReadAsStringAsync();

            if (result.Contains("Failed"))
            {
                ViewBag.Msg = "Login Failed ❌";
                return View("~/Views/BankAdmin/Login.cshtml");
            }

            // ✔ SUCCESS par CustomerListView open hoga
            return RedirectToAction("AdminDashboard", "BankAdminMVC");
        }
    }
}