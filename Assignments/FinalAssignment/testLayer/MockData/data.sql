drop table if exists student;
create table student (Id INT auto_increment primary key, 
                      Name char(50) not null, 
                      ProgramId INT not null);
insert into student(Name, ProgramId) values ('Jack Cao', 1);
insert into student(Name, ProgramId) values ('Jack Nguyen', 1);
insert into student(Name, ProgramId) values ('John Peterson', 1);
insert into student(Name, ProgramId) values ('James Riddle', 2);
insert into student(Name, ProgramId) values ('Franco Harris', 3);
insert into student(Name, ProgramId) values ('Jenkin Johnson', 1);