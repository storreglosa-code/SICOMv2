using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sicom.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablecimientoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Establecimientos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TadId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LocalidadId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establecimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosLineas",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosLineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcasCelulares",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasCelulares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadesLineas",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadesLineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrigenesServicios",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigenesServicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrestadoresServicios",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadoresServicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEquiposTelefonicos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEquiposTelefonicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablecimientoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modulos_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelosCelulares",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaCelularId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosCelulares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelosCelulares_MarcasCelulares_MarcaCelularId",
                        column: x => x.MarcaCelularId,
                        principalTable: "MarcasCelulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pabellones",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuloId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EstablecimientoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PoblacionPenal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pabellones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pabellones_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineasCelulares",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Sim = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    EstadoLineaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EstablecimientoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PrestadorServicioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Imei = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MarcaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ModeloId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AgenteId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UbicacionFinal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanContratado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    MotivoBaja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasCelulares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineasCelulares_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasCelulares_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasCelulares_EstadosLineas_EstadoLineaId",
                        column: x => x.EstadoLineaId,
                        principalTable: "EstadosLineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasCelulares_MarcasCelulares_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarcasCelulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasCelulares_ModelosCelulares_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "ModelosCelulares",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineasCelulares_PrestadoresServicios_PrestadorServicioId",
                        column: x => x.PrestadorServicioId,
                        principalTable: "PrestadoresServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineasAdministrativas",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroLinea = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NroInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoLineaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EstablecimientoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ModuloId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PabellonId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ModalidadId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UbicacionFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrestadorServicioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OrigenServicioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    MotivoBaja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasAdministrativas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_EstadosLineas_EstadoLineaId",
                        column: x => x.EstadoLineaId,
                        principalTable: "EstadosLineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_ModalidadesLineas_ModalidadId",
                        column: x => x.ModalidadId,
                        principalTable: "ModalidadesLineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_OrigenesServicios_OrigenServicioId",
                        column: x => x.OrigenServicioId,
                        principalTable: "OrigenesServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_Pabellones_PabellonId",
                        column: x => x.PabellonId,
                        principalTable: "Pabellones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineasAdministrativas_PrestadoresServicios_PrestadorServicioId",
                        column: x => x.PrestadorServicioId,
                        principalTable: "PrestadoresServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineasPublicas",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroLinea = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EstadoLineaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EstablecimientoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ModuloId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PabellonId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ModalidadId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PrestadorServicioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OrigenServicioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TipoEquipoTelefonicoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UbicacionFinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    MotivoBaja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasPublicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineasPublicas_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPublicas_EstadosLineas_EstadoLineaId",
                        column: x => x.EstadoLineaId,
                        principalTable: "EstadosLineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPublicas_ModalidadesLineas_ModalidadId",
                        column: x => x.ModalidadId,
                        principalTable: "ModalidadesLineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPublicas_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineasPublicas_OrigenesServicios_OrigenServicioId",
                        column: x => x.OrigenServicioId,
                        principalTable: "OrigenesServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPublicas_Pabellones_PabellonId",
                        column: x => x.PabellonId,
                        principalTable: "Pabellones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineasPublicas_PrestadoresServicios_PrestadorServicioId",
                        column: x => x.PrestadorServicioId,
                        principalTable: "PrestadoresServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineasPublicas_TiposEquiposTelefonicos_TipoEquipoTelefonicoId",
                        column: x => x.TipoEquipoTelefonicoId,
                        principalTable: "TiposEquiposTelefonicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgenteId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LineaPublicaId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    LineaAdministrativaId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    LineaCelularId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observaciones_Agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observaciones_LineasAdministrativas_LineaAdministrativaId",
                        column: x => x.LineaAdministrativaId,
                        principalTable: "LineasAdministrativas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observaciones_LineasCelulares_LineaCelularId",
                        column: x => x.LineaCelularId,
                        principalTable: "LineasCelulares",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observaciones_LineasPublicas_LineaPublicaId",
                        column: x => x.LineaPublicaId,
                        principalTable: "LineasPublicas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_EstablecimientoId",
                table: "LineasAdministrativas",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_EstadoLineaId",
                table: "LineasAdministrativas",
                column: "EstadoLineaId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_ModalidadId",
                table: "LineasAdministrativas",
                column: "ModalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_ModuloId",
                table: "LineasAdministrativas",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_OrigenServicioId",
                table: "LineasAdministrativas",
                column: "OrigenServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_PabellonId",
                table: "LineasAdministrativas",
                column: "PabellonId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasAdministrativas_PrestadorServicioId",
                table: "LineasAdministrativas",
                column: "PrestadorServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasCelulares_AgenteId",
                table: "LineasCelulares",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasCelulares_EstablecimientoId",
                table: "LineasCelulares",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasCelulares_EstadoLineaId",
                table: "LineasCelulares",
                column: "EstadoLineaId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasCelulares_MarcaId",
                table: "LineasCelulares",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasCelulares_ModeloId",
                table: "LineasCelulares",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasCelulares_PrestadorServicioId",
                table: "LineasCelulares",
                column: "PrestadorServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_EstablecimientoId",
                table: "LineasPublicas",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_EstadoLineaId",
                table: "LineasPublicas",
                column: "EstadoLineaId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_ModalidadId",
                table: "LineasPublicas",
                column: "ModalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_ModuloId",
                table: "LineasPublicas",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_OrigenServicioId",
                table: "LineasPublicas",
                column: "OrigenServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_PabellonId",
                table: "LineasPublicas",
                column: "PabellonId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_PrestadorServicioId",
                table: "LineasPublicas",
                column: "PrestadorServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_LineasPublicas_TipoEquipoTelefonicoId",
                table: "LineasPublicas",
                column: "TipoEquipoTelefonicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosCelulares_MarcaCelularId",
                table: "ModelosCelulares",
                column: "MarcaCelularId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_EstablecimientoId",
                table: "Modulos",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_AgenteId",
                table: "Observaciones",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_LineaAdministrativaId",
                table: "Observaciones",
                column: "LineaAdministrativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_LineaCelularId",
                table: "Observaciones",
                column: "LineaCelularId");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_LineaPublicaId",
                table: "Observaciones",
                column: "LineaPublicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pabellones_ModuloId",
                table: "Pabellones",
                column: "ModuloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Observaciones");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "LineasAdministrativas");

            migrationBuilder.DropTable(
                name: "LineasCelulares");

            migrationBuilder.DropTable(
                name: "LineasPublicas");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropTable(
                name: "ModelosCelulares");

            migrationBuilder.DropTable(
                name: "EstadosLineas");

            migrationBuilder.DropTable(
                name: "ModalidadesLineas");

            migrationBuilder.DropTable(
                name: "OrigenesServicios");

            migrationBuilder.DropTable(
                name: "Pabellones");

            migrationBuilder.DropTable(
                name: "PrestadoresServicios");

            migrationBuilder.DropTable(
                name: "TiposEquiposTelefonicos");

            migrationBuilder.DropTable(
                name: "MarcasCelulares");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Establecimientos");
        }
    }
}
