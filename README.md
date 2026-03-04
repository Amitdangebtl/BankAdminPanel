# 🏦 BankAdminPanel

Simple **Bank Admin Panel** built using **ASP.NET Core Web API + ASP.NET Core MVC + Entity Framework Core**.

This project allows bank admin to manage **customers, bank accounts, and transactions** through a clean UI connected to Web API.

---

# 📌 Project Overview

BankAdminPanel is a simple banking management system where:

- Admin can manage Customers
- Admin can manage Bank Accounts
- Admin can perform Deposit / Withdraw / Transfer
- Admin can view Transaction History
- Data is stored using **Entity Framework Core**
- MVC UI communicates with **ASP.NET Core Web API**

This project does **not include role/permission system**. It is a simple admin-level banking system for learning and practice.

---

# 🏗️ Solution Architecture

This solution contains **2 Projects**

---

## 1️⃣ BankAdminPanelAPI (Backend - Web API)

Responsible for:

- REST APIs
- Business Logic
- Database operations
- Entity Framework Core integration

### Main Structure

```
Controllers/
Models/
BankAdminPanelContext.cs
Program.cs
```

### Important Files

- BankAdminController.cs  
- Account.cs  
- Customer.cs  
- Transaction.cs  
- AdminUser.cs  
- BankAdminPanelContext.cs  

---

## 2️⃣ UIBankAdminPanel (Frontend - MVC)

Responsible for:

- Razor Views
- UI Pages
- API integration
- Displaying bank data

### Main Structure

```
Controllers/
Models/
Views/
wwwroot/
```

### Important Controllers

- BankAdminMVCController.cs  
- HomeController.cs  

---

# 🗄️ Database

- SQL Server
- Entity Framework Core
- Code First Approach

### Main Tables

- Customers
- Accounts
- Transactions
- AdminUsers

---

# 🛠️ Technologies Used

- ASP.NET Core Web API
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Bootstrap

---

# ⚙️ How to Run

## 1️⃣ Clone Repository

```
git clone https://github.com/Amitdangebtl/BankAdminPanel.git
```

---

## 2️⃣ Configure Database

Update **appsettings.json** in API project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BankAdminPanelDB;Trusted_Connection=True;"
}
```

---

## 3️⃣ Apply Migrations

```
dotnet ef database update
```

---

## 4️⃣ Run API

```
dotnet run --project BankAdminPanelAPI
```

---

## 5️⃣ Run MVC UI

```
dotnet run --project UIBankAdminPanel
```

---

# 📌 Features

✔ Manage Customers  
✔ Manage Bank Accounts  
✔ Deposit Money  
✔ Withdraw Money  
✔ Transfer Money  
✔ View Transaction History  
✔ Admin Dashboard  
✔ MVC + Web API Architecture  

---

# 📷 Application Screenshots

## 🔹 Login Page
![Login](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Login.png)

---

## 🔹 Banking Admin Dashboard
![Dashboard](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Deshboard%20Banking%20Admin%20Panel.png)

---

## 🔹 Bank Admin Home
![Home](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Bank%20Admin%20Home.png)

---

## 🔹 Create Customer
![Create Customer](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Create%20Customer.png)

---

## 🔹 Customer List
![Customer List](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Customer%20List.png)

---

## 🔹 Update Customer
![Update Customer](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Update%20Customer.png)

---

## 🔹 Delete Customer
![Delete Customer](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Delete%20Customer.png)

---

## 🔹 Create Bank Account
![Create Account](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Create%20Bank%20Account.png)

---

## 🔹 Account List
![Account List](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Account%20List.png)

---

## 🔹 Update Bank Account
![Update Account](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Update%20Bank%20Account.png)

---

## 🔹 Delete Bank Account
![Delete Account](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Delete%20Bank%20Account.png)

---

## 🔹 Deposit Money
![Deposit](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Deposit%20Money.png)

---

## 🔹 Withdraw Money
![Withdraw](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Withdraw%20Money.png)

---

## 🔹 Transfer Money
![Transfer](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Transfer%20Money.png)

---

## 🔹 Transaction History
![Transaction](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Transaction%20History.png)

---

## 🔹 Swagger API Documentation
![Swagger](https://raw.githubusercontent.com/Amitdangebtl/BankAdminPanel/master/Swagger.png)

---

# 🎯 Key Highlights

✔ Clean MVC + Web API architecture  
✔ Entity Framework Core integration  
✔ CRUD operations for banking system  
✔ Transaction management system  
✔ Beginner friendly banking application  

---

# 👨‍💻 Author

**Amit Dange**  
.NET Developer
