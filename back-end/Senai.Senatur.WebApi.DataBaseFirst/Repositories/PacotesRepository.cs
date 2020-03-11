using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using Senai.Senaitur.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaiturContext ctx = new SenaiturContext();

        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            pacoteBuscado.Valor = pacoteAtualizado.Valor;
            pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;

            ctx.Pacotes.Update(pacoteBuscado);

            ctx.SaveChanges();
        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Cadastrar(Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            ctx.Pacotes.Remove(pacoteBuscado);

            ctx.SaveChanges();
        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }
    }
}
