﻿using System;
using System.Collections.Generic;

namespace lvl7_yana;

public partial class ProductType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double? DefectedPercent { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
