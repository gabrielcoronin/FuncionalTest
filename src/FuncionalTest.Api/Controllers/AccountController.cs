using AutoMapper;
using FuncionalTest.Api.ViewModels;
using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FuncionalTest.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper = null)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("saldo")]
        public IActionResult VerificarSaldo(AccountModel model)
        {
            var command = _mapper.Map<VerificarSaldoCommand>(model);

            var notification = _accountService.VerificarSaldo(command);

            if (notification.Success) return Ok(notification);

            return BadRequest(notification);
        }

        [HttpPatch]
        [Route("sacar")]
        public IActionResult Sacar(AccountModel model)
        {
            var command = _mapper.Map<SacarCommand>(model);

            var notification = _accountService.Sacar(command);

            if (notification.Success) return Ok(notification);

            return BadRequest(notification);
        }

        [HttpPatch]
        [Route("depositar")]
        public IActionResult Depositar(AccountModel model)
        {
            var command = _mapper.Map<DepositarCommand>(model);

            var notification = _accountService.Depositar(command);

            if (notification.Success) return Ok(notification);

            return BadRequest(notification);
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
