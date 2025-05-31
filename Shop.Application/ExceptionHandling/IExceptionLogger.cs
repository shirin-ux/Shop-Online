using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ExceptionHandling
{
   public interface IExceptionLogger
   {
       Task Log(Exception ex);
   }
}
