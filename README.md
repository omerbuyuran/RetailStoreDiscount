# RetailStoreDiscount
 This project is calculating discounts and bill for different type of users, for according to spesific rules:
   1.	If the user type is an employee of the store, he gets a 30% discount
   2.	If the user type is an affiliate of the store, he gets a 10% discount
   3.	If the user has been a customer for over 2 years, he gets a 5% discount. (If the user type is an customer, he gets a 5% discount. New Customer is another user type)
   4.	For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount).
   5.	The percentage based discounts do not apply on groceries.
   6.	A user can get only one of the percentage based discounts on a bill.
# Install & Run
   1. Clone the Repository
   2. Create a db with using sql script.
   3. Change the ConnectionStrings in appsettings.json
   4. The app running on localhost:5265
# Tooling
1.	Swagger - API documentation
2.	MSSQL - DB
3.	AutoMapper - Mapping framework
4.	EntityFramework
