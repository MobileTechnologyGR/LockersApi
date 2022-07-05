using System;
using System.Collections.Generic;

namespace LockersService.Model
{
    public partial class CsLockersParcel
    {
        public Guid TaskGid { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerBranchCode { get; set; }
        public string? LockerId { get; set; }
        public string? ParcelId { get; set; }
        public string? ParcelNumber { get; set; }
        public string? LockerSize { get; set; }
        public string? LockerUid { get; set; }
        public decimal Depth { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string LockerStatus { get; set; } = null!;
        public string? LockerState { get; set; }
    }
}
