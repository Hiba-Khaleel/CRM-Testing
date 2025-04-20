# CRM-Site Testing Project

![CI](https://github.com/Hiba-Khaleel/CRM-Testing/actions/workflows/CI.yml/badge.svg)

## 📌 Overview

This repository contains the automated test suite for the **CRM-Site** project, focusing on:

- ✅ Unit Testing with **xUnit**
- 🎭 UI Testing with **Playwright**
- 🔁 Continuous Integration via **GitHub Actions**

These tests help ensure the system’s **reliability**, **functionality**, and **stability** across all layers of the application.

---

## 🚀 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/Hiba-Khaleel/CRM-Testing.git
cd CRMTest
```

### 2. Restore Dependencies

```bash
dotnet restore
```

---

## 📁 Test Structure

### 🧪 Unit Tests — xUnit

**Path:** `CRMTest/UnitTests/ClassesUnitTest`

| Test File            | Description                        |
|----------------------|------------------------------------|
| `CompanyFormTests.cs` | Validates form creation logic      |
| `EmployeeTests.cs`    | Tests employee data processing     |
| `IssueTests.cs`       | Verifies issue management          |
| `MessageTests.cs`     | Tests message handling             |
| `UserTests.cs`        | Validates user data integrity      |

**Path:** `CRMTest/UnitTests/TestEmailService`

| Test File              | Description                          |
|------------------------|--------------------------------------|
| `EmailServiceTests.cs` | Tests email construction & SMTP config |

---

### 🎭 UI Tests — Playwright

**Path:** `CRMTest/Steps/Register`

| Test File           | Description                |
|---------------------|----------------------------|
| `Register.spec.cs`  | Registration functionality |

**Path:** `CRMTest/Steps/Login`

| Test File  | Description                                 |
|------------|---------------------------------------------|
| `Login.cs` | Validates login and session termination     |

**Path:** `CRMTest/Steps/CreateIssue`

| Test File        | Description                          |
|------------------|--------------------------------------|
| `CreateIssue.cs` | Tests creating a new issue after login |

---

## ▶️ Running Tests

### 1. Run Unit Tests

```bash
dotnet test CRMTest/UnitTests
```

### 2. Run Playwright UI Tests

```bash
dotnet build CRMTest/
dotnet test CRMTest/
```

> ✅ Test reports are generated automatically on execution.

---

## ⚙️ Continuous Integration

GitHub Actions is set up to automatically build and test your code on every push or pull request to the `main` branch.

**Workflow:** `CI.yml`

| Job        | Trigger             | Description                           |
|------------|----------------------|---------------------------------------|
| `test`     | Push / PR to `main`  | Builds app and runs xUnit & Playwright tests |
| `deploy`   | After `test` passes  | Deploys the application to remote server |

---

## 🤝 Contributing

Want to contribute? Awesome! Follow these steps:

1. **Fork** the repository  
2. **Create** your feature branch:  
   ```bash
   git checkout -b feature/your-feature
   ```
3. **Commit** your changes:  
   ```bash
   git commit -m "Add your feature"
   ```
4. **Push** to GitHub:  
   ```bash
   git push origin feature/your-feature
   ```
5. **Open a Pull Request**

> 🔒 **Note:** All tests must pass before a PR is merged! 🚀

---

## 📬 Contact

For questions, feedback, or collaboration, feel free to reach out via GitHub issues or discussions.

---

Let me know if you’d like a section for test coverage reports, environment variables, or Docker instructions!
