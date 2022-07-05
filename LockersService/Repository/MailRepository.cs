using LockersService.Model;
using LockersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace LockersService.Repository
{
    public class MailRepository  : IMailRepository
    {
        private MobileTechnologyContext _dbContext;

        public MailRepository() 
        {
            _dbContext = new MobileTechnologyContext();
        }

        public async Task<List<CsLockersParcel>> GetParcels()
        {
            return await _dbContext.CsLockersParcels.ToListAsync();
            //.Include(c => c.ContactInfos.Emails).SingleOrDefaultAsync(
            //    c => c.Id == companyId);
        }

        public async Task<List<CsLockersTransaction>> GetDeliveryFromCustomers()
        {
            return await _dbContext.CsLockersTransactions.Where(t =>
                t.TransactionType == "0" &&
                t.BookingDate != null &&
                t.InDate == null &&
                (t.MailStatus == "0" || t.MailStatus == null)
            ).ToListAsync();
        }



        public async Task<List<CsLockersTransaction>> GiveDeliveryToCustomers()
        {
            return await _dbContext.CsLockersTransactions.Where(t =>
                t.TransactionType == "3" &&
                t.BookingDate != null &&
                t.OutDate == null &&
                t.MailStatus == "0" 
            ).ToListAsync();
        }

        public async Task<List<CsLockersTransaction>> GiveEquipmentToCustomers()
        {
            return await _dbContext.CsLockersTransactions.Where(t =>
                t.TransactionType == "4" &&
                t.BookingDate != null &&
                t.OutDate == null &&
                t.MailStatus == "0" 
            ).ToListAsync();
        }

        public async Task<List<CsLockersTransaction>> CompleteDeliverToCustomer()
        {
            return await _dbContext.CsLockersTransactions.Where(t =>
                t.TransactionType == "0" &&
                t.BookingDate != null &&
                t.InDate != null &&
                (t.MailStatus == "1")
            ).ToListAsync();
        }

        public async Task<List<CsLockersTransaction>> CompleteGetFromCustomer()
        {
            return await _dbContext.CsLockersTransactions.Where(t =>
                t.TransactionType == "3" || t.TransactionType == "4" &&
                t.BookingDate != null &&
                t.OutDate != null &&
                t.MailStatus == "1"
            ).ToListAsync();
        }

        public async Task<List<CsLockersTransaction>> CloseParcel()
        {
            return await _dbContext.CsLockersTransactions.Where(t =>
                t.TransactionType == "3" || t.TransactionType == "4" &&
                (t.BookingDate != null || t.OutDate == null)
            ).ToListAsync();
        }

        public void Dispose()
        {
            //_dbContext.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
//    public async Task<Company> GetCompanyRootIncludeShopEimails(
//        int companyId)
//    {
//        return await _companyContext.Companies
//            .Include(c => c.Shops)
//                .ThenInclude(s => s.ContactInfos.Emails)
//                .SingleOrDefaultAsync(c => c.Id == companyId);
//    }
//    public async Task<Company> GetCompanyRootIncludeFullShop(
//        int companyId)
//    {
//        return await _companyContext.Companies
//            //.Include(c => c.Shops)
//            //    .ThenInclude(s => s.ContactInfos.Emails)
//            //.Include(c => c.Shops)
//            //    .ThenInclude(s => s.ContactInfos.Phones)
//            //.Include(c => c.Shops)
//            //    .ThenInclude(s => s.ContactInfos.SocialMedias)

//            //.Include(c => c.Shops)
//            //    .ThenInclude(s => s.DeliveryInfo)
//            //.Include(s => s.Shops)
//            //    .ThenInclude(s => s.Country)
//            //.Include(s => s.Shops)
//            //    .ThenInclude(s => s.City)
//            //.Include(s => s.Shops)
//            //    .ThenInclude(s => s.Area)
//            //.Include(s => s.Shops)
//            //    .ThenInclude(s => s.ZipCode)
//            //.Include(s => s.Shops)
//            //    .ThenInclude(s => s.Street)
//            .SingleOrDefaultAsync(c => c.Id == companyId);
//    }