using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace r.Models
{

    public class LinkContext : DbContext
    {
        public LinkContext(): base("DefaultConnection")
        {
        }

        public DbSet<Link> Links { get; set; }
    }

    public class LinkSeed : DropCreateDatabaseIfModelChanges<LinkContext>
    {
        protected override void Seed(LinkContext context)
        {
            context.Links.Add(new Link
            {
                Code = "1",
                URL = "https://twitter.com/mikevh",
                HitCount = 0,
                Id = 1
            });
        }
    }

    public class Link
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string URL { get; set; }
        public int HitCount { get; set; }
        public int X { get; set; }
    }

    public class LinkViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string URL { get; set; }
        public int HitCount { get; set; }
    }
}