# SauceDemo Automation Project

## Site for testing
[https://www.saucedemo.com](https://www.saucedemo.com)

---

## 📝 Task Description & Scenarios

### **UC-1: Test Login form with only Username provided**
1. **Enter** any username.
2. **Enter** password.
3. **Clear** the "Password" field.
4. **Click** the "Login" button.
5. **Verify** that an error message `"Password is required"` appears.

### **UC-2: Test Login form with valid credentials**
1. **Enter** username for a standard user.
2. **Enter** a password from the section “Password for all users”.
3. **Click** “Login” button and **verify** that main page contains:
   * Burger menu button
   * Label “Swag Labs”
   * Shopping cart icon
   * Dropdown with sorting filters
   * List of inventory items

### **UC-3: Test adding products to shopping cart**
1. **Login** with standard user.
2. **Open details** of any product by clicking on it.
3. **Add** product to cart.
4. **Verify** that the shopping cart icon displays the number of added products.

---

## ⚙️ Technical Requirements
* **Parallel Execution**: Implemented at the Fixture level for optimized performance.
* **Logging**: Integrated execution flow tracking via `TestContext` in `BasePage`.
* **Data-Driven Testing**: Used `[TestCase]` approach to separate logic from test data.
* **Full Coverage**: All scenarios (UC-1, UC-2, UC-3) support the above conditions.

---

## Project Options Used
* **Test Automation tool**: Selenium WebDriver
* **Browsers**: 
  1. Firefox 
  2. Chrome 
* **Locators**: CSS Selectors
* **Test Runner**: NUnit
* **Assertions**: Fluent Assertion
* **Patterns**: Factory method (for WebDriver implementation)
