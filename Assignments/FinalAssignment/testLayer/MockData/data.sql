drop database if exists 000433430CSTP2104TestingProject;
create database 000433430CSTP2104TestingProject;
use 000433430CSTP2104TestingProject;
create table program(ProgramId INT auto_increment primary key, 
                     Name char(50) not null);
create table course(CourseId INT auto_increment primary key, 
                    Name char(50) not null, 
                    Description char(200) not null,
                    PrerequisiteId INT);
create table programCourse(ProgramId Int, 
                           CourseId INT, 
                           PRIMARY KEY (ProgramId, CourseId), 
                           foreign key (CourseId) references course(CourseId),
                           foreign key (ProgramId) references program(ProgramId));
create table PrerequisiteGroup(GroupId INT auto_increment primary key);
create table PrerequisiteGroupCourse(GroupId INT not null, 
                                     CourseId int not null,
                                     PRIMARY KEY (GroupId, CourseId),
                                     foreign key (GroupId) references PrerequisiteGroup(GroupId),
                                     foreign key (CourseId) references course(courseId));
create table Prerequisite(CourseId INT not null, 
                          PrerequisiteGroupId INT not null, 
                          PRIMARY KEY(CourseId, PrerequisiteGroupId),
                          foreign key (CourseId) references course(CourseId),
                          foreign key (PrerequisiteGroupId) references PrerequisiteGroup(GroupId));
create table semester(Id INT auto_increment primary key , Year INT not null, Term char(20));
create table semesterCourse(SemesterId INT not null, 
                            CourseId INT not null,
                            primary key (SemesterId, CourseId),
                            foreign key(SemesterId) references semester(Id),
                            foreign key (CourseId) references course(CourseId));
create table student (Id INT auto_increment primary key, 
                      Name char(50) not null, 
                      ProgramId INT not null,
                      foreign key (ProgramId) references program(ProgramId));
create table StudentCourses (StudentId INT not null, 
                             CourseId INT not null,
                             SemesterId INT not null,
                             Grader INT,
                             primary key (StudentId, CourseId, SemesterId),
                             foreign key (StudentId) references student(Id),
                             foreign key (CourseId) references  course(CourseId),
                             foreign key (SemesterId) references semester(Id)
                             );
insert into program(Name) values ('Computer system technology');
insert into student(Name, ProgramId) values ('Son Minh Nguyen', 1),('Nicole Tan', 1);

