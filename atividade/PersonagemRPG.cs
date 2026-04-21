using System;

namespace atividade;

public class PersonagemRPG
{
    private readonly string _nome;
    private readonly string _classe;
    private int _nivel;
    private double _vidaAtual;
    private double _vidaMaxima;

    public string Nome => _nome;
    public string Classe => _classe;
    public int Nivel => _nivel;
    public double VidaAtual => _vidaAtual;
    public double VidaMaxima => _vidaMaxima;
    public bool EstaMorto => _vidaAtual <= 0;

    public PersonagemRPG(string nome, string classe)
    {
        _nome = nome;
        _classe = classe;
        _nivel = 1;

        _vidaMaxima = _classe.ToLower() == "guerreiro" ? 150 : 80;
        _vidaAtual = _vidaMaxima;
    }

    public void ReceberDano(double pontos)
    {
        if (pontos <= 0) return;

        _vidaAtual -= pontos;

        if (_vidaAtual < 0)
            _vidaAtual = 0;
    }

    public bool Curar(double pontos)
    {
        if (EstaMorto)
        {
            Console.WriteLine($"{_nome} está morto e não pode ser curado.");
            return false;
        }

        if (pontos <= 0) return false;

        _vidaAtual += pontos;

        if (_vidaAtual > _vidaMaxima)
            _vidaAtual = _vidaMaxima;

        return true;
    }

    public bool SubirNivel()
    {
        if (EstaMorto)
        {
            Console.WriteLine($"{_nome} está morto e não pode subir de nível.");
            return false;
        }

        if (_nivel >= 99)
        {
            Console.WriteLine($"{_nome} já está no nível máximo (99).");
            return false;
        }

        _nivel++;
        _vidaMaxima *= 1.10;
        _vidaAtual = _vidaMaxima;

        return true;
    }

    public void Ressuscitar()
    {
        _vidaAtual = _vidaMaxima;
        Console.WriteLine($"{_nome} foi ressuscitado! Nível mantido: {_nivel}.");
    }

    public override string ToString()
    {
        return $"{_nome} ({_classe}) - Lvl {_nivel} - HP: {_vidaAtual:F0}/{_vidaMaxima:F0}";
    }
}
