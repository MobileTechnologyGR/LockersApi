using System;
using System.Collections.Generic;

namespace LockersService.Model
{
    public partial class Es00dbchange
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public int Version { get; set; }
        public string TableName { get; set; } = null!;
        public string? Value1 { get; set; }
        public string? Value2 { get; set; }
        public string? Value3 { get; set; }
        public byte Executed { get; set; }
        public string? Workstation { get; set; }
        public string? UserCreated { get; set; }
        public string? UserExecuted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public Guid Gid { get; set; }
        public string? Sqlbody { get; set; }
    }
}
