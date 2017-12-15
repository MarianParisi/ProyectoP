using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class ExerciseRoutine
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Required]
		public int RoutineID { get; set;}
		public int ExerciseID { get; set; }
		public virtual Routine Routine { get; set; }
		public virtual Exercise Exercise { get; set; }
	}
}