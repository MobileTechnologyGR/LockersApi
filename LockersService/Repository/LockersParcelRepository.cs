using LockersService.Model;
using LockersService.Domain;
using Microsoft.EntityFrameworkCore;

namespace LockersService.Repository
{
    public class LockersParcelRepository //: GenericRepository<Company>, IDisposable
    {
        private MobileTechnologyContext _dbContext;

        public LockersParcelRepository() 
        {
            _dbContext = new MobileTechnologyContext();
        }

        public async Task<List<CsLockersParcel>> GetParcels()
        {
            return await _dbContext.CsLockersParcels.ToListAsync();
            //.Include(c => c.ContactInfos.Emails).SingleOrDefaultAsync(
            //    c => c.Id == companyId);
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

        public void Dispose()
        {
            //_dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
