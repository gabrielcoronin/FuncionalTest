using AutoMapper;
using FuncionalTest.Api.ViewModels;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FuncionalTest.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class AccountController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;


        public AccountController(IAccountRepository accountRepository, IAccountService accountService, IMapper mapper = null)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> VerificarSaldo(AccountModel model)
        {

        }

        [HttpPatch]
        public async Task<ActionResult> Sacar(AccountModel model)
        { 
            
        }

        [HttpPatch]
        public async Task<ActionResult> Depositar(AccountModel model)
        {

        }

        [HttpPost]
        public async Task<ActionResult> CriarConta (AccountModel model)
        {

        }


    }
}
