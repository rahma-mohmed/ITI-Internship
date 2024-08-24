use company_SD
---1
select Dependent_name , D.Sex from Dependent D
inner join Employee E ON D.ESSN = E.SSN
where D.sex = 'F' and E.Sex = 'F'

select Dependent_name , D.sex from Dependent D
inner join Employee E ON D.ESSN = E.SSN
where D.sex = 'M' and E.Sex = 'M'

select Dependent_name , D.Sex from Dependent D
inner join Employee E ON D.ESSN = E.SSN
where D.sex = 'F' and E.Sex = 'F'
union all
select Dependent_name , D.sex from Dependent D
inner join Employee E ON D.ESSN = E.SSN
where D.sex = 'M' and E.Sex = 'M'

---2
select Pname, SUM(Hours) AS TotalHours
from Works_for W
join Project P ON W.Pno = P.Pnumber
group by Pname;

---3
SELECT *
FROM Departments D
where D.Dnum = (select dno from Employee E
WHERE E.SSN = (SELECT MIN(SSN) FROM Employee))

---4
select Dname, MAX(Salary) max_salary, MIN(Salary) min_salary, AVG(Salary) avg_salary
from Departments D
JOIN Employee E ON D.Dnum = E.Dno
group by Dname;

---5
select fname + ' ' + lname as full_name from employee e
join Departments d
on e.SSN = d.MGRSSN 
and d.MGRSSN not in (select ESSN from Dependent)

---6
SELECT D.Dnum, D.Dname, count(E.SSN) EmployeeCount
FROM Departments D join Employee E
on D.Dnum = E.Dno
group by D.Dnum , D.Dname
having avg(E.salary) < (select avg(salary) from Employee)

---7
select fname , lname , pname 
from Employee , Works_for , Project
where SSN = ESSn and Pnumber = Pno
order by Dnum , Lname , Fname 

---8
select salary from Employee
where salary 
in(select top(2) Salary from Employee order by Salary desc)

---9
select fname , lname 
from Employee
where fname + ' ' + lname 
in (select Dependent_name from Dependent)

---10
select SSN, Fname, Lname
from Employee
where EXISTS(
    select 1 
    FROM Dependent 
    WHERE ESSN = SSN
)

---11
insert into Departments values('DEPT IT' , 100 , 112233, '2006-11-01')

---12
update Departments set MGRSSN = 968574 where Dnum = 100
update Departments set MGRSSN = 102672 where Dnum = 20
update Employee set Superssn = 102672 where SSN = 102660

---13
delete from Dependent where ESSN = 223344
update Departments set MGRSSN = null where MGRSSN = 223344
update Employee set Superssn = null where Superssn = 223344
delete from Works_for where ESSN = 223344;
delete from Employee where SSN = 223344;

---14
update Employee set Salary += Salary*0.3
where SSN
in (select ESSN from Works_for join Project on Pnumber = Pno and Pname = 'Al Rawdah')
