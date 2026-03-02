using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAdminPanelAPI.Models;

namespace BankAdminPanelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankAdminController : ControllerBase
    {
        private readonly BankAdminPanelContext _db;

        public BankAdminController(BankAdminPanelContext db)
        {
            _db = db;
        }

        // Admin Login
        [HttpPost]
        public IActionResult AdminLogin(string userName, string password)
        {
            var admin = _db.AdminUsers
                .FirstOrDefault(a => a.UserName == userName && a.PasswordHash == password);

            if (admin == null)
                return Ok("Login Failed");

            return Ok("Login Success");
        }

        // Customer List
        [HttpGet]
        public IActionResult CustomerList()
        {
            var list = _db.Customers.ToList();
            return Ok(list);
        }

        // Account List with Customer
        [HttpGet]
        public IActionResult AccountList()
        {
            var list = _db.Accounts.Select(a => new {
                a.AccountNumber,
                a.CustomerId,
                a.Balance,
                a.AccountType
            }).ToList();

            return Ok(list);
        }

        // Deposit
        [HttpPost]
        public IActionResult Deposit(int accNo, int amount)
        {
            var acc = _db.Accounts.Find(accNo);
            if (acc == null)
                return Ok("Account Not Found");

            acc.Balance += amount;
            _db.SaveChanges();

            _db.Transections.Add(new Transection { AccountNumber = accNo, Type = "Deposit", Amount = amount });
            _db.SaveChanges();

            return Ok("Deposit Success");
        }

        // Withdraw
        [HttpPost]
        public IActionResult Withdraw(int accNo, int amount)
        {
            var acc = _db.Accounts.Find(accNo);
            if (acc == null)
                return Ok("Account Not Found");

            if (acc.Balance < amount)
                return Ok("Insufficient Balance");

            acc.Balance -= amount;
            _db.SaveChanges();

            _db.Transections.Add(new Transection { AccountNumber = accNo, Type = "Withdraw", Amount = amount });
            _db.SaveChanges();

            return Ok("Withdraw Success");
        }

        // Transaction History
        [HttpGet]
        public IActionResult TransectionHistory(int accNo)
        {
            var list = _db.Transections.Where(t => t.AccountNumber == accNo).OrderByDescending(t => t.Date).ToList();
            return Ok(list);
        }

        // CREATE ACCOUNT
        [HttpPost]
        public IActionResult CreateAccount(int customerId, string accountType, int balance)
        {
            var customer = _db.Customers.Find(customerId);
            if (customer == null)
                return Ok("Customer Not Found");

            var acc = new Account
            {
                CustomerId = customerId,
                AccountType = accountType,
                Balance = balance
            };

            _db.Accounts.Add(acc);
            _db.SaveChanges();

            return Ok("Account Created Successfully");
        }

        // UPDATE ACCOUNT
        [HttpPut]
        public IActionResult UpdateAccount(int accNo, string accountType, int balance)
        {
            var acc = _db.Accounts.Find(accNo);
            if (acc == null)
                return Ok("Account Not Found");

            acc.AccountType = accountType;
            acc.Balance = balance;

            _db.SaveChanges();

            return Ok("Account Updated Successfully");
        }

        // DELETE ACCOUNT
        [HttpDelete]
        public IActionResult DeleteAccount(int accNo)
        {
            var acc = _db.Accounts.Find(accNo);
            if (acc == null)
                return Ok("Account Not Found");

            _db.Accounts.Remove(acc);
            _db.SaveChanges();

            return Ok("Account Deleted Successfully");
        }

        // CREATE CUSTOMER
        [HttpPost]
        public IActionResult CreateCustomer(string name, long phone, string address, string email)
        {
            var customer = new Customer
            {
                Name = name,
                Phone = phone,
                Address = address,
                Email = email
            };

            _db.Customers.Add(customer);
            _db.SaveChanges();

            return Ok("Customer Created Successfully");
        }
        // UPDATE CUSTOMER
        [HttpPut]
        public IActionResult UpdateCustomer(int customerId, string name, long phone, string address, string email)
        {
            var customer = _db.Customers.Find(customerId);
            if (customer == null)
                return Ok("Customer Not Found");

            customer.Name = name;
            customer.Phone = phone;
            customer.Address = address;
            customer.Email = email;

            _db.SaveChanges();
            return Ok("Customer Updated Successfully");
        }
        // DELETE CUSTOMER
        [HttpDelete]
        public IActionResult DeleteCustomer(int customerId)
        {
            var customer = _db.Customers.Find(customerId);
            if (customer == null)
                return Ok("Customer Not Found");

            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return Ok("Customer Deleted Successfully");
        }

        [HttpPost]
        public IActionResult Transfer(int fromAccNo, int toAccNo, int amount)
        {
            if (amount <= 0)
                return Ok("❌ Invalid amount!");

            var from = _db.Accounts.FirstOrDefault(a => a.AccountNumber == fromAccNo);
            var to = _db.Accounts.FirstOrDefault(a => a.AccountNumber == toAccNo);

            if (from == null || to == null)
                return Ok("❌ One or both accounts not found!");

            if (from.CustomerId == to.CustomerId)
                return Ok("⚠ Transfer not allowed between accounts of the same customer!");

            if (from.Balance < amount)
                return Ok("⚠ Insufficient balance! Please deposit first.");

            // Debit & Credit
            from.Balance -= amount;
            to.Balance += amount;
            _db.SaveChanges();

            
            _db.Transections.Add(new Transection
            {
                AccountNumber = fromAccNo,
                Type = "Withdraw",  
                Amount = amount,
                Date = DateTime.Now
            });

            _db.Transections.Add(new Transection
            {
                AccountNumber = toAccNo,
                Type = "Deposit",  
                Amount = amount,
                Date = DateTime.Now
            });

            _db.SaveChanges();

            return Ok("✔ Transfer successful! ₹" + amount + " moved.");
        }
    }
}

