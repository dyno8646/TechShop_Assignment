
-----------------------------------------------------ASSIGNMENT-1(TechShop)------------------------------------------------------------



------------TABLES CREATION



-- Customers Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address VARCHAR(255)
);

-- Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Description TEXT,
    Price DECIMAL(10, 2)
);

-- Orders Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- OrderDetails Table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Inventory Table
CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY,
    ProductID INT,
    QuantityInStock INT,
    LastStockUpdate DATETIME,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);




------------------INSERTION OF VALUES---------------------

-- Sample records for Customers table
INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address)
VALUES
    (1, 'Amit', 'Sharma', 'amit.sharma@email.com', '9876543210', '123 Main St, Mumbai'),
    (2, 'Priya', 'Patel', 'priya.patel@email.com', '9876543211', '456 Oak St, Ahmedabad'),
    (3, 'Rahul', 'Singh', 'rahul.singh@email.com', '9876543212', '789 Pine St, Delhi'),
    (4, 'Sneha', 'Gupta', 'sneha.gupta@email.com', '9876543213', '101 Willow St, Kolkata'),
    (5, 'Vikram', 'Verma', 'vikram.verma@email.com', '9876543214', '202 Cedar St, Bangalore'),
    (6, 'Neha', 'Kumar', 'neha.kumar@email.com', '9876543215', '303 Maple St, Chennai'),
    (7, 'Ankit', 'Malhotra', 'ankit.malhotra@email.com', '9876543216', '404 Birch St, Hyderabad'),
    (8, 'Ritu', 'Saxena', 'ritu.saxena@email.com', '9876543217', '505 Elm St, Pune'),
    (9, 'Ravi', 'Choudhary', 'ravi.choudhary@email.com', '9876543218', '606 Pine St, Jaipur'),
    (10, 'Pooja', 'Shukla', 'pooja.shukla@email.com', '9876543219', '707 Cedar St, Lucknow');

-- Sample records for Products table
INSERT INTO Products (ProductID, ProductName, Description, Price)
VALUES
    (1, 'Smartphone X', 'High-performance smartphone', 799.99),
    (2, 'Laptop Pro', 'Powerful laptop for professionals', 1299.99),
    (3, 'Wireless Earbuds', 'Premium wireless earbuds', 149.99),
    (4, 'Tablet Z', 'Portable and lightweight tablet', 499.99),
    (5, 'Smartwatch 3', 'Water-resistant smartwatch', 199.99),
    (6, 'Bluetooth Speaker', 'High-quality portable speaker', 79.99),
    (7, 'Gaming Console', 'Next-gen gaming console', 399.99),
    (8, 'Camera Kit', 'Professional photography kit', 899.99),
    (9, 'Fitness Tracker', 'Track your fitness activities', 59.99),
    (10, 'Drones Unlimited', 'Explore the skies with our drones', 599.99);

-- Sample records for Orders table
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES
    (1, 3, '2023-11-28', 149.99),
    (2, 7, '2023-11-28', 799.99),
    (3, 1, '2023-11-27', 1299.99),
    (4, 5, '2023-11-27', 499.99),
    (5, 2, '2023-11-26', 199.99),
    (6, 8, '2023-11-26', 79.99),
    (7, 4, '2023-11-25', 399.99),
    (8, 6, '2023-11-25', 899.99),
    (9, 9, '2023-11-24', 59.99),
    (10, 10, '2023-11-24', 599.99);

-- Sample records for OrderDetails table
INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity)
VALUES
    (1, 1, 3, 2),
    (2, 2, 1, 1),
    (3, 3, 2, 1),
    (4, 4, 4, 3),
    (5, 5, 5, 2),
    (6, 6, 6, 1),
    (7, 7, 7, 1),
    (8, 8, 8, 1),
    (9, 9, 9, 5),
    (10, 10, 10, 1);

-- Sample records for Inventory table
INSERT INTO Inventory (InventoryID, ProductID, QuantityInStock, LastStockUpdate)
VALUES
    (1, 1, 50, '2023-11-28'),
    (2, 2, 30, '2023-11-28'),
    (3, 3, 100, '2023-11-28'),
    (4, 4, 20, '2023-11-28'),
    (5, 5, 40, '2023-11-28'),
    (6, 6, 50, '2023-11-28'),
    (7, 7, 15, '2023-11-28'),
    (8, 8, 10, '2023-11-28'),
    (9, 9, 80, '2023-11-28'),
    (10, 10, 25, '2023-11-28');


-----------Question from 1-12---------

select * from Customers;
select * from Inventory;
select * from Orders;
select * from OrderDetails;
select * from Products;

-- 1. Write an SQL query to retrieve the names and emails of all customers. 
SELECT FirstName, LastName, Email FROM Customers;

