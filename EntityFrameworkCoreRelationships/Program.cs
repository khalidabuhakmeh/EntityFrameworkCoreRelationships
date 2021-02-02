using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var db = new Relationships();
        }
    }

    public class Relationships : DbContext
    {
        public DbSet<NotRelated> NotRelateds { get; set; }
        // 1 to 1 (bidirectional)
        public DbSet<OneToOneLeft> OneToOneLefts { get; set; }
        public DbSet<OneToOneRight> OneToOneRights { get; set; }
        // 1 to 1 (owned)
        public DbSet<OneToOneOwner> OneToOneOwners { get; set; }
        // 1 to Many
        public DbSet<OneToMany> OneToManys { get; set; }
        public DbSet<OneToManyItem> OneToManyItems { get; set; }
        // 1 to Many (owned)
        public DbSet<OneToManyOwner> OneToManyOwners { get; set; }
        // Many To Many (Transparent)
        public DbSet<ManyToManyLeft> ManyToManyLefts { get; set; }
        public DbSet<ManyToManyRight> ManyToManyRights { get; set; }
        // Many To Many (Modeled Relationship)
        public DbSet<ManyToManyWithModeledLeft> ManyToManyWithModeledLefts { get; set; }
        public DbSet<ManyToManyWithModeledRight> ManyToManyWithModeledRights { get; set; }
        public DbSet<ManyToManyRelationship> ManyToManyRelationships { get; set; }
        // Hierarchical
        public DbSet<Hierarchical> Hierarchicals { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=relationships.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1 to 1 (bidirectional)
            modelBuilder.Entity<OneToOneLeft>()
                .HasOne<OneToOneRight>()
                .WithOne(r => r.Left)
                .HasForeignKey<OneToOneRight>(r => r.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }

    public class NotRelated
    {
        public int Id { get; set; }
    }

    public class OneToOneLeft
    {
        public int Id { get; set; }
        public int OneToOneRightId { get; set; }
        public OneToOneRight Right { get; set; }
    }

    public class OneToOneRight
    {
        public int Id { get; set; }
        public int OneToOneLeftId { get; set; }
        public OneToOneLeft Left { get; set; }
    }

    public class OneToOneOwner
    {
        public int Id { get; set; }
        public OneToOneOwned Owned { get; set; } 
    }

    [Owned]
    public class OneToOneOwned
    {
        public string Value { get; set; }
    }

    public class OneToMany
    {
        public int Id { get; set; }
        public List<OneToManyItem> Items { get; set; } 
    }

    public class OneToManyItem
    {
        public int Id { get; set; }
        public int OneToManyId { get; set; }
        public OneToMany OneToMany { get; set; }
    }
    
    public class OneToManyOwner
    {
        public int Id { get; set; }
        public List<OneToManyOwnedItem> Items { get; set; }
    }

    [Owned]
    public class OneToManyOwnedItem
    {
        public string Name { get; set; }
    }

    public class ManyToManyLeft
    {
        public int Id { get; set; }
        public List<ManyToManyRight> Rights { get; set; }
    }

    public class ManyToManyRight
    {
        public int Id { get; set; }
        public List<ManyToManyLeft> Lefts { get; set; }
    }

    public class ManyToManyWithModeledLeft
    {
        public int Id { get; set; }
        public ManyToManyRelationship Relationship { get; set; }
    }
    
    public class ManyToManyWithModeledRight
    {
        public int Id { get; set; }
        public ManyToManyRelationship Relationship { get; set; }
    }

    public class ManyToManyRelationship
    {
        public int Id { get; set; }
        public List<ManyToManyWithModeledLeft> Lefts { get; set; }
        public List<ManyToManyWithModeledRight> Rights { get; set; }
    }

    public class Hierarchical
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Hierarchical Parent { get; set; }
        public List<Hierarchical> Children { get; set; }
    }
}