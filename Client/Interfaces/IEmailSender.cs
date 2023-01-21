﻿namespace BlazorApp.Client.Interfaces
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
