using System;
using System.Collections.Generic;

namespace BankAdminPanelAPI.Models;

public partial class Account
{
    public int AccountNumber { get; set; }

    public int CustomerId { get; set; }

    public int Balance { get; set; }

    public string? AccountType { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Transection> Transections { get; set; } = new List<Transection>();
}
