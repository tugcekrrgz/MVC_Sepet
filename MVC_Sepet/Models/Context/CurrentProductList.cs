﻿using System;
using System.Collections.Generic;

namespace MVC_Sepet.Models.Context;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
