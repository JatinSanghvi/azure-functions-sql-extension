## SQL Commands to Prepare Database and Table

```sql
ALTER DATABASE [<database name>]
SET CHANGE_TRACKING = ON
(CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON);

CREATE TABLE Employees (
        EmployeeId int NOT NULL,
        FirstName varchar(255),
        LastName varchar(255),
        Company varchar(255),
        Team varchar(255),
		PRIMARY KEY (EmployeeId)
);

ALTER TABLE Employees
ENABLE CHANGE_TRACKING;
```