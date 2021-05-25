use place

alter TABLE Students
(
    ID_s  int identity PRIMARY KEY ,
    Last_Name varchar(50) NOT NULL,
    First_Name varchar(50) NOT NULL,
    grade int,
    talk_level int,
	row_prefer int,
	line int,
	choose_row int
)


--alter TABLE Class(
--ID_c identity int primary key,
--class_name varchar(20)
--)
--alter table PropertiePlaces(
--ID_p identity int primary key,
--propertie_Name varchar(50),
--)
--alter table Constraints(
--studentID int foreign key ,
--propertieID int foreign key,
--yesNo varchar(10),
--)