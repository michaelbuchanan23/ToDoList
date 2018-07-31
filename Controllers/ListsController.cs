using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Models;
using ToDoList.Utility;

namespace ToDoList.Controllers
{
    public class ListsController : ApiController
    {
		private ToDoListDbContext db = new ToDoListDbContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Lists.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse List(int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.Lists.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(List list) {
			if(list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of list"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.Lists.Add(list);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = list
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(List list) {
			if(list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of list"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(list).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = list
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(List list) {
			if(list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of List"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(list).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = list
			};
		}

		//REMOVE/ID
		[HttpPost]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a List.Id"
				};
			var list = db.Lists.Find(id);
			if(list == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No Lists have Id of {id}"
				};
			db.Lists.Remove(list);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = list
			};
		}



	}
}
