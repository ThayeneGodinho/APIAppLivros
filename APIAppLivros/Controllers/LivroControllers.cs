using APIAppLivros.Models;
using APIAppLivros.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace APIAppLivros.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosRepository _livrosRepository;

        public LivrosController(LivrosRepository livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        [Route("listar")]
        [SwaggerOperation(Summary = "Listar todos os livros", Description = "Este endpoint retorna um listagem de livros cadastradas.")]
        public async Task<IEnumerable<Livros>> Listar([FromQuery] bool? ativo = null)
        {
            return await _livrosRepository.ListarTodasLivros(ativo);
        }

        // GET api/<LivrosController>/5
        [HttpGet("detalhes/{id}")]
        [SwaggerOperation(
            Summary = "Obtém dados de um livro pelo ID",
            Description = "Este endpoint retorna todos os dados de um livro cadastrado filtrando pelo ID.")]
        public async Task<Livros> BuscarPorId(int id)
        {
            return await _livrosRepository.BuscarPorId(id);
        }

        // POST api/<LivrosController>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Cadastrar um novo Livro",
            Description = "Este endpoint é responsavel por cadastrar um novo livro no banco")]
        public async void Post([FromBody] Livros dados)
        {
            await _livrosRepository.Salvar(dados);
        }

        // PUT api/<LivrosController>/5
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizar os dados de Pessoa filtrando pelo ID.",
            Description = "Este endpoint é responsavel por atualizar os dados de uma pessoa no banco")]
        public async Task<IActionResult> Put(int id, [FromBody] Livros dados)
        {
            dados.Id = id;
            await _livrosRepository.Atualizar(dados);
            return Ok();
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remover um Livro filtrando pelo ID.",
            Description = "Este endpoint é responsavel por remover os dados de um livro no banco")]
        public async Task<IActionResult> Delete(int id)
        {
            await _livrosRepository.DeletarPorId(id);
            return Ok();
        }
    }

}
