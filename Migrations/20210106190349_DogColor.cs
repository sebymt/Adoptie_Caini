using Microsoft.EntityFrameworkCore.Migrations;

namespace Adoptie_Caini.Migrations
{
    public partial class DogColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreedID",
                table: "Dog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DogColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogColor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DogColor_Color_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogColor_Dog_DogID",
                        column: x => x.DogID,
                        principalTable: "Dog",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_BreedID",
                table: "Dog",
                column: "BreedID");

            migrationBuilder.CreateIndex(
                name: "IX_DogColor_ColorID",
                table: "DogColor",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_DogColor_DogID",
                table: "DogColor",
                column: "DogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Breed_BreedID",
                table: "Dog",
                column: "BreedID",
                principalTable: "Breed",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Breed_BreedID",
                table: "Dog");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "DogColor");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Dog_BreedID",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "BreedID",
                table: "Dog");
        }
    }
}
