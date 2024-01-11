﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerhovskiyIvanKT_41_20.Models;
using VerhovskiyIvanKT_41_20;

namespace VerhovskiyIvanKT_41_20.Database.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "Students";

        public void Configure(EntityTypeBuilder<Student> builder)
        {   //Задаем первичный ключ
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.StudentId).ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            //HasComment добавит комментарий, который будет отобрадаться в СУБД (добавлять по желанию)
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType("varchar").HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType("varchar").HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType("varchar").HasMaxLength(100)
                .HasComment("Отчество студента");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType("varchar").HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("c_student_groupid")
                .HasColumnType("int")
                .HasComment("id группы");


            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            //Добавляем явную автоподшрузку связанной сущности
            builder.Navigation(p => p.Group)
                .AutoInclude();


        }
    }
}
