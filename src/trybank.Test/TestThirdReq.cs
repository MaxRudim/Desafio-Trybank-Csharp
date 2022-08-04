using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestThirdReq
{
    [Theory(DisplayName = "Deve devolver o saldo em uma conta logada")]
    [InlineData(0)]
    public void TestCheckBalanceSucess(int balance)
    {        
        var instancee = new Trybank();

        instancee.RegisterAccount(1, 2, 3);

        instancee.Login(1, 2, 3);

        var result = instancee.CheckBalance();

        result.Should().Be(balance);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestCheckBalanceWithoutLogin(int balance)
    {        
        var instance = new Trybank();

        // Só para usar o parâmetro, pois ele não é necessário.
        instance.RegisterAccount(balance, 2, 3);

        Action act = () => instance.CheckBalance();

        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve depositar um saldo em uma conta logada")]
    [InlineData(500)]
    public void TestDepositSucess(int value)
    {        
        var instancee = new Trybank();

        instancee.RegisterAccount(1, 2, 3);

        instancee.Login(1, 2, 3);

        instancee.Deposit(value);

        var result = instancee.CheckBalance();

        result.Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestDepositWithoutLogin(int value)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(1, 2, 3);

        Action act = () => instance.Deposit(value);

        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve sacar um valor em uma conta logada")]
    [InlineData(500, 200)]
    public void TestWithdrawSucess(int balance, int value)
    {        
        var instancee = new Trybank();

        instancee.RegisterAccount(1, 2, 3);

        instancee.Login(1, 2, 3);

        instancee.Deposit(balance);

        instancee.Withdraw(value);

        int total = balance - value;

        var result = instancee.CheckBalance();

        result.Should().Be(total);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestWithdrawWithoutLogin(int value)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(1, 2, 3);

        Action act = () => instance.Withdraw(value);

        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção quando o saldo for insuficiente")]
    [InlineData(500, 1000)]
    public void TestWithdrawWithoutBalance(int balance, int value)
    {        
        var instancee = new Trybank();

        instancee.RegisterAccount(1, 2, 3);

        instancee.Login(1, 2, 3);

        instancee.Deposit(balance);

        Action act = () => instancee.Withdraw(value);

        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}