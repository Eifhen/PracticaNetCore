using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticaMigracion.Migrations
{
    public partial class correccion_estado_jugador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TablaDeEstado_Jugadores_JugadoresId",
                table: "TablaDeEstado");

            migrationBuilder.DropIndex(
                name: "IX_TablaDeEstado_JugadoresId",
                table: "TablaDeEstado");

            migrationBuilder.DropColumn(
                name: "JugadoresId",
                table: "TablaDeEstado");

            migrationBuilder.AddColumn<int>(
                name: "id_EstadoID",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_id_EstadoID",
                table: "Jugadores",
                column: "id_EstadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_TablaDeEstado_id_EstadoID",
                table: "Jugadores",
                column: "id_EstadoID",
                principalTable: "TablaDeEstado",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_TablaDeEstado_id_EstadoID",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_id_EstadoID",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "id_EstadoID",
                table: "Jugadores");

            migrationBuilder.AddColumn<int>(
                name: "JugadoresId",
                table: "TablaDeEstado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablaDeEstado_JugadoresId",
                table: "TablaDeEstado",
                column: "JugadoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_TablaDeEstado_Jugadores_JugadoresId",
                table: "TablaDeEstado",
                column: "JugadoresId",
                principalTable: "Jugadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
