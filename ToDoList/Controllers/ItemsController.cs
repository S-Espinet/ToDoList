using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

  [HttpGet("/categories/{categoryId}/items/new")]
  //we need the category because you can't create a new item without first creating its category
  public ActionResult New(int categoryId)
  {
     Category category = Category.Find(categoryId);
     return View(category);
  }

    [HttpGet("/categories/{categoryId}/items/{itemId}")]
    //includes category information because items are now inside categories; we can locate the parent and child objects since they both have ids, and pass them to our dictionary
    public ActionResult Show(int categoryId, int itemId)
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", item);
      model.Add("category", category);
      return View(model);
    }


    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
  }
}