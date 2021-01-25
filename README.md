# Exame de Programador C\#

## Objetivo
Desenvolver uma API em C# com .NET Core que simule algumas funcionalidades de um banco digital.

## Desafio
Você deverá garantir que o usuário conseguirá realizar uma movimentação de sua conta corrente para quitar uma dívida.

## Cenários

1 - 
{
  DADO QUE eu consuma a API <br>
  QUANDO eu chamar a mutation `sacar` informando o número da conta e um valor válido<br>
  ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo<br>
  E a mutation retornará o saldo atualizado.
}

2 - 
{
  DADO QUE eu consuma a API <br>
  QUANDO eu chamar a mutation `sacar` informando o número da conta e um valor maior do que o meu saldo<br>
  ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente
}

3 - 
{
  DADO QUE eu consuma a API <br>
  QUANDO eu chamar a mutation `depositar` informando o número da conta e um valor válido<br>
  ENTÃO a mutation atualizará o saldo da conta no banco de dados<br>
  E a mutation retornará o saldo atualizado.
}

4 -
{
  DADO QUE eu consuma a API <br>
  QUANDO eu chamar a query `saldo` informando o número da conta<br>
  ENTÃO a query retornará o saldo atualizado.
}


## Instruções

* 1 - Package Manage Console -> Selecionar FuncionalTest.Data -> Update-Database
* 2 - Executar o ambiente IIS - Dev
* 3 - Importar a collection do Postman que está na pasta "postman" na pasta raiz do repositório
* 4 - Testar em REST ou GraphQL
* 5 - Executar primeiro o endpoint de criar conta, e com os dados obtidos, testar os demais endpoints.
