using System;

namespace atividade;

public class CofreDigital
{
    private readonly string _dono;
    private string _senha;
    private bool _estaAberto;
    private int _tentativasErradas;
    private bool _bloqueado;

    public string Dono => _dono;
    public bool EstaAberto => _estaAberto;
    public int TentativasErradas => _tentativasErradas;
    public bool Bloqueado => _bloqueado;

    public CofreDigital(string dono, string senhaInicial)
    {
        _dono = dono;
        _senha = senhaInicial;
        _estaAberto = false;
        _tentativasErradas = 0;
        _bloqueado = false;
    }

    public string Abrir(string senhaInformada)
    {
        if (_bloqueado)
            return "Cofre Bloqueado. Reinicie o objeto para desbloquear.";

        if (_senha == senhaInformada)
        {
            _estaAberto = true;
            _tentativasErradas = 0;
            return "Cofre aberto com sucesso.";
        }

        _tentativasErradas++;

        if (_tentativasErradas >= 3)
        {
            _bloqueado = true;
            return "Cofre Bloqueado após 3 tentativas erradas.";
        }

        return $"Senha incorreta. Tentativas restantes: {3 - _tentativasErradas}.";
    }

    public void Fechar()
    {
        _estaAberto = false;
    }

    public bool AlterarSenha(string senhaAntiga, string novaSenha)
    {
        if (!_estaAberto)
        {
            Console.WriteLine("O cofre precisa estar aberto para alterar a senha.");
            return false;
        }

        if (_senha != senhaAntiga)
        {
            Console.WriteLine("Senha antiga incorreta.");
            return false;
        }

        _senha = novaSenha;
        Console.WriteLine("Senha alterada com sucesso.");
        return true;
    }

    public void Resetar()
    {
        _tentativasErradas = 0;
        _bloqueado = false;
        _estaAberto = false;
        Console.WriteLine("Cofre resetado.");
    }

    public override string ToString()
    {
        string status = _bloqueado ? "BLOQUEADO" : (_estaAberto ? "Aberto" : "Fechado");
        return $"Cofre de {_dono} - Status: {status} - Tentativas erradas: {_tentativasErradas}";
    }
}