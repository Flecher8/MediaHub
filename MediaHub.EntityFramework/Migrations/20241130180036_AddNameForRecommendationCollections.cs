﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaHub.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddNameForRecommendationCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RecommendationCollections",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RecommendationCollections");
        }
    }
}
