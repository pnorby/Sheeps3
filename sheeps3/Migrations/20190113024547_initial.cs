using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace sheeps3.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CrackCount = table.Column<int>(nullable: false),
                    CurrentPoints = table.Column<double>(nullable: false),
                    GameInt = table.Column<int>(nullable: false),
                    PlayerActive = table.Column<bool>(nullable: false),
                    PlayerInHand = table.Column<bool>(nullable: false),
                    PlayerNickName = table.Column<string>(nullable: true),
                    PlayerPosition = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentDoublers = table.Column<int>(nullable: false),
                    CurrentMonetary = table.Column<int>(nullable: false),
                    Player1 = table.Column<string>(nullable: true),
                    Player2 = table.Column<string>(nullable: true),
                    Player3 = table.Column<string>(nullable: true),
                    Player4 = table.Column<string>(nullable: true),
                    Player5 = table.Column<string>(nullable: true),
                    Player6 = table.Column<string>(nullable: true),
                    Player7 = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BJBlitz = table.Column<string>(nullable: true),
                    BQBlitz = table.Column<string>(nullable: true),
                    Completed = table.Column<DateTime>(nullable: false),
                    Crack = table.Column<string>(nullable: true),
                    CrackBack = table.Column<string>(nullable: true),
                    Dealer = table.Column<string>(nullable: true),
                    Deals = table.Column<int>(nullable: false),
                    Doubler = table.Column<bool>(nullable: false),
                    GameHandNumber = table.Column<int>(nullable: false),
                    GameInt = table.Column<int>(nullable: false),
                    HandScore = table.Column<int>(nullable: false),
                    HandType = table.Column<string>(nullable: true),
                    Opponent1 = table.Column<string>(nullable: true),
                    Opponent2 = table.Column<string>(nullable: true),
                    Opponent3 = table.Column<string>(nullable: true),
                    Opponent4 = table.Column<string>(nullable: true),
                    Partner = table.Column<string>(nullable: true),
                    Picker = table.Column<string>(nullable: true),
                    PointMonetary = table.Column<double>(nullable: false),
                    RJBlitz = table.Column<string>(nullable: true),
                    RQBlitz = table.Column<string>(nullable: true),
                    ReCrack = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameHistories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Hands");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
