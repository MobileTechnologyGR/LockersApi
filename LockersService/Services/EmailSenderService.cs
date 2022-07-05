//using Leadtools;
//using Leadtools.Barcode;
//using Leadtools.Codecs;
using LockersService.Interfaces;
using LockersService.Model;
using LockersService.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Drawing;
using ZXing.QrCode;
using MimeKit.Utils;
using Leadtools.Barcode;
using Leadtools;
using Leadtools.Codecs;

namespace LockersService.Services
{
    public class EmailSenderService : IEmailSender
    {

        private readonly SmtpSettings _smtpSettings;

        public EmailSenderService()
        {
        }


        public async Task<string> SendEmailAsync0(
            string recipientEmail,
            string recipientFirstName,
            string Link,
            SmtpSettings smtpSettings,
            CsLockersTransaction lockersTransaction)
        {


            string QRstring = lockersTransaction.TaskCode.Split("-")[1] + "-" +
                lockersTransaction.CustomerCode + "-" +
                lockersTransaction.CustomerBranchCode;

            byte[] byteArray = GenerateQRcode(QRstring);

            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Mobile Technology MTLockers";


            var builder = new BodyBuilder();
            string image = "data:image/png;base64," + Convert.ToBase64String(byteArray);
            // Set the plain-text version of the message text
            builder.TextBody = @"Γεια σας,

            για την παράδοση του προς επισκευή εξοπλισμού σας, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων της MobileTechnology 
            την «ημερομηνία δέσμευσης». 
            Μπορείτε να παραδώσετε το δέμα σας στα Mobile Lockers  με τη χρήση του παρακάτω QR code:

            Με εκτίμηση,

            -- Mobile Technology
            ";


            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@$"<b><p>Γειά σας, <br>
            <p>για την παράδοση του προς επισκευή εξοπλισμού σας, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων <<{lockersTransaction.ParcelNumber}>> της MobileTechnology
            την ημερομηνία δέσμευσης: <<{lockersTransaction.BookingDate}>>.<br>
            <p>Μπορείτε να παραδώσετε το δέμα σας στα MT Lockers με τη χρήση του παρακάτω QR code:</b><br>" +
            "<center><tb><img src='" + image + "'/> </center>" +
            "<p><br><i> Αυτό είναι ένα αυτοματοποιημένο ηλεκτρονικό μήνυμα, παρακαλούμε μην απαντήσετε.</i></p></br>" +
            "<br><b> © Copyright 2022 - Mobile Technology - All Rights Reserved</b></br>" +
            "<br><b>MOBILE TECHNOLOGY A.E.</b></br>" +
            "<br>");

            //<center><img src=""cid:{0}""></center>"//, image.ContentId);

            // We may also want to attach a calendar event for Monica's party...

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            var client = new SmtpClient();
            client.CheckCertificateRevocation = false;

            try
            {
                await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, false);
                await client.AuthenticateAsync(new NetworkCredential(smtpSettings.SenderEmail, smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }

        }

        public async Task<string> SendEmailAsync1(
            string recipientEmail,
            string recipientFirstName,
            string Link,
            SmtpSettings settings,
            CsLockersTransaction lockersTransaction)

