CREATE VIEW alumnos_notas_view AS
SELECT a.id, a.nombre, m.id_materia, m.calificacion_1, calificacion_2, calificacion_3
FROM MATERIASxALUMNOS m, ALUMNOS a
WHERE m.id_alumno = a.id;

select * from alumnos_notas_view;