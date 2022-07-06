using LockersService.Model;
using LockersService.Models;
using LockersService.Services;

namespace TestProject1
{
    public class EimailSenderServiceTest
    {

        private SmtpSettings smpt;
        private CsLockersTransaction csLockersTransaction;

        public EimailSenderServiceTest() {

            smpt = new SmtpSettings();
            smpt.SenderEmail = "mailservice3@mobiletechnology.gr";
            smpt.SenderName = "Mobile Technology";
            smpt.Port = 25;
            smpt.Password = "!mail093*&Mt";
            smpt.UserName = "mailservice3";
            smpt.Server = "172.16.247.12";
            //smpt.SSL = false;

            csLockersTransaction = createTestModel();

        }


        [Fact]
        public async Task SendEmail()
        {
            //Arrange
            EmailSenderService sut = new EmailSenderService();

            //Act 
            var ans = await sut.SendEmailAsync0(
                "salexiou@mobiletechnology.gr",
                "Sotos",
                "",
                smpt,
                csLockersTransaction
            );

            //Assert
            Assert.Equal("Email Sent Successfully", ans );
        }

        private CsLockersTransaction createTestModel()
        {
            var model = new CsLockersTransaction();
            model.BookingDate = DateTime.Parse("7/4/2022 12:00:00 AM");
            model.BoxesNumber = 2.000000000000m;
            model.ContactDate = DateTime.Parse("7/1/2022 4:11:02 PM");
            model.ContactName = "ΠΑΠΟΥΤΣΗΣ ΓΙΩΡΓΟΣ";
            model.CustomerAddress = "ΛΑΓΟΥΜΙΤΖΗ 24";
            model.CustomerBranchCode = "1";
            model.CustomerCode = "3707";
            model.CustomerName = "REWORK M.I.K.E.";
            model.Depth = 0.000000000m;
            model.EmailAddress = "gpapoutsis@mobiletechnology.gr";
            model.Esdcreated = DateTime.Parse("7/1/2022 4:12:20 PM");
            model.TaskCode = "LCK_TR - 00041";
            return model;
        }
    }
}