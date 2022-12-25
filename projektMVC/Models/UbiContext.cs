using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projektMVC.Models;

public partial class UbiContext : DbContext
{
    public UbiContext()
    {
    }

    public UbiContext(DbContextOptions<UbiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Courseinfo> Courseinfos { get; set; }

    public virtual DbSet<Diplomainfo> Diplomainfos { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Fileinfo> Fileinfos { get; set; }

    public virtual DbSet<Groupinfo> Groupinfos { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<Settlementinfo> Settlementinfos { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Timetableinfo> Timetableinfos { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=UBI;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Courseinfo>(entity =>
        {
            entity.HasKey(e => e.Courseid);

            entity.ToTable("courseinfo", "course");

            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .HasColumnName("description");
            entity.Property(e => e.Thema)
                .HasMaxLength(20)
                .HasColumnName("thema");
        });

        modelBuilder.Entity<Diplomainfo>(entity =>
        {
            entity.HasKey(e => e.Diplomaid);

            entity.ToTable("diplomainfo", "diploma");

            entity.Property(e => e.Diplomaid).HasColumnName("diplomaid");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("createDate");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .HasColumnName("description");
            entity.Property(e => e.Fileid).HasColumnName("fileid");
            entity.Property(e => e.FinishDate)
                .HasColumnType("date")
                .HasColumnName("finishDate");
            entity.Property(e => e.Promotorid).HasColumnName("promotorid");
            entity.Property(e => e.Reviewerid).HasColumnName("reviewerid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Theme)
                .HasMaxLength(50)
                .HasColumnName("theme");
            entity.Property(e => e.Whoupload).HasColumnName("whoupload");

            entity.HasOne(d => d.File).WithMany(p => p.Diplomainfos)
                .HasForeignKey(d => d.Fileid)
                .HasConstraintName("FK_diplomainfo_fileinfo");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.DiplomainfoReviewers)
                .HasForeignKey(d => d.Reviewerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_diplomainfo_userinfo");

            entity.HasOne(d => d.Student).WithMany(p => p.DiplomainfoStudents)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_diplomainfo_userinfo1");

            entity.HasOne(d => d.WhouploadNavigation).WithMany(p => p.DiplomainfoWhouploadNavigations)
                .HasForeignKey(d => d.Whoupload)
                .HasConstraintName("FK_diplomainfo_userinfo3");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("employee", "person");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate)
                .HasColumnType("date")
                .HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.Titleofcourtesy)
                .HasMaxLength(25)
                .HasColumnName("titleofcourtesy");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_employee_userinfo");
        });

        modelBuilder.Entity<Fileinfo>(entity =>
        {
            entity.HasKey(e => e.Fileid);

            entity.ToTable("fileinfo", "diploma");

            entity.Property(e => e.Fileid).HasColumnName("fileid");
            entity.Property(e => e.FileDate)
                .HasColumnType("date")
                .HasColumnName("fileDate");
            entity.Property(e => e.FileName)
                .HasMaxLength(20)
                .HasColumnName("fileName");
            entity.Property(e => e.FileType)
                .HasMaxLength(10)
                .HasColumnName("fileType");
            entity.Property(e => e.FileWeight)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("fileWeight");
        });

        modelBuilder.Entity<Groupinfo>(entity =>
        {
            entity.HasKey(e => e.Groupid);

            entity.ToTable("groupinfo", "group");

            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .HasColumnName("description");
            entity.Property(e => e.Groupname)
                .HasMaxLength(20)
                .HasColumnName("groupname");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.ToTable("lecturer", "person");

            entity.Property(e => e.Lecturerid).HasColumnName("lecturerid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Emplid).HasColumnName("emplid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate)
                .HasColumnType("date")
                .HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");

            entity.HasOne(d => d.Empl).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.Emplid)
                .HasConstraintName("FK_lecturer_employee");
        });

        modelBuilder.Entity<Settlementinfo>(entity =>
        {
            entity.HasKey(e => e.Settlemenid);

            entity.ToTable("settlementinfo", "settlement");

            entity.Property(e => e.Settlemenid).HasColumnName("settlemenid");
            entity.Property(e => e.Accountbanknumber)
                .HasMaxLength(20)
                .HasColumnName("accountbanknumber");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .HasColumnName("description");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Settlementinfos)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_settlementinfo_userinfo1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("student", "person");

            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            entity.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate)
                .HasColumnType("date")
                .HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            entity.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_student_userinfo");
        });

        modelBuilder.Entity<Timetableinfo>(entity =>
        {
            entity.HasKey(e => e.Timetableid);

            entity.ToTable("timetableinfo", "timetable");

            entity.Property(e => e.Timetableid).HasColumnName("timetableid");
            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .HasColumnName("class");
            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.Day)
                .HasMaxLength(1)
                .HasColumnName("day");
            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Period).HasColumnName("period");

            entity.HasOne(d => d.Course).WithMany(p => p.Timetableinfos)
                .HasForeignKey(d => d.Courseid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_timetableinfo_courseinfo");

            entity.HasOne(d => d.Group).WithMany(p => p.Timetableinfos)
                .HasForeignKey(d => d.Groupid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_timetableinfo_groupinfo");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Userid);

            entity.ToTable("userinfo", "user");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.CreateAccountDate)
                .HasColumnType("date")
                .HasColumnName("createAccountDate");
            entity.Property(e => e.LastLoginDate)
                .HasColumnType("date")
                .HasColumnName("lastLoginDate");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .HasColumnName("prefix");
            entity.Property(e => e.StatusAccount).HasColumnName("statusAccount");
            entity.Property(e => e.Timetableid).HasColumnName("timetableid");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .HasColumnName("username");

            entity.HasOne(d => d.Timetable).WithMany(p => p.Userinfos)
                .HasForeignKey(d => d.Timetableid)
                .HasConstraintName("FK_userinfo_timetableinfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
