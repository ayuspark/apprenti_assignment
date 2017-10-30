using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace asp_identity_core_ef.Migrations
{
    public partial class second_resto_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restos",
                columns: table => new
                {
                    RestoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restos", x => x.RestoId);
                });

            migrationBuilder.CreateTable(
                name: "RestoReviews",
                columns: table => new
                {
                    RestoReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApplicationUserEmail = table.Column<string>(type: "longtext", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "varchar(127)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RestoId = table.Column<int>(type: "int", nullable: false),
                    ReviewContent = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestoReviews", x => x.RestoReviewId);
                    table.ForeignKey(
                        name: "FK_RestoReviews_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestoReviews_Restos_RestoId",
                        column: x => x.RestoId,
                        principalTable: "Restos",
                        principalColumn: "RestoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestoReviews_ApplicationUserId",
                table: "RestoReviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestoReviews_RestoId",
                table: "RestoReviews",
                column: "RestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestoReviews");

            migrationBuilder.DropTable(
                name: "Restos");
        }
    }
}
