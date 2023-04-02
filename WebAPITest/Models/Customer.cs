using System;
using System.Collections.Generic;

namespace WebAPITest.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public string? Gender { get; set; }
}
