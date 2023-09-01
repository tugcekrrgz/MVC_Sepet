using System;
using System.Collections.Generic;

namespace MVC_Sepet.Models.Context;

public partial class SatışRaporu
{
    public string ÇalışanAdSoyad { get; set; } = null!;

    public string ŞirketAdı { get; set; } = null!;

    public string KategoriAdı { get; set; } = null!;

    public decimal? ÜrünFiyatı { get; set; }

    public short Adet { get; set; }
}
