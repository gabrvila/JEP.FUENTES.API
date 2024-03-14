using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UsuarioNotFoundException : NotFoundException
    {
        public UsuarioNotFoundException(string nombreAcceso)
        : base($"El usuario {nombreAcceso} no existe en la base de datos.")
            {
            }
    }
}
