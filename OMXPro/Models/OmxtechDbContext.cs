using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OMXPro.Models;

namespace OMXPro.Models
{
    public class OmxtechDbContext : DbContext
    {
        public OmxtechDbContext():base("name=OmxtechConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

        public DbSet<tbl_article> tbl_articles { get; set; }
        public DbSet<tbl_post> tbl_posts { get; set; }
        public DbSet<tbl_image> tbl_images { get; set; }
        public DbSet<tbl_navmenu> tbl_navmenu { get; set; }
        public DbSet<tbl_contact> tbl_contacts { get; set; }
        public DbSet<tbl_Account> tbl_accounts { get; set; }
        public DbSet<Social> socials { get; set; }
        public DbSet<tbl_siteSection> tbl_sitesections { get; set; }

    }
}