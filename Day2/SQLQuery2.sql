Use Company_SD

---1
SELECT * FROM Employee

---2
SELECT Fname, Lname, Salary, Dno
FROM Employee;

---3
select Pname , Plocation , Dnum from Project

--4
SELECT Fname + ' ' + Lname as [Full Name], salary *12*0.1 AS "ANNUAL COMM"
FROM Employee;

---5
select SSN , Fname + ' ' + Lname as [Full Name] FROM Employee
where salary > 1000;

---6
select SSN , Fname + ' ' + Lname as [Full Name] FROM Employee
where salary*12 > 10000;

---7
select Fname + ' ' + Lname as [Full Name] , salary FROM Employee where Sex = 'F'

---8
select Dnum , Dname from Departments where MGRSSN = 968574

---9
select Pnumber , Pname , Plocation from Project where Dnum = 10;



