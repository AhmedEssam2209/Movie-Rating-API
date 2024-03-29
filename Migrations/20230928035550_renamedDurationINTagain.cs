﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRateApp.Migrations
{
    /// <inheritdoc />
    public partial class renamedDurationINTagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ation",
                table: "Movies",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Movies",
                newName: "ation");
        }
    }
}
