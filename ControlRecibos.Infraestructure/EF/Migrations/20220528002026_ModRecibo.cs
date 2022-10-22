using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlRecibos.Infraestructure.EF.Migrations {
	public partial class ModRecibo : Migration {
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.RenameColumn(
				name: "montoPagado",
				table: "Recibo",
				newName: "montoTotal");
		}

		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.RenameColumn(
				name: "montoTotal",
				table: "Recibo",
				newName: "montoPagado");
		}
	}
}