-- 2. Write an SQL query to list all orders with their order dates and corresponding customer names.
SELECT OrderID, OrderDate,
    (SELECT CONCAT(FirstName, ' ', LastName) FROM Customers WHERE Customers.CustomerID = Orders.CustomerID) AS CustomerName
FROM Orders;

-- 3. Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.
INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address)
VALUES (11, 'Swanam', 'Krishna', 'swanam.krishna@email.com', '7736780630', '110 Thanniyam, Thrissur');
Select* from Customers;

-- 4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
select * from Products;
UPDATE Products
SET Price = Price * 1.10;

select * from Products;

select * from Orders;

-- 5. Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables. 
--Allow users to input the order ID as a parameter.
DECLARE @OrderIDToDelete INT;
SET @OrderIDToDelete =6;
DELETE FROM OrderDetails
WHERE OrderID = @OrderIDToDelete;
DELETE FROM Orders
WHERE OrderID = @OrderIDToDelete;

select * from Orders;

-- 6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.
select * from Orders;
DECLARE @OrderID INT;
DECLARE @CustomerID INT;
DECLARE @OrderDate DATE;
DECLARE @TotalAmount DECIMAL(10, 2);
SET @OrderID = 6;
SET @CustomerID = 5;
SET @OrderDate = GETDATE(); 
SET @TotalAmount = 280.99;
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES (@OrderID, @CustomerID, @OrderDate, @TotalAmount);

--or
INSERT INTO Orders (order_id, customer_id, order_date, total_amount)
VALUES (11, 104, '2023-12-01', 220.75);


select * from Orders;

-- 7. Write an SQL query to update the contact information (e.g., email and address) of a specific customer in the "Customers" table. 
--Allow users to input the customer ID and new contact information.
select * from Customers;
DECLARE @CustomerIDToUpdate INT;
DECLARE @NewEmail NVARCHAR(255);
DECLARE @NewAddress NVARCHAR(255);
SET @CustomerIDToUpdate = 11;
SET @NewEmail = 'swanam.k@email.com';
SET @NewAddress = '110 Thrissur, Kerala';

UPDATE Customers
SET Email = @NewEmail, Address = @NewAddress
WHERE CustomerID = @CustomerIDToUpdate;
select * from Customers;

-- 8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" table 
--based on the prices and quantities in the "OrderDetails" table.
select * from Orders;
UPDATE Orders
SET TotalAmount = (
    SELECT SUM(od.Quantity * p.Price)
    FROM OrderDetails od
    JOIN Products p ON od.ProductID = p.ProductID
    WHERE od.OrderID = Orders.OrderID
);
SELECT * FROM Orders;

-- 9. Write an SQL query to delete all orders and their associated order details for a specific customer from the "Orders" and "OrderDetails" tables. 
--Allow users to input the customer ID as a parameter.
select *  from Orders, OrderDetails;
DECLARE @CustomerIDToDelete INT;
SET @CustomerIDToDelete = 5;
DELETE FROM OrderDetails
WHERE OrderID IN (SELECT OrderID FROM Orders WHERE CustomerID = @CustomerIDToDelete);
DELETE FROM Orders
WHERE CustomerID = @CustomerIDToDelete;
select *  from Orders, OrderDetails;


-- 10. Write an SQL query to insert a new electronic gadget product into the "Products" table, including product name, 
--category, price, and any other relevant details.
select *  from Products;
ALTER TABLE Products
ADD Category NVARCHAR(255);
INSERT INTO Products (ProductID, ProductName, Description, Price, Category)
VALUES (11, 'New Gadget', 'Cutting-edge features and technology', 699.99,
'Electronic Gadget');
select *  from Products;

-- 11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from "Pending" to "Shipped"). 
--Allow users to input the order ID and the new status.
select * from Orders;
ALTER TABLE Orders
ADD Status NVARCHAR(50) DEFAULT 'Pending';
DECLARE @OrderIDToUpdate INT;
DECLARE @NewStatus NVARCHAR(50);
SET @OrderIDToUpdate = 5;
SET @NewStatus = 'Shipped';
UPDATE Orders
SET Status = @NewStatus
WHERE OrderID = @OrderIDToUpdate;

select * from Orders;

-- 12. Write an SQL query to calculate and update the number of orders placed by each customer in 
--the "Customers" table based on the data in the "Orders" table.
select * from Customers;
ALTER TABLE Customers
ADD OrdersCount INT;


UPDATE Customers
SET OrdersCount = ( SELECT COUNT(*) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID)
select * from Customers;




-- JOINS--------------AND---------------AGGREGATES

--1
SELECT Orders.OrderID, Orders.OrderDate, Customers.CustomerID, 
CONCAT(Customers.FirstName, ' ', Customers.LastName) AS CustomerName
FROM Orders
JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

--2

