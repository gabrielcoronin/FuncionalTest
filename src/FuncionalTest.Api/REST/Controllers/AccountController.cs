using FuncionalTest.Api.Validations;
using FuncionalTest.Domain.REST.Commands;
using FuncionalTest.Domain.REST.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FuncionalTest.Api.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("saldo")]
        public IActionResult VerificarSaldo(string contaId)
        {
            var conta = Guid.Parse(contaId);
            var command = new VerificarSaldoCommand(conta);
            var verificarSaldoValidator = new VerificarSaldoValidator();
            var validation = verificarSaldoValidator.Validate(command);

            var notification = _accountService.VerificarSaldo(command);

            if (validation.IsValid && notification.Success)
                return Ok(notification);

            return BadRequest(notification);
        }

        [HttpPatch]
        [Route("sacar")]
        public IActionResult Sacar(string contaId, string valor)
        {
            var conta = Guid.Parse(contaId);
            var valorSacado = double.Parse(valor);

            var command = new AccountCommand(conta, valorSacado);
            var sacarValidator = new SacarValidator();
            var validation = sacarValidator.Validate(command);

            var notification = _accountService.Sacar(command);

            if (validation.IsValid && notification.Success)
                return Ok(notification);

            return BadRequest(notification);
        }

        [HttpPatch]
        [Route("depositar")]
        public IActionResult Depositar(string contaId, string valor)
        {
            var conta = Guid.Parse(contaId);
            var valorDepositado = double.Parse(valor);

            var command = new AccountCommand(conta, valorDepositado);
            var depositarValidator = new DepositarValidator();
            var validation = depositarValidator.Validate(command);

            var notification = _accountService.Depositar(command);

            if (validation.IsValid && notification.Success)
                return Ok(notification);

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
