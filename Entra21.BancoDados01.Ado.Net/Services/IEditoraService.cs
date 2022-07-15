using Entra21.BancoDados01.Ado.Net.DataBase1;
using Entra21.BancoDados01.Ado.Net.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.BancoDados01.Ado.Net.Services
{
    internal interface IEditoraService
    {
        List<Editora> ObterTodos();


    }
}
