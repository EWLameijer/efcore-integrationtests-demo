using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreIntTestSmith.Business.Migrations
{
    /// <inheritdoc />
    public partial class correctedtags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Brands_BrandId",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneTag_Phone_PhoneId",
                table: "PhoneTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneTag_Tag_TagsId",
                table: "PhoneTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phone",
                table: "Phone");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Phone",
                newName: "Phones");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_BrandId",
                table: "Phones",
                newName: "IX_Phones_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneTag_Phones_PhoneId",
                table: "PhoneTag",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneTag_Tags_TagsId",
                table: "PhoneTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Brands_BrandId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneTag_Phones_PhoneId",
                table: "PhoneTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneTag_Tags_TagsId",
                table: "PhoneTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_BrandId",
                table: "Phone",
                newName: "IX_Phone_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phone",
                table: "Phone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Brands_BrandId",
                table: "Phone",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneTag_Phone_PhoneId",
                table: "PhoneTag",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneTag_Tag_TagsId",
                table: "PhoneTag",
                column: "TagsId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
