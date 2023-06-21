using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Util.Email.Interface
{
    public interface IEmailHelper
    {
        public Task<bool> SendEmail(string userEmail, string message);

    }
}
