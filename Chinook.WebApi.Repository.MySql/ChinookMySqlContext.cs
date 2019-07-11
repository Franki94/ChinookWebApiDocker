using Chinook.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chinook.WebApi.Repository.MySql
{
    public class ChinookMySqlContext : DbContext

    {
        public ChinookMySqlContext(DbContextOptions<ChinookMySqlContext> options)
          : base(options)
        {
        }
        public ChinookMySqlContext()
        {

        }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=chinook;user=root;password=12345;", opt  => opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasIndex(e => e.ArtistId)
                    .HasName("album_ix_artist_id");

                entity.HasKey(e => e.AlbumId).HasName("album_pkey");

                entity.Property(e => e.AlbumId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("album_artist_id_fkey");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.ArtistId).HasName("artist_pkey");

                entity.Property(e => e.ArtistId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.SupportRepId)
                    .HasName("customer_ix_support_rep_id");

                entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

                entity.Property(e => e.CustomerId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Company).HasMaxLength(80);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.HasOne(d => d.SupportRep)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SupportRepId)
                    .HasConstraintName("customer_support_rep_id_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.ReportsTo)
                    .HasName("employee_ix_reports_to");

                entity.HasKey(e => e.EmployeeId).HasName("employee_pkey");

                entity.Property(e => e.EmployeeId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);

                entity.Property(e => e.Title).HasMaxLength(30);

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("employee_reports_to_fkey");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId).HasName("genre_pkey");

                entity.Property(e => e.GenreId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("invoice_ix_customer_id");

                entity.HasKey(e => e.InvoiceId).HasName("invoice_pkey");

                entity.Property(e => e.InvoiceId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.BillingAddress).HasMaxLength(70);

                entity.Property(e => e.BillingCity).HasMaxLength(40);

                entity.Property(e => e.BillingCountry).HasMaxLength(40);

                entity.Property(e => e.BillingPostalCode).HasMaxLength(10);

                entity.Property(e => e.BillingState).HasMaxLength(40);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invoice_customer_id_fkey");
            });

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.HasIndex(e => e.InvoiceId)
                    .HasName("invoice_line_ix_invoice_id");

                entity.HasIndex(e => e.TrackId)
                    .HasName("invoice_line_ix_track_id");

                entity.HasKey(e => e.InvoiceLineId).HasName("invoice_line_pkey");

                entity.Property(e => e.InvoiceLineId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLine)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invoice_line_invoice_id_fkey");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.InvoiceLine)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invoice_line_track_id_fkey");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.HasKey(e => e.MediaTypeId).HasName("media_type_pkey");

                entity.Property(e => e.MediaTypeId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.PlaylistId).HasName("playlist_pkey");

                entity.Property(e => e.PlaylistId).HasColumnType("int").ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(120);
            });

            modelBuilder.Entity<PlaylistTrack>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.TrackId })
                    .HasName("playlist_track_pkey");

                entity.HasIndex(e => e.TrackId)
                    .HasName("playlist_track_ix_track_id");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_track_playlist_id_fkey");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_track_track_id_fkey");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasIndex(e => e.AlbumId)
                    .HasName("track_ix_album_id");

                entity.HasIndex(e => e.GenreId)
                    .HasName("track_ix_genre_id");

                entity.HasIndex(e => e.MediaTypeId)
                    .HasName("track_ix_media_type_id");

                entity.HasKey(e => e.TrackId).HasName("track_pkey");

                entity.Property(e => e.TrackId).HasColumnType("int")
                .ValueGeneratedNever();                ;

                entity.Property(e => e.Composer).HasMaxLength(220);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("track_album_id_fkey");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("track_genre_id_fkey");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("track_media_type_id_fkey");
            });
        }
    }
}
