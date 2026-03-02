using System;
using System.Collections.Generic;

namespace BankAdminPanelAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public long Phone { get; set; }

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
