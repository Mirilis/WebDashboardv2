using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebDashboardv2.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "ProductAlerts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionRequired = table.Column<string>(nullable: true),
                    AlertDate = table.Column<DateTime>(nullable: false),
                    AuthorizedBy = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CustomerNumber = table.Column<int>(nullable: false),
                    Departments = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image1Path = table.Column<string>(nullable: true),
                    Image2Path = table.Column<string>(nullable: true),
                    Image3Path = table.Column<string>(nullable: true),
                    Image4Path = table.Column<string>(nullable: true),
                    ProductNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    RepeatCount = table.Column<int>(nullable: false),
                    RootCause = table.Column<string>(nullable: true),
                    TemplateTypePath = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAlerts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "ProductAlerts");

                  }
    }
}
