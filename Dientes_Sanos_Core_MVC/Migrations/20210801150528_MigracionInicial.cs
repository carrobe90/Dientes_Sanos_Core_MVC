using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dientes_Sanos_Core_MVC.Migrations
{
    public partial class MigracionInicial : Migration
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
                name: "TBL_CIE10",
                columns: table => new
                {
                    CIE_CODIGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIE_CONCEPTO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CIE10", x => x.CIE_CODIGO);
                });

            migrationBuilder.CreateTable(
                name: "TBL_DENTADURA",
                columns: table => new
                {
                    DENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DENT_NOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DENTADURA", x => x.DENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_GENERO",
                columns: table => new
                {
                    GENERO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GENERO_NOMBRE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_GENERO", x => x.GENERO_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_HISTORIA_CLINICA",
                columns: table => new
                {
                    HISCLI_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HISCLI_COD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HISCLI_COD_ODONT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HISCLI_COD_PAC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HISCLI_MOT_CON = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HISCLI_ENF_PRO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_PRE_ART = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_FRE_CAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_TEM_COR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_FRE_RES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_EST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_ANT15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_CIE101 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_EVOLUCION1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_CIE102 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_EVOLUCION2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_CIE103 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_EVOLUCION3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_CIE104 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_EVOLUCION4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_PRESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_OBSERVACIONES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_PDF_1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_PDF_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_PDF_2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_PDF_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_4 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_5 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_6 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_7 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_8 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_9 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_10 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_11 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_12 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_13 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_14 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_IMG_15 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HISCLI_N_IMG_15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISCLI_FEC_ELA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HISCLI_FEC_ACT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HISCLI_EST_ELI = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_HISTORIA_CLINICA", x => x.HISCLI_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ODONTOLOGO",
                columns: table => new
                {
                    ODONT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ODONT_CODIGO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ODONT_NOMBRE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ODONT_APELLIDO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ODONT_ESPECIALIDAD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ODONT_FEC_NAC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODONT_ID_TITULO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ODONT_FEC_ELA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODONT_FEC_ACT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODONT_ESTADO = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
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
                    PAC_CODIGO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PAC_NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAC_APELLIDO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAC_SEXO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PAC_RUT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PAC_FECHA_NAC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAC_EDAD = table.Column<int>(type: "int", nullable: false),
                    PAC_REPRESENTANTE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_DIRECCION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_COMUNA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PAC_OTRAS_COMUNAS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_TELEFONO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_CORREO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAC_CONVENIO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PAC_PREVISIONES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_OBSERVACIONES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAC_COD_ODONT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PAC_IMAGEN = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PAC_FEC_REG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAC_FEC_ACT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PACIENTE", x => x.PAC_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PIEZA",
                columns: table => new
                {
                    PIE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIE_DENT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PIE_PIEZA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PIEZA", x => x.PIE_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRESUPUESTO",
                columns: table => new
                {
                    PRE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRE_COD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PRE_COD_PAC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PRE_NOM_PAC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PRE_COD_ODON = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PRE_NOM_ODON = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PRE_RUT = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PRE_DEN_PAC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PRE_PIE_DEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PRE_TRA_PAC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PRE_VAL_PRE = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_POR = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_DES = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_SUB = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_POR_DSC_SUB = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_TOT_DSC_SUB = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_POR_TAR_SUB = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_TOT_TAR_SUB = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_VAL_TOT = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PRE_ELA_PRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRE_ELA_ACT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PRE_EST_ELI = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PRE_EST_REA = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRESUPUESTO", x => x.PRE_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PROVINCIA",
                columns: table => new
                {
                    PROV_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PROV_NOMBRE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PROVINCIA", x => x.PROV_ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_TRATAMIENTO",
                columns: table => new
                {
                    TRA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRA_CONCEPTO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TRA_VALOR = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TRA_POR_DESC = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TRA_DESC = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TRA_TOTAL = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TRA_ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TRATAMIENTO", x => x.TRA_ID);
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
                name: "TBL_CIE10");

            migrationBuilder.DropTable(
                name: "TBL_DENTADURA");

            migrationBuilder.DropTable(
                name: "TBL_GENERO");

            migrationBuilder.DropTable(
                name: "TBL_HISTORIA_CLINICA");

            migrationBuilder.DropTable(
                name: "TBL_ODONTOLOGO");

            migrationBuilder.DropTable(
                name: "TBL_PACIENTE");

            migrationBuilder.DropTable(
                name: "TBL_PIEZA");

            migrationBuilder.DropTable(
                name: "TBL_PRESUPUESTO");

            migrationBuilder.DropTable(
                name: "TBL_PROVINCIA");

            migrationBuilder.DropTable(
                name: "TBL_TRATAMIENTO");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
