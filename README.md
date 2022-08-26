# Boas-vindas ao repositório do projeto TryBank

# Requisitos

Boas-vindas ao TryBank, uma iniciativa de implementar um serviço de banco financeiro para sua instituição do coração.💚

Você recebeu a demanda de criar a versão inicial do TryBank, bem como seus testes. Nesse projeto, você tem como objetivo construir um banco que contenha contas. Além disso, deve criar e validar os processos de cadastro, login, saque, depósito e transferência do saldo dessas contas. 

De olho na dica👀: Faça uma boa separação de responsabilidades e crie testes estruturados, garantindo assim que a evolução desse sistema ocorra facilmente.
 

## 1 - O programa deve cadastrar novas contas
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir o cadastro de novas contas</summary><br />

Crie esse requisito na função `RegisterAccount()`

</details>

<details>
  <summary>Crie os testes para o cadastro de contas</summary><br />

Crie esse requisito em `src/trybank.Test/TestFirstReq.cs`

</details>

## 2 - A pessoa usuária deve conseguir fazer Login e Logout
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir o Login da pessoa usuária</summary><br />

Crie esse requisito na função `Login()`

O estado de pessoa usuária logada é controlado pela variável `Logged`

</details>

<details>
  <summary>O programa deve permitir o Logout do usário</summary><br />

Crie esse requisito na função `Logout()`

</details>

<details>
  <summary>Crie os testes para o Login</summary><br />

Crie esse requisito em `src/trybank.Test/TestSecondReq.cs`

</details>

<details>
  <summary>Crie os testes para o Logout</summary><br />

Crie esse requisito em `src/trybank.Test/TestSecondReq.cs`


</details>

## 3 - O programa deve permitir checar o saldo, depositar e sacar dinheiro

Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir verificar o saldo na conta da pessoa usária logada</summary><br />

Crie esse requisito na função `CheckBalance()`

</details>

<details>
  <summary>O programa deve permitir o depósito de um valor na conta da pessoa usária logada</summary><br />

Crie esse requisito na função `Deposit()`

</details>

<details>
  <summary>O programa deve permitir o saque de um valor na conta da pessoa usuária logada</summary><br />

Crie esse requisito na função `Withdraw()`

</details>

<details>
  <summary>Crie os testes para Checar o Saldo</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

</details>

<details>
  <summary>Crie os testes para o Deposito</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

</details>

<details>
  <summary>Crie os testes para o Sacar</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

</details>

## 4 - O programa deve transferir dinheiro entre contas
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir a transferência de saldo entre uma pessoa usuária logada e uma conta existente</summary><br />

Crie esse requisito na função `    public void Transfer(int destinationNumber, int destinationAgency, int value)
()`

</details>

<details>
  <summary>Crie os testes para a Transferência</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

</details>

Este projeto envolve os conhecimentos de estruturas de controle condicional e de repetição, além das exceções e seu controle sobre o fluxo de trabalho. A partir deste desafio, você certamente será uma pessoa mais bem preparada para os desafios do mercado de trabalho! #VQV 🚀
