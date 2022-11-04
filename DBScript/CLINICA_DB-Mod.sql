USE MASTER
GO

CREATE DATABASE CLINICA_DB
GO

USE CLINICA_DB
GO

CREATE TABLE Personas (
ID SMALLINT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
DNI VARCHAR(8) NOT NULL,
Mail VARCHAR(120) NOT NULL,
FechaNacimiento DATE NOT NULL CHECK (FechaNacimiento <= GETDATE())
)
GO

CREATE TABLE Administradores (
IDAdmin SMALLINT PRIMARY KEY IDENTITY (1,1),
IDPersona SMALLINT FOREIGN KEY REFERENCES Personas (ID) NOT NULL
)
GO

CREATE TABLE Pacientes (
IDPaciente SMALLINT PRIMARY KEY IDENTITY (1,1),
IDPersona SMALLINT FOREIGN KEY REFERENCES Personas (ID) NOT NULL
)
GO

CREATE TABLE Especialidades (
IDEspecialidad SMALLINT PRIMARY KEY IDENTITY (1,1),
Nombre VARCHAR(50) NOT NULL
)

GO

CREATE TABLE Profesionales (
IDProfesional SMALLINT PRIMARY KEY IDENTITY(1,1),
IDPersona SMALLINT FOREIGN KEY REFERENCES Personas (ID) NOT NULL,
IDEspecialidad SMALLINT FOREIGN KEY REFERENCES Especialidades (IDEspecialidad) NOT NULL
)
GO

CREATE TABLE Procedimientos (
IDProcedimiento SMALLINT PRIMARY KEY IDENTITY (1,1),
Descripcion VARCHAR(200) NOT NULL
)
GO

CREATE TABLE Procedimientos_X_Profesional (
IDProcedimiento SMALLINT  NOT NULL,
IDProfesional SMALLINT  NOT NULL,
PRIMARY KEY (IDProcedimiento, IDProfesional),
FOREIGN KEY (IDProcedimiento) REFERENCES Procedimientos(IDProcedimiento),
FOREIGN KEY (IDProfesional) REFERENCES Profesionales(IDProfesional),
)
GO

CREATE TABLE Horarios (
IDHorario INT PRIMARY KEY IDENTITY (1,1),
FechaInicio DATE NOT NULL,
FechaFin DATE NOT NULL,
HoraInicio VARCHAR(6) NOT NULL, -- cambiar a date
HoraFin VARCHAR(6) NOT NULL, -- cambiar a date
DiaDeLaSemana TINYINT NOT NULL, -- TINYINT O VARCHAR??
Intervalo SMALLINT NOT NULL
)
GO

CREATE TABLE Turnos (
IDTurno INT PRIMARY KEY IDENTITY (1,1),
IDPaciente SMALLINT FOREIGN KEY REFERENCES Pacientes (IDPaciente) NOT NULL,
IDProfesional SMALLINT FOREIGN KEY REFERENCES Profesionales (IDProfesional) NOT NULL,
IDHorario INT FOREIGN KEY REFERENCES Horarios (IDHorario) NOT NULL,
IDProcedimiento SMALLINT FOREIGN KEY REFERENCES Procedimientos (IDProcedimiento) NOT NULL,
IDEspecialidad SMALLINT FOREIGN KEY REFERENCES Especialidades (IDEspecialidad) NOT NULL,
Hora TIME NOT NULL
)

-- Post Creacion de la DB
-- MODIFICACIONES:
-- OBS: Tenia un error al crear la clave
ALTER TABLE Profesionales
ADD CONSTRAINT FK_IDEspecialidad FOREIGN KEY (IDEspecialidad) REFERENCES Especialidades (IDEspecialidad) 




