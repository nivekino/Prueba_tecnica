CREATE PROCEDURE [spNUEVO_MAESTRO] @nombre varchar(40), @apellido varchar(40)
AS
BEGIN
		
		INSERT INTO MAESTRO(nombre, apellido)
		VALUES (@nombre, @apellido);

END


EXEC spNUEVO_MAESTRO @nombre = 'Kevin', @apellido = 'Mejia';
EXEC spNUEVO_MAESTRO @nombre = 'Edenilson', @apellido = 'Batres';
EXEC spNUEVO_MAESTRO @nombre = 'Fernando', @apellido = 'Marinero';
EXEC spNUEVO_MAESTRO @nombre = 'Paul', @apellido = 'Perez';
EXEC spNUEVO_MAESTRO @nombre = 'Diego', @apellido = 'Maradonna';


SELECT * FROM MAESTRO;