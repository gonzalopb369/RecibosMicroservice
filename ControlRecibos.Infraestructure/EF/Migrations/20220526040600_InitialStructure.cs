using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlRecibos.Infraestructure.EF.Migrations {
	public partial class InitialStructure : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.CreateTable(
				name: "Recibo",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier",nullable: false),
					nroRecibo = table.Column<int>(type: "int",nullable: false),
					fechaPago = table.Column<DateTime>(type: "DateTime",nullable: false),
					nombrePasajero = table.Column<string>(type: "nvarchar(500)",maxLength: 500,nullable: true),
					codigoReserva = table.Column<string>(type: "nvarchar(100)",maxLength: 100,nullable: true),
					concepto = table.Column<string>(type: "nvarchar(100)",maxLength: 100,nullable: true),
					montoPagado = table.Column<decimal>(type: "decimal(12,2)",precision: 12,scale: 2,nullable: false),
					MontoLiteral = table.Column<string>(type: "nvarchar(max)",nullable: true),
					aCuenta = table.Column<decimal>(type: "decimal(12,2)",precision: 12,scale: 2,nullable: false),
					saldo = table.Column<decimal>(type: "decimal(12,2)",precision: 12,scale: 2,nullable: false),
					estado = table.Column<int>(type: "int",nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Recibo",x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Recibo");
		}
	}
}
