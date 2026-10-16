using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTask.Models;

public partial class Departamento
{
    [Key]
    public int Codigo { get; set; }

    public string Descricao { get; set; } = null!;

    public bool? Ativo { get; set; }
}