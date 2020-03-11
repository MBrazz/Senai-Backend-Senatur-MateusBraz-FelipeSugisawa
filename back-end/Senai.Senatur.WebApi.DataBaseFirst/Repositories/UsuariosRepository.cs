using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using Senai.Senaitur.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaiturContext ctx = new SenaiturContext();

        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;


            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return usuarioBuscado;
        }

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(p => p.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuarios pacoteBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(pacoteBuscado);

            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
