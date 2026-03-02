using System;
using System.Collections.Generic;

namespace BankAdminPanelAPI.Models;

public partial class Transection
{
    public int TransectionId { get; set; }

    public int AccountNumber { get; set; }

    public string? Type { get; set; }

    public int Amount { get; set; }

    public DateTime Date { get; set; }

    public virtual Account AccountNumberNavigation { get; set; } = null!;
}
