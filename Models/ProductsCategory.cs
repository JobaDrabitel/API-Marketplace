using System;
using System.Collections.Generic;

namespace API_Marketplace_.net_7_v1.Models1;

public partial class ProductsCategory
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Product? Product { get; set; }
}
