using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;
using TodoApi.Domain.Repositories.Exceptions;
using TodoApi.Domain.ViewModels;
using TodoApi.Domain.ViewModels.TodoViewModels;

namespace TodoApi.Application.Controllers
{
    public class TodosController : BaseController
    {
        private readonly IBaseRepository<Todo> _todoRepository;
        private readonly IMapper _mapper;

        public TodosController(IBaseRepository<Todo> todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere um novo lembrete no banco de dados.
        /// </summary>
        /// <param name="inputModel">O lembrete a ser criado.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Todo))]
        [ProducesResponseType(400, Type = typeof(ErrorViewModel))]
        public async Task<IActionResult> Create([FromBody] TodoInputModel inputModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Todo todo = _mapper.Map<Todo>(inputModel);
                    await _todoRepository.InsertAsync(todo);
                    return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
                }

                return BadRequest(new ErrorViewModel(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(error => error.Errors).Select(message => message.ErrorMessage).ToList()));
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new ErrorViewModel(HttpStatusCode.BadRequest, "Não é possível criar um lembrete vazio."));
            }
        }

        /// <summary>
        /// Recupera um lembrete correspondente ao ID fornecido.
        /// </summary>
        /// <param name="id">O ID do lembrete a ser recuperado.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Todo))]
        [ProducesResponseType(400, Type = typeof(ErrorViewModel))]
        [ProducesResponseType(404, Type = typeof(ErrorViewModel))]
        public async Task<IActionResult> GetById(int? id)
        {
            try
            {
                return Ok(await _todoRepository.GetByIdAsync(id));
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new ErrorViewModel(HttpStatusCode.BadRequest, "Insira um número identificador (ID) válido."));
            }
            catch (NotFoundException)
            {
                return NotFound(new ErrorViewModel(HttpStatusCode.NotFound, "Não foi possível encontrar um lembrete correspondente ao ID fornecido."));
            }
        }

        /// <summary>
        /// Recupera todos os lembretes registrados no banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Todo>))]
        public async Task<IActionResult> GetAll() => Ok(await _todoRepository.GetAll());

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Todo))]
        [ProducesResponseType(400, Type = typeof(ErrorViewModel))]
        [ProducesResponseType(404, Type = typeof(ErrorViewModel))]
        public async Task<IActionResult> Update(int? id, TodoInputModel inputModel)
        {
            try
            {
                Todo todo = _mapper.Map<Todo>(inputModel);
                await _todoRepository.UpdateAsync(id, todo);
                return Ok(todo);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new ErrorViewModel(HttpStatusCode.BadRequest, "Insira um número identificador (ID) válido."));
            }
            catch (NotFoundException)
            {
                return NotFound(new ErrorViewModel(HttpStatusCode.NotFound, "Não foi possível recuperar nenhum lembrete correspondete ao ID fornecido."));
            }
        }

        /// <summary>
        /// Remove um lembrete do banco de dados correspondente ao ID fornecido.
        /// </summary>
        /// <param name="id">O ID do lembrete a ser excluído.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(ErrorViewModel))]
        [ProducesResponseType(404, Type = typeof(ErrorViewModel))]
        public async Task<IActionResult> Remove(int? id)
        {
            try
            {
                await _todoRepository.RemoveAsync(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound(new ErrorViewModel(HttpStatusCode.NotFound, "Não foi possível encontrar um lembrete correspondente ao ID fornecido."));
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new ErrorViewModel(HttpStatusCode.BadRequest, "Insira um número identificador (ID) válido."));
            }
        }
    }
}
