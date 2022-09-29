using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp3.Model;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    public virtual DbSet<Category> Categories { get; set; } = null!;

    public virtual DbSet<Department> Departments { get; set; } = null!;

    public virtual DbSet<Faculty> Faculties { get; set; } = null!;

    public virtual DbSet<Group> Groups { get; set; } = null!;

    public virtual DbSet<Lib> Libs { get; set; } = null!;

    public virtual DbSet<Press> Presses { get; set; } = null!;

    public virtual DbSet<SCard> SCards { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<TCard> TCards { get; set; } = null!;

    public virtual DbSet<Teacher> Teachers { get; set; } = null!;

    public virtual DbSet<Theme> Themes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NIHAD; Initial Catalog=library; Integrated Security=SSPI; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .HasColumnOrder(1);
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnOrder(2);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("NoInsertLib"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .HasColumnOrder(8);
            entity.Property(e => e.IdAuthor)
                .HasColumnOrder(6)
                .HasColumnName("Id_Author");
            entity.Property(e => e.IdCategory)
                .HasColumnOrder(5)
                .HasColumnName("Id_Category");
            entity.Property(e => e.IdPress)
                .HasColumnOrder(7)
                .HasColumnName("Id_Press");
            entity.Property(e => e.IdThemes)
                .HasColumnOrder(4)
                .HasColumnName("Id_Themes");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnOrder(1);
            entity.Property(e => e.Pages).HasColumnOrder(2);
            entity.Property(e => e.Quantity).HasColumnOrder(9);
            entity.Property(e => e.YearPress).HasColumnOrder(3);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Author");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Category");

            entity.HasOne(d => d.IdPressNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Press");

            entity.HasOne(d => d.IdThemesNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdThemes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Theme");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.IdFaculty)
                .HasColumnOrder(2)
                .HasColumnName("Id_Faculty");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnOrder(1);

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groups_Faculty");
        });

        modelBuilder.Entity<Lib>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .HasColumnOrder(1);
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnOrder(2);
        });

        modelBuilder.Entity<Press>(entity =>
        {
            entity.ToTable("Press");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<SCard>(entity =>
        {
            entity.ToTable("S_Cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.DateIn)
                .HasColumnOrder(4)
                .HasColumnType("datetime");
            entity.Property(e => e.DateOut)
                .HasColumnOrder(3)
                .HasColumnType("datetime");
            entity.Property(e => e.IdBook)
                .HasColumnOrder(2)
                .HasColumnName("Id_Book");
            entity.Property(e => e.IdLib)
                .HasColumnOrder(5)
                .HasColumnName("Id_Lib");
            entity.Property(e => e.IdStudent)
                .HasColumnOrder(1)
                .HasColumnName("Id_Student");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Book");

            entity.HasOne(d => d.IdLibNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdLib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Lib");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.SCards)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_S_Cards_Stud");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .HasColumnOrder(1);
            entity.Property(e => e.IdGroup)
                .HasColumnOrder(3)
                .HasColumnName("Id_Group");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnOrder(2);
            entity.Property(e => e.Term).HasColumnOrder(4);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Group");
        });

        modelBuilder.Entity<TCard>(entity =>
        {
            entity.ToTable("T_Cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.DateIn)
                .HasColumnOrder(4)
                .HasColumnType("datetime");
            entity.Property(e => e.DateOut)
                .HasColumnOrder(3)
                .HasColumnType("datetime");
            entity.Property(e => e.IdBook)
                .HasColumnOrder(2)
                .HasColumnName("Id_Book");
            entity.Property(e => e.IdLib)
                .HasColumnOrder(5)
                .HasColumnName("Id_Lib");
            entity.Property(e => e.IdTeacher)
                .HasColumnOrder(1)
                .HasColumnName("Id_Teacher");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Book");

            entity.HasOne(d => d.IdLibNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdLib)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Lib");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TCards)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_Cards_Teacher");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .HasColumnOrder(1);
            entity.Property(e => e.IdDep)
                .HasColumnOrder(3)
                .HasColumnName("Id_Dep");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnOrder(2);

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_Dep");
        });

        modelBuilder.Entity<Theme>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnOrder(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
