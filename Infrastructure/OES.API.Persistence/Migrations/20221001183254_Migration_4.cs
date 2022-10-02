using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES.API.Persistence.Migrations
{
    public partial class Migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserEtkinlik");

            migrationBuilder.DropTable(
                name: "Biletler");

            migrationBuilder.DropTable(
                name: "Kontenjanlar");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Sehirler");

            migrationBuilder.RenameColumn(
                name: "WebSitesi",
                table: "AspNetUsers",
                newName: "WebAddressUrl");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EventConfirmation = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserEvent",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserEvent", x => new { x.EventsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserEvent_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserEvent_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfParticipants = table.Column<int>(type: "integer", nullable: false),
                    MaxParticipantsNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotas_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    TicketPrice = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "96d48e6d-0eef-470f-a0e7-75d1443ffd89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "54b3f4f0-608e-487b-a1fd-5545fa9e8b91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "c6a2951e-dfda-4d11-8389-899ca582e2b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ac1e09a-3cba-4b20-b5b0-b87b89d55890", "AQAAAAEAACcQAAAAEIzGWL/DJzIJExxL+AOIfyqD8TUtHKcboGuF56QBlwvj/5EAFPZGwh0tF53K2tPO6g==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserEvent_UsersId",
                table: "AppUserEvent",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CityId",
                table: "Events",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotas_EventId",
                table: "Quotas",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserEvent");

            migrationBuilder.DropTable(
                name: "Quotas");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.RenameColumn(
                name: "WebAddressUrl",
                table: "AspNetUsers",
                newName: "WebSitesi");

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KategoriAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SehirAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KategoriId = table.Column<Guid>(type: "uuid", nullable: false),
                    SehirId = table.Column<Guid>(type: "uuid", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: false),
                    EtkinlikAdi = table.Column<string>(type: "text", nullable: false),
                    EtkinlikOnayi = table.Column<bool>(type: "boolean", nullable: false),
                    EtkinlikTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonBasvuruTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etkinlikler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etkinlikler_Sehirler_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserEtkinlik",
                columns: table => new
                {
                    EtkinliklerId = table.Column<Guid>(type: "uuid", nullable: false),
                    KatilimcilarId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserEtkinlik", x => new { x.EtkinliklerId, x.KatilimcilarId });
                    table.ForeignKey(
                        name: "FK_AppUserEtkinlik_AspNetUsers_KatilimcilarId",
                        column: x => x.KatilimcilarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserEtkinlik_Etkinlikler_EtkinliklerId",
                        column: x => x.EtkinliklerId,
                        principalTable: "Etkinlikler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biletler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EtkinlikId = table.Column<Guid>(type: "uuid", nullable: false),
                    BiletUcreti = table.Column<double>(type: "double precision", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biletler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biletler_Etkinlikler_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlikler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kontenjanlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EtkinlikId = table.Column<Guid>(type: "uuid", nullable: false),
                    KatilimciKapasitesi = table.Column<int>(type: "integer", nullable: false),
                    KatilimciSayisi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontenjanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontenjanlar_Etkinlikler_EtkinlikId",
                        column: x => x.EtkinlikId,
                        principalTable: "Etkinlikler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c675b5e2-214a-45a1-b790-2141d102e409");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "2c82decb-3b17-4342-b6fc-3e794e224ef2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "95dd1c55-f7a4-4ee8-8eec-896dd5a0e63a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88af6c0a-4f84-4f3b-a10e-deb5393d9c1e", "AQAAAAEAACcQAAAAED4/BonoPoINEWFT+JMIVLTItMRBrMYQEmIis2dxrTeb+NGb6inaCxnCe7zx5RWqtA==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserEtkinlik_KatilimcilarId",
                table: "AppUserEtkinlik",
                column: "KatilimcilarId");

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_EtkinlikId",
                table: "Biletler",
                column: "EtkinlikId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlikler_KategoriId",
                table: "Etkinlikler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlikler_SehirId",
                table: "Etkinlikler",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kontenjanlar_EtkinlikId",
                table: "Kontenjanlar",
                column: "EtkinlikId",
                unique: true);
        }
    }
}
