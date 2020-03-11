using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Interfaces
{
    interface ITiposUsuarioRepository
    {
        List<TiposUsuario> Listar();
    }
}
