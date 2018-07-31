using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models {
	public class ToDoListDbContext: DbContext {

		public DbSet<User> Users { get; set; }
		public DbSet<List> Lists { get; set; }

		public ToDoListDbContext() : base() { }
	}
}