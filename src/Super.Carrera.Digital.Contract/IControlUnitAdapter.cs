using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.Carrera.Digital.Contract
{
    internal interface IControlUnitAdapter
    {
        Task SendAsync(byte[] startCommand);
    }
}
