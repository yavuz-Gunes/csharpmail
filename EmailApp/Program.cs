using System;
using MailKit.Net.Smtp;
using MimeKit;

class Program
{
    static void Main(string[] args)
    {
        SendEmail("GÖNDERİLCEK KİŞİ MAİL", "Test Subject", "Test Email Body").Wait();
    }

    public static async Task SendEmail(string toEmail, string subject, string body)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Your Name", "GÖNDEREN MAİL ADRESİ"));
        emailMessage.To.Add(new MailboxAddress("", toEmail));
        emailMessage.Subject = subject;

        var bodyBuilder = new BodyBuilder { TextBody = body };
        emailMessage.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            try
            {
                // SMTP sunucu bilgilerini ve kimlik doğrulama bilgilerinizi girin
                await client.ConnectAsync("mail.server.com", 587, false);    // SERVER DEĞİŞTİR FACEANDBRAST
                await client.AuthenticateAsync("deneme@kaansari.com.tr", "deneme123.");  //// GÖNDEREN MAİL ŞİFRE
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);

                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
