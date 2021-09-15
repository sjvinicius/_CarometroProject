using Carometro.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Comum.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
