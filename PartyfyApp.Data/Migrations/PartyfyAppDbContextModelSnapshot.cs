#nullable disable
namespace PartyfyApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    [DbContext(typeof(PartyfyAppDbContext))]
    partial class PartyfyAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationUserTicket", b =>
                {
                    b.Property<Guid>("BuyedTicketsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BuyedTicketsId", "BuyersId");

                    b.HasIndex("BuyersId");

                    b.ToTable("TicketsBuyers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Techno"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rap"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pop-folk"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Winamp"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Latino"
                        });
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DJ")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HosterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PosterImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("HosterId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            CreatedOn = new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9049),
                            DJ = "COZTOF",
                            Description = "This season is centred around what we want to see more, it's all about the deep connection with the subconscious and the city that made us, the true urban jungle that we all want to be part of each and every week!",
                            EventDate = new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HosterId = new Guid("0d62abeb-9bf6-4ef1-b428-2712ccccdd29"),
                            Location = "EXE club, Sofia",
                            PosterImagePath = "~/images/EXE CLUB.png",
                            Status = false,
                            Title = "EXE season 7 OPENING"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 5,
                            CreatedOn = new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9072),
                            DJ = "Pandora MC Bram",
                            Description = "Feel the heat with the best Latin music, from sensual salsa to reggaeton beats that will keep you dancing all night long. Whether you're a seasoned dancer or just looking to have a great time, our DJ will spin the hottest tracks to make sure the energy never stops!",
                            EventDate = new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HosterId = new Guid("0d62abeb-9bf6-4ef1-b428-2712ccccdd29"),
                            Location = "Hacienda canteen, Sofia",
                            PosterImagePath = "~/images/Ladies Night.png",
                            Status = false,
                            Title = "Ladies night"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9078),
                            DJ = "Dimitar Georgiev - Groky",
                            Description = "Our world-class DJ lineup will take you on an intense sonic journey with hard-hitting bass, hypnotic melodies, and deep, driving rhythms that will make you lose yourself on the dance floor. This is where the music speaks, and the crowd moves as one.",
                            EventDate = new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HosterId = new Guid("0d62abeb-9bf6-4ef1-b428-2712ccccdd29"),
                            Location = "Yalta club, Sofia",
                            PosterImagePath = "~/images/Techno Rave.png",
                            Status = false,
                            Title = "Les Machines with Commissar Lag"
                        });
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Hoster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Hosters");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketTypeId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c71b25d8-7828-45eb-9340-26f7908bcaa1"),
                            EventId = 1,
                            Price = 20.0m,
                            Quantity = 400,
                            TicketTypeId = 2
                        },
                        new
                        {
                            Id = new Guid("295ecf74-1900-4180-acaf-4ec6b5e39f8e"),
                            EventId = 2,
                            Price = 50.0m,
                            Quantity = 30,
                            TicketTypeId = 1
                        },
                        new
                        {
                            Id = new Guid("488da7e1-c767-4a08-a874-1aa40480aa6f"),
                            EventId = 2,
                            Price = 30.0m,
                            Quantity = 100,
                            TicketTypeId = 2
                        },
                        new
                        {
                            Id = new Guid("22ba6eeb-b9fb-4335-aab4-7a2de2295dd8"),
                            EventId = 3,
                            Price = 80.0m,
                            Quantity = 45,
                            TicketTypeId = 1
                        },
                        new
                        {
                            Id = new Guid("867e1eed-3341-48c4-ad36-06628d6435d4"),
                            EventId = 3,
                            Price = 50.0m,
                            Quantity = 200,
                            TicketTypeId = 2
                        },
                        new
                        {
                            Id = new Guid("f68b9d7f-001a-4253-9591-c3dd9c963e93"),
                            EventId = 3,
                            Price = 20.0m,
                            Quantity = 200,
                            TicketTypeId = 3
                        });
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.TicketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("TicketTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "VIP"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Standart"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Standing"
                        });
                });

            modelBuilder.Entity("ApplicationUserTicket", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.Ticket", null)
                        .WithMany()
                        .HasForeignKey("BuyedTicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("BuyersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Event", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PartyfyApp.Data.Models.Hoster", "Hoster")
                        .WithMany("MyEvents")
                        .HasForeignKey("HosterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", "User")
                        .WithMany("LikedEvents")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("Hoster");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Hoster", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Ticket", b =>
                {
                    b.HasOne("PartyfyApp.Data.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PartyfyApp.Data.Models.TicketType", "TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("TicketType");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("LikedEvents");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.Hoster", b =>
                {
                    b.Navigation("MyEvents");
                });

            modelBuilder.Entity("PartyfyApp.Data.Models.TicketType", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
