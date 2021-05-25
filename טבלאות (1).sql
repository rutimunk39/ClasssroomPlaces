use class
create table students
(id int primary key,
family_name nvarchar(20) not null,
first_name nvarchar(15) not null,
class int not null,
chat int check(chat>0 and chat<6),
rec_row int,
col int,
line int,
constraint stu_class_fk foreign key(class) references class(id)
)
create table class
(
id int primary key,
class_name nvarchar(10)
)
create table seat_type
(
id int primary key,
name_type nvarchar(10)
)
create table student_type
(
id int primary key,
student_id int,
type_kod int,
ok bit
constraint stuType_stu_fk foreign key(student_id) references students(id),
constraint stuType_type_fk foreign key(type_kod) references seat_type(id)
)