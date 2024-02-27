﻿using System;
using System.Collections.Generic;

namespace lvl7_yana.DbModel;

public partial class Supplier
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public int? QualityRating { get; set; }

    public string? SupplierType { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
