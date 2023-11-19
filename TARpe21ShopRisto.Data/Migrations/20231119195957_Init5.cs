﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21ShopRisto.Data.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_spaceships",
                table: "spaceships");

            migrationBuilder.RenameTable(
                name: "spaceships",
                newName: "Spaceships");

            migrationBuilder.RenameColumn(
                name: "MaxSpeedInVaccum",
                table: "Spaceships",
                newName: "MaxSpeedInVaccuum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SpaceshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    FaxNumber = table.Column<int>(type: "int", nullable: false),
                    ListingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareMeters = table.Column<int>(type: "int", nullable: false),
                    BuildDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    EstateFloor = table.Column<int>(type: "int", nullable: true),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    DoesHaveParkingSpace = table.Column<bool>(type: "bit", nullable: false),
                    DoesHavePowerGridConnection = table.Column<bool>(type: "bit", nullable: false),
                    DoesHaveWaterGridConnection = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPropertyNewDevelopment = table.Column<bool>(type: "bit", nullable: false),
                    IsPropertySold = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesToApi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExistingFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToApi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesToApi_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesToApi_RealEstateId",
                table: "FilesToApi",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesToApi");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spaceships",
                table: "Spaceships");

            migrationBuilder.RenameTable(
                name: "Spaceships",
                newName: "spaceships");

            migrationBuilder.RenameColumn(
                name: "MaxSpeedInVaccuum",
                table: "spaceships",
                newName: "MaxSpeedInVaccum");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spaceships",
                table: "spaceships",
                column: "Id");
        }
    }
}
