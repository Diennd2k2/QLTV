using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QLTV.Models
{
    public partial class PROJECT_QLTVContext : DbContext
    {
        public PROJECT_QLTVContext()
        {
        }

        public PROJECT_QLTVContext(DbContextOptions<PROJECT_QLTVContext> options): base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BookLoanPapers> BookLoanPapers { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BookShelfs> BookShelfs { get; set; }
        public virtual DbSet<LibraryCards> LibraryCards { get; set; }
        public virtual DbSet<LoanPaperDetails> LoanPaperDetails { get; set; }
        public virtual DbSet<PublisingHouse> PublisingHouse { get; set; }
        public virtual DbSet<Readers> Readers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=PROJECT_QLTV;uid=sa;pwd=12345678;MultipleActiveResultSets=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.IdAccount);

                entity.ToTable("ACCOUNTS");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__ACCOUNTS__C9F284566E6B00F1")
                    .IsUnique();

                entity.Property(e => e.Avatar)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__ACCOUNTS__IdRole__15502E78");
            });

            modelBuilder.Entity<BookLoanPapers>(entity =>
            {
                entity.HasKey(e => e.IdLoanPaper);

                entity.ToTable("BOOK_LOAN_PAPERS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateLoan).HasColumnType("date");

                entity.Property(e => e.DatePay).HasColumnType("date");

                entity.Property(e => e.IdLibraryCard).HasMaxLength(50);

                entity.HasOne(d => d.IdLibraryCardNavigation)
                    .WithMany(p => p.BookLoanPapers)
                    .HasForeignKey(d => d.IdLibraryCard)
                    .HasConstraintName("FK__BOOK_LOAN__IdLib__2C3393D0");

                entity.HasOne(d => d.IdReaderNavigation)
                    .WithMany(p => p.BookLoanPapers)
                    .HasForeignKey(d => d.IdReader)
                    .HasConstraintName("FK__BOOK_LOAN__IdRea__2D27B809");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.ToTable("BOOKS");

                entity.HasIndex(e => e.NameBook)
                    .HasName("UQ__BOOKS__FFD74EF0B5F2CED1")
                    .IsUnique();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DescribeNote).HasColumnType("ntext");

                entity.Property(e => e.NameBook)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UrlImage)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBookShelfNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdBookShelf)
                    .HasConstraintName("FK__BOOKS__IdBookShe__24927208");

                entity.HasOne(d => d.IdPublisingHouseNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdPublisingHouse)
                    .HasConstraintName("FK__BOOKS__IdPublisi__239E4DCF");
            });

            modelBuilder.Entity<BookShelfs>(entity =>
            {
                entity.HasKey(e => e.IdBookShelf);

                entity.ToTable("BOOK_SHELFS");

                entity.HasIndex(e => e.NameBookShelf)
                    .HasName("UQ__BOOK_SHE__5F57F26FFB42BDB5")
                    .IsUnique();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DescribeNote).HasColumnType("ntext");

                entity.Property(e => e.NameBookShelf)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LibraryCards>(entity =>
            {
                entity.HasKey(e => e.IdLibraryCard);

                entity.ToTable("LIBRARY_CARDS");

                entity.Property(e => e.IdLibraryCard)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Avrtar)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdReaderNavigation)
                    .WithMany(p => p.LibraryCards)
                    .HasForeignKey(d => d.IdReader)
                    .HasConstraintName("FK__LIBRARY_C__IdRea__286302EC");
            });

            modelBuilder.Entity<LoanPaperDetails>(entity =>
            {
                entity.HasKey(e => e.IdLoanPaperDetail);

                entity.ToTable("LOAN_PAPER_DETAILS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.LoanPaperDetails)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("FK__LOAN_PAPE__IdBoo__31EC6D26");

                entity.HasOne(d => d.IdLoanPaperNavigation)
                    .WithMany(p => p.LoanPaperDetails)
                    .HasForeignKey(d => d.IdLoanPaper)
                    .HasConstraintName("FK__LOAN_PAPE__IdLoa__30F848ED");
            });

            modelBuilder.Entity<PublisingHouse>(entity =>
            {
                entity.HasKey(e => e.IdPublisingHouse);

                entity.ToTable("PUBLISING_HOUSE");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Readers>(entity =>
            {
                entity.HasKey(e => e.IdReader);

                entity.ToTable("READERS");

                entity.HasIndex(e => e.PhoneReader)
                    .HasName("UQ__READERS__D37AFB4843EECED2")
                    .IsUnique();

                entity.Property(e => e.AddressReader).HasMaxLength(250);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailReader)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameReader)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Passport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneReader)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("ROLES");

                entity.HasIndex(e => e.NameRole)
                    .HasName("UQ__ROLES__7EF6AFD6AC2B388F")
                    .IsUnique();

                entity.Property(e => e.NameRole)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
