# 🏦 BankAdminPanel

Simple Bank Admin Panel built using **ASP.NET Core Web API + ASP.NET Core MVC + Entity Framework Core**.

This project allows admin to manage bank customers, accounts, and transactions.

---

## 📌 Project Overview

BankAdminPanel is a basic banking management system where:

- Admin can manage Customers
- Admin can manage Accounts
- Admin can view Transactions
- Data is stored using Entity Framework Core
- UI communicates with Web API

This project does not include role/permission system. It is a simple admin-level system.

---

## 🏗️ Solution Architecture

This solution contains **2 Projects**:

---

### 1️⃣ BankAdminPanelAPI (Backend - Web API)

Responsible for:

- REST APIs
- Database operations
- Entity Framework Core
- Business logic

**Main Structure:**

```
Controllers/
Models/
BankAdminPanelContext.cs
Program.cs
```

Important Files:

- BankAdminController.cs  
- Account.cs  
- Customer.cs  
- Transaction.cs  
- AdminUser.cs  
- BankAdminPanelContext.cs  

---

### 2️⃣ UIBankAdminPanel (Frontend - MVC)

Responsible for:

- Razor Views
- UI Pages
- Calling API
- Displaying Data

**Main Structure:**

```
Controllers/
Models/
Views/
wwwroot/
```

Important Controllers:

- BankAdminMVCController.cs  
- HomeController.cs  

---

## 🗄️ Database

- SQL Server  
- Entity Framework Core  
- Code First Approach  

Main Tables:

- Customers  
- Accounts  
- Transactions  
- AdminUsers  

---

## 🛠️ Technologies Used

- ASP.NET Core Web API  
- ASP.NET Core MVC  
- C#  
- Entity Framework Core  
- SQL Server  
- Bootstrap  

---

## ⚙️ How to Run

### 1️⃣ Clone Repository

```
git clone https://github.com/Amitdangebtl/BankAdminPanel.git
```

---

### 2️⃣ Configure Database

Update `appsettings.json` in API project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BankAdminPanelDB;Trusted_Connection=True;"
}
```

---

### 3️⃣ Apply Migrations

```
dotnet ef database update
```

---

### 4️⃣ Run API

```
dotnet run --project BankAdminPanelAPI
```

---

### 5️⃣ Run MVC UI

```
dotnet run --project UIBankAdminPanel
```

---

## 📌 Features

✔ Manage Customers  
✔ Manage Accounts  
✔ View Transactions  
✔ Admin Dashboard  
✔ Clean MVC Architecture  
✔ Separate API & UI Layer  

---

## 🎯 Key Highlights

- Two-tier architecture (UI + API)  
- Entity Framework Core integration  
- Clean folder structure  
- Beginner-friendly banking system  
- Good practice project for CRUD operations  

---

## 👨‍💻 Author

**Amit Dange**  
.NET Developer  
