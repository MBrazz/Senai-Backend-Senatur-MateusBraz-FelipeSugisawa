using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using Senai.Senaitur.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        SenaiturContext ctx = new SenaiturContext();

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }
    }
}
