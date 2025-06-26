SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Contraseña], [Rol], [Ci_Valor]) VALUES (1, N'Ismael', N'De Hoyos', N'ismadehoyoss@gmail.com', N'qasd3141', 0, N'54577150')
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Contraseña], [Rol], [Ci_Valor]) VALUES (2, N'Ismael', N'De Hoyos', N'asheashe', N'qasd3141', 2, N'54577150')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF


INSERT INTO Usuarios (Nombre, Apellido, Email, Contraseña, Rol, Ci_Valor) VALUES
('María', 'González', 'maria.gonzalez@email.com', 'Pass1234!', 0, '12345678'),
('Juan', 'Pérez', 'juan.perez@email.com', 'SecurePwd#9', 1, '87654321'),
('Lucía', 'Rodríguez', 'lucia.rodriguez@email.com', 'MiClave2025', 2, '11223344'),
('Carlos', 'Fernández', 'carlos.fernandez@email.com', 'ClaveF!23', 0, '44332211'),
('Sofía', 'Martínez', 'sofia.martinez@email.com', 'SofiPass$56', 1, '55667788'),
('Diego', 'López', 'diego.lopez@email.com', 'D!eG0123', 2, '88776655'),
('Valentina', 'Gómez', 'valentina.gomez@email.com', 'Val3nt1na*', 0, '33445566'),
('Matías', 'Sánchez', 'matias.sanchez@email.com', 'M4t!@sPwd', 1, '66554433'),
('Camila', 'Torres', 'camila.torres@email.com', 'CamiPwd2025', 2, '77889900'),
('Federico', 'Vega', 'federico.vega@email.com', 'FedVega#1', 0, '00998877');