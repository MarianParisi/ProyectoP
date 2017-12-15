using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class Routine
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Required]
		public int UserID { get; set; }
		public virtual User User { get; set; }
		public virtual Level Level { get; set; }
		public virtual ICollection<ExerciseRoutine> ExerciseRoutine { get; set; }
	}
}