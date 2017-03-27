using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Services
{
    public interface IMailer
    {
        bool SendMail(string fullName, string email, string message);
    }
}
