using LockersService.Model;
using Microsoft.EntityFrameworkCore;

namespace LockersService.Domain
{
    public partial class MobileTechnologyContext : DbContext
    {
        public MobileTechnologyContext()
        {
        }

        public MobileTechnologyContext(DbContextOptions<MobileTechnologyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CsLockersCustomerPin> CsLockersCustomerPins { get; set; } = null!;
        public virtual DbSet<CsLockersParcel> CsLockersParcels { get; set; }
        public virtual DbSet<CsLockersTransaction> CsLockersTransactions { get; set; } = null!;
        public virtual DbSet<Es00dbchange> Es00dbchanges { get; set; } = null!;
        public virtual DbSet<Es00odsschemaVersion> Es00odsschemaVersions { get; set; } = null!;
        public virtual DbSet<Es00odsversion> Es00odsversions { get; set; } = null!;
        public virtual DbSet<MtLockersLog> MtLockersLogs { get; set; } = null!;
        public virtual DbSet<MtLockersTransaction> MtLockersTransactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MBT01-ERP-01;User ID=MBT_Lock;Password=MTL0cK2022!@#x;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CsLockersCustomerPin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CS_Lockers_CustomerPIN");

                entity.Property(e => e.CustomerCode).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.CustomerPin)
                    .HasMaxLength(255)
                    .HasColumnName("CustomerPIN");

                entity.Property(e => e.FTradeAccountGid).HasColumnName("fTradeAccountGID");

