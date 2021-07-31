using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dientes_Sanos_Core_MVC.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_GENERO",
                columns: table => new
                {
                    GENERO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GENERO_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_GENERO", x => x.GENERO_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ODONTOLOGO",
                columns: table => new
                {
                    ODONT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ODONT_CODIGO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODONT_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODONT_APELLIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODONT_ESPECIALIDAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODONT_FEC_NAC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODONT_ID_TITULO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODONT_FEC_ELA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODONT_FEC_ACT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODONT_ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ODONTOLOGO", x => x.ODONT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PACIENTE",
                columns: table => new
                {
                    PAC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PAC_CODIGO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAC_APELLIDO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAC_SEXO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_RUT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PAC_FECHA_NAC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAC_EDAD = table.Column<int>(type: "int", nullable: false),
                    PAC_REPRESENTANTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_DIRECCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_COMUNA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_OTRAS_COMUNAS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_TELEFONO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_CORREO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAC_CONVENIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_PREVISIONES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_OBSERVACIONES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_COD_ODONT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_IMAGEN = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PAC_FEC_REG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAC_FEC_ACT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PACIENTE", x => x.PAC_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PROVINCIA",
                columns: table => new
                {
                    PROV_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROV_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PROVINCIA", x => x.PROV_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIO",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_APELLIDO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_RUT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_CELULAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_PASS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_ROL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    USER_ID_USER = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIO", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "TBL_GENERO");

            migrationBuilder.DropTable(
                name: "TBL_ODONTOLOGO");

            migrationBuilder.DropTable(
                name: "TBL_PACIENTE");

            migrationBuilder.DropTable(
                name: "TBL_PROVINCIA");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
