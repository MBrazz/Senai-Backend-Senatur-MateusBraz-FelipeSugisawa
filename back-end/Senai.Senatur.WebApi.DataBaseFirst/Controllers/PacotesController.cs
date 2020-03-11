using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senaitur.WebApi.DataBaseFirst.Domains;
using Senai.Senaitur.WebApi.DataBaseFirst.Interfaces;
using Senai.Senaitur.WebApi.DataBaseFirst.Repositories;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Controllers
{   [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacoteRepository;

        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacoteRepository.Listar());
        }

        [Authorize(Roles = "1, 2")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacoteRepository.Cadastrar(novoPacote);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            _pacoteRepository.Atualizar(id, pacoteAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pacoteRepository.Deletar(id);

            return StatusCode(204);
        }


    }
}