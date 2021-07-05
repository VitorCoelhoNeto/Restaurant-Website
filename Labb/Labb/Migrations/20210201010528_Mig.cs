using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    bloqueado_valor = table.Column<bool>(nullable: true),
                    bloqueado_razao = table.Column<string>(maxLength: 250, nullable: true),
                    bloqueado_duracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    id_Utilizador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__254574288B0EC1BA", x => x.id_Utilizador);
                    table.ForeignKey(
                        name: "FK__Administr__id_Ut__286302EC",
                        column: x => x.id_Utilizador,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id_Utilizador = table.Column<int>(nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__2545742888451838", x => x.id_Utilizador);
                    table.ForeignKey(
                        name: "FK__Cliente__id_Util__2B3F6F97",
                        column: x => x.id_Utilizador,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    id_Utilizador = table.Column<int>(nullable: false),
                    nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    descricao = table.Column<string>(maxLength: 50, nullable: false),
                    foto = table.Column<string>(maxLength: 250, nullable: false),
                    validado = table.Column<bool>(nullable: false),
                    telefone = table.Column<decimal>(type: "numeric(9, 0)", nullable: false),
                    morada = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    gps = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    dia_descanso = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    tipo_takeaway = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    tipo_local = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    tipo_entrega = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    hora_de_abertura = table.Column<string>(unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    hora_de_fecho = table.Column<string>(unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    adminIdUtilizador = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__254574289C9A4CB1", x => x.id_Utilizador);
                    table.ForeignKey(
                        name: "FK__Restauran__id_Ut__35BCFE0A",
                        column: x => x.id_Utilizador,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurante_Administrador_adminIdUtilizador",
                        column: x => x.adminIdUtilizador,
                        principalTable: "Administrador",
                        principalColumn: "id_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PratoDoDia",
                columns: table => new
                {
                    id_Prato = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 250, nullable: false),
                    descricao = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    tipo_prato = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    foto = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    preco = table.Column<decimal>(type: "money", nullable: false),
                    data_prato = table.Column<DateTime>(type: "date", nullable: false),
                    apagado = table.Column<bool>(type: "bit", nullable: false),
                    restauranteIdUtilizador = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PratoDoD__F8A3CCADC548BD1D", x => x.id_Prato);
                    table.ForeignKey(
                        name: "FK_PratoDoDia_Restaurante_restauranteIdUtilizador",
                        column: x => x.restauranteIdUtilizador,
                        principalTable: "Restaurante",
                        principalColumn: "id_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante_Favorito",
                columns: table => new
                {
                    id_Restaurante = table.Column<int>(nullable: false),
                    id_Cliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Restaura__4F606914AE57BBBB", x => new { x.id_Restaurante, x.id_Cliente });
                    table.ForeignKey(
                        name: "FK__Restauran__id_Cl__4222D4EF",
                        column: x => x.id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "id_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Restauran__id_Re__412EB0B6",
                        column: x => x.id_Restaurante,
                        principalTable: "Restaurante",
                        principalColumn: "id_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prato_Favorito",
                columns: table => new
                {
                    id_Cliente = table.Column<int>(nullable: false),
                    id_Prato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Prato_Fa__F8064C9E76D9AA51", x => new { x.id_Cliente, x.id_Prato });
                    table.ForeignKey(
                        name: "FK__Prato_Fav__id_Cl__44FF419A",
                        column: x => x.id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "id_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Prato_Fav__id_Pr__45F365D3",
                        column: x => x.id_Prato,
                        principalTable: "PratoDoDia",
                        principalColumn: "id_Prato",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prato_Favorito_id_Prato",
                table: "Prato_Favorito",
                column: "id_Prato");

            migrationBuilder.CreateIndex(
                name: "IX_PratoDoDia_restauranteIdUtilizador",
                table: "PratoDoDia",
                column: "restauranteIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_adminIdUtilizador",
                table: "Restaurante",
                column: "adminIdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Favorito_id_Cliente",
                table: "Restaurante_Favorito",
                column: "id_Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Prato_Favorito");

            migrationBuilder.DropTable(
                name: "Restaurante_Favorito");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PratoDoDia");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
