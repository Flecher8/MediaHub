using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaHub.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRecommendationCollectionUserAccessTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionUserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationCollectionUserAccesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecommendationCollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollectionUserRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationCollectionUserAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_CollectionUserRoles_CollectionUserRoleId",
                        column: x => x.CollectionUserRoleId,
                        principalTable: "CollectionUserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendationCollectionUserAccesses_RecommendationCollections_RecommendationCollectionId",
                        column: x => x.RecommendationCollectionId,
                        principalTable: "RecommendationCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionUserRoles_Name",
                table: "CollectionUserRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollectionUserAccesses_CollectionUserRoleId",
                table: "RecommendationCollectionUserAccesses",
                column: "CollectionUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollectionUserAccesses_RecommendationCollectionId",
                table: "RecommendationCollectionUserAccesses",
                column: "RecommendationCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationCollectionUserAccesses_UserId",
                table: "RecommendationCollectionUserAccesses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecommendationCollectionUserAccesses");

            migrationBuilder.DropTable(
                name: "CollectionUserRoles");
        }
    }
}
