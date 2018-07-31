using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models {
	public class List {
		public int Id { get; set; }
		public string Name { get; set; }
		public string UserId { get; set; }
		public virtual User User { get; set; }
		public bool Completed { get; set; } = false;

		public List() {

		}
	}
}