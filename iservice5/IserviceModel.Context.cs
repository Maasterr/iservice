﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iservice5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class iServiceEntities : DbContext
    {
        public iServiceEntities()
            : base("name=iServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<iservice_cars> iservice_cars { get; set; }
        public virtual DbSet<iservice_customers> iservice_customers { get; set; }
        public virtual DbSet<iservice_items> iservice_items { get; set; }
        public virtual DbSet<iservice_orders> iservice_orders { get; set; }
        public virtual DbSet<iservice_orders_items> iservice_orders_items { get; set; }
        public virtual DbSet<iservice_timeline> iservice_timeline { get; set; }
        public virtual DbSet<iservice_users> iservice_users { get; set; }
    }
}