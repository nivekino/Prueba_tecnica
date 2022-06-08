CREATE PROCEDURE [dbo].[spCATALOGO_NOTAS] AS
BEGIN
	SELECT a.id 'Clave alumno',
		   a.nombre 'Nombre alumno', 
		   m.id_materia 'Clave materia',
		   ma.nombre_materia 'Nombre materia', 
		   m.calificacion_1 'Calificac�on 1', 
		   calificacion_2 'Calificac�on 2', 
		   calificacion_3 'Calificac�on 3'
FROM MATERIASxALUMNOS m, ALUMNOS a, MATERIAS ma
WHERE m.id_alumno = a.id
	  and m.id_materia = ma.id;
EN