using FuncionalTest.Api.Validations;
using FuncionalTest.Domain.REST.Commands;
using FuncionalTest.Domain.REST.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FuncionalTest.Api.V2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
             

        [HttpPost]
        [Route("criarConta")]
        public IActionResult Criarconta()
        {            
            var notification = _accountService.CriarConta();

            if (notification.Success) return Ok(notification);

            return BadRequest(notification);
        }
    }
}
