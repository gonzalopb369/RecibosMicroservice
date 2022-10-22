using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlRecibos.Infraestructure.EF.Migrations
{
    public partial class ModCodRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "codigoReserva",
                table: "Recibo",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "codigoReserva",
                table: "Recibo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);
        }
    }
}
