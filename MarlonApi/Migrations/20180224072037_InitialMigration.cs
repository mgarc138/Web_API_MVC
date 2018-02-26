using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MarlonApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(type: "text", nullable: true),
                    BSEducationSchool = table.Column<string>(type: "text", nullable: true),
                    BSEducationTitle = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ExtraCurricularActivitiesOne = table.Column<string>(type: "text", nullable: true),
                    ExtraCurricularActivitiesTwo = table.Column<string>(type: "text", nullable: true),
                    MSEducationSchool = table.Column<string>(type: "text", nullable: true),
                    MSEducationTitle = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PHdEducationSchool = table.Column<string>(type: "text", nullable: true),
                    PHdEducationTitle = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    WorkExperienceCompanyNameOne = table.Column<string>(type: "text", nullable: true),
                    WorkExperienceCompanyNameThree = table.Column<string>(type: "text", nullable: true),
                    WorkExperienceCompanyNameTwo = table.Column<string>(type: "text", nullable: true),
                    WorkExperienceTitleOne = table.Column<string>(type: "text", nullable: true),
                    WorkExperienceTitleThree = table.Column<string>(type: "text", nullable: true),
                    WorkExperienceTitleTwo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
