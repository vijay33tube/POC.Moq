using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace POC.Moq
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var moqEmailService = new Mock<IEmailService>();

            moqEmailService.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var emailer = new Emailer(moqEmailService.Object);

            emailer.SendBatchEmails();
        }
    }

    public class Emailer
    {
        private IEmailService emailService = null;
        public Emailer(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void SendBatchEmails()
        {
            if(!emailService.SendMail("a","b"))
            {
                throw new Exception("Some error");
            }
        }
    }

    public interface IEmailService
    {
        bool SendMail(string email, string message);
    }

    public class EmailService : IEmailService
    { 
        public bool SendMail(string email, string message)
        {
            return false;
        }
    }
}
