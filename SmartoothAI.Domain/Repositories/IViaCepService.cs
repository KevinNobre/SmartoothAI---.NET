using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartoothAI.Domain.Entities;

namespace SmartoothAI.Domain.Repositories
{
    public interface IViaCepService
    {
        Task<ViaCepResult> BuscarEnderecoPorCepAsync(string cep);
    }
}