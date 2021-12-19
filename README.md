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
# UML Diagram
![RetailStore (1)](https://user-images.githubusercontent.com/33779983/146680759-04ae00c6-8745-489a-9529-f11a56a63556.jpg)

# Sample Request Flow
Get User List
Request URL
GET http://localhost:5265/api/User/GetList

Response:

[

  {
    "id": 1,
    "name": "Ömer",
    "surname": "Buyuran",
    "type": "Employee"
  },
  
  {
    "id": 2,
    "name": "Ali",
    "surname": "Mutlu",
    "type": "Affiliate"
  },
  
  {
    "id": 3,
    "name": "Selman",
    "surname": "Yalçın",
    "type": "Customer"
  },
  
  {
    "id": 4,
    "name": "Elif",
    "surname": "Yeşil",
    "type": "New Customer"
  }
  
]

Then Get Product List
Request URL
GET http://localhost:5265/api/Product/GetList

Response:

[
  {
  
    "id": 1,
    "name": "Smart Phone",
    "category": "Technology",
    "price": 5000
  },
  
  {
    "id": 2,
    "name": "Milk",
    "category": "Grocery",
    "price": 20
  },
  
  {
    "id": 3,
    "name": "Cheese",
    "category": "Grocery",
    "price": 50
  },
  
  {
    "id": 4,
    "name": "Butter",
    "category": "Grocery",
    "price": 100
  },
  
  {
    "id": 5,
    "name": "Table",
    "category": "Home Design",
    "price": 3000
  }
  
]

Choose an User and ProductList, take ids

Request URL
POST http://localhost:5265/api/userbill/GetBill

Request:

{
  "userId": 2,
  "productIdList": [
    1,2
  ]
}

Response:

{

    "productList": [
        {
            "id": 1,
            "name": "Smart Phone",
            "category": "Technology",
            "price": 5000.0000
        },
        
        {
            "id": 2,
            "name": "Milk",
            "category": "Grocery",
            "price": 20.0000
        }
        
    ],
    "user": {
        "id": 2,
        "name": "Ali",
        "surname": "Mutlu",
        "type": "affiliate"
    },
    
    "totalBill": 4295.0000,
    "privateCustomerDiscountAmount": 500.0000,
    "billDiscountAmount": 225,
    "totalDiscountAmount": 725.0000,
    "success": true,
    "message": ""
}
