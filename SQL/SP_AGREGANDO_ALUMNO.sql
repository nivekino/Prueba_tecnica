CREATE PROCEDURE [spNUEVO_ALUMNO] @nombre varchar(40), @apellido varchar(40)
AS
BEGIN
		
		INSERT INTO ALUMNOS(nombre, apellido)
		VALUES (@nombre, @apellido);

END

EXEC spNUEVO_ALUMNO @nombre = 'Kevin', @apellido = 'Mejia';
EXEC spNUEVO_ALUMNO @nombre = 'Fernando', @apellido = 'Marinero';
EXEC spNUEVO_ALUMNO @nombre = 'Paul', @apellido = 'Perez';

select * from ALUMNOS;