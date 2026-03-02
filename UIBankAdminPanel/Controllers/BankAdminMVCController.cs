using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankAdminPanelMVC.Controllers
{
    [Route("BankAdmin/[action]")]
    public class BankAdminMVCController : Controller
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

        // ✔ UI page open karega (HTML)
        [HttpGet]
        public IActionResult CustomerListView()
        {
            return View("~/Views/BankAdmin/CustomerList.cshtml");
        }

        // ✔ API proxy JSON return karega UI ke liye
        [HttpGet]
        public async Task<IActionResult> CustomerListAPI()
        {
            string url = baseUrl + "CustomerList";
            Console.WriteLine("API HITTING → " + url);

            var response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();

            var customers = JsonSerializer.Deserialize<object>(result);
            return Json(customers); // 🔥 important → JSON UI ko mil jayega
        }

        // ✔ Account list ka UI page open karega
        [HttpGet]
        public IActionResult AccountListView()
        {
            return View("~/Views/BankAdmin/AccountList.cshtml");
        }

        // ✔ Backend API call → JSON UI ko mil jayega
        [HttpGet]
        public async Task<IActionResult> AccountListAPI()
        {
            string url = baseUrl + "AccountList"; ;
            Console.WriteLine("API HITTING → " + url);

            var response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();

            var accounts = JsonSerializer.Deserialize<object>(result);
            return Json(accounts);
        }

        // Deposit page open karega (UI)
        [HttpGet]
        public IActionResult DepositView()
        {
            return View("~/Views/BankAdmin/Deposit.cshtml");
        }

        // Deposit API ko call karega
        [HttpPost]
        public async Task<IActionResult> Deposit(int accNo, int amount)
        {
            string apiUrl = "https://localhost:7138/api/BankAdmin/Deposit?accNo=" + accNo + "&amount=" + amount;
            Console.WriteLine("API HITTING → " + apiUrl);

            var response = await client.PostAsync(apiUrl, null);
            string result = await response.Content.ReadAsStringAsync();

            return Content(result);
        }

        [HttpGet]
        public IActionResult WithdrawView()
        {
            return View("~/Views/BankAdmin/Withdraw.cshtml");
        }

        // ✔ Backend API ko call karega
        [HttpPost]
        public async Task<IActionResult> Withdraw(int accNo, int amount)
        {
            string url = baseUrl + "Withdraw?accNo=" + accNo + "&amount=" + amount;
            System.Console.WriteLine("API HITTING → " + url);

            var res = await client.PostAsync(url, null);
            string result = await res.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/Withdraw.cshtml");
        }

        [HttpGet]
        public IActionResult TransectionHistoryView()
        {
            return View("~/Views/BankAdmin/TransectionHistory.cshtml");
        }

        // ✔ API call karega aur JSON UI ko dega
        [HttpGet]
        public async Task<IActionResult> TransectionHistory(int accNo)
        {
            string url = baseUrl + "TransectionHistory?accNo=" + accNo;
            System.Console.WriteLine("API HITTING → " + url);

            var res = await client.GetAsync(url);
            string json = await res.Content.ReadAsStringAsync();

            return Json(JsonSerializer.Deserialize<object>(json));
        }

        // ✔ Dashboard open karega
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View("~/Views/BankAdmin/AdminDashboard.cshtml");
        }

        // ✔ Recent Transactions proxy
        [HttpGet]
        public async Task<IActionResult> RecentTransactionsProxy()
        {
            string url = baseUrl + "TransectionHistory?accNo=1";
            var res = await client.GetAsync(url);
            string result = await res.Content.ReadAsStringAsync();
            return Json(JsonSerializer.Deserialize<object>(result));
        }


        [HttpGet]
        public IActionResult CreateAccountView()
        {
            return View("~/Views/BankAdmin/CreateAccount.cshtml");
        }

        // ✔ Backend API ko hit karega
        [HttpPost]
        public async Task<IActionResult> CreateAccount(int customerId, string accountType, int balance)
        {
            string url = baseUrl + "CreateAccount?customerId=" + customerId + "&accountType=" + accountType + "&balance=" + balance;
            Console.WriteLine("API HITTING → " + url);

            var res = await client.PostAsync(url, null);
            string result = await res.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/CreateAccount.cshtml");
        }

        [HttpGet]
        public IActionResult UpdateAccountView()
        {
            return View("~/Views/BankAdmin/UpdateAccount.cshtml");
        }

        // ✔ Backend PUT API ko hit karega
        [HttpPost] // Browser form PUT nahi bhejta, isliye hum POST se proxy kar rahe
        public async Task<IActionResult> UpdateAccount(int accNo, string accountType, int balance)
        {
            string url = baseUrl + "UpdateAccount?accNo=" + accNo + "&accountType=" + accountType + "&balance=" + balance;
            Console.WriteLine("API HITTING → " + url);

            var req = new HttpRequestMessage(HttpMethod.Put, url);
            var res = await client.SendAsync(req);
            string result = await res.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/UpdateAccount.cshtml");
        }
        [HttpGet]
        public IActionResult DeleteAccountView()
        {
            return View("~/Views/BankAdmin/DeleteAccount.cshtml");
        }

        // ✔ Backend DELETE API ko call karega
        [HttpPost] // form DELETE nahi bhejta, isliye POST se proxy
        public async Task<IActionResult> DeleteAccount(int accNo)
        {
            string url = baseUrl + "DeleteAccount?accNo=" + accNo;
            Console.WriteLine("API HITTING → " + url);

            var req = new HttpRequestMessage(HttpMethod.Delete, url);
            var res = await client.SendAsync(req);
            string result = await res.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/DeleteAccount.cshtml");
        }

        [HttpGet]
        public IActionResult CreateCustomerView()
        {
            return View("~/Views/BankAdmin/CreateCustomer.cshtml");
        }

        // ✔ Backend API ko call karke customer create karega
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(string name, long phone, string address, string email)
        {
            string url = baseUrl + "CreateCustomer?name=" + name + "&phone=" + phone + "&address=" + address + "&email=" + email;
            Console.WriteLine("API HITTING → " + url);

            var res = await client.PostAsync(url, null);
            string result = await res.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/CreateCustomer.cshtml");
        }

        [HttpGet]
        public IActionResult UpdateCustomerView()
        {
            return View("~/Views/BankAdmin/UpdateCustomer.cshtml");
        }

        // ✔ Backend PUT API ko hit karega
        [HttpPost] // form se POST aayega, controller PUT me convert karke API ko call karega
        public async Task<IActionResult> UpdateCustomer(int customerId, string name, long phone, string address, string email)
        {
            string url = baseUrl + "UpdateCustomer?customerId=" + customerId +
                         "&name=" + name +
                         "&phone=" + phone +
                         "&address=" + address +
                         "&email=" + email;

            Console.WriteLine("API HITTING → " + url);

            var request = new HttpRequestMessage(HttpMethod.Put, url);
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/UpdateCustomer.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteCustomerView()
        {
            return View("~/Views/BankAdmin/DeleteCustomer.cshtml");
        }

        // ✔ Backend DELETE API ko hit karega
        [HttpPost] // Form POST dega, hum isko DELETE me proxy kar rahe
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            string url = baseUrl + "DeleteCustomer?customerId=" + customerId;
            Console.WriteLine("API HITTING → " + url);

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return View("~/Views/BankAdmin/DeleteCustomer.cshtml");
        }

        [HttpGet]
        public IActionResult TransferView()
        {
            return View("~/Views/BankAdmin/Transfer.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> TransferAPI(int fromAccNo, int toAccNo, int amount)
        {
            string url = baseUrl + "Transfer?fromAccNo=" + fromAccNo + "&toAccNo=" + toAccNo + "&amount=" + amount;
            Console.WriteLine("API HITTING → " + url);

            var res = await client.PostAsync(url, null);
            string result = await res.Content.ReadAsStringAsync();

            ViewBag.Msg = result;
            return Ok(result);
        }

    }
}
