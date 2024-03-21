// {325E8FF6-BD69-4919-9ABB-98C5497204AC}
IMPLEMENT_OLECREATE(<<class>>, <<external_name>>, 
0x325e8ff6, 0xbd69, 0x4919, 0x9a, 0xbb, 0x98, 0xc5, 0x49, 0x72, 0x4, 0xac);
// {73967DCB-8C16-49A1-8816-C824E89A4BE5}
IMPLEMENT_OLECREATE(<<class>>, <<external_name>>, 
0x73967dcb, 0x8c16, 0x49a1, 0x88, 0x16, 0xc8, 0x24, 0xe8, 0x9a, 0x4b, 0xe5);
// {85BFC514-1E90-44AD-B010-D79BC26E2CCD}
IMPLEMENT_OLECREATE(<<class>>, <<external_name>>, 
0x85bfc514, 0x1e90, 0x44ad, 0xb0, 0x10, 0xd7, 0x9b, 0xc2, 0x6e, 0x2c, 0xcd);



{
    "Order": {
        "CustomerId": "325E8FF6-BD69-4919-9ABB-98C5497204AC",
        "OrderName": "Sample Order",
        "ShippingAddress": {
            "FirstName": "John",
            "LastName": "Doe",
            "EmailAddress": "johndoe@example.com",
            "AddressLine": "123 Main St",
            "Country": "United States",
            "State": "California",
            "ZipCode": "90001"
        },
        "BillingAddress": {
            "FirstName": "John",
            "LastName": "Doe",
            "EmailAddress": "johndoe@example.com",
            "AddressLine": "123 Main St",
            "Country": "United States",
            "State": "California",
            "ZipCode": "90001"
        },
        "Payment": {
            "CardName": "John Doe",
            "CardNumber": "1234 5678 9012 3456",
            "Expiration": "12/25",
            "Cvv": "123",
            "PaymentMethod": 1
        },
        "Status": "2",
        "OrderItems": [
            {
                "ProductId": "325E8FF6-BD69-4919-9ABB-98C5497204AC",
                "Quantity": 2,
                "Price": 25.99
            },
            {
                "ProductId": "73967DCB-8C16-49A1-8816-C824E89A4BE5",
                "Quantity": 1,
                "Price": 49.99
            }
        ]
    }
}

---The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Orders_Customers_CustomerId". The conflict occurred in database "OrderDb", table "dbo.Customers", column 'Id'.
The INSERT statement conflicted with the FOREIGN KEY constraint "FK_OrderItems_Products_ProductId". The conflict occurred in database "OrderDb", table "dbo.Products", column 'Id'.
The statement has been terminated.