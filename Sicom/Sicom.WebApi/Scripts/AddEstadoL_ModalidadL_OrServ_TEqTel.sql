-- Estado Linea
SET IDENTITY_INSERT EstadosLineas ON;
INSERT INTO EstadosLineas (Id, Descripcion) VALUES (1, 'Activa');
INSERT INTO EstadosLineas (Id, Descripcion) VALUES (2, 'Inactiva');
SET IDENTITY_INSERT EstadosLineas OFF;


-- Modalidad Linea
SET IDENTITY_INSERT ModalidadesLineas ON;
INSERT INTO ModalidadesLineas (Id, Descripcion) VALUES (1, 'Entrante');
INSERT INTO ModalidadesLineas (Id, Descripcion) VALUES (2, 'Saliente');
INSERT INTO ModalidadesLineas (Id, Descripcion) VALUES (3, 'Bidireccional');
SET IDENTITY_INSERT ModalidadesLineas OFF;


-- Origen Servicio
SET IDENTITY_INSERT OrigenesServicios ON;
INSERT INTO OrigenesServicios (Id, Descripcion) VALUES (1, 'COBRE');
INSERT INTO OrigenesServicios (Id, Descripcion) VALUES (2, 'GSM');
INSERT INTO OrigenesServicios (Id, Descripcion) VALUES (3, 'IP');
SET IDENTITY_INSERT OrigenesServicios OFF;

-- Tipo Equipo Telefonico
SET IDENTITY_INSERT TiposEquiposTelefonicos ON;
INSERT INTO TiposEquiposTelefonicos (Id, Descripcion) VALUES (1, 'Antivandálico');
INSERT INTO TiposEquiposTelefonicos (Id, Descripcion) VALUES (2, 'Plástico');
SET IDENTITY_INSERT TiposEquiposTelefonicos OFF;

