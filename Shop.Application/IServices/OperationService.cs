using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public class OperationService : ITransientService, ISingletonService, IScopedService
    {

        private Guid _guid;

        public OperationService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid getGuid()
        {

            return _guid;
        }

    }
}
