using System;
using System.Collections.Generic;

namespace LockersService.Model
{
    public partial class MtLockersLog
    {
        public string? TaskCode { get; set; }
        public string TransactionType { get; set; } = null!;
        public string CustomerCode { get; set; } = null!;
        public string CustomerBranchCode { get; set; } = null!;
        public string LockerUid { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public string BoxStatus { get; set; } = null!;
    }
}