-- INSERTS:
USE CLINICA_DB
GO
--Especialidades
INSERT INTO Especialidades VALUES ('Clinico')
INSERT INTO Especialidades VALUES ('Dermatologia')
INSERT INTO Especialidades VALUES ('Traumatologia')
--Pacientes
INSERT INTO Personas VALUES ('Pepe','Navajas','12345678','elmail@mail.com','01/01/1990')
INSERT INTO Personas VALUES ('Juan','Cruz','12345677','elmail@mail.com','07/10/1970')
INSERT INTO Personas VALUES ('Alicia','Cruz','12345676','elmail@mail.com','15/08/1960')
INSERT INTO Personas VALUES ('Roberto','Alvarez','12345675','elmail@mail.com','07/05/2000')
INSERT INTO Personas VALUES ('Rocio','Alvarez','12345674','elmail@mail.com','03/07/2010')
INSERT INTO Pacientes VALUES (1)
INSERT INTO Pacientes VALUES (3)
INSERT INTO Pacientes VALUES (4)
INSERT INTO Pacientes VALUES (5)
INSERT INTO Pacientes VALUES (6)
--Profecionales
INSERT INTO Personas VALUES ('Mariana','Lopez','12345673','elmail@mail.com','02/07/2010')
INSERT INTO Personas VALUES ('Facundo','Amarilla','12345672','elmail@mail.com','01/07/2010')
INSERT INTO Personas VALUES ('Luciano','Apugliese','12345671','elmail@mail.com','30/09/2009')
INSERT INTO Personas VALUES ('Regina','Laurentino','12345670','elmail@mail.com','29/08/2008')
INSERT INTO Personas VALUES ('Maxi','Sar Fernandez','12345669','elmail@mail.com','28/12/2007')
INSERT INTO Profesionales VALUES (7, 1)
INSERT INTO Profesionales VALUES (8, 1)
INSERT INTO Profesionales VALUES (9, 2)
INSERT INTO Profesionales VALUES (10, 2)
INSERT INTO Profesionales VALUES (11, 3)
--Horarios
/*
CREATE TABLE Horarios (
IDHorario INT PRIMARY KEY IDENTITY (1,1),
FechaInicio DATE NOT NULL,
FechaFin DATE NOT NULL,
HoraInicio VARCHAR(6) NOT NULL,
HoraFin VARCHAR(6) NOT NULL,
DiaDeLaSemana TINYINT NOT NULL,
Intervalo SMALLINT NOT NULL
)
*/
INSERT INTO Horarios VALUES (GETDATE(), GETDATE(), '09:00', '09:30', 1, 1)
INSERT INTO Horarios VALUES (GETDATE(), GETDATE(), '09:30', '10:00', 1, 2)
INSERT INTO Horarios VALUES (GETDATE(), GETDATE(), '10:30', '11:00', 2, 3)
INSERT INTO Horarios VALUES (GETDATE(), GETDATE(), '11:30', '12:00', 2, 4)
INSERT INTO Horarios VALUES (GETDATE(), GETDATE(), '12:30', '13:00', 3, 5)
INSERT INTO Horarios VALUES (GETDATE(), GETDATE(), '13:30', '14:00', 3, 6)

-- SELECTS:
SELECT ID, Personas.Nombre, Personas.Apellido FROM Personas INNER JOIN Pacientes on Pacientes.IDPaciente = Personas.ID WHERE IDPersona = ID
SELECT * FROM Personas 
SELECT * FROM Pacientes
SELECT * FROM Profesionales
SELECT * FROM Especialidades
SELECT * FROM Horarios


SELECT per.ID, per.Nombre, per.Apellido, per.DNI, per.Mail, per.FechaNacimiento
FROM Personas per INNER JOIN Pacientes on Pacientes.IDPersona = per.ID

SELECT prof.IDProfesional as 'ID', per.Nombre, per.Apellido, per.DNI, esp.Nombre as 'Especialidad'
	FROM Personas per INNER JOIN Profesionales prof on prof.IDPersona = per.ID 
	INNER JOIN Especialidades esp on prof.IDEspecialidad = esp.IDEspecialidad

SELECT IDHorario, FechaInicio as 'Dia', HoraInicio, HoraFin, DiaDeLaSemana, Intervalo FROM Horarios
