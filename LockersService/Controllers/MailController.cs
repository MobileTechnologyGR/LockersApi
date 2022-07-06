using LockersService.Interfaces;
using LockersService.Models;
using LockersService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LockersService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MailController : ControllerBase
    {

        private readonly ILogger<MailController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IMailRepository _mailRepository;
        private readonly IConfiguration _configuration;
        private SmtpSettings _smtpSettings;

        public MailController(
            ILogger<MailController> logger,
            IEmailSender emailSender, 
            IMailRepository mailRepository,
            IConfiguration configuration)
        {
            _logger = logger;
            _emailSender = emailSender;
            _mailRepository = mailRepository;
            _configuration = configuration;
            _smtpSettings = new SmtpSettings();
            _smtpSettings.SenderEmail = _configuration["SmtpSettings:SenderEmail"];
            _smtpSettings.SenderName = _configuration["SmtpSettings:SenderName"];
            _smtpSettings.Port = Int32.Parse(_configuration["SmtpSettings:Port"]);
            _smtpSettings.Password = _configuration["SmtpSettings:Password"];
            _smtpSettings.UserName = _configuration["SmtpSettings:UserName"];
            _smtpSettings.Server = _configuration["SmtpSettings:Server"];

        }

        [HttpPost(Name = "GetDeliveryFromCustomers")]
        public async Task<IActionResult> GetDeliveryFromCustomers()
        {
            var array = await _mailRepository.GetDeliveryFromCustomers();
            var resultsArray = array.ToArray();

            if (resultsArray.Length > 0)
            {
                try
                {
                    var counter = 0;
                    var statusList = new List<String>();
                    for (int i = 0; i < resultsArray.Length; i++)
                    {
                        string messageStatus = await _emailSender.SendEmailAsync0(
                        resultsArray[i].EmailAddress, resultsArray[i].ContactName, "", _smtpSettings, resultsArray[i]);
                        statusList.Add(messageStatus);
                        _mailRepository.addLockerTransaction(resultsArray[i]);
                    }

                    return Ok(statusList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }

            }
            else
            {
                return Ok("No Data");
            }
        }

        [HttpPost(Name = "GiveDeliveryToCustomers")]
        public async Task<IActionResult> GiveDeliveryToCustomers()
        {
            var array = await _mailRepository.GiveDeliveryToCustomers();
            var resultsArray = array.ToArray();

            if (resultsArray.Length > 0)
            {
                try
                {
                    var counter = 0;
                    var statusList = new List<String>();
                    for (int i = 0; i < resultsArray.Length; i++)
                    {
                        string messageStatus = await _emailSender.SendEmailAsync1(
                        resultsArray[i].EmailAddress, resultsArray[i].ContactName, "", _smtpSettings, resultsArray[i]);
                        statusList.Add(messageStatus);
                        _mailRepository.addLockerTransaction(resultsArray[i]);
                    }
                    return Ok(statusList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }

            }
            else
            {
                return Ok("No Data");
            }

        }


        [HttpPost(Name = "GiveEquimpentToCustomers")]
        public async Task<IActionResult> GiveEquimpentToCustomers()
        {
            var array = await _mailRepository.GiveEquipmentToCustomers();
            var resultsArray = array.ToArray();

            if (resultsArray.Length > 0)
            {
                try
                {
                    var counter = 0;
                    var statusList = new List<String>();
                    for (int i = 0; i < resultsArray.Length; i++)
                    {
                        string messageStatus = await _emailSender.SendEmailAsync3(
                        resultsArray[i].EmailAddress, resultsArray[i].ContactName, "", _smtpSettings, resultsArray[i]);
                        statusList.Add(messageStatus);

                        _mailRepository.addLockerTransaction(resultsArray[i]);
                    }
                    return Ok(statusList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }

            }
            else
            {
                return Ok("No Data");
            }

        }


        //TODO(TEST)

        [HttpPost(Name = "CompletedDeliveredToCustomer")]
        public async Task<IActionResult> CompletedDeliveredToCustomer()
        {
            var array = await _mailRepository.CompleteDeliverToCustomer();
            var resultsArray = array.ToArray();

            if (resultsArray.Length > 0)
            {
                try
                {
                    var counter = 0;
                    var statusList = new List<String>();
                    for (int i = 0; i < resultsArray.Length; i++)
                    {
                        string messageStatus = await _emailSender.SendEmailAsync5(
                        resultsArray[i].EmailAddress, resultsArray[i].ContactName, "", _smtpSettings, resultsArray[i]);
                        statusList.Add(messageStatus);

                        _mailRepository.addLockerTransaction(resultsArray[i], "2");
                    }
                    return Ok(statusList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }

            }
            else
            {
                return Ok("No Data");
            }

        }
      

        [HttpPost(Name = "CompletedGetFromCustomer")]
        public async Task<IActionResult> CompletedGetFromCustomer()
        {
            var array = await _mailRepository.CompleteGetFromCustomer();
            var resultsArray = array.ToArray();

            if (resultsArray.Length > 0)
            {
                try
                {
                    var counter = 0;
                    var statusList = new List<String>();
                    for (int i = 0; i < resultsArray.Length; i++)
                    {
                        string messageStatus = await _emailSender.SendEmailAsync4(
                        resultsArray[i].EmailAddress, resultsArray[i].ContactName, "", _smtpSettings, resultsArray[i]);
                        statusList.Add(messageStatus);
                        _mailRepository.addLockerTransaction4(resultsArray[i]);

                        _mailRepository.addLockerTransaction(resultsArray[i], "2");
                    }
                    return Ok(statusList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }
            }
            else
            {
                return Ok("No Data");
            }

        }


        [HttpPost(Name = "CloseParcel")]
        public async Task<IActionResult> CloseParcel()
        {
            var array = await _mailRepository.CloseParcel();
            var resultsArray = array.ToArray();

            if (resultsArray.Length > 0)
            {
                try
                {
                    var counter = 0;
                    var statusList = new List<String>();
                    for (int i = 0; i < resultsArray.Length; i++)
                    {
                        string messageStatus = await _emailSender.SendEmailAsync6(
                        resultsArray[i].EmailAddress, resultsArray[i].ContactName, "", _smtpSettings, resultsArray[i]);
                        statusList.Add(messageStatus);
                    }
                    return Ok(statusList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message.ToString());
                }
            }
            else
            {
                return Ok("No Data");
            }

        }

    }
}