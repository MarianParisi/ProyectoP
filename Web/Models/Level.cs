using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class Level
	{
		[Key, ForeignKey("Routine")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Required]
		public string Description { get; set; }
		public int Rounds { get; set; }
		public int ExerciseNumber { get; set; }
		public int RoutineDays { get; set; }
		public int ExerciseRepetition { get; set; }
		public virtual Routine Routine { get; set; }
	}
}