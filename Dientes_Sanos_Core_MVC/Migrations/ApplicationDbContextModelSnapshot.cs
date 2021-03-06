// <auto-generated />
using System;
using Dientes_Sanos_Core_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dientes_Sanos_Core_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Historial.Models.MODELO_HISTORIAL", b =>
                {
                    b.Property<int>("HISCLI_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HISCLI_ANT1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_ANT9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_CIE101")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_CIE102")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_CIE103")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_CIE104")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_COD")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HISCLI_COD_ODONT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HISCLI_COD_PAC")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HISCLI_ENF_PRO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_EST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_EST_ELI")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("HISCLI_EVOLUCION1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_EVOLUCION2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_EVOLUCION3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_EVOLUCION4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HISCLI_FEC_ACT")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HISCLI_FEC_ELA")
                        .HasColumnType("datetime2");

                    b.Property<string>("HISCLI_FRE_CAR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_FRE_RES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HISCLI_IMG_1")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_10")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_11")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_12")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_13")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_14")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_15")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_3")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_4")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_5")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_6")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_7")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_8")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_IMG_9")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("HISCLI_MOT_CON")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("HISCLI_N_IMG_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_IMG_9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_PDF_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_N_PDF_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_OBSERVACIONES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HISCLI_PDF_1")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HISCLI_PDF_2")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("HISCLI_PRESCRIPCION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_PRE_ART")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HISCLI_TEM_COR")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HISCLI_ID");

                    b.ToTable("TBL_HISTORIA_CLINICA");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Paciente.Models.MODELO_CIE10", b =>
                {
                    b.Property<int>("CIE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CIE_CODIGO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CIE_CONCEPTO")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("CIE_ID");

                    b.ToTable("TBL_CIE10");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Paciente.Models.MODELO_COMUNA", b =>
                {
                    b.Property<int>("PROV_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PROV_NOMBRE")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PROV_ID");

                    b.ToTable("TBL_PROVINCIA");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Paciente.Models.MODELO_GENERO", b =>
                {
                    b.Property<int>("GENERO_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GENERO_NOMBRE")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GENERO_ID");

                    b.ToTable("TBL_GENERO");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Paciente.Models.MODELO_ODONTOLOGO", b =>
                {
                    b.Property<int>("ODONT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ODONT_APELLIDO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ODONT_CODIGO")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ODONT_ESPECIALIDAD")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ODONT_ESTADO")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("ODONT_FEC_ACT")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ODONT_FEC_ELA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ODONT_FEC_NAC")
                        .HasColumnType("datetime2");

                    b.Property<string>("ODONT_ID_TITULO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ODONT_NOMBRE")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ODONT_ID");

                    b.ToTable("TBL_ODONTOLOGO");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Paciente.Models.MODELO_PACIENTE", b =>
                {
                    b.Property<int>("PAC_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PAC_APELLIDO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PAC_CODIGO")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PAC_COD_ODONT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_COMUNA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_CONVENIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_CORREO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_DIRECCION")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PAC_EDAD")
                        .HasColumnType("int");

                    b.Property<DateTime>("PAC_FECHA_NAC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PAC_FEC_ACT")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PAC_FEC_REG")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PAC_IMAGEN")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PAC_NOMBRE")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PAC_OBSERVACIONES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_OTRAS_COMUNAS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_PREVISIONES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_REPRESENTANTE")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PAC_RUT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PAC_SEXO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAC_TELEFONO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PAC_ID");

                    b.ToTable("TBL_PACIENTE");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models.MODELO_DENTADURA", b =>
                {
                    b.Property<int>("DENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DENT_NOM")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DENT_ID");

                    b.ToTable("TBL_DENTADURA");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models.MODELO_PIEZA", b =>
                {
                    b.Property<int>("PIE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PIE_DENT")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PIE_PIEZA")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PIE_ID");

                    b.ToTable("TBL_PIEZA");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models.MODELO_PRESUPUESTO", b =>
                {
                    b.Property<int>("PRE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PRE_COD")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PRE_COD_ODON")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PRE_COD_PAC")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PRE_DEN_PAC")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("PRE_ELA_ACT")
                        .HasColumnType("datetime2");

                    b.Property<string>("PRE_ELA_PRE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PRE_EST_ELI")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("PRE_EST_REA")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("PRE_NOM_ODON")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PRE_NOM_PAC")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PRE_PIE_DEN")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PRE_RUT")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PRE_TRA_PAC")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PRE_VAL_DES")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_POR")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_POR_DSC_SUB")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_POR_TAR_SUB")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_PRE")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_SUB")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_TOT")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_TOT_DSC_SUB")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("PRE_VAL_TOT_TAR_SUB")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("PRE_ID");

                    b.ToTable("TBL_PRESUPUESTO");
                });

            modelBuilder.Entity("Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models.MODELO_TRATAMIENTO", b =>
                {
                    b.Property<int>("TRA_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TRA_CONCEPTO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TRA_DESC")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("TRA_ESTADO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TRA_POR_DESC")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("TRA_TOTAL")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("TRA_VALOR")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("TRA_ID");

                    b.ToTable("TBL_TRATAMIENTO");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SalesSystem.Areas.Users.Models.MODELO_USUARIO", b =>
                {
                    b.Property<int>("USER_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("USER_APELLIDO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_CELULAR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_ID_USER")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("USER_IMAGE")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("USER_NOMBRE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_PASS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_ROL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_RUT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("USER_ID");

                    b.ToTable("TBL_USUARIO");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