                entity.Property(e => e.TaskGid).HasColumnName("TaskGID");
            });

            modelBuilder.Entity<CsLockersParcel>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CS_Lockers_Parcels");

                entity.Property(e => e.CustomerBranchCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(50);

                entity.Property(e => e.Depth).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.Height).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.LockerId)
                    .HasMaxLength(255)
                    .HasColumnName("LockerID");

                entity.Property(e => e.LockerSize).HasMaxLength(255);

                entity.Property(e => e.LockerState).HasMaxLength(255);

                entity.Property(e => e.LockerStatus).HasMaxLength(50);

                entity.Property(e => e.LockerUid)
                    .HasMaxLength(388)
                    .HasColumnName("Locker_UID");

                entity.Property(e => e.ParcelId)
                    .HasMaxLength(255)
                    .HasColumnName("ParcelID");

                entity.Property(e => e.ParcelNumber).HasMaxLength(30);

                entity.Property(e => e.TaskGid).HasColumnName("TaskGID");

                entity.Property(e => e.Width).HasColumnType("decimal(25, 10)");
            });

            modelBuilder.Entity<CsLockersTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CS_Lockers_Transactions");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.BoxesNumber).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.ContactDate).HasColumnType("datetime");

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.CustomerAddress).HasMaxLength(100);

                entity.Property(e => e.CustomerBranchCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.DeliveryPersonEmail).HasMaxLength(255);

                entity.Property(e => e.DeliveryPersonName).HasMaxLength(255);

                entity.Property(e => e.DeliveryPersonPhone).HasMaxLength(255);

                entity.Property(e => e.DeliveryPersonSurname).HasMaxLength(255);

                entity.Property(e => e.Depth).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("EMailAddress");

                entity.Property(e => e.Esdcreated)
                    .HasColumnType("datetime")
                    .HasColumnName("ESDCreated");

                entity.Property(e => e.Esdmodified)
                    .HasColumnType("datetime")
                    .HasColumnName("ESDModified");

                entity.Property(e => e.Height).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.InDate).HasColumnType("datetime");

                entity.Property(e => e.LockerSn)
                    .HasMaxLength(255)
                    .HasColumnName("LockerSN");

                entity.Property(e => e.LockerUid)
                    .HasMaxLength(388)
                    .HasColumnName("LockerUID");

                entity.Property(e => e.MailStatus).HasMaxLength(255);

                entity.Property(e => e.OutDate).HasColumnType("datetime");

                entity.Property(e => e.ParcelComment).HasMaxLength(255);

                entity.Property(e => e.ParcelId)
                    .HasMaxLength(255)
                    .HasColumnName("ParcelID");

                entity.Property(e => e.ParcelNumber).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.TaskCode).HasMaxLength(50);

                entity.Property(e => e.TransactionGid).HasColumnName("TransactionGID");

                entity.Property(e => e.TransactionType).HasMaxLength(255);

                entity.Property(e => e.Width).HasColumnType("decimal(25, 10)");
            });

            modelBuilder.Entity<Es00dbchange>(entity =>
            {
                entity.ToTable("ES00DBChanges");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ExecuteDate).HasColumnType("datetime");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.Sqlbody)
                    .HasColumnType("ntext")
                    .HasColumnName("SQLBody");

                entity.Property(e => e.TableName).HasMaxLength(100);

                entity.Property(e => e.UserCreated).HasMaxLength(50);

                entity.Property(e => e.UserExecuted).HasMaxLength(50);

                entity.Property(e => e.Value1).HasMaxLength(500);

                entity.Property(e => e.Value2).HasMaxLength(500);

                entity.Property(e => e.Value3).HasMaxLength(500);

                entity.Property(e => e.Workstation).HasMaxLength(100);
            });

            modelBuilder.Entity<Es00odsschemaVersion>(entity =>
            {
                entity.HasKey(e => e.OdsschemaVersion);

                entity.ToTable("ES00ODSSchemaVersion");

                entity.Property(e => e.OdsschemaVersion)
                    .HasMaxLength(100)
                    .HasColumnName("ODSSchemaVersion");
            });

            modelBuilder.Entity<Es00odsversion>(entity =>
            {
                entity.HasKey(e => e.Odsversion);

                entity.ToTable("ES00ODSVersion");

                entity.Property(e => e.Odsversion)
                    .HasMaxLength(100)
                    .HasColumnName("ODSVersion");

                entity.Property(e => e.Dbversion).HasColumnName("DBVersion");
            });

            modelBuilder.Entity<MtLockersLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mt_LockersLog");

                entity.Property(e => e.BoxStatus).HasMaxLength(50);

                entity.Property(e => e.CustomerBranchCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(50);

                entity.Property(e => e.LockerUid)
                    .HasMaxLength(388)
                    .HasColumnName("LockerUID");

                entity.Property(e => e.TaskCode).HasMaxLength(50);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.TransactionType).HasMaxLength(25);
            });

            modelBuilder.Entity<MtLockersTransaction>(entity =>
            {
                //entity.HasNoKey();

                entity.HasKey(e => e.TransactionGid);

                entity.ToTable("mt_Lockers_Transactions");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.BoxesNumber).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.ContactDate).HasColumnType("datetime");

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.CustomerAddress).HasMaxLength(100);

                entity.Property(e => e.CustomerBranchCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCode).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.DeliveryPersonEmail).HasMaxLength(255);

                entity.Property(e => e.DeliveryPersonName).HasMaxLength(255);

                entity.Property(e => e.DeliveryPersonPhone).HasMaxLength(255);

                entity.Property(e => e.DeliveryPersonSurname).HasMaxLength(255);

                entity.Property(e => e.Depth).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("EMailAddress");

                entity.Property(e => e.Esdcreated)
                    .HasColumnType("datetime")
                    .HasColumnName("ESDCreated");

                entity.Property(e => e.Esdmodified)
                    .HasColumnType("datetime")
                    .HasColumnName("ESDModified");

                entity.Property(e => e.Height).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.InDate).HasColumnType("datetime");

                entity.Property(e => e.InsertId).HasColumnName("Insert_ID");

                entity.Property(e => e.LastUpdateDts)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdateDTS");

                entity.Property(e => e.LockerSn)
                    .HasMaxLength(255)
                    .HasColumnName("LockerSN");

                entity.Property(e => e.LockerUid)
                    .HasMaxLength(388)
                    .HasColumnName("LockerUID");

                entity.Property(e => e.MailStatus).HasMaxLength(255);

                entity.Property(e => e.OutDate).HasColumnType("datetime");

                entity.Property(e => e.ParcelComment).HasMaxLength(255);

                entity.Property(e => e.ParcelId)
                    .HasMaxLength(255)
                    .HasColumnName("ParcelID");

                entity.Property(e => e.ParcelNumber).HasColumnType("decimal(25, 10)");

                entity.Property(e => e.TaskCode).HasMaxLength(50);

                entity.Property(e => e.TransactionGid).HasColumnName("TransactionGID");

                entity.Property(e => e.TransactionType).HasMaxLength(255);

                entity.Property(e => e.Width).HasColumnType("decimal(25, 10)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
