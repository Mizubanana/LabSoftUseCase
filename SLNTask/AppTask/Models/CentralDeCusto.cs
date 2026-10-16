using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public partial class CentralDeCusto
{
    [Key]
    public int Codigo { get; set; }

    public string NomeCentral { get; set; } = null!;

    public decimal? ValorMetaAnual { get; set; }
}