using System;
using System.Collections.Generic;

namespace LockersService.Model
{
    public partial class CsLockersTransaction
    {
        public Guid TransactionGid { get; set; }
        public string TaskCode { get; set; } = null!;
        public string? TransactionType { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerBranchCode { get; set; }
        public string? CustomerAddress { get; set; }
        public DateTime? ContactDate { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? Esdcreated { get; set; }
        public DateTime? Esdmodified { get; set; }
        public string? LockerSn { get; set; }
        public decimal BoxesNumber { get; set; }
        public decimal Depth { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string? ContactName { get; set; }
        public string? EmailAddress { get; set; }
        public string? ParcelId { get; set; }
        public decimal? ParcelNumber { get; set; }
        public string? LockerUid { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonSurname { get; set; }
        public string? DeliveryPersonEmail { get; set; }
        public string? DeliveryPersonPhone { get; set; }
        public string? ParcelComment { get; set; }
        public string? MailStatus { get; set; }
    }
}
