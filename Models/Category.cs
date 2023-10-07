using System;
using System.Collections.Generic;

namespace API_Marketplace_.net_7_v1.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProductsCategory> ProductsCategories { get; set; } = new List<ProductsCategory>();
}
