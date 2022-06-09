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