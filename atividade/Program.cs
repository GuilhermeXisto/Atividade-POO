// See https://aka.ms/new-console-template for more information
using System;
using atividade;

// ============================================================
//  Program.cs — Testes das 4 classes do exercício OOP C#
// ============================================================
class Program
{
    static void Main(string[] args)
    {
        // ---- 1. Lâmpada Inteligente --------------------------------
        Console.WriteLine("=== LÂMPADA INTELIGENTE ===");
        var lampada = new LampadaInteligente("Philips", "LED");
        Console.WriteLine(lampada);                  // desligada, brilho 100

        lampada.AjustarBrilho(50);                   // falha: desligada
        lampada.Alternar();                          // liga
        lampada.AjustarBrilho(75);                   // ok
        Console.WriteLine(lampada);                  // ligada, brilho 75

        lampada.Alternar();                          // desliga
        Console.WriteLine(lampada);                  // desligada, brilho 75 mantido
        lampada.Alternar();                          // liga novamente
        Console.WriteLine(lampada);                  // ligada, brilho 75

        Console.WriteLine();

        // ---- 2. Cofre Digital --------------------------------------
        Console.WriteLine("=== COFRE DIGITAL ===");
        var cofre = new CofreDigital("Maria", "1234");
        Console.WriteLine(cofre);

        Console.WriteLine(cofre.Abrir("0000"));      // errada 1
        Console.WriteLine(cofre.Abrir("0000"));      // errada 2
        Console.WriteLine(cofre.Abrir("0000"));      // bloqueado na 3ª
        Console.WriteLine(cofre.Abrir("1234"));      // ainda bloqueado

        cofre.Resetar();
        Console.WriteLine(cofre.Abrir("1234"));      // ok após reset
        cofre.AlterarSenha("1234", "abcd");
        cofre.Fechar();
        Console.WriteLine(cofre);

        Console.WriteLine();

        // ---- 3. Conta Corrente Universitária -----------------------
        Console.WriteLine("=== CONTA CORRENTE UNIVERSITÁRIA ===");
        var conta = new ContaCorrenteUniversitaria(1001, "João");
        Console.WriteLine(conta);

        conta.Depositar(200);
        Console.WriteLine($"Depósito R$200 -> Saldo: {conta.Saldo} | Total: {conta.SaldoTotal} | Status: {conta.StatusConta}");

        conta.Sacar(650);   // saldo fica -450
        Console.WriteLine($"Saque R$650   -> Saldo: {conta.Saldo} | Status: {conta.StatusConta}");

        conta.Sacar(200);   // falha: SaldoTotal = 50, menor que 200
        conta.Titular = "João Silva";
        Console.WriteLine(conta);

        Console.WriteLine();

        // ---- 4. Personagem de RPG ----------------------------------
        Console.WriteLine("=== PERSONAGEM DE RPG ===");
        var guerreiro = new PersonagemRPG("Arthas", "Guerreiro");
        var mago = new PersonagemRPG("Gandalf", "Mago");

        Console.WriteLine(guerreiro);   // HP 150/150
        Console.WriteLine(mago);        // HP 80/80

        guerreiro.ReceberDano(80);
        Console.WriteLine(guerreiro);   // HP 70/150

        guerreiro.Curar(200);           // cap na vida máxima
        Console.WriteLine(guerreiro);   // HP 150/150

        guerreiro.SubirNivel();
        Console.WriteLine(guerreiro);   // Lvl 2, HP 165/165

        mago.ReceberDano(80);           // mata o mago
        Console.WriteLine(mago);        // HP 0/80

        mago.Curar(50);                 // falha: morto
        mago.SubirNivel();              // falha: morto
        mago.Ressuscitar();
        Console.WriteLine(mago);        // HP 80/80, Lvl 1
    }
}