SELECT ProductName, SUM(Quantity * Price) AS TotalRevenue
FROM Products
JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID
JOIN Orders ON OrderDetails.OrderID = Orders.OrderID
GROUP BY ProductName;


UPDATE PRODUCTS
SET ProductName = 'GPS'
WHERE ProductID = 11;
UPDATE Products
SET Category = 'Electronic Gadget';

SELECT * FROM Products;

UPDATE OrderDetails
SET Quantity = 0
WHERE OrderDetailID = 5;

UPDATE OrderDetails
SET Quantity = 0
WHERE OrderDetailID = 7;


--3
SELECT Customers.CustomerID, Customers.FirstName, Customers.LastName, Customers.Phone
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName, Customers.LastName, Customers.Phone;


--4a
SELECT TOP 1 P.ProductName, SUM(OD.Quantity) AS TotalQuantityOrdered
FROM Products P
JOIN OrderDetails OD ON P.ProductID = OD.ProductID
JOIN Orders O ON OD.OrderID = O.OrderID
WHERE P.Category = 'Electronic Gadget'
GROUP BY P.ProductID, P.ProductName
ORDER BY TotalQuantityOrdered DESC;

	--4b
SELECT P.ProductName, P.Category
FROM Products P
WHERE P.Category = 'Electronic Gadget';

--5
SELECT P.ProductName, P.Category
FROM Products P
WHERE P.Category = 'Electronic Gadget';

--6
SELECT C.CustomerID, C.FirstName, C.LastName, AVG(OD.Quantity * P.Price) AS AvgOrderValue
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY C.CustomerID, C.FirstName, C.LastName;

--7
SELECT TOP 1 O.OrderID, C.CustomerID, C.FirstName, C.LastName, SUM(OD.Quantity * P.Price) AS TotalRevenue
FROM Orders O
JOIN Customers C ON O.CustomerID = C.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY O.OrderID, C.CustomerID, C.FirstName, C.LastName
ORDER BY TotalRevenue DESC;

--8
SELECT P.ProductID, P.ProductName, COUNT(OD.OrderID) AS OrderCount
FROM Products P
JOIN OrderDetails OD ON P.ProductID = OD.ProductID
GROUP BY P.ProductID, P.ProductName;

--9
DECLARE @ProductName NVARCHAR(255) = 'Laptop Pro';
SELECT C.CustomerID, C.FirstName, C.LastName
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
WHERE P.ProductName = @ProductName;

--10
select * from Orders;
DECLARE @StartDate DATE = '2023-11-25', @EndDate DATE = '2023-11-27';
SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue
FROM Orders O
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
WHERE O.OrderDate BETWEEN @StartDate AND @EndDate;



--Agregate Functions

--1
SELECT CustomerID, FirstName, LastName FROM Customers WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders);

--2
SELECT COUNT(*) AS TotalProducts FROM Products;

--3
SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue FROM OrderDetails OD JOIN Products P ON OD.ProductID = P.ProductID;

--4
DECLARE @CategoryName NVARCHAR(255) = 'Electronic Gadget'; 
SELECT AVG(OD.Quantity) AS AvgQuantityOrdered FROM OrderDetails OD 
JOIN Products P ON OD.ProductID = P.ProductID WHERE P.Category = @CategoryName;

--5
DECLARE @CustomerID INT = 6; 
SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue FROM OrderDetails OD 
JOIN Products P ON OD.ProductID = P.ProductID 
WHERE OD.OrderID IN (SELECT OrderID FROM Orders WHERE CustomerID = @CustomerID);

--6
SELECT C.CustomerID, C.FirstName, C.LastName, COUNT(O.OrderID) AS OrderCount
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
GROUP BY C.CustomerID, C.FirstName, C.LastName
ORDER BY OrderCount DESC;

--7
SELECT P.Category
FROM Products P
JOIN OrderDetails OD ON P.ProductID = OD.ProductID
GROUP BY P.Category
ORDER BY SUM(OD.Quantity) DESC;

--8
SELECT AVG(TotalRevenue) AS AverageOrderValue 
FROM (SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue 
FROM OrderDetails OD 
JOIN Products P ON OD.ProductID = P.ProductID 
GROUP BY OD.OrderID) AS OrderTotals;

--9
SELECT AVG(TotalRevenue) AS AverageOrderValue 
FROM (SELECT SUM(OD.Quantity * P.Price) AS TotalRevenue 
FROM OrderDetails OD 
JOIN Products P ON OD.ProductID = P.ProductID 
GROUP BY OD.OrderID) AS OrderTotals;

--10
SELECT C.CustomerID, C.FirstName, C.LastName, 
COUNT(O.OrderID) AS OrderCount 
FROM Customers C 
JOIN Orders O ON C.CustomerID = O.CustomerID 
GROUP BY C.CustomerID, C.FirstName, C.LastName;
