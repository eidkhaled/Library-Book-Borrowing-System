using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
 public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = "";

    // Nullable ParentCategoryId for self-referencing
    public int? ParentCategoryId { get; set; }

    // Navigation property for the parent category
    [ForeignKey("ParentCategoryId")]
    public virtual Category ParentCategory { get; set; }

    // Collection for child categories
    public virtual ICollection<Category> ChildCategories { get; set; }

    public ICollection<Book> Books { get; set; }

    public Category()
    {
        ChildCategories = new HashSet<Category>();
        Books = new HashSet<Book>();
    }
}

}
