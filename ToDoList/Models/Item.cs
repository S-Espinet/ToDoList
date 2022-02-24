using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set ;}
    public int Priority { get; set; }
    private static List<Item> _instances = new List<Item>{};
    
    //Methods
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    
    //Constructor
    public Item (string description)
    {
      Description = description;
      _instances.Add(this); //add yourself to home we all share, like a baby being born - like Korokmen sharing a tree home
    }
    public Item (string description, int priority)
      : this(description)
      {
        Priority = priority;
      }
  }
}

//"this" 1 refers to this instance of object (Item, in this case)
//"this" 2 refers to the first constructor - this, followed by parens refers to the other place where there is the same thing in parens - unclear what order things run in - :this calls the other constructor