using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    //create lets us process submissions from the form located in New; this post request makes the actual changes the user requested in that form, so the paths are the same for these two routes
    {
      Category newCategory = new Category(categoryName);
      //this route accepts a categoryName argument. This refers to the contents of the category name form field in the New view.
      return RedirectToAction("Index");
      //Index send the user back to the index route (at the top of this list)
    }

    [HttpGet("/categories/{id}")]
    //this is the page that will show - the id's page, which shows a category's details (the category's details are the tasks, i.e. Items, that are in that category) - it knows which category to show from the dynamically-generated id
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = selectedCategory.Items;
      model.Add("category", selectedCategory);
      model.Add("items", categoryItems);
      //the two lines above create a dictionary called model, which holds key value pairs. The keys are the category and item strings, which are ideas (or classes?) and the values are the selected category (category object), and its associated items. We can pass the whole dictionary into view.
      return View(model);
    }

    [HttpPost("categories/{categoryId}/items")]
    //this did go in items controller, but the act of adding an item changes the category object, so we include it with other category object routes
    public ActionResult Create(int categoryId, string itemDescription)
    //create needs the category id now, as well as the description of the item because items live inside categories
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      //using the id from above, we have to find the category object that we're adding the item to
      Item newItem = new Item(itemDescription);
      //the line above is from the user's input in the form
      newItem.Save();
      //this line saves to database
      foundCategory.AddItem(newItem);
      List<Item> categoryItems = foundCategory.Items;
      //the view requires all of the items in this list because when it renders, it displays all of the items in the list that belongs to this category
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }
  }
}

//paths for all item routes will now include a fragment from the parent category before the item information