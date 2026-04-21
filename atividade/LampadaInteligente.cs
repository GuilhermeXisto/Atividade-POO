using System;

namespace atividade;

public class LampadaInteligente
{
    private string _marca;
    private readonly string _tecnologia;
    private bool _ligada;
    private int _brilho;

    public string Marca => _marca;
    public string Tecnologia => _tecnologia;
    public bool Ligada => _ligada;
    public int Brilho => _brilho;

    public LampadaInteligente(string marca, string tecnologia)
    {
        _marca = marca;
        _tecnologia = tecnologia;
        _ligada = false;
        _brilho = 100;
    }

    public void Alternar()
    {
        _ligada = !_ligada;
    }

    public bool AjustarBrilho(int novoBrilho)
    {
        if (!_ligada)
        {
            Console.WriteLine("Não é possível ajustar o brilho com a lâmpada desligada.");
            return false;
        }

        if (novoBrilho < 0 || novoBrilho > 100)
        {
            Console.WriteLine("Brilho inválido. Informe um valor entre 0 e 100.");
            return false;
        }

        _brilho = novoBrilho;
        return true;
    }

    public override string ToString()
    {
        string estado = _ligada ? "Ligada" : "Desligada";
        return $"Lâmpada {_marca} ({_tecnologia}) - {estado} - Brilho: {_brilho}%";
    }
}
