using System;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Welcome to Your To-Do List.");
      while(true)
      {
        Console.WriteLine("Would you like to add an item to your list, view your list, clear all items, or quit? (Add/View/Clear/Quit)");
        string decision = Console.ReadLine().ToUpper();
        if (decision == "ADD")
        {
          Console.WriteLine("Please enter your task.");
          string myTask = Console.ReadLine();
          Item userTask = new Item(myTask);
          Console.WriteLine($"{userTask.Description} has been added to your list. Would you like to add an item to your list or view your list?");
          // Main();
        }
        else if (decision == "VIEW")
        {
           foreach (Item task in Item.GetAll())
           {
            Console.WriteLine(task.Description);
           }
        }
        else if (decision == "CLEAR")
        {
          Item.ClearAll();
        }
        else if (decision == "QUIT")
        {
          return;
        }
        else
        {
          Console.WriteLine("Invalid entry - try again.");
          return;
        }
      }
    }
  }
}

