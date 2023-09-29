CREATE NONCLUSTERED INDEX IX_Products_Price ON Products (Pprice);

CREATE NONCLUSTERED INDEX IX_Payments ON Payment (totalamount_payed);

CREATE NONCLUSTERED INDEX IX_Usernames ON Users (username);

CREATE NONCLUSTERED INDEX IX_RefundPIDs ON Refund (PaymentID);
