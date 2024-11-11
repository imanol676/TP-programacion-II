using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVehiculos.Migrations
{
    /// <inheritdoc />
    public partial class migracionNueva1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_ApplicationUser_UsuarioId",
                table: "Reserves");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Vehicles_VehiculoId",
                table: "Reserves");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Vehicles_VehiculoId1",
                table: "Reserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_UsuarioId",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_VehiculoId1",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "VehiculoId1",
                table: "Reserves");

            migrationBuilder.RenameTable(
                name: "Reserves",
                newName: "Reservas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservas",
                newName: "ReservaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_VehiculoId",
                table: "Reservas",
                newName: "IX_Reservas_VehiculoId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UserId",
                table: "Reservas",
                column: "UserId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Reserva_Fecha",
                table: "Reservas",
                sql: "FechaInicio >= GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_ApplicationUser_UserId",
                table: "Reservas",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vehicles_VehiculoId",
                table: "Reservas",
                column: "VehiculoId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_ApplicationUser_UserId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vehicles_VehiculoId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_UserId",
                table: "Reservas");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Reserva_Fecha",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservas");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reserves");

            migrationBuilder.RenameColumn(
                name: "ReservaId",
                table: "Reserves",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_VehiculoId",
                table: "Reserves",
                newName: "IX_Reserves_VehiculoId");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Reserves",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId1",
                table: "Reserves",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_UsuarioId",
                table: "Reserves",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_VehiculoId1",
                table: "Reserves",
                column: "VehiculoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_ApplicationUser_UsuarioId",
                table: "Reserves",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Vehicles_VehiculoId",
                table: "Reserves",
                column: "VehiculoId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Vehicles_VehiculoId1",
                table: "Reserves",
                column: "VehiculoId1",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
