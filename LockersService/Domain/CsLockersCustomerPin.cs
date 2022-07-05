using System;
using System.Collections.Generic;

namespace LockersService.Model
{
    public partial class CsLockersCustomerPin
    {
        public Guid? FTradeAccountGid { get; set; }
        public Guid TaskGid { get; set; }
        public string CustomerCode { get; set; } = null!;
        public string? CustomerName { get; set; }
        public string? CustomerPin { get; set; }
    }
}
