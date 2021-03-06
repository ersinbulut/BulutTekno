using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class Context:DbContext
    {
        public Context() : base("Context")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<WriterUser> Writers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<AdminUser> Admins { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<News> News { get; set; }
    }
}
