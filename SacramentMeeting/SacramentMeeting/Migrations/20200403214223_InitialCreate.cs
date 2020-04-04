using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeeting.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    ConductingID = table.Column<int>(nullable: false),
                    OpeningHymnID = table.Column<int>(nullable: false),
                    OpeningPrayerID = table.Column<int>(nullable: false),
                    SacramentHymnID = table.Column<int>(nullable: false),
                    IntermediateHymnID = table.Column<int>(nullable: true),
                    ClosingHymnID = table.Column<int>(nullable: false),
                    ClosingPrayerID = table.Column<int>(nullable: false),
                    PresidingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_ClosingHymnID",
                        column: x => x.ClosingHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_ClosingPrayerID",
                        column: x => x.ClosingPrayerID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_ConductingID",
                        column: x => x.ConductingID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_IntermediateHymnID",
                        column: x => x.IntermediateHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_OpeningHymnID",
                        column: x => x.OpeningHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_OpeningPrayerID",
                        column: x => x.OpeningPrayerID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meeting_Member_PresidingID",
                        column: x => x.PresidingID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Hymn_SacramentHymnID",
                        column: x => x.SacramentHymnID,
                        principalTable: "Hymn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberID = table.Column<int>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    MeetingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Speaker_Meeting_MeetingID",
                        column: x => x.MeetingID,
                        principalTable: "Meeting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Speaker_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ClosingHymnID",
                table: "Meeting",
                column: "ClosingHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ClosingPrayerID",
                table: "Meeting",
                column: "ClosingPrayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_ConductingID",
                table: "Meeting",
                column: "ConductingID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_IntermediateHymnID",
                table: "Meeting",
                column: "IntermediateHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_OpeningHymnID",
                table: "Meeting",
                column: "OpeningHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_OpeningPrayerID",
                table: "Meeting",
                column: "OpeningPrayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_PresidingID",
                table: "Meeting",
                column: "PresidingID");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_SacramentHymnID",
                table: "Meeting",
                column: "SacramentHymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MeetingID",
                table: "Speaker",
                column: "MeetingID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MemberID",
                table: "Speaker",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
