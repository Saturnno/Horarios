using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BusinessException:Exception
    {
        public BusinessException() { }
        public BusinessException(string message) : base(message)
        {
        }
        public BusinessException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}