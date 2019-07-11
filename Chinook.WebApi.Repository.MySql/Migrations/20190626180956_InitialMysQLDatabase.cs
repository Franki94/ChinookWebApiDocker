using System;
using Chinook.WebApi.Repository.MySql.Migrations.Data;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chinook.WebApi.Repository.MySql.Migrations
{
    public partial class InitialMysQLDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("artist_pkey", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: true),
                    ReportsTo = table.Column<int>(nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(maxLength: 70, nullable: true),
                    City = table.Column<string>(maxLength: 40, nullable: true),
                    State = table.Column<string>(maxLength: 40, nullable: true),
                    Country = table.Column<string>(maxLength: 40, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Phone = table.Column<string>(maxLength: 24, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "employee_reports_to_fkey",
                        column: x => x.ReportsTo,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre_pkey", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    MediaTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("media_type_pkey", x => x.MediaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_pkey", x => x.PlaylistId);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 160, nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("album_pkey", x => x.AlbumId);
                    table.ForeignKey(
                        name: "album_artist_id_fkey",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 40, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Company = table.Column<string>(maxLength: 80, nullable: true),
                    Address = table.Column<string>(maxLength: 70, nullable: true),
                    City = table.Column<string>(maxLength: 40, nullable: true),
                    State = table.Column<string>(maxLength: 40, nullable: true),
                    Country = table.Column<string>(maxLength: 40, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Phone = table.Column<string>(maxLength: 24, nullable: true),
                    Fax = table.Column<string>(maxLength: 24, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    SupportRepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_pkey", x => x.CustomerId);
                    table.ForeignKey(
                        name: "customer_support_rep_id_fkey",
                        column: x => x.SupportRepId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    AlbumId = table.Column<int>(nullable: true),
                    MediaTypeId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: true),
                    Composer = table.Column<string>(maxLength: 220, nullable: true),
                    Milliseconds = table.Column<int>(nullable: false),
                    Bytes = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("track_pkey", x => x.TrackId);
                    table.ForeignKey(
                        name: "track_album_id_fkey",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "track_genre_id_fkey",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "track_media_type_id_fkey",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaType",
                        principalColumn: "MediaTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BillingAddress = table.Column<string>(maxLength: 70, nullable: true),
                    BillingCity = table.Column<string>(maxLength: 40, nullable: true),
                    BillingState = table.Column<string>(maxLength: 40, nullable: true),
                    BillingCountry = table.Column<string>(maxLength: 40, nullable: true),
                    BillingPostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_pkey", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "invoice_customer_id_fkey",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTrack",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_track_pkey", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "playlist_track_playlist_id_fkey",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "playlist_track_track_id_fkey",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                columns: table => new
                {
                    InvoiceLineId = table.Column<int>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_line_pkey", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "invoice_line_invoice_id_fkey",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "invoice_line_track_id_fkey",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "album_ix_artist_id",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "customer_ix_support_rep_id",
                table: "Customer",
                column: "SupportRepId");

            migrationBuilder.CreateIndex(
                name: "employee_ix_reports_to",
                table: "Employee",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "invoice_ix_customer_id",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "invoice_line_ix_invoice_id",
                table: "InvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "invoice_line_ix_track_id",
                table: "InvoiceLine",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "playlist_track_ix_track_id",
                table: "PlaylistTrack",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "track_ix_album_id",
                table: "Track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "track_ix_genre_id",
                table: "Track",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "track_ix_media_type_id",
                table: "Track",
                column: "MediaTypeId");

            migrationBuilder.Sql(SeedData.AddGenreData);
            migrationBuilder.Sql(SeedData.AddMediaTypeData);
            migrationBuilder.Sql(SeedData.AddArtist);
            migrationBuilder.Sql(SeedData.AddAlbumData);
            migrationBuilder.Sql(SeedData.AddTrackData);
            migrationBuilder.Sql(SeedData.AddEmployeeData);
            migrationBuilder.Sql(SeedData.AddCustomerData);
            migrationBuilder.Sql(SeedData.AddInvoiceData);
            migrationBuilder.Sql(SeedData.AddInvoiceLineData);
            migrationBuilder.Sql(SeedData.AddPlayList);
            migrationBuilder.Sql(SeedData.AddPlayListTrackData);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLine");

            migrationBuilder.DropTable(
                name: "PlaylistTrack");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
