select salary
from Instructor

select sum(salary) as total
from Instructor

select count(ins_id) as Cnt
from Instructor

select min(salary),Max(salary)
from Instructor

select count(*),Count(st_id),count(st_fname),count(st_age)
from Student

select avg(st_age)
from Student

select avg(isnull(st_age,0))
from Student

select sum(st_age)/count(*)
from Student

select sum(salary),dept_id
from Instructor
group by Dept_Id

select sum(salary),d.dept_id,dept_name
from Instructor i inner join Department d
	on d.Dept_Id = i.Dept_Id
group by d.dept_id,dept_name

select count(st_id),st_address
from Student
group by St_Address

select count(st_id),dept_id
from Student
group by dept_id

select count(st_id),st_address,Dept_Id
from Student
group by st_address,Dept_Id

select sum(salary),dept_id
from Instructor
group by Dept_Id

select sum(salary),dept_id
from Instructor
where salary>1000
group by Dept_Id

select sum(salary),dept_id
from Instructor
group by Dept_Id

select sum(salary),dept_id
from Instructor
group by Dept_Id
having sum(salary)>25000

select sum(salary),dept_id
from Instructor
group by Dept_Id
having count(ins_id)>6

--having without group by
select sum(salary),avg(salary)
from Instructor
having count(ins_id)<100
--------------------------------------
--set operators   union   union all   intersect   except

--batch
--set of independent queries

select st_fname
from Student
union all
select ins_name
from Instructor

select st_fname as [ITInames]
from Student
union all
select ins_name
from Instructor

select st_fname,st_id
from Student
union all
select ins_name,ins_id
from Instructor

select convert(varchar(10),st_id)
from Student
union all
select ins_name
from Instructor

select st_fname
from Student
union --distinct   (order+unique)
select ins_name
from Instructor

select st_fname
from Student
intersect
select ins_name
from Instructor

select st_fname
from Student
except
select ins_name
from Instructor
-----------------------------
--Aggregate functions + grouping + having
--set operators
--subquery
select *
from Student
where st_age<(select avg(st_age) from Student)

select *,(select count(st_id) from Student)
from Student

select dept_name
from Department
where Dept_Id in (select distinct dept_id
                  from Student
				  where Dept_Id is not null)

select distinct dept_name
from Student S inner join Department D
	on d.Dept_Id = S.Dept_Id

--subqueries  + DML
delete from Stud_Course
where crs_id=100


delete from Stud_Course
where crs_id =(select crs_id from Course where crs_name='OOP')

--------------------------------------------------------
select st_fname , dept_id , st_age
from Student
where St_Address='cairo'

select st_fname , dept_id , st_age
from Student
order by st_address

select st_fname , dept_id , st_age
from Student
order by 1

select st_fname , dept_id , st_age
from Student
order by Dept_Id asc, st_age desc

select st_fname+' '+st_lname as fullname
from Student
order by fullname

select st_fname+' '+st_lname as fullname
from Student
where fullname='ahmed hassan'

select st_fname+' '+st_lname as fullname
from Student
where st_fname+' '+st_lname='ahmed hassan'

select *
from (select st_fname+' '+st_lname as fullname
	  from Student) as newtable
where fullname='ahmed hassan'

--execute order
--from
--join
--on
--where
--group by
--having
--select
--order
--top

--batch   script   transaction
--batch
--set of independent queries
insert
update
delete


--ddl
--script
--set of batches separated by go
create table
go
drop table
go

--transaction
--set of dependent queries
--run as single unit of work

insert
update
delete

create table parent (Pid int Primary key)

create table child(cid int foreign key references Parent(pid))

insert into Parent values(1)
insert into Parent values(2)
insert into Parent values(3)
insert into Parent values(4)

insert into child values(1)
insert into child values(22)
insert into child values(3)

begin transaction
	insert into child values(1)
	insert into child values(2)
	insert into child values(3)
rollback

begin transaction
	insert into child values(1)
	insert into child values(2)
	insert into child values(66)
commit

begin try
	begin transaction
		insert into child values(1)
		insert into child values(2)
		insert into child values(300)
	commit
end try
begin catch
	rollback
	select ERROR_LINE(),ERROR_MESSAGE(),ERROR_NUMBER()
end catch

select * from child
delete from child

--transaction Properties  ACID
-----------------------------------------
drop table student  --ddl    data & metadata

delete from student  --dml data  --where --slower  --log --rollback
                     --parent child

truncate table student  --data  faster --somestime log --can't rollback
                        --child    --reset identity  --ddl

insert into test2 values('ali')

select * from test2

delete from test2

truncate table test2

-----------------------------------

select db_name()

select suser_name()

select host_name()

select upper(st_fname),lower(st_lname)
from student

select len(st_fname),st_fname
from student

select substring(st_fname,1,3)
from Student

select substring(st_fname,3,3)
from Student

select substring(st_fname,1,len(st_fname)-1)
from Student

select concat('ahmed','ali','khalid','omar')
select concat_ws(' & ','ahmed','ali','khalid','omar')









