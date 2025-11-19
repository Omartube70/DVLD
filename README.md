# 🚦 DVLD - Driving & Vehicle License Department System

<div align="center">

![DVLD System Demo](https://github.com/Omartube70/DVLD/blob/master/DVLD.gif)

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)

**A comprehensive desktop application for managing driver's licenses and vehicle registrations**

[Features](#-features) • [Architecture](#️-architecture) • [Installation](#-installation) • [Tech Stack](#-tech-stack) • [Screenshots](#-screenshots)

</div>

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Architecture](#️-architecture)
- [Tech Stack](#-tech-stack)
- [Installation](#-installation)
- [Usage](#-usage)
- [Database Schema](#-database-schema)
- [Screenshots](#-screenshots)
- [Contributing](#-contributing)
- [License](#-license)
- [Contact](#-contact)

---

## 🌟 Overview

**DVLD (Driving & Vehicle License Department)** is a robust desktop application built with C# and .NET Framework that automates and manages all operations related to issuing and renewing driver's licenses in a virtual traffic department.

The system is built on **3-Tier Architecture**, making it powerful, organized, and easy to maintain and develop in the future.

### 🎯 Key Highlights

- ✅ **Secure Authentication** with role-based access control
- ✅ **Complete License Management** (Local & International)
- ✅ **Multi-Test System** (Vision, Written, Street Tests)
- ✅ **Application Tracking** for all license types
- ✅ **User-Friendly Interface** with intuitive navigation
- ✅ **Scalable Architecture** following industry best practices

---

## 🚀 Features

<table>
  <tr>
    <td width="50%">
      
### 👥 User Management
- Secure login system with password hashing
- Role-based access control
- User activity tracking
- Password change functionality
- Account activation/deactivation

    </td>
    <td width="50%">
      
### 👤 People Management
- Add, edit, and delete person records
- Advanced search capabilities
- Document upload support
- Nationality tracking
- Complete profile management

    </td>
  </tr>
  <tr>
    <td width="50%">
      
### 📝 Application Processing
- Local driving license applications
- International license applications
- License renewal requests
- Replacement for lost/damaged licenses
- Application status tracking

    </td>
    <td width="50%">
      
### 🎓 Test Management
- Vision test scheduling
- Written test scheduling
- Street test scheduling
- Test result recording
- Retry test management
- Test appointment tracking

    </td>
  </tr>
  <tr>
    <td width="50%">
      
### 🪪 License Operations
- Issue new licenses
- Renew expired licenses
- Replace lost/damaged licenses
- Detain licenses
- Release detained licenses
- License history tracking

    </td>
    <td width="50%">
      
### 📊 Reporting & Analytics
- Application reports
- License statistics
- Test results analysis
- User activity logs
- System audit trails

    </td>
  </tr>
</table>

---

## 🏗️ Architecture

The project follows the **3-Tier Architecture** pattern for separation of concerns and code organization:

### 📦 Layer Breakdown

<table>
  <tr>
    <th width="20%">Layer</th>
    <th width="30%">Responsibility</th>
    <th width="50%">Components</th>
  </tr>
  <tr>
    <td><strong>🖥️ Presentation</strong><br/><code>DVLD</code></td>
    <td>User Interface & Interaction</td>
    <td>
      • Windows Forms<br/>
      • User Controls<br/>
      • Input Validation<br/>
      • Data Binding
    </td>
  </tr>
  <tr>
    <td><strong>⚙️ Business Logic</strong><br/><code>DVLD_Business</code></td>
    <td>Business Rules & Logic</td>
    <td>
      • Business Objects<br/>
      • Validation Rules<br/>
      • Data Processing<br/>
      • Workflow Management
    </td>
  </tr>
  <tr>
    <td><strong>💾 Data Access</strong><br/><code>DVLD_DataAccess</code></td>
    <td>Database Operations</td>
    <td>
      • ADO.NET<br/>
      • SQL Queries<br/>
      • Stored Procedures<br/>
      • Connection Management
    </td>
  </tr>
</table>

---

## 🛠️ Tech Stack

<div align="center">

| Category | Technology |
|----------|-----------|
| **Language** | ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) |
| **Framework** | ![.NET](https://img.shields.io/badge/.NET%20Framework%204.8-512BD4?style=flat&logo=.net&logoColor=white) |
| **UI** | ![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=flat&logo=windows&logoColor=white) |
| **Database** | ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white) |
| **Data Access** | ![ADO.NET](https://img.shields.io/badge/ADO.NET-512BD4?style=flat&logo=.net&logoColor=white) |
| **Security** | ![BCrypt](https://img.shields.io/badge/BCrypt-323330?style=flat&logo=lock&logoColor=white) |

</div>

---

## 💻 Installation

### 📋 Prerequisites

Before you begin, ensure you have the following installed:

- ![Visual Studio](https://img.shields.io/badge/Visual%20Studio%202019+-5C2D91?style=flat&logo=visual-studio&logoColor=white) or later
- ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white) (2016 or later)
- ![.NET Framework](https://img.shields.io/badge/.NET%20Framework%204.8-512BD4?style=flat&logo=.net&logoColor=white)

### 🔧 Setup Steps

#### 1️⃣ Clone the Repository
```bash
git clone https://github.com/Omartube70/DVLD.git
cd DVLD
```

#### 2️⃣ Database Setup

1. Open **SQL Server Management Studio (SSMS)**
2. Create a new database named `DVLD`
3. Locate the database script: `Database/DVLD_Database.sql`
4. Execute the script to create tables, stored procedures, and seed data
```sql
-- Execute in SSMS
USE master;
GO

CREATE DATABASE DVLD;
GO

USE DVLD;
GO

-- Run the DVLD_Database.sql script here
```

#### 3️⃣ Configure Connection String

1. Open the solution file `DVLD.sln` in Visual Studio
2. Navigate to the **DVLD_DataAccess** project
3. Open `clsDataAccessSettings.cs`
4. Update the connection string:
```csharp
public static class clsDataAccessSettings
{
    // Update this with your SQL Server instance name
    public static string ConnectionString = 
        "Server=YOUR_SERVER_NAME;Database=DVLD;Integrated Security=True;";
}
```

**Common Server Names:**
- `.` (local default instance)
- `localhost`
- `(localdb)\MSSQLLocalDB` (LocalDB)
- `YOUR_COMPUTER_NAME\SQLEXPRESS`

#### 4️⃣ Build and Run

1. Build the solution: `Ctrl + Shift + B`
2. Set `DVLD` project as startup project
3. Run the application: `F5`

### 🔐 Default Login Credentials
```
Username: Admin
Password: 1234
```

> ⚠️ **Security Note:** Change the default password after first login!

---

## 📖 Usage

### 🚪 Getting Started

1. **Login** with your credentials
2. Navigate through the **main menu** to access different modules
3. Use the **search** functionality to find existing records
4. Create **new applications** for license processing
5. Track **application status** through the workflow

### 📊 Common Workflows

<details>
<summary><b>🆕 New License Application</b></summary>

1. Navigate to **Applications** → **New Driving License** → **Local License**
2. Select or create a **person record**
3. Choose **license class**
4. Pay **application fees**
5. Schedule **vision test**
6. Complete all required **tests**
7. **Issue license** upon passing all tests

</details>

<details>
<summary><b>🔄 Renew Existing License</b></summary>

1. Navigate to **Applications** → **Renew Driving License**
2. Search for **existing license**
3. Verify **license details**
4. Pay **renewal fees**
5. **Issue renewed license**

</details>

<details>
<summary><b>🌍 International License</b></summary>

1. Navigate to **Applications** → **New International License**
2. Select **active local license**
3. Pay **application fees**
4. **Issue international license**

</details>

---

## 🗄️ Database Schema

<details>
<summary><b>📊 Main Tables</b></summary>

### Core Tables

- **People** - Personal information
- **Users** - System users and credentials
- **Applications** - Base application data
- **LocalDrivingLicenseApplications** - Local license applications
- **InternationalLicenses** - International license records
- **Licenses** - Issued licenses
- **Drivers** - Driver information
- **Tests** - Test records
- **TestAppointments** - Test scheduling
- **DetainedLicenses** - Detained license tracking

### Lookup Tables

- **Countries** - Country master data
- **ApplicationTypes** - Application type definitions
- **TestTypes** - Test type definitions
- **LicenseClasses** - License class definitions

</details>

---

## 📸 Screenshots

<details open>
<summary><b>🖼️ View Application Screenshots</b></summary>

### Login Screen
*Add your screenshot here*

### Main Dashboard
*Add your screenshot here*

### People Management
*Add your screenshot here*

### License Application
*Add your screenshot here*

### Test Scheduling
*Add your screenshot here*

</details>

---

## 🤝 Contributing

Contributions are welcome! Here's how you can help:

### 🌟 Ways to Contribute

- 🐛 Report bugs
- 💡 Suggest new features
- 📝 Improve documentation
- 🔧 Submit pull requests

### 📝 Contribution Guidelines

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. **Open** a Pull Request

### 🐛 Reporting Issues

When reporting issues, please include:

- Clear description of the problem
- Steps to reproduce
- Expected vs actual behavior
- Screenshots (if applicable)
- Environment details (OS, .NET version, SQL Server version)

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.
```
MIT License

Copyright (c) 2024 Omar

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
```

---

## 📧 Contact

<div align="center">

**Omar Mohamed**

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Omartube70)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/yourprofile)
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:your.email@example.com)

**Project Link:** [https://github.com/Omartube70/DVLD](https://github.com/Omartube70/DVLD)

</div>

---

<div align="center">

### ⭐ If you found this project helpful, please give it a star!

Made with ❤️ by [Omar Mohamed](https://github.com/Omartube70)

![Visitors](https://visitor-badge.laobi.icu/badge?page_id=Omartube70.DVLD)

</div>

---

## 🙏 Acknowledgments

- Icons by [Font Awesome](https://fontawesome.com/)
- Badges by [Shields.io](https://shields.io/)
- README inspiration from [Best-README-Template](https://github.com/othneildrew/Best-README-Template)

---

<div align="center">

**[⬆ Back to Top](#-dvld---driving--vehicle-license-department-system)**

</div>
