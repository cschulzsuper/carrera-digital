using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.Carrera.Digital
{
    public record ControlUnitTimer(
        int Controller,
        int Timestamp,
        int Sector);   
}
