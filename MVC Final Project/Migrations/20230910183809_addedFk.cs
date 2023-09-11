using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class addedFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_List_ListId",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_List_ListId",
                table: "Task",
                column: "ListId",
                principalTable: "List",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_List_ListId",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_List_ListId",
                table: "Task",
                column: "ListId",
                principalTable: "List",
                principalColumn: "Id");
        }
    }
}
