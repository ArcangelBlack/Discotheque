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
                name: "AppCompanie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Ruc = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCompanie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDiscothequeCategorie",
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
                    table.PrimaryKey("PK_AppDiscothequeCategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRol",
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
                    table.PrimaryKey("PK_AppRol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppDiscotheque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Cp = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_AppDiscotheque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDiscotheque_AppCompanie_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AppCompanie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppEmployee",
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
                    LastName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEmployee_AppRol_RolId",
                        column: x => x.RolId,
                        principalTable: "AppRol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
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
                    LastName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    RolId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_AppRol_RolId",
                        column: x => x.RolId,
                        principalTable: "AppRol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDiscothequeDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscothequeCategoryId = table.Column<int>(nullable: false),
                    DiscothequeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDiscothequeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDiscothequeDetail_AppDiscothequeCategorie_DiscothequeCategoryId",
                        column: x => x.DiscothequeCategoryId,
                        principalTable: "AppDiscothequeCategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDiscothequeDetail_AppDiscotheque_DiscothequeId",
                        column: x => x.DiscothequeId,
                        principalTable: "AppDiscotheque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppMusic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMusic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMusic_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppMusicDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DiscothequeId = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    MusicId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMusicDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMusicDetail_AppDiscotheque_DiscothequeId",
                        column: x => x.DiscothequeId,
                        principalTable: "AppDiscotheque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppMusicDetail_AppMusic_MusicId",
                        column: x => x.MusicId,
                        principalTable: "AppMusic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDiscotheque_CompanyId",
                table: "AppDiscotheque",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDiscothequeDetail_DiscothequeCategoryId",
                table: "AppDiscothequeDetail",
                column: "DiscothequeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDiscothequeDetail_DiscothequeId",
                table: "AppDiscothequeDetail",
                column: "DiscothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployee_RolId",
                table: "AppEmployee",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMusic_UserId",
                table: "AppMusic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMusicDetail_DiscothequeId",
                table: "AppMusicDetail",
                column: "DiscothequeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMusicDetail_MusicId",
                table: "AppMusicDetail",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_RolId",
                table: "AppUser",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDiscothequeDetail");

            migrationBuilder.DropTable(
                name: "AppEmployee");

            migrationBuilder.DropTable(
                name: "AppMusicDetail");

            migrationBuilder.DropTable(
                name: "AppDiscothequeCategorie");

            migrationBuilder.DropTable(
                name: "AppDiscotheque");

            migrationBuilder.DropTable(
                name: "AppMusic");

            migrationBuilder.DropTable(
                name: "AppCompanie");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "AppRol");
        }
    }
}
