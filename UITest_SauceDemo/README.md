# Sauce Demo Checkout Automation

This project is an automated test suite for the Sauce Demo website using Visual Studio 2022, Selenium WebDriver, C#, and NUnit.

## Prerequisites

- Visual Studio
- .NET SDK  (net8)
- Chrome WebDriver

## Installation

1. Clone the repository.
2. Open the project in Visual Studio.
3. Restore NuGet packages.

## Running Tests

To run the tests, use the Test Explorer in Visual Studio. Ensure that ChromeDriver is available in the project directory.

## **How to Run Tests**
### **From Visual Studio**
1. Open the Test Explorer window (**Test > Test Explorer**).
2. Build the project to discover all test cases.
3. Select individual tests or run all tests.

## Test Details
Test 1
- Logs into the Sauce Demo website using standard user credentials.
- Adds first two items to the shopping cart.
- Validates that the correct items are in the cart.
- Proceeds to checkout and verifies items and totals.

Test 2
- Logs into the Sauce Demo website using standard user credentials.
- Open Cart without no selection on produts
- Check "Checkout" button is not having


