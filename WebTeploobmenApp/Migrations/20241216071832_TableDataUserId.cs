﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTeploobmenApp.Migrations
{
    /// <inheritdoc />
    public partial class TableDataUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DataInput",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DataInput");
        }
    }
}
