using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DiscothequeW.Migrations
{
    public partial class ProyectApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDiscothequeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDiscothequeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IdRol = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    RolId = table.Column<int>(nullable: true),
                    Ruc = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCompanies_AppRols_RolId",
                        column: x => x.RolId,
                        principalTable: "AppRols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IdRol = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEmployees_AppRols_RolId",
                        column: x => x.RolId,
                        principalTable: "AppRols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IdRol = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    RolId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppRols_RolId",
                        column: x => x.RolId,
                        principalTable: "AppRols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDiscotheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    Cp = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: false),
                    IdCompany = table.Column<int>(nullable: false),
                    Latitud = table.Column<double>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Longitud = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    WebSite = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDiscotheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDiscotheques_AppCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AppCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppMusics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IdCustomer = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMusics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMusics_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDiscothequeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscothequeCategoryId = table.Column<int>(nullable: true),
                    DiscothequeId = table.Column<int>(nullable: true),
                    IdDiscotheque = table.Column<int>(nullable: false),
                    IdDiscothequeCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDiscothequeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDiscothequeDetails_AppDiscothequeCategories_DiscothequeCategoryId",
                        column: x => x.DiscothequeCategoryId,
                        principalTable: "AppDiscothequeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDiscothequeDetails_AppDiscotheques_DiscothequeId",
                        column: x => x.DiscothequeId,
                        principalTable: "AppDiscotheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppMusicDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DiscothequeId = table.Column<int>(nullable: true),
                    Discount = table.Column<decimal>(nullable: false),
                    IdDiscotheque = table.Column<int>(nullable: false),
                    IdMusic = table.Column<int>(nullable: false),
                    MusicId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMusicDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMusicDetails_AppDiscotheques_DiscothequeId",
                        column: x => x.DiscothequeId,
                        principalTable: "AppDiscotheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppMusicDetails_AppMusics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "AppMusics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCompanies_RolId",
                table: "AppCompanies",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDiscothequeDetails_DiscothequeCategoryId",
                table: "AppDiscothequeDetails",
                column: "DiscothequeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDiscothequeDetails_DiscothequeId",
                table: "AppDiscothequeDetails",
                column: "DiscothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDiscotheques_CompanyId",
                table: "AppDiscotheques",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployees_RolId",
                table: "AppEmployees",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMusicDetails_DiscothequeId",
                table: "AppMusicDetails",
                column: "DiscothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMusicDetails_MusicId",
                table: "AppMusicDetails",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMusics_UserId",
                table: "AppMusics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RolId",
                table: "AppUsers",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDiscothequeDetails");

            migrationBuilder.DropTable(
                name: "AppEmployees");

            migrationBuilder.DropTable(
                name: "AppMusicDetails");

            migrationBuilder.DropTable(
                name: "AppDiscothequeCategories");

            migrationBuilder.DropTable(
                name: "AppDiscotheques");

            migrationBuilder.DropTable(
                name: "AppMusics");

            migrationBuilder.DropTable(
                name: "AppCompanies");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppRols");
        }
    }
}
