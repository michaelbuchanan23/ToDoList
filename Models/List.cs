using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models {
	public class List {
		public int Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Required]
		public string UserId { get; set; }
		public virtual User User { get; set; }
		[Required]
		public bool Completed { get; set; } = false;

		public List() {

		}
	}
}