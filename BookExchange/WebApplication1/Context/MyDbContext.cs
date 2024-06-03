using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookReview> BookReviews { get; set; }

    public virtual DbSet<FavoriteBook> FavoriteBooks { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GenreBook> GenreBooks { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupType> GroupTypes { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DELL-7020\\SQLEXPRESS;Database=oicardatabase;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Idaccount).HasName("PK__Account__1D323F90B651915B");

            entity.ToTable("Account");

            entity.Property(e => e.Idaccount).HasColumnName("IDAccount");
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Idbook).HasName("PK__Book__2339855F008084D2");

            entity.ToTable("Book");

            entity.Property(e => e.Idbook).HasColumnName("IDBook");
            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.CoverPageImage).HasMaxLength(255);
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublicationDate).HasColumnType("datetime");
            entity.Property(e => e.Publisher).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(e => e.IdbookReview).HasName("PK__BookRevi__C49CE0BB7F5D6D8C");

            entity.ToTable("BookReview");

            entity.Property(e => e.IdbookReview).HasColumnName("IDBookReview");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Book).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BookRevie__BookI__4CA06362");

            entity.HasOne(d => d.User).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__BookRevie__UserI__4BAC3F29");
        });

        modelBuilder.Entity<FavoriteBook>(entity =>
        {
            entity.HasKey(e => e.IdfavouriteBooks).HasName("PK__Favorite__7637794D2FF2FF10");

            entity.Property(e => e.IdfavouriteBooks).HasColumnName("IDFavouriteBooks");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Book).WithMany(p => p.FavoriteBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__FavoriteB__BookI__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteBooks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__FavoriteB__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Idgenre).HasName("PK__Genre__23FDA2F07E280101");

            entity.ToTable("Genre");

            entity.Property(e => e.Idgenre).HasColumnName("IDGenre");
            entity.Property(e => e.GenreName).HasMaxLength(255);
        });

        modelBuilder.Entity<GenreBook>(entity =>
        {
            entity.HasKey(e => e.IdgenreBook).HasName("PK__Genre_Bo__8C707226962EB326");

            entity.ToTable("Genre_Book");

            entity.Property(e => e.IdgenreBook).HasColumnName("IDGenreBook");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");

            entity.HasOne(d => d.Book).WithMany(p => p.GenreBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Genre_Boo__BookI__5535A963");

            entity.HasOne(d => d.Genre).WithMany(p => p.GenreBooks)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Genre_Boo__Genre__5629CD9C");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Idgroup).HasName("PK__Group__CB4260CAE223AC0D");

            entity.ToTable("Group");

            entity.Property(e => e.Idgroup).HasColumnName("IDGroup");
            entity.Property(e => e.GroupTypeId).HasColumnName("GroupTypeID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.GroupType).WithMany(p => p.Groups)
                .HasForeignKey(d => d.GroupTypeId)
                .HasConstraintName("FK__Group__GroupType__412EB0B6");
        });

        modelBuilder.Entity<GroupType>(entity =>
        {
            entity.HasKey(e => e.IdgroupType).HasName("PK__GroupTyp__08B83145D8D0E6B8");

            entity.ToTable("GroupType");

            entity.Property(e => e.IdgroupType).HasColumnName("IDGroupType");
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Idmessage).HasName("PK__Message__195595ECAB0EBA3D");

            entity.ToTable("Message");

            entity.Property(e => e.Idmessage).HasColumnName("IDMessage");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Group).WithMany(p => p.Messages)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Message__GroupID__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Message__UserID__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__User__EAE6D9DFEC772C10");

            entity.ToTable("User");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Contact).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__User__AccountID__3C69FB99");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK__User__UserTypeID__3B75D760");
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.IduserGroup).HasName("PK__User_Gro__2DE7BEFF50481EA5");

            entity.ToTable("User_Group");

            entity.Property(e => e.IduserGroup).HasColumnName("IDUserGroup");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.IduserType).HasName("PK__UserType__EA4074F245715E77");

            entity.ToTable("UserType");

            entity.Property(e => e.IduserType).HasColumnName("IDUserType");
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
