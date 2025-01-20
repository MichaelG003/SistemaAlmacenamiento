using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAlmacenamiento.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFecModyEstadoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Clientes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Clientes",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Clientes");
        }
    }
}
