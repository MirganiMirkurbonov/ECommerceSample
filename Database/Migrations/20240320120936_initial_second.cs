using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class initial_second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_email",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_phone_number",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                filter: "email IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_number",
                table: "user",
                column: "phone_number",
                filter: "phone_number IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_email",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_phone_number",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_user_phone_number",
                table: "user",
                column: "phone_number",
                filter: "[email] IS NOT NULL");
        }
    }
}
