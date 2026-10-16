using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public partial class Incidente
{
    [Key]
    public int codigo { get; set; }

    public string DescricaoProblema { get; set; } = null!;

    public DateTime DataIncidente { get; set; }

    public string? Solucao { get; set; }

    public string Resolvido { get; set; } = null!;
}