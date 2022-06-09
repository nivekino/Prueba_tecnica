CREATE PROCEDURE [spNUEVO_MAESTRO] @nombre varchar(40), @apellido varchar(40)
AS
BEGIN
		
		INSERT INTO MAESTRO(nombre, apellido)
		VALUES (@nombre, @apellido);

END


EXEC spNUEVO_MAESTRO @nombre = 'Jorge', @apellido = 'Ortiz';
EXEC spNUEVO_MAESTRO @nombre = 'Reina', @apellido = 'Lopez';
EXEC spNUEVO_MAESTRO @nombre = 'Rene', @apellido = 'Mejia';
EXEC spNUEVO_MAESTRO @nombre = 'Diego', @apellido = 'Maradona';


SELECT * FROM MAESTRO;