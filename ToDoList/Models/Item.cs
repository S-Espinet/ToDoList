using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    public Item()
    {
      this.JoinEntities = new HashSet<CategoryItem>();
    }

    public int ItemId { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; } = false;
    public DateTime DueDate { get; set; }

    public virtual ICollection<CategoryItem> JoinEntities { get;}
  }
}