using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestSecondReq
{
    [Theory(DisplayName = "Deve logar em uma conta!")]
    [InlineData(1, 2, 3)]
    public void TestLoginSucess(int number, int agency, int pass)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(number, agency, pass);

        instance.Login(number, agency, pass);

        var result = instance.Logged;

        result.Should().Be(true);
    }

    [Theory(DisplayName = "Deve retornar exceção ao tentar logar em conta já logada")]
    [InlineData(1, 2, 3)]
    public void TestLoginExceptionLogged(int number, int agency, int pass)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(number, agency, pass);

        instance.Login(number, agency, pass);

        Action act = () => instance.Login(number, agency, pass);

        act.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve retornar exceção ao errar a senha")]
    [InlineData(1, 2, 3)]
    public void TestLoginExceptionWrongPass(int number, int agency, int pass)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(number, agency, pass);

        Action act = () => instance.Login(number, agency, 101010);

        act.Should().Throw<ArgumentException>().WithMessage("Senha incorreta");
    }

    [Theory(DisplayName = "Deve retornar exceção ao digitar conta que não existe")]
    [InlineData(1, 2, 3)]
    public void TestLoginExceptionNotFounded(int number, int agency, int pass)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(number, agency, pass);

        Action act = () => instance.Login(101010, 111111, pass);

        act.Should().Throw<ArgumentException>().WithMessage("Agência + Conta não encontrada");
    }

    [Theory(DisplayName = "Deve sair de uma conta!")]
    [InlineData(1, 2, 3)]
    public void TestLogoutSucess(int number, int agency, int pass)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(number, agency, pass);

        instance.Login(number, agency, pass);

        instance.Logout();

        var logged = instance.Logged;
        var loggedUser = instance.loggedUser;

        logged.Should().Be(false);
        loggedUser.Should().Be(-99);

    }

    [Theory(DisplayName = "Deve retornar exceção ao sair quando não está logado")]
    [InlineData(1, 2, 3)]
    public void TestLogoutExceptionNotLogged(int number, int agency, int pass)
    {        
        var instance = new Trybank();

        instance.RegisterAccount(number, agency, pass);

        Action act = () => instance.Logout();

        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

}
