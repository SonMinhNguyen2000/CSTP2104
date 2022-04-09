drop database if exists 000433430CSTP2104TestingProject;
create database 000433430CSTP2104TestingProject;
use 000433430CSTP2104TestingProject;
create table program(ProgramId INT auto_increment primary key, 
                     Name char(50) not null);
create table course(CourseId char(50) primary key, 
                    Name char(100) not null, 
                    Description char(200),
                    hasPrerequisite bool not null
                    );
create table programCourse(ProgramId Int, 
                           CourseId char(50), 
                           PRIMARY KEY (ProgramId, CourseId), 
                           foreign key (CourseId) references course(CourseId),
                           foreign key (ProgramId) references program(ProgramId));
create table prerequisiteGroup(GroupId INT auto_increment primary key);
create table prerequisiteGroupCourse(GroupId INT not null, 
                                     CourseId char(50) not null,
                                     PRIMARY KEY (GroupId, CourseId),
                                     foreign key (GroupId) references prerequisiteGroup(GroupId),
                                     foreign key (CourseId) references course(courseId));
create table prerequisite(CourseId char(50) not null, 
                          PrerequisiteGroupId INT not null, 
                          PRIMARY KEY (CourseId, PrerequisiteGroupId),
                          foreign key (CourseId) references course(CourseId),
                          foreign key (PrerequisiteGroupId) references prerequisiteGroup(GroupId));
create table semester(Id INT auto_increment primary key , Year INT not null, Term char(20));
create table semesterCourse(SemesterId INT not null, 
                            CourseId char(50) not null,
                            primary key (SemesterId, CourseId),
                            foreign key(SemesterId) references semester(Id),
                            foreign key (CourseId) references course(CourseId));
create table student (Id INT auto_increment primary key, 
                      Name char(50) not null, 
                      ProgramId INT not null,
                      foreign key (ProgramId) references program(ProgramId));
create table studentCourses (StudentId INT not null, 
                             CourseId char(50) not null,
                             SemesterId INT not null,
                             Grade INT default 0,
                             primary key (StudentId, CourseId, SemesterId),
                             foreign key (StudentId) references student(Id),
                             foreign key (CourseId) references  course(CourseId),
                             foreign key (SemesterId) references semester(Id)
                             );
insert into program(Name) values ('Computer system technology');
insert into student(Name, ProgramId) 
values 
       ('Son Minh Nguyen', 1),
       ('Nicole Tan', 1), 
       ('Mikado Hanzo', 1), 
       ('Jack Cao', 1);
insert into course(courseid, name, description, hasPrerequisite) 
values 
       ('cstp1101', 'communication and workplace behaviour','', false),
       ('cstp1103', 'Data and document management fundamental','', false),
       ('cstp1104', 'Computer system administration','', false),
       ('cstp1105', 'Introduction to programming','', false),
       ('cstp1106', 'Website development','', false),
       ('cstp1108', 'Applied mathematics','', false),
       ('cstp1201', 'Introduction to database mangagement system','', true),
       ('cstp1202', 'Introduction to Data Communication and networking','', true),
       ('cstp1203', 'Introduction to Server Admininstration','', true),
       ('cstp1204', 'Software Analysis and Design','', true),
       ('cstp1205', 'Programming in C++','', true),
       ('cstp1206', 'Introduction to INternet programming & web applications','', true),
       ('cstp1207', 'Techinal communication','', true);
insert into prerequisiteGroup(GroupId) values (1),(2),(3),(4),(5),(6),(7),(8),(9),(10);
insert into prerequisiteGroupCourse(groupid, courseid)
 values   
        (1, 'cstp1105'),
        (2, 'cstp1104'),
        (3, 'cstp1105'),
        (3, 'cstp1106'),
        (4, 'cstp1101');
insert into prerequisite(courseid, prerequisitegroupid) 
values 
       ('cstp1201', 1),
       ('cstp1202', 2),
       ('cstp1203', 2),
       ('cstp1204', 1),
       ('cstp1205', 1),
       ('cstp1206', 3),
       ('cstp1207', 4);
insert into programCourse (ProgramId, CourseId) 
values 
       (1, 'cstp1101'),
       (1, 'cstp1103'),
       (1, 'cstp1104'),
       (1, 'cstp1105'),
       (1, 'cstp1106'),
       (1, 'cstp1108'),
       (1, 'cstp1201'),
       (1, 'cstp1202'),
       (1, 'cstp1203'),
       (1, 'cstp1204'),
       (1, 'cstp1205'),
       (1, 'cstp1206'),
       (1, 'cstp1207');
insert into semester(Year, Term) 
values 
       (2020, 'Fall'),
       (2020, 'Spring'),
       (2020, 'Summer');
insert into studentCourses (StudentId, CourseId, SemesterId, Grade)
values 
       (1, 'cstp1101', 1, 100),
       (1, 'cstp1103', 1, 100),
       (1, 'cstp1104', 1, 100),
       (1, 'cstp1105', 1, 40),
       (1, 'cstp1106',1, 80),
       (1, 'cstp1108',1, 90);
       
       
        

                                    

