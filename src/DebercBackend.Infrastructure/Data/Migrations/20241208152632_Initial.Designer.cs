﻿// <auto-generated />
using DebercBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DebercBackend.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241208152632_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DebercBackend.Core.ContributorAggregate.Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contributor");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Suit")
                        .HasColumnType("int");

                    b.Property<int?>("TrickId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TrickId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Combination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameRoundId")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameRoundId");

                    b.HasIndex("OwnerTeamId");

                    b.ToTable("Combinations");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DealerId")
                        .HasColumnType("int");

                    b.Property<int?>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("OpenPoints")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BargainRound")
                        .HasColumnType("int");

                    b.Property<int?>("DisplayedCardId")
                        .HasColumnType("int");

                    b.Property<int?>("DutyPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderPlayerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderSuit")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerGameId")
                        .HasColumnType("int");

                    b.Property<int?>("VotePlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisplayedCardId");

                    b.HasIndex("DutyPlayerId");

                    b.HasIndex("OrderPlayerId");

                    b.HasIndex("OwnerGameId");

                    b.HasIndex("VotePlayerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstPlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("SecondPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstPlayerId");

                    b.HasIndex("SecondPlayerId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Trick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OwnerRoundId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("StarterPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerRoundId");

                    b.HasIndex("StarterPlayerId");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Tricks");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstPlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("SecondPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstPlayerId");

                    b.HasIndex("SecondPlayerId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DebercBackend.Core.ContributorAggregate.Contributor", b =>
                {
                    b.OwnsOne("DebercBackend.Core.ContributorAggregate.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ContributorId")
                                .HasColumnType("int");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Extension")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ContributorId");

                            b1.ToTable("Contributor");

                            b1.WithOwner()
                                .HasForeignKey("ContributorId");
                        });

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Card", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Trick", null)
                        .WithMany("Cards")
                        .HasForeignKey("TrickId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Combination", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Round", "GameRound")
                        .WithMany("Combinations")
                        .HasForeignKey("GameRoundId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Team", "OwnerTeam")
                        .WithMany()
                        .HasForeignKey("OwnerTeamId");

                    b.Navigation("GameRound");

                    b.Navigation("OwnerTeam");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Game", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "Dealer")
                        .WithMany()
                        .HasForeignKey("DealerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.Navigation("Dealer");

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Round", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Card", "DisplayedCard")
                        .WithMany()
                        .HasForeignKey("DisplayedCardId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "DutyPlayer")
                        .WithMany()
                        .HasForeignKey("DutyPlayerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "OrderPlayer")
                        .WithMany()
                        .HasForeignKey("OrderPlayerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Game", "OwnerGame")
                        .WithMany("Rounds")
                        .HasForeignKey("OwnerGameId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "VotePlayer")
                        .WithMany()
                        .HasForeignKey("VotePlayerId");

                    b.Navigation("DisplayedCard");

                    b.Navigation("DutyPlayer");

                    b.Navigation("OrderPlayer");

                    b.Navigation("OwnerGame");

                    b.Navigation("VotePlayer");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Team", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "FirstPlayer")
                        .WithMany()
                        .HasForeignKey("FirstPlayerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "SecondPlayer")
                        .WithMany()
                        .HasForeignKey("SecondPlayerId");

                    b.Navigation("FirstPlayer");

                    b.Navigation("SecondPlayer");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Trick", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Round", "OwnerRound")
                        .WithMany("Tricks")
                        .HasForeignKey("OwnerRoundId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "StarterPlayer")
                        .WithMany()
                        .HasForeignKey("StarterPlayerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Team", "WinnerTeam")
                        .WithMany()
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("OwnerRound");

                    b.Navigation("StarterPlayer");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.User", b =>
                {
                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "FirstPlayer")
                        .WithMany()
                        .HasForeignKey("FirstPlayerId");

                    b.HasOne("DebercBackend.Core.GameAggregate.Player", "SecondPlayer")
                        .WithMany()
                        .HasForeignKey("SecondPlayerId");

                    b.Navigation("FirstPlayer");

                    b.Navigation("SecondPlayer");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Game", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Round", b =>
                {
                    b.Navigation("Combinations");

                    b.Navigation("Tricks");
                });

            modelBuilder.Entity("DebercBackend.Core.GameAggregate.Trick", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
