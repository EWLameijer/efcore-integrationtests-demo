using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreIntTestSmith.Business.Migrations
{
    /// <inheritdoc />
    public partial class bettermanytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Phones_PhoneId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_PhoneId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "PhoneTag",
                columns: table => new
                {
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTag", x => new { x.PhoneId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PhoneTag_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneTag_TagsId",
                table: "PhoneTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneTag");

            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_PhoneId",
                table: "Tag",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Phones_PhoneId",
                table: "Tag",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id");
        }
    }
}
