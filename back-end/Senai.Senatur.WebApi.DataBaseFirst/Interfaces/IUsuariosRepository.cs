using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuarios> Listar();

        Usuarios BuscarPorId(int id);

        void Cadastrar(Usuarios novoUsuario);

        void Atualizar(int id, Usuarios usuarioAtualizado);

        void Deletar(int id);

        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
