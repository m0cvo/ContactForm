# ContactForm
Created by Nigel Booth for Mogpie Software.

This is a demonstration of how to produce a dynamic contact form using ASP.Net Core and Razor pages (.cshtml & C#).

The smtp connection details in this example are for Microsoft Outlook or Hotmail. You can use whichever email service you
wish and obtain the SMTP commands from the service provider.

All the work is done using MailKit which is available as a nuGet package.  Use your console manager to install it with the command:   Install-Package MailKit.  

This is because the standard SmtpClient that is part of the .Net package is not supported by all platforms.  MailKit however, is fully supported.  More information can be found at: https://github.com/jstedfast/MailKit. 

