using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sicom.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] scriptFilesUp = new[]
                {
                    "AddProvincias.sql",
                    "AddLocalidades.sql",
                    "AddEstablecimientos.sql",
                    "AddModulosCPF.sql",
                    "AddPabellonesCPF.sql",
                    "AddPrestadoresServicios.sql",
                    "AddEstadoL_ModalidadL_OrServ_TEqTel.sql",
                    "AddMarcasCelulares.sql",
                    "AddModelosCelulares.sql",
                    "AddAgenteTEST.sql"
                };

            foreach (var fileName in scriptFilesUp)
            {
                var sqlFilePath = Path.Combine("Scripts", fileName);
                var sqlScript = File.ReadAllText(sqlFilePath);
                migrationBuilder.Sql(sqlScript);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string[] scriptFilesDown = new[]
            {
                "AddProvincias_rollback.sql",
                "AddLocalidades_rollback.sql",
                "AddEstablecimientos_rollback.sql",
                "AddModulosCPF_rollback.sql",
                "AddPabellonesCPF_rollback.sql",
                "AddPrestadoresServicios_rollback.sql",
                "AddEstadoL_ModalidadL_OrServ_TEqTel_rollback.sql",
                "AddMarcasCelulares_rollback.sql",
                "AddModelosCelulares_rollback.sql",
                "AddAgenteTEST_rollback.sql"
            };

            foreach (var fileName in scriptFilesDown)
            {
                var sqlFilePath = Path.Combine("Scripts", fileName);
                var sqlScript = File.ReadAllText(sqlFilePath);
                migrationBuilder.Sql(sqlScript);
            }

        }
    }
}
