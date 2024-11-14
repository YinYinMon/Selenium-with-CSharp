
# Fake Store API - Automated API Test Suite

This project contains a suite of automated API tests developed in C# using NUnit to validate the functionality of the [Fake Store API](https://fakestoreapi.com/docs). The suite tests several key endpoints for both positive and negative scenarios.
---

## **Project Setup**

### **Prerequisites**
1. **Visual Studio** (2022 or later)
   - Ensure the `.NET 8.0 SDK` is installed.
2. **Dependencies**
   - The following NuGet packages are used in this project:
     - `NUnit` (3.14.0) 
     - `NUnit3TestAdapter` (4.5.0)
     - `RestSharp` (112.1.0)
     - `Microsoft.NET.Test.Sdk` (17.8.0) 
     - `coverlet.collector` (6.0.0) 
     - `NUnit.Analyzers` (3.9.0) 

### **Installation Instructions**
1. Clone this repository:
   ```bash
   git clone https://github.com/YinYinMon/Selenium-with-CSharp.git
   cd Selenium-with-CSharp
   ```
2. Open the solution (`.sln`) file in Visual Studio.
3. Restore the NuGet packages:
   - Navigate to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution** and install missing dependencies.

## **How to Run Tests**
### **From Visual Studio**
1. Open the Test Explorer window (**Test > Test Explorer**).
2. Build the project to discover all test cases.
3. Select individual tests or run all tests.

