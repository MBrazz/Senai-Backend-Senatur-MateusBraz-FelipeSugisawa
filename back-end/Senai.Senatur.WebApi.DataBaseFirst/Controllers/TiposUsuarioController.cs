using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senaitur.WebApi.DataBaseFirst.Interfaces;
using Senai.Senaitur.WebApi.DataBaseFirst.Repositories;

namespace Senai.Senaitur.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]

    // Define que somente o tipo de usuário 1 (administrador) pode acessar os endpoints
    [Authorize(Roles = "1")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposUsuarioRepository.Listar());
        }

    }
}