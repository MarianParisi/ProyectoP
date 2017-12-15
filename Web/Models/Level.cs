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
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Required]
		public string Description { get; set; }
		public int Rounds { get; set; }
		public int ExerciseNumber { get; set; }
		public string RoutineDays { get; set; }
		public int ExerciseRepetition { get; set; }
		public virtual ICollection<Routine> Routine { get; set; }
	}
}