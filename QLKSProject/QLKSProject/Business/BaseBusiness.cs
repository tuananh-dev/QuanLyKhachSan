using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using QLKSProject.Models;


namespace QLKSProject.Business
{
    public class BaseBusiness : IDisposable
    {
        protected QLKSDbContext models;

        public BaseBusiness()
        {
            models = this.CreateModel();
        }
        private QLKSDbContext CreateModel()
        {
            return new QLKSDbContext();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseBusiness()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #region Ham Tai Su Dung
        protected string GuiMailTuDong(string toEmail,string subject, string body)
        {
            string senderID = "nguyenductuananh110@gmail.com";
            string senderPassword = "Anhanh01";
            string result = "Email Sent Successfully";
            
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress(senderID);
                mail.Subject = "My Test Email!";
                mail.Body = body;
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                result = "problem occurred";
            }
            return result;
        }
        #endregion
    }
}