# Selenium Practice - C# Automation Framework

A test automation framework built with Selenium WebDriver and C#, 
demonstrating Page Object Model (POM) design pattern.

## Tech Stack
- C# / .NET 10
- Selenium WebDriver 4
- NUnit
- Page Object Model (POM)

## Project Structure
SeleniumPractice/
├── Pages/
│   └── LoginPage.cs       # Page Object for login page
├── LoginTests.cs          # Test cases for login functionality
└── SeleniumPractice.csproj

## Test Cases
### Login Tests
- Login with valid credentials → should succeed
- Login with wrong username → should show error
- Login with wrong password → should show error

## How to Run
```bash
dotnet test
```

## Website Under Test
[Sauce Demo](https://www.saucedemo.com) - A demo e-commerce site for automation practice