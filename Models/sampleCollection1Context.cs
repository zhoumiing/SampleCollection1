using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleCollection1.Models;

public partial class sampleCollection1Context : DbContext
{
    public sampleCollection1Context()
    {
    }

    public sampleCollection1Context(DbContextOptions<sampleCollection1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactModel> ContactModels { get; set; }

    public virtual DbSet<MemberModel> MemberModels { get; set; }

    public virtual DbSet<MemberTagModel> MemberTagModels { get; set; }

    public virtual DbSet<MemberWechatModel> MemberWechatModels { get; set; }

    public virtual DbSet<MemberWithMemberTagModel> MemberWithMemberTagModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=/Users/x.m./Projects/_Sqlite3/MemberManagement2.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactModel>(entity =>
        {
            entity.HasKey(e => e.CommonId);

            entity.HasIndex(e => e.CommonId, "IX_ContactModels_commonId").IsUnique();

            entity.HasIndex(e => e.MemberId, "IX_ContactModels_memberId");

            entity.Property(e => e.CommonId).HasColumnName("commonId");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.ContactType).HasColumnName("contactType");
            entity.Property(e => e.ContactValue).HasColumnName("contactValue");
            entity.Property(e => e.MemberId).HasColumnName("memberId");

            entity.HasOne(d => d.Member).WithMany(p => p.ContactModels).HasForeignKey(d => d.MemberId);
        });

        modelBuilder.Entity<MemberModel>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.HasIndex(e => e.MemberId, "IX_MemberModels_memberId").IsUnique();

            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.MemberBirthday).HasColumnName("memberBirthday");
            entity.Property(e => e.MemberJoinDate).HasColumnName("memberJoinDate");
            entity.Property(e => e.MemberNickName).HasColumnName("memberNickName");
            entity.Property(e => e.Sexual).HasColumnName("sexual");
        });

        modelBuilder.Entity<MemberTagModel>(entity =>
        {
            entity.HasKey(e => e.MemberTagId);

            entity.HasIndex(e => e.MemberTagId, "IX_MemberTagModels_memberTagId").IsUnique();

            entity.Property(e => e.MemberTagId).HasColumnName("memberTagId");
            entity.Property(e => e.TagComments).HasColumnName("tagComments");
            entity.Property(e => e.TagName).HasColumnName("tagName");
        });

        modelBuilder.Entity<MemberWechatModel>(entity =>
        {
            entity.HasKey(e => e.WechatId);

            entity.HasIndex(e => e.MemberId, "IX_MemberWechatModels_memberId");

            entity.HasIndex(e => e.WechatId, "IX_MemberWechatModels_wechatId").IsUnique();

            entity.Property(e => e.WechatId).HasColumnName("wechatId");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.Nickname).HasColumnName("nickname");
            entity.Property(e => e.Sexual).HasColumnName("sexual");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberWechatModels).HasForeignKey(d => d.MemberId);
        });

        modelBuilder.Entity<MemberWithMemberTagModel>(entity =>
        {
            entity.HasKey(e => new { e.MemberId, e.MemberTagId });

            entity.ToTable("memberWithMemberTagModels");

            entity.HasIndex(e => e.MemberTagId, "IX_memberWithMemberTagModels_memberTagId");

            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.MemberTagId).HasColumnName("memberTagId");
            entity.Property(e => e.SimilarScore).HasColumnName("similarScore");
            entity.Property(e => e.SupportScore).HasColumnName("supportScore");
            entity.Property(e => e.TagScore).HasColumnName("tagScore");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberWithMemberTagModels).HasForeignKey(d => d.MemberId);

            entity.HasOne(d => d.MemberTag).WithMany(p => p.MemberWithMemberTagModels).HasForeignKey(d => d.MemberTagId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
