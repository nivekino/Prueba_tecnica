Create database Colegio_prueba_tecnica;

use Colegio_prueba_tecnica;

CREATE TABLE ALUMNOS (
	id int primary key IDENTITY(1,1),
	nombre VARCHAR(40),
	apellido VARCHAR(40),
);

CREATE TABLE MATERIAS (
	id INT PRIMARY key IDENTITY(1,1),
	nombre_materia VARCHAR(40),
	id_profesor int
);

CREATE TABLE MAESTRO (
	id int primary key IDENTITY(1,1),
	nombre VARCHAR(40),
	apellido VARCHAR(40),
);

CREATE TABLE MATERIASxALUMNOS (
	id int primary key IDENTITY(1,1),
	id_materia int,
	id_alumno int,
	calificacion_1 float,
	calificacion_2 float,
	calificacion_3 float
);

alter table MATERIAxALUMNOS add constraint FK_materiaxalumnos_alumnos
	foreign key(id_alumno) references ALUMNOS(id);

alter table MATERIAxALUMNOS add constraint FK_materiaxalumnos_materias
	foreign key(id_materia) references MATERIAS(id);

alter table MATERIAS add constraint FK_materias_maestro
	foreign key(id_profesor) references MAESTRO(id);

insert into MATERIAS (nombre_materia, id_profesor) values('ciencia','1')
insert into MATERIAS (nombre_materia, id_profesor) values('matematica','2')
insert into MATERIAS (nombre_materia, id_profesor) values('lenguaje','3')
insert into MATERIAS (nombre_materia, id_profesor) values('sociales','4')

insert into MATERIASxALUMNOS (id_materia, id_alumno, calificacion_1, calificacion_2, calificacion_3) values('1','1','5','8.8','9.7')
insert into MATERIASxALUMNOS (id_materia, id_alumno, calificacion_1, calificacion_2, calificacion_3) values('2','1','4','8.8','7.7')
insert into MATERIASxALUMNOS (id_materia, id_alumno, calificacion_1, calificacion_2, calificacion_3) values('3','1','8.8','4.8','6.7')
insert into MATERIASxALUMNOS (id_materia, id_alumno, calificacion_1, calificacion_2, calificacion_3) values('4','1','7','3.8','9.7')


select * from MATERIAS;

select * from MATERIASxALUMNOS;