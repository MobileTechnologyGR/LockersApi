using LockersService.Model;

namespace LockersService.Repository
{
    public interface IMailRepository
    {
        public Task<List<CsLockersTransaction>> GetDeliveryFromCustomers();
        public Task<List<CsLockersTransaction>> GiveDeliveryToCustomers();
        public Task<List<CsLockersTransaction>> GiveEquipmentToCustomers();
        public Task<List<CsLockersTransaction>> CompleteDeliverToCustomer();
        public Task<List<CsLockersTransaction>> CompleteGetFromCustomer();
        public Task<List<CsLockersTransaction>> CloseParcel();
        void addLockerTransaction(CsLockersTransaction model, string status = "1");
        void addLockerTransaction4(CsLockersTransaction model);
    }
}
