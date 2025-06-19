CREATE PROCEDURE GetMaxSalary
    @CurrentSalary INT 
AS
BEGIN
    SELECT AVG(Salary) as AverSalary FROM Employee
    GROUP BY Employee.NameEmployee
    HAVING AVG(Salary) > @CurrentSalary
END 