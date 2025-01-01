using Microsoft.EntityFrameworkCore;
using SadGrpcService.Models.SqlServer;

namespace SadGrpcService.DataBase
{
    /// <summary>
    /// SadSchool database context.
    /// </summary>
    public partial class SadSchoolContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SadSchoolContext"/> class. The default constructor.
        /// </summary>
        public SadSchoolContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SadSchoolContext"/> class.
        /// </summary>
        /// <param name="options">DB context options.</param>
        public SadSchoolContext(DbContextOptions<SadSchoolContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the classes table.
        /// </summary>
        public virtual DbSet<Class> Classes { get; set; }

        /// <summary>
        /// Gets or sets the lessons table.
        /// </summary>
        public virtual DbSet<Lesson> Lessons { get; set; }

        /// <summary>
        /// Gets or sets the scheduled lessons table.
        /// </summary>
        public virtual DbSet<ScheduledLesson> ScheduledLessons { get; set; }

        /// <summary>
        /// Gets or sets the start times (schedule positions) table.
        /// </summary>
        public virtual DbSet<StartTime> StartTimes { get; set; }

        /// <summary>
        /// Gets or sets the students table.
        /// </summary>
        public virtual DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets the subjects table.
        /// </summary>
        public virtual DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the teachers table.
        /// </summary>
        public virtual DbSet<Teacher> Teachers { get; set; }

        /// <summary>
        /// Methos for db context configuration.
        /// </summary>
        /// <param name="optionsBuilder">Options builder object.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies();
    }
}