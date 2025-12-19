-- Выполни в SQL Server Management Studio или через Visual Studio
USE publishing;
SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME IN ('Publications', 'Authors', 'Offices');