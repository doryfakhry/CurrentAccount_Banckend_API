# CurrentAccount_Banckend_API
The Back end solution is developed using ASP.NET core 5 with Entity Framework and designed using repository pattern.
The API consists of two Endpoints:
1-	Account: to open and new account (POST)
It takes the below object from the body then creates a new account and a transaction if initialcredit not equal to zero.

Request: Base.URL/Account
Body:
{
  "id": 1,
  "initialcredit": 150
}

Response:
Code 200 if succeeded

2-	User/{id}: to get user info, Accounts and transaction details (GET)
It takes an Id and return a json object

Request: Base.URL/User/1

Response:
{
  "id": 1,
  "name": "Dory",
  "surName": "Fakhry",
  "accountList": [
    {
      "id": 1,
      "initialcredit": 100,
      "transactionList": [
        {
          "id": 1,
          "transactionDate": "2022-08-01T09:50:47.2781997",
          "amount": 100,
          "accountId": 1
        }
      ],
      "userId": 1
    },
    {
      "id": 2,
      "initialcredit": 0,
      "transactionList": [],
      "userId": 1
    },
    {
      "id": 4,
      "initialcredit": 0,
      "transactionList": [],
      "userId": 1
    },
    {
      "id": 5,
      "initialcredit": 0,
      "transactionList": [],
      "userId": 1
    },
    {
      "id": 6,
      "initialcredit": 1010,
      "transactionList": [],
      "userId": 1
    },
    {
      "id": 7,
      "initialcredit": 1011,
      "transactionList": [],
      "userId": 1
    },
    {
      "id": 8,
      "initialcredit": 1013,
      "transactionList": [],
      "userId": 1
    },
    {
      "id": 9,
      "initialcredit": 1020,
      "transactionList": [
        {
          "id": 2,
          "transactionDate": "2022-08-01T12:57:12.3547679",
          "amount": 1020,
          "accountId": 9
        }
      ],
      "userId": 1
    },
    {
      "id": 10,
      "initialcredit": 10452,
      "transactionList": [
        {
          "id": 3,
          "transactionDate": "2022-08-01T13:02:24.5988378",
          "amount": 10452,
          "accountId": 10
        }
      ],
      "userId": 1
    },
    {
      "id": 11,
      "initialcredit": 10453,
      "transactionList": [
        {
          "id": 4,
          "transactionDate": "2022-08-01T13:02:55.1601246",
          "amount": 10453,
          "accountId": 11
        }
      ],
      "userId": 1
    },
    {
      "id": 12,
      "initialcredit": 104555,
      "transactionList": [
        {
          "id": 5,
          "transactionDate": "2022-08-01T13:03:10.1107923",
          "amount": 104555,
          "accountId": 12
        }
      ],
      "userId": 1
    },
    {
      "id": 13,
      "initialcredit": 150,
      "transactionList": [
        {
          "id": 6,
          "transactionDate": "2022-08-01T13:22:57.0171793",
          "amount": 150,
          "accountId": 13
        }
      ],
      "userId": 1
    }
  ]
}

The application uses a local in memory database (localdb)\\mssqllocaldb.
After downloading and opening the project using visual studio, please open terminal and type:
Update-database in order to create the database and the table entities.
Run the project and know you can test it using Swagger interface ,Postman or the Angular frontend App provided.

											Thank You
											Dory Fakhry
