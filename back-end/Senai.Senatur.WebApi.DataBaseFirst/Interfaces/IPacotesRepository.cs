using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> Listar();

        Pacotes BuscarPorId(int id);

        void Cadastrar(Pacotes novoPacote);

        void Atualizar(int id, Pacotes pacoteAtualizado);

        void Deletar(int id);
    }
}
