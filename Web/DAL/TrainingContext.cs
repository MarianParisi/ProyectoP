using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.DAL
{
	public class TrainingContext : DbContext
	{
		public TrainingContext() : base("TrainingContext")
		{
		}
		public DbSet<Models.Routine> Routine { get; set; }
		public DbSet<Models.Level> Level { get; set; }
		public DbSet<Models.User> User { get; set; }
		public DbSet<Models.Exercise> Exercise { get; set; }
		public DbSet<Models.ExerciseRoutine> ExerciseRoutine { get; set; }
		public DbSet<Models.ExerciseType> ExerciseType { get; set; }
 	}
}