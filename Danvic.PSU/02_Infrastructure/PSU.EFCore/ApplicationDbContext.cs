﻿//-----------------------------------------------------------------------
// <copyright file= "ApplicationDbContext.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/11 星期日 13:38:54
// Modified by:
// Description: 数据库连接上下文
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using PSU.Entity.Admission;
using PSU.Entity.Basic;
using PSU.Entity.Dormitory;
using PSU.Entity.School;
using PSU.Entity.SignUp;

namespace PSU.EFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        #region Admission

        /// <summary>
        /// 物品信息表
        /// </summary>
        public virtual DbSet<Goods> Goods { get; set; }

        /// <summary>
        /// 学生提问表
        /// </summary>
        public virtual DbSet<Question> Question { get; set; }

        /// <summary>
        /// 迎新车辆服务表
        /// </summary>
        public virtual DbSet<Service> Service { get; set; }

        #endregion

        #region Basic

        /// <summary>
        /// 网站公告表
        /// </summary>
        public virtual DbSet<Bulletin> Bulletin { get; set; }

        /// <summary>
        /// 网站登录日志表
        /// </summary>
        public virtual DbSet<Logging> Logging { get; set; }

        /// <summary>
        /// 账号操作记录表
        /// </summary>
        public virtual DbSet<Record> Record { get; set; }

        /// <summary>
        /// 账号信息表
        /// </summary>
        public virtual DbSet<IdentityUser> IdentityUser { get; set; }

        #endregion

        #region Dormitory

        /// <summary>
        /// 寝室楼信息表
        /// </summary>
        public virtual DbSet<Building> Building { get; set; }

        /// <summary>
        /// 床位信息表
        /// </summary>
        public virtual DbSet<Bunk> Bunk { get; set; }

        /// <summary>
        /// 寝室信息表
        /// </summary>
        public virtual DbSet<Dorm> Dorm { get; set; }

        #endregion

        #region School

        /// <summary>
        /// 院系信息表
        /// </summary>
        public virtual DbSet<Department> Department { get; set; }

        /// <summary>
        /// 专业班级表
        /// </summary>
        public virtual DbSet<MajorClass> MajorClass { get; set; }

        #endregion

        #region SignUp

        /// <summary>
        /// 选取物品信息表
        /// </summary>
        public virtual DbSet<GoodsInfo> GoodsInfo { get; set; }

        /// <summary>
        /// 选取床铺信息表
        /// </summary>
        public virtual DbSet<BunkInfo> BunkInfo { get; set; }

        /// <summary>
        /// 已报名信息表
        /// </summary>
        public virtual DbSet<Register> Register { get; set; }

        /// <summary>
        /// 预定车辆服务信息表
        /// </summary>
        public virtual DbSet<ServiceInfo> ServiceInfo { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Add ConcurrencyToken

            modelBuilder.Entity<Goods>().Property(p => p.ModifiedOn).IsConcurrencyToken();
            modelBuilder.Entity<Service>().Property(p => p.ModifiedOn).IsConcurrencyToken();
            modelBuilder.Entity<Bulletin>().Property(p => p.ModifiedOn).IsConcurrencyToken();

            modelBuilder.Entity<Building>().Property(p => p.ModifiedOn).IsConcurrencyToken();
            modelBuilder.Entity<Bunk>().Property(p => p.ModifiedOn).IsConcurrencyToken();
            modelBuilder.Entity<Dorm>().Property(p => p.ModifiedOn).IsConcurrencyToken();

            modelBuilder.Entity<Department>().Property(p => p.ModifiedOn).IsConcurrencyToken();
            modelBuilder.Entity<MajorClass>().Property(p => p.ModifiedOn).IsConcurrencyToken();

            #endregion
        }
    }
}
