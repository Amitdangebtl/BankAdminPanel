using System;
using System.Collections.Generic;

namespace BankAdminPanelAPI.Models;

public partial class AdminUser
{
    public int AdminId { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
