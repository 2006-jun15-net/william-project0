--CREATE tables
CREATE TABLE Customer (
    CustomerId INT IDENTITY PRIMARY KEY NOT NULL,
    FirstName varchar(255) NOT NULL,
    LastName varchar(255) NOT NULL,
    Email varchar(255) NULL --Make unique maybe
);
---------------------------------------
---------------------------------------

CREATE TABLE StoreLocation (
	LocationId INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(255) NOT NULL,
	Address NVARCHAR(255) NULL
);

CREATE TABLE Product (
	ProductId INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(255) NOT NULL,
	Price SMALLMONEY DEFAULT $0.00 --If I don't say a price, then it's free.
);
---------------------------------------
CREATE TABLE OrderHistory (
	OrderId INT IDENTITY PRIMARY KEY NOT NULL,
	Date DATE NOT NULL,
	Time TIME NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customer(CustomerId),
	LocationId INT FOREIGN KEY REFERENCES StoreLocation(LocationId)
);
----
CREATE TABLE Inventory (
	Amount INT,
	CHECK (Amount > -1),
	LocationId INT FOREIGN KEY REFERENCES StoreLocation(LocationId),
	ProductId INT FOREIGN KEY REFERENCES Product(ProductId),
	CONSTRAINT PK_Inventory PRIMARY KEY (LocationId, ProductId)
);

----
CREATE TABLE StoreOrder (	
	Amount INT,
	CHECK (Amount > -1),
	ProductId INT FOREIGN KEY REFERENCES Product(ProductId),
	OrderId INT FOREIGN KEY REFERENCES OrderHistory(OrderId),
	CONSTRAINT PK_Order PRIMARY KEY (ProductId, OrderId)
);
----
-- 
-----------------------------
--
---------------------------------------------------------------------- Add some data ----

INSERT INTO Customer (FirstName, LastName, Email) VALUES
('william', 'nesham', 'william.nesham@gmail.com'),
('hua', 'updog', ''),
('allround', 'worl', '');
--
INSERT INTO Product (Name, Price) VALUES
('macklemore', $0.99),
('updog', NULL),
('dead_meme', $0.69),
('car', $1.00),
('soupdog', $0.01),
('chilldog', $0.02),
('book', $1.01),
('lambo', $70.07),
('diamond', $1.00),
('datboi', $1000.25),
('24', $0.25),
('pepe', $0.33),
('foreveralone', NULL);
--
INSERT INTO StoreLocation (Name, Address) VALUES
('chilly', '420 goteem dr'),
('dechoppa', 'where you dr'),
('reddit', 'r/ memes');
--
INSERT INTO Inventory (Amount, LocationId, ProductId) VALUES
(50, 1, 2),
(55, 1, 1),
(77, 1, 3),
(50, 1, 5),
(49, 1, 4),
(50, 1, 6),
(50, 1, 7),
(50, 1, 8),
(50, 1, 9),
(53, 1, 11),
(50, 1, 10),
(52, 1, 12),
(60, 1, 13),
(50, 2, 2),
(55, 2, 1),
(77, 2, 3),
(50, 2, 5),
(49, 2, 4),
(50, 2, 6),
(50, 2, 7),
(50, 2, 8),
(50, 2, 9),
(53, 2, 11),
(50, 2, 10),
(52, 2, 12),
(60, 2, 13),
(50, 3, 2),
(55, 3, 1),
(77, 3, 3),
(50, 3, 5),
(49, 3, 4),
(50, 3, 6),
(50, 3, 7),
(50, 3, 8),
(50, 3, 9),
(53, 3, 11),
(50, 3, 10),
(52, 3, 12),
(60, 3, 13);
--
INSERT INTO OrderHistory (CustomerId, LocationId, Date, Time) VALUES
(2, 2, '2015-12-17', '00:00:10'),
(3, 3, GETDATE(), '16:00:20'),
(2, 2, '2020-05-24', '16:00:21'),
(1, 1, GETDATE(), '16:00:22'),
(2, 2, GETDATE(), '16:00:23'),
(1, 2, GETDATE(), '17:00:24'),
(1, 3, GETDATE(), '18:00:24'),
(2, 2, GETDATE(), '20:00:25');
--
INSERT INTO StoreOrder (ProductId, Amount, OrderId) VALUES
(2, 3, 9),
(1, 1, 2),
(2, 2, 3),
(3, 1, 4),
(2, 10, 5),
(4, 1, 6),
(2, 11, 7),
(5, 2, 8);
---------------------------------------------------------------------- End ISERTions ----

SELECT * FROM StoreLocation
SELECT * FROM Product WHERE ProductId = (SELECT ProductId FROM Product WHERE ProductId=9)
SELECT * FROM Inventory
SELECT * FROM Customer
SELECT * FROM OrderHistory
SELECT * FROM StoreOrder