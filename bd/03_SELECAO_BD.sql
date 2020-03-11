-- DQL

USE Senatur_TARDE;

SELECT Usuarios.Email, Usuarios.Senha, TiposUsuario.Titulo FROM Usuarios
INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario;

SELECT * FROM Pacotes;


