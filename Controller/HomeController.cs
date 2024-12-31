using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly EmailService _emailService;

    public HomeController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult SendEmail()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(string toEmail, string subject, string body)
    {
        var result = await _emailService.SendEmailAsync(toEmail, subject, body);

        if (result)
        {
            ViewBag.Message = "Email sent successfully.";
        }
        else
        {
            ViewBag.Message = "Failed to send email.";
        }

        return View();
    }
}
