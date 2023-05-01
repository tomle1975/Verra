declare @employeeId as UNIQUEIDENTIFIER;
declare @counter as int;

set @counter = 1;
set @employeeId = NEWID();
insert into Employee values(@employeeId, concat('FirstName', @counter), concat('LastName', @counter), 'IT Department', NEWID(), concat('Street ', @counter), null, concat('City', @counter), 'GA', concat('ZipCode', @counter), 'USA', '01/01/1990', 'Male');
insert into EmployeePosition values(NEWID(), GETDATE(), 'Software Engineer', 100000, @employeeId);

set @counter = @counter + 1;
set @employeeId = NEWID();
insert into Employee values(@employeeId, concat('FirstName', @counter), concat('LastName', @counter), 'IT Department', NEWID(), concat('Street ', @counter), null, concat('City', @counter), 'GA', concat('ZipCode', @counter), 'USA', '01/01/1990', 'Male');
insert into EmployeePosition values(NEWID(), GETDATE(), 'Software Engineer', 100000, @employeeId);

set @counter = @counter + 1;
set @employeeId = NEWID();
insert into Employee values(@employeeId, concat('FirstName', @counter), concat('LastName', @counter), 'IT Department', NEWID(), concat('Street ', @counter), null, concat('City', @counter), 'GA', concat('ZipCode', @counter), 'USA', '01/01/1990', 'Male');
insert into EmployeePosition values(NEWID(), GETDATE(), 'Software Engineer', 100000, @employeeId);

set @counter = @counter + 1;
set @employeeId = NEWID();
insert into Employee values(@employeeId, concat('FirstName', @counter), concat('LastName', @counter), 'IT Department', NEWID(), concat('Street ', @counter), null, concat('City', @counter), 'GA', concat('ZipCode', @counter), 'USA', '01/01/1990', 'Male');
insert into EmployeePosition values(NEWID(), GETDATE(), 'Software Engineer', 100000, @employeeId);

set @counter = @counter + 1;
set @employeeId = NEWID();
insert into Employee values(@employeeId, concat('FirstName', @counter), concat('LastName', @counter), 'IT Department', NEWID(), concat('Street ', @counter), null, concat('City', @counter), 'GA', concat('ZipCode', @counter), 'USA', '01/01/1990', 'Male');
insert into EmployeePosition values(NEWID(), GETDATE(), 'Software Engineer', 100000, @employeeId);

set @counter = @counter + 1;
set @employeeId = NEWID();
insert into Employee values(@employeeId, 'FirstName' + @counter, 'LastName'  + @counter, 'IT Department', NEWID(), 'Street ' +  + @counter, null, 'City'  + @counter, 'GA', 'ZipCode'  + @counter, 'USA', '01/01/1990', 'Male');
insert into EmployeePosition values(NEWID(), GETDATE(), 'Software Engineer', 100000, @employeeId);