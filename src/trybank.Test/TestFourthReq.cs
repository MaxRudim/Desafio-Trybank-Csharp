using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFourthReq
{
    [Theory(DisplayName = "Deve transefir um valor com uma conta logada")]
    [InlineData(1000, 300)]
    public void TestTransferSucess(int balance, int value)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(1, 2, 3);
        instance.RegisterAccount(4, 5, 6);

        instance.Login(1, 2, 3);

        instance.Deposit(balance);

        instance.Transfer(4, 5, value);

        var result1 = instance.CheckBalance();

        result1.Should().Be(balance - value);

        instance.Logout();

        instance.Login(4, 5, 6);

        var result2 = instance.CheckBalance();

        result2.Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestTransferWithoutLogin(int value)
    {        
        var instance = new Trybank();

        Action act = () => instance.Transfer(1, 2, value);

        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção caso o saldo a ser transferido seja insuficiente")]
    [InlineData(500, 1000)]
    public void TestTransferWithoutBalance(int balance, int value)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(1, 2, 3);

        instance.Login(1, 2, 3);

        instance.Deposit(balance);

        Action act = () => instance.Transfer(4, 5, value);

        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}
