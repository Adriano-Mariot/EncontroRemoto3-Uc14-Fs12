using CapituloApi.Interfaces;
//using CapituloApi.Repositories;
using CapituloApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapituloApi.Interfaces;

namespace CapituloApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
       
        private readonly ILivroRepository _iLivroRepository;

        public LivroController(ILivroRepository iLivroRepository)
        {
            _iLivroRepository = iLivroRepository;
        }

        // Professor Caiqui não usuou interface
        //private readonly LivroRepository _livroRepository;
        //public LivroController(LivroRepository livroRepository)
        //{
        //    _livroRepository = livroRepository;
        //}

        [HttpGet]
        public IActionResult Listar() 
        {
            try 
            {
                // return Ok(_iLivroRepository.ler()); prof- matheus
                return Ok(_iLivroRepository.ler());
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("(Id)")]
        public IActionResult BuscarPorId(int Id)
        {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorId(Id);
                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro); 
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _iLivroRepository.Cadastrar(livro);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        [HttpPut ("(Id)")]
        public IActionResult Atualizar(int Id, Livro livro)
        {
            try
            {
                _iLivroRepository.Atualizar(Id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        [HttpDelete("(Id)")]
        public IActionResult Deletar(int Id)
        {
            try
            {
                _iLivroRepository.Deletar(Id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
