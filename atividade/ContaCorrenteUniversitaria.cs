using System;

namespace atividade;

public class ContaCorrenteUniversitaria
{
    private readonly int _numeroConta;
    private string _titular;
    private double _saldo;
    private readonly double _limite;

    public int NumeroConta => _numeroConta;

    public string Titular
    {
        get => _titular;
        set => _titular = value;
    }

    public double Saldo => _saldo;
    public double Limite => _limite;

    // Campo calculado: saldo disponível + limite
    public double SaldoTotal => _saldo + _limite;

    // Campo calculado: status da conta
    public string StatusConta => _saldo < 0 ? "Negativo" : "Positivo";

    public ContaCorrenteUniversitaria(int numeroConta, string titular)
    {
        _numeroConta = numeroConta;
        _titular = titular;
        _saldo = 0;
        _limite = 500;
    }

    public bool Depositar(double valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo.");
            return false;
        }

        _saldo += valor;
        return true;
    }

    public bool Sacar(double valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo.");
            return false;
        }

        if (valor > SaldoTotal)
        {
            Console.WriteLine("Saldo insuficiente (incluindo limite).");
            return false;
        }

        _saldo -= valor;
        return true;
    }

    public override string ToString()
    {
        return $"Conta: {_numeroConta} | Titular: {_titular} | Saldo: {_saldo:F2} | Limite: {_limite:F2}";
    }
}
