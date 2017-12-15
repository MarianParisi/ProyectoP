using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class Exercise
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Required]
		public int ExerciseTypeID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ExerciseType ExerciseType { get; set; }
		public virtual ICollection<ExerciseRoutine> ExerciseRoutine { get; set; }
	}

	
}