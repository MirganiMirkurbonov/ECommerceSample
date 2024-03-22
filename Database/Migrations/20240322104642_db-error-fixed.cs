using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class dberrorfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_file_user_user",
                table: "user_file");

            migrationBuilder.DropIndex(
                name: "IX_user_file_user",
                table: "user_file");

            migrationBuilder.DropColumn(
                name: "user",
                table: "user_file");

            migrationBuilder.AddForeignKey(
                name: "FK_user_file_user_user_id",
                table: "user_file",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_file_user_user_id",
                table: "user_file");

            migrationBuilder.AddColumn<Guid>(
                name: "user",
                table: "user_file",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_user_file_user",
                table: "user_file",
                column: "user");

            migrationBuilder.AddForeignKey(
                name: "FK_user_file_user_user",
                table: "user_file",
                column: "user",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
