﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dwa.webapi.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_marca_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalogo_tipo_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogoMarca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoMarca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    ImagemFileName = table.Column<string>(nullable: true),
                    CatalogoTipoId = table.Column<int>(nullable: false),
                    CatalogoMarcaId = table.Column<int>(nullable: false),
                    EstoqueDisponivel = table.Column<int>(nullable: false),
                    RestockThreshold = table.Column<int>(nullable: false),
                    MaxStockThreshold = table.Column<int>(nullable: false),
                    OnReorder = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogo_CatalogoMarca_CatalogoMarcaId",
                        column: x => x.CatalogoMarcaId,
                        principalTable: "CatalogoMarca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalogo_CatalogoTipo_CatalogoTipoId",
                        column: x => x.CatalogoTipoId,
                        principalTable: "CatalogoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_RoleClaims_Core_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UserClaims_Core_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Core_UserLogins_Core_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Core_UserRoles_Core_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_UserRoles_Core_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Core_UserTokens_Core_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_CatalogoMarcaId",
                table: "Catalogo",
                column: "CatalogoMarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_CatalogoTipoId",
                table: "Catalogo",
                column: "CatalogoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_RoleClaims_RoleId",
                table: "Core_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserClaims_UserId",
                table: "Core_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserLogins_UserId",
                table: "Core_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRoles_RoleId",
                table: "Core_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Core_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Core_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogo");

            migrationBuilder.DropTable(
                name: "Core_RoleClaims");

            migrationBuilder.DropTable(
                name: "Core_UserClaims");

            migrationBuilder.DropTable(
                name: "Core_UserLogins");

            migrationBuilder.DropTable(
                name: "Core_UserRoles");

            migrationBuilder.DropTable(
                name: "Core_UserTokens");

            migrationBuilder.DropTable(
                name: "CatalogoMarca");

            migrationBuilder.DropTable(
                name: "CatalogoTipo");

            migrationBuilder.DropTable(
                name: "Core_Roles");

            migrationBuilder.DropTable(
                name: "Core_Users");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_marca_hilo");

            migrationBuilder.DropSequence(
                name: "catalogo_tipo_hilo");
        }
    }
}
