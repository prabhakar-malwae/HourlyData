// <copyright file="AssignmentDbContext.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace HourlyData.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// AssignmentDbContext DB Context class 
    /// </summary>
    public partial class AssignmentDbContext : DbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentDbContext"/> struct.
        /// </summary>
        public AssignmentDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentDbContext"/> struct.
        /// </summary>
        /// <param name="options">options set for db context</param>
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// IntervalData db set.
        /// </summary>
        public virtual DbSet<IntervalData> IntervalData { get; set; }

        /// <summary>
        /// OnConfiguring method to handle connection string
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder to configure connection strings</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AssignmentDb;Trusted_Connection=True;");
            }
        }

        /// <summary>
        /// OnModelCreating method to configure ModelProperties 
        /// </summary>
        /// <param name="modelBuilder">options set for db context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntervalData>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SlotVal).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
