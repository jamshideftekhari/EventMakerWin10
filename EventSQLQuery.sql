CREATE DATABASE EventDb
GO

USE EventDb;
GO

CREATE TABLE Event(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50),
Place VARCHAR(50),
DateAndTime DATETIME,
Description VARCHAR(70)
)

INSERT INTO Event VALUES( 'Pitching 2end semester Projects', 'Auditorium 202', '2017-04-22 10:30:00', 'De studerende fremlægger deres eksamensprojekt');
INSERT INTO Event VALUES( 'Pitching 3end semester Projects', 'Auditorium 203', '2017-04-22 10:30:00', 'De studerende fremlægger deres eksamensprojekt');
INSERT INTO Event VALUES( 'Pitching 4end semester Projects', 'Auditorium 204', '2017-04-22 10:30:00', 'De studerende fremlægger deres eksamensprojekt');
INSERT INTO Event VALUES( 'Pitching 5end semester Projects', 'Auditorium 205', '2017-04-22 10:30:00', 'De studerende fremlægger deres eksamensprojekt');
INSERT INTO Event VALUES( 'Pitching 6end semester Projects', 'Auditorium 206', '2017-04-22 10:30:00', 'De studerende fremlægger deres eksamensprojekt');