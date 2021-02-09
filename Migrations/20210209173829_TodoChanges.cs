using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class TodoChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnterdOn",
                table: "TodoItems",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "Endtime",
                table: "TodoItems",
                newName: "finishedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "finishedOn",
                table: "TodoItems",
                newName: "Endtime");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "TodoItems",
                newName: "EnterdOn");
        }
    }
}
