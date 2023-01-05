using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IndvDtaDbPrjctTest.Models;

namespace IndvDtaDbPrjctTest.Data
{
    public partial class NewSchoolContext : DbContext
    {
        public NewSchoolContext()
        {
        }

        public NewSchoolContext(DbContextOptions<NewSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveClass> ActiveClasses { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Credential> Credentials { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmploymentHistory> EmploymentHistories { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<FacultyType> FacultyTypes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;
        public virtual DbSet<StudentInformation> StudentInformations { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<TeacherCourse> TeacherCourses { get; set; } = null!;
        public virtual DbSet<TeachersInDepartment> TeachersInDepartments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-3V4DD649\\SQLEXPRESS; Initial Catalog=NewSchool;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Active Classes");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.PkClassId)
                    .HasName("PK__Class__CCB73664405A67C9");

                entity.ToTable("Class");

                entity.Property(e => e.PkClassId).HasColumnName("PK_ClassId");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasKey(e => e.PkUserId);

                entity.Property(e => e.PkUserId).HasColumnName("PK_UserId");

                entity.Property(e => e.PassWord).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.PkDepartmentId);

                entity.ToTable("Department");

                entity.Property(e => e.PkDepartmentId).HasColumnName("PK_DepartmentId");

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<EmploymentHistory>(entity =>
            {
                entity.HasKey(e => e.PkEmployeeId);

                entity.ToTable("EmploymentHistory");

                entity.Property(e => e.PkEmployeeId).HasColumnName("PK_EmployeeId");

                entity.Property(e => e.FkDepartmentId).HasColumnName("FK_DepartmentId");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.FkDepartment)
                    .WithMany(p => p.EmploymentHistories)
                    .HasForeignKey(d => d.FkDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmploymentHistory_Department");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.PkFacultyId)
                    .HasName("PK__Faculty__6D22529DA5F66F4F");

                entity.ToTable("Faculty");

                entity.Property(e => e.PkFacultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_FacultyId");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeId");

                entity.Property(e => e.FkFacultyTypeId).HasColumnName("FK_FacultyTypeId");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_Faculty_EmploymentHistory");

                entity.HasOne(d => d.FkFacultyType)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.FkFacultyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_FacultyType");
            });

            modelBuilder.Entity<FacultyType>(entity =>
            {
                entity.HasKey(e => e.PkFacultyTypeId);

                entity.ToTable("FacultyType");

                entity.Property(e => e.PkFacultyTypeId).HasColumnName("PK_FacultyTypeId");

                entity.Property(e => e.FacultyType1)
                    .HasMaxLength(50)
                    .HasColumnName("FacultyType");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.PkGradeId)
                    .HasName("PK__Grade__B62E54542B34B294");

                entity.ToTable("Grade");

                entity.Property(e => e.PkGradeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_GradeId");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PkStudentId)
                    .HasName("PK__Student__168480D11AFC1AF2");

                entity.ToTable("Student");

                entity.Property(e => e.PkStudentId).HasColumnName("PK_StudentId");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.PersonNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StudentGrade");

                entity.Property(e => e.DateOfGrade).HasColumnType("date");

                entity.Property(e => e.FkFacultyId).HasColumnName("FK_FacultyId");

                entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.FkSubjectId).HasColumnName("FK_SubjectId");

                entity.HasOne(d => d.FkFaculty)
                    .WithMany()
                    .HasForeignKey(d => d.FkFacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Faculty");

                entity.HasOne(d => d.FkGrade)
                    .WithMany()
                    .HasForeignKey(d => d.FkGradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Grade");

                entity.HasOne(d => d.FkStudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Student");

                entity.HasOne(d => d.FkSubject)
                    .WithMany()
                    .HasForeignKey(d => d.FkSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Subject");
            });

            modelBuilder.Entity<StudentInformation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Student Information");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.PersonNummer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PkStudentId).HasColumnName("PK_StudentId");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.PkSubjectId)
                    .HasName("PK__Subject__26328D7477036727");

                entity.ToTable("Subject");

                entity.Property(e => e.PkSubjectId).HasColumnName("PK_SubjectId");

                entity.Property(e => e.FkDepartmentId).HasColumnName("FK_DepartmentId");

                entity.Property(e => e.SubjectName).HasMaxLength(50);

                entity.HasOne(d => d.FkDepartment)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.FkDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Department");
            });

            modelBuilder.Entity<TeacherCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Teacher Course");

                entity.Property(e => e.SubjectName).HasMaxLength(50);

                entity.Property(e => e.Teacher).HasMaxLength(101);
            });

            modelBuilder.Entity<TeachersInDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Teachers In Department");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InDepartment).HasColumnName("In Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
