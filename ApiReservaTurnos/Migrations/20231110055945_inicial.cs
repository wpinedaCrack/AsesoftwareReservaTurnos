using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiReservaTurnos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comercio",
                columns: table => new
                {
                    id_comercio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_comercio = table.Column<string>(type: "varchar(50)", nullable: false),
                    aforo_maximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comercio", x => x.id_comercio);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    id_Servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Comercio = table.Column<int>(type: "int", nullable: false),
                    nom_servicio = table.Column<string>(type: "varchar(60)", nullable: false),
                    hora_apertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    hora_cierre = table.Column<TimeSpan>(type: "time", nullable: false),
                    duracion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.id_Servicio);
                    table.ForeignKey(
                        name: "FK_Servicio_Comercio_id_Comercio",
                        column: x => x.id_Comercio,
                        principalTable: "Comercio",
                        principalColumn: "id_comercio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    id_turno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_servicio = table.Column<int>(type: "int", nullable: false),
                    fecha_turno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora_inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    hora_fin = table.Column<TimeSpan>(type: "time", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.id_turno);
                    table.ForeignKey(
                        name: "FK_Turnos_Servicio_id_servicio",
                        column: x => x.id_servicio,
                        principalTable: "Servicio",
                        principalColumn: "id_Servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_id_Comercio",
                table: "Servicio",
                column: "id_Comercio");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_id_servicio",
                table: "Turnos",
                column: "id_servicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Comercio");
        }
    }
}
