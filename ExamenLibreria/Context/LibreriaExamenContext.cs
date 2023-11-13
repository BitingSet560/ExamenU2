using System;
using System.Collections.Generic;
using ExamenLibreria.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenLibreria.Context;

public partial class LibreriaExamenContext : DbContext
{
    public LibreriaExamenContext()
    {
    }

    public LibreriaExamenContext(DbContextOptions<LibreriaExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3BDSUT1;Database=libreriaExamen;Trust Server Certificate=true;User Id=sa;Password=angel;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor).HasName("PK__author__5EE9536DCF2FEA53");

            entity.ToTable("author");

            entity.Property(e => e.IdAuthor).HasColumnName("idAuthor");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book__3213E83F3B0653B2");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chapters).HasColumnName("chapters");
            entity.Property(e => e.IdAuthor).HasColumnName("idAuthor");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__book__price__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
