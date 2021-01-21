using FuncionalTest.Data.Context;
using FuncionalTest.Domain.Commands;
using FuncionalTest.Domain.Interfaces.IRepositories;
using FuncionalTest.Domain.Interfaces.IServices;
using FuncionalTest.Domain.Models;
using FuncionalTest.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace FuncionalTest.Test.AccountTest
{
    public class AccountServiceTest
    {
        protected IAccountService _accountService;
        protected IAccountRepository _accountRepository;

        protected Mock<IAccountRepository> _mockAccountRepository;

        protected Mock<MeuDbContext> _mockDbContext;
        protected DbSet<Account> _dbSetAccount;

        public AccountServiceTest()
        {
            _mockAccountRepository = new Mock<IAccountRepository>();
            _accountService = new AccountService(_mockAccountRepository.Object);
        }

        [Fact(DisplayName = "Account Service - Devera obter saldo")]
        [Trait("Categoria", "Account Service")]
        public void Obter_Saldo()
        {
            //Given
            var id = Guid.NewGuid();
            var command = new VerificarSaldoCommand(id);

            var conta = new Account
            {
                Id = id,
                Saldo = 150
            };

            command.Account = conta;

            //When
            _mockAccountRepository.Setup(c => c.BuscarConta(conta)).Returns(conta);

            //Then
            var notification = _accountService.VerificarSaldo(command);

            Assert.True(notification.Success);
        }              

        [Fact(DisplayName = "Account Service - Devera sacar se o valor for menor que o saldo")]
        [Trait("Categoria", "Account Service")]
        public void Devera_Sacar()
        {
            //Given
            var valor = 100;
            var id = Guid.NewGuid();
            var command = new AccountCommand(id, valor);

            var conta = new Account
            {
                Id = id,
                Saldo = 150
            };

            command.Account = conta;

            //When
            _mockAccountRepository.Setup(c => c.BuscarConta(conta)).Returns(conta);

            //Then
            var notification = _accountService.Sacar(command);

            Assert.True(notification.Success);
        }

        [Fact(DisplayName = "Account Service - NÃO devera sacar se o valor for maior que o saldo")]
        [Trait("Categoria", "Account Service")]
        public void Nao_Devera_Sacar()
        {
            //Given
            var valor = 200;
            var id = Guid.NewGuid();
            var command = new AccountCommand(id, valor);

            var conta = new Account
            {
                Id = id,
                Saldo = 150
            };

            command.Account = conta;

            //When
            _mockAccountRepository.Setup(c => c.BuscarConta(conta)).Returns(conta);

            //Then
            var notification = _accountService.Sacar(command);

            Assert.False(notification.Success);
        }

        [Fact(DisplayName = "Account Service - NÃO devera sacar se o valor for maior que o saldo")]
        [Trait("Categoria", "Account Service")]
        public void Nao_Devera_Sacar_Se_Saldo_For_Igual_A_Zero()
        {
            //Given
            var valor = 200;
            var id = Guid.NewGuid();
            var command = new AccountCommand(id, valor);

            var conta = new Account
            {
                Id = id,
                Saldo = 0
            };

            command.Account = conta;

            //When
            _mockAccountRepository.Setup(c => c.BuscarConta(conta)).Returns(conta);

            //Then
            var notification = _accountService.Sacar(command);

            Assert.False(notification.Success);
        }     

        [Fact(DisplayName = "Account Service - Deveria depositar normalmente")]
        [Trait("Categoria", "Account Service")]
        public void Devera_Depositar()
        {
            //Given
            var valor = 200;
            var id = Guid.NewGuid();
            var command = new AccountCommand(id, valor);

            var conta = new Account
            {
                Id = id,
                Saldo = 150
            };

            command.Account = conta;

            //When
            _mockAccountRepository.Setup(c => c.BuscarConta(conta)).Returns(conta);

            //Then
            var notification = _accountService.Depositar(command);

            Assert.True(notification.Success);
        }     
    }
}