        {
            string QRstring = lockersTransaction.TaskCode.Split("-")[1] + "-" +
                lockersTransaction.CustomerCode + "-" +
                lockersTransaction.CustomerBranchCode;

            byte[] byteArray = GenerateQRcode(QRstring);

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(settings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Mobile Technology MTLockers";

            var builder = new BodyBuilder();
            string image = "data:image/png;base64," + Convert.ToBase64String(byteArray);

            // Set the plain-text version of the message text
            builder.TextBody = @"Γειά σας,
            για την παραλαβή του προς επισκευή σας εξοπλισμού, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων της MobileTechnology
            την «ημερομηνία δέσμευσης». 
            Μπορείτε να παραλάβετε το δέμα σας απο τα MΤ Lockers με τη χρήση του παρακάτω QR code:

            Με εκτίμηση,

            -- Mobile Technology
            ";

            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.
            //var image = builder.LinkedResources.Add(@"C:\Users\salexiou.MOBILETECH\Downloads\1.jpg");
            //image.ContentId = MimeUtils.GenerateMessageId();

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@$"<b><p>Γειά σας, <br>
            <p>για την παραλαβή του προς επισκευή σας εξοπλισμού, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων <<{lockersTransaction.ParcelNumber}>> της MobileTechnology
            την ημερομηνία δέσμευσης: <<{lockersTransaction.BookingDate}>>.<br>
            <p>Μπορείτε να παραλάβετε το δέμα σας απο τα MΤ Lockers με τη χρήση του παρακάτω QR code:</b><br>" +
            "<center><tb><img src='" + image + "'/> </center>" +
            "<p><br><i> Αυτό είναι ένα αυτοματοποιημένο ηλεκτρονικό μήνυμα, παρακαλούμε μην απαντήσετε.</i></p></br>" +
            "<br><b> © Copyright 2022 - Mobile Technology - All Rights Reserved</b></br>" +
            "<br><b>MOBILE TECHNOLOGY A.E.</b></br>" +
            "<br>");


            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            var client = new SmtpClient();
            client.CheckCertificateRevocation = false;

            try
            {
                await client.ConnectAsync(settings.Server, settings.Port, false);
                await client.AuthenticateAsync(new NetworkCredential(settings.SenderEmail, settings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }

        public async Task<string> SendEmailAsync3(string recipientEmail,
            string recipientFirstName,
            string Link,
            SmtpSettings smtpSettings,
            CsLockersTransaction lockersTransaction)
        {

            string QRstring = lockersTransaction.TaskCode.Split("-")[1] + "-" +
                lockersTransaction.CustomerCode + "-" +
                lockersTransaction.CustomerBranchCode;

            byte[] byteArray = GenerateQRcode(QRstring);

            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Mobile Technology MTLockers";


            var builder = new BodyBuilder();
            string image = "data:image/png;base64," + Convert.ToBase64String(byteArray);

            // Set the plain-text version of the message text
            builder.TextBody = @"Γεια σας,

            Η παραγγελία σας είναι έτοιμη και θα βρίσκεται στη θυρίδα δεμάτων των ΜΤ Lockers προς παραλαβή 
            την «ημερομηνία δέσμευσης». 
            Μπορείτε να παραλάβετε το δέμα σας με τη χρήση του παρακάτω QR code:

            Με εκτίμηση,

            -- Mobile Technology
            ";

            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.
            //var image = builder.LinkedResources.Add(@"C:\Users\salexiou.MOBILETECH\Downloads\1.jpg");
            //image.ContentId = MimeUtils.GenerateMessageId();

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@$" < b >< p > Γειά σας, < br >
            < p > Η παραγγελία σας είναι έτοιμη και θα βρίσκεται στη θυρίδα δεμάτων των ΜΤ Lockers προς παραλαβή
            την ημερομηνία δέσμευσης: <<{lockersTransaction.BookingDate}>>.<br>
            < p > Μπορείτε να παραλάβετε το δέμα σας με τη χρήση του παρακάτω QR code:</ b >< br > " +
            "<center><tb><img src='" + image + "'/> </center>" +
            "<p><br><i> Αυτό είναι ένα αυτοματοποιημένο ηλεκτρονικό μήνυμα, παρακαλούμε μην απαντήσετε.</i></p></br>" +
            " <p><br><b> © Copyright 2022 - Mobile Technology - All Rights Reserved</b></p></br>" +
            "<p><br><b>MOBILE TECHNOLOGY A.E.</b></p></br>" +
            "<br>");

            //<center><img src=""cid:{0}""></center>", image.ContentId);

            // We may also want to attach a calendar event for Monica's party...

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            var client = new SmtpClient();
            client.CheckCertificateRevocation = false;

            try
            {
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, false);
                await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }

        }

        public async Task<string> SendEmailAsync4(
             string recipientEmail,
             string recipientFirstName,
             string Link,
             SmtpSettings smtpSettings,
             CsLockersTransaction lockersTransaction)
        {


            string QRstring = lockersTransaction.TaskCode.Split("-")[1] + "-" +
                lockersTransaction.CustomerCode + "-" +
                lockersTransaction.CustomerBranchCode;

            byte[] byteArray = GenerateQRcode(QRstring);

            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Mobile Technology MTLockers";


            var builder = new BodyBuilder();
            string image = "data:image/png;base64," + Convert.ToBase64String(byteArray);
            // Set the plain-text version of the message text
            builder.TextBody = @"Γεια σας,

            Η παράδοση του δέματός σας από τα MT Lockers πραγματοποιήθηκε επιτυχώς.

            Με εκτίμηση,

            -- Mobile Technology
            ";


            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@$"<b><p>Γειά σας, <br>
            <p>Η παράδοση του δέματός σας πραγματοποιήθηκε επιτυχώς.<br>" +
            "<p><br><i> Αυτό είναι ένα αυτοματοποιημένο ηλεκτρονικό μήνυμα, παρακαλούμε μην απαντήσετε.</i></p></br>" +
            " <p><br><b> © Copyright 2022 - Mobile Technology - All Rights Reserved</b></p></br>" +
            "<p><br><b>MOBILE TECHNOLOGY A.E.</b></p></br>" +
            "<br>");

            //<center><img src=""cid:{0}""></center>"//, image.ContentId);

            // We may also want to attach a calendar event for Monica's party...

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            var client = new SmtpClient();
            client.CheckCertificateRevocation = false;

            try
            {
                await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, false);
                await client.AuthenticateAsync(new NetworkCredential(smtpSettings.SenderEmail, smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }

        }

        public async Task<string> SendEmailAsync5(
            string recipientEmail,
            string recipientFirstName,
            string Link,
            SmtpSettings smtpSettings,
            CsLockersTransaction lockersTransaction)
        {


            string QRstring = lockersTransaction.TaskCode.Split("-")[1] + "-" +
                lockersTransaction.CustomerCode + "-" +
                lockersTransaction.CustomerBranchCode;

            byte[] byteArray = GenerateQRcode(QRstring);

            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Mobile Technology MTLockers";


            var builder = new BodyBuilder();
            string image = "data:image/png;base64," + Convert.ToBase64String(byteArray);
            // Set the plain-text version of the message text
            builder.TextBody = @"Γεια σας,

            για την παράδοση του προς επισκευή εξοπλισμού σας, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων της MobileTechnology 
            την «ημερομηνία δέσμευσης». 
            Μπορείτε να παραδώσετε το δέμα σας στα Mobile Lockers  με τη χρήση του παρακάτω QR code:

            Με εκτίμηση,

            -- Mobile Technology
            ";


            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@$"<b><p>Γειά σας, <br>
            <p>Η παραλαβή του δέματός σας πραγματοποιήθηκε επιτυχώς.<br>" +
            "<p><br><i> Αυτό είναι ένα αυτοματοποιημένο ηλεκτρονικό μήνυμα, παρακαλούμε μην απαντήσετε.</i></p></br>" +
            " <p><br><b> © Copyright 2022 - Mobile Technology - All Rights Reserved</b></p></br>" +
            "<p><br><b>MOBILE TECHNOLOGY A.E.</b></p></br>" +
            "<br>");
            //<center><img src=""cid:{0}""></center>"//, image.ContentId);

            // We may also want to attach a calendar event for Monica's party...

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            var client = new SmtpClient();
            client.CheckCertificateRevocation = false;

            try
            {
                await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, false);
                await client.AuthenticateAsync(new NetworkCredential(smtpSettings.SenderEmail, smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }

        }

        public async Task<string> SendEmailAsync6(
            string recipientEmail,
            string recipientFirstName,
            string Link,
            SmtpSettings smtpSettings,
            CsLockersTransaction lockersTransaction)
        {


            string QRstring = lockersTransaction.TaskCode.Split("-")[1] + "-" +
                lockersTransaction.CustomerCode + "-" +
                lockersTransaction.CustomerBranchCode;

            byte[] byteArray = GenerateQRcode(QRstring);

            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(recipientEmail));
            message.Subject = "Mobile Technology MTLockers";


            var builder = new BodyBuilder();
            string image = "data:image/png;base64," + Convert.ToBase64String(byteArray);
            // Set the plain-text version of the message text
            builder.TextBody = @"Γεια σας,

            για την παράδοση του προς επισκευή εξοπλισμού σας, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων της MobileTechnology 
            την «ημερομηνία δέσμευσης». 
            Μπορείτε να παραδώσετε το δέμα σας στα Mobile Lockers  με τη χρήση του παρακάτω QR code:

            Με εκτίμηση,

            -- Mobile Technology
            ";


            // In order to reference selfie.jpg from the html text, we'll need to add it
            // to builder.LinkedResources and then use its Content-Id value in the img src.

            // Set the html version of the message text
            builder.HtmlBody = string.Format(@$"<b><p>Γειά σας, <br>
            <p>για την παράδοση του προς επισκευή εξοπλισμού σας, μπορείτε να χρησιμοποιήσετε τη θυρίδα δεμάτων της MobileTechnology
            την «ημερομηνία δέσμευσης».<br>
            <p>Μπορείτε να παραδώσετε το δέμα σας στα Mobile Technology Lockers με τη χρήση του παρακάτω QR code:</b><br>" +
            "<center><tb><img src='" + image + "'/> </center>" +
            "<p><br><i> Αυτό είναι ένα αυτοματοποιημένο ηλεκτρονικό μήνυμα, παρακαλούμε μην απαντήσετε.</i></p></br>" +
            " <p><br><b> © Copyright 2022 - Mobile Technology - All Rights Reserved</b></p></br>" +
            "<p><br><b>MOBILE TECHNOLOGY A.E.</b></p></br>" +
            "<br>");

            //<center><img src=""cid:{0}""></center>"//, image.ContentId);

            // We may also want to attach a calendar event for Monica's party...

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();


            var client = new SmtpClient();
            client.CheckCertificateRevocation = false;

            try
            {
                await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, false);
                await client.AuthenticateAsync(new NetworkCredential(smtpSettings.SenderEmail, smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }

        }

        //public async Task<string> SendEmailAsync(
        //     string recipientEmail, 
        //     string recipientFirstName, 
        //     string Link, 
        //     SmtpSettings smtpSettings,
        //     CsLockersTransaction lockersTransaction)
        // {

        //     var message = new MimeMessage();
        //     message.From.Add(MailboxAddress.Parse(recipientEmail));
        //     message.Subject = "This is My Email subject";
        //     message.Body = new TextPart("plain")
        //     {
        //         Text = "This is my email Body"
        //     };

        //     var client = new SmtpClient();
        //     client.CheckCertificateRevocation = false;
        //     try
        //     {
        //         await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, false);
        //         await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
        //         await client.SendAsync(message);
        //         await client.DisconnectAsync(true);
        //         return ("Successfull");
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        //     finally 
        //     {
        //         client.Dispose();
        //     }
        // }


        private byte[] GenerateQRcode(String qrText)
        {

            Byte[] byteArray;
            var width = 250; // width of the Qr Code
            var height = 250; // height of the Qr Code
            var margin = 0;
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };
            var pixelData = qrCodeWriter.Write(qrText);

            // creating a bitmap from the raw pixel data; if only black and white colors are used it makes no difference
            // that the pixel data ist BGRA oriented and the bitmap is initialized with RGB
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                using (var ms = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    try
                    {
                        // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    // save to stream as PNG
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byteArray = ms.ToArray();
                    return byteArray;
                }
            }

        }

    }
}
