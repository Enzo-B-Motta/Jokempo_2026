// See https://aka.ms/new-console-template for more information
using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

static (int opcaoUser, int opcaoPC) Escolha(String nomeUser)
{
    Console.WriteLine("Escolha uma opção, " + nomeUser + ": 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");

    var opcao = Console.ReadKey().KeyChar;

    var opcaoPC = new Random().Next(3);

    return (opcao, opcaoPC);
}

static bool ComparacaoEscolhas(int opcaoUser, int opcaoPC, bool vitoria)
{
    switch (opcaoUser)
    {
        case '0':
            Console.WriteLine("\nVocê escoheu Pedra ✊!");
            vitoria = (opcaoPC == 2);
            break;
        case '1':
            Console.WriteLine("\nVocê escoheu Papel ✋");
            vitoria = (opcaoPC == 0);
            break;
        case '2':
            Console.WriteLine("\nVocê escoheu Tesoura ✌");
            vitoria = (opcaoPC == 1);
            break;
    }

    switch (opcaoPC)
    {
        case 0:
            Console.WriteLine("\nEu escolhi Pedra ✊!");
            break;
        case 1:
            Console.WriteLine("\nEu escolhi Papel ✋");
            break;
        case 2:
            Console.WriteLine("\nEu escolhi Tesoura ✌");
            break;
    }

    if (int.Parse(opcaoUser.ToString()) == opcaoPC)
        Console.WriteLine("\n😀 Legal! Nós empatamos!");
    else if (vitoria)
        Console.WriteLine("\n😀 Parabéns! Você venceu.");
    else
        Console.WriteLine("\n😀 Haha, eu venci! Não foi dessa vez. Você pode ter mais sorte na próxima.");

    return vitoria;
}

static void AddListas(List<String> ListaUsers, List<int> ListaVitorias, List<int> ListaDerrotas, String UserAtual, int VitoriaAtual, int DerrotaAtual, bool vitoria)
{
    ListaUsers.Add(UserAtual);

    if (vitoria = true)
    {
        int indexAtual = ListaVitorias.Count();
        indexAtual = indexAtual - 1;
        int valorAtual = ListaVitorias[indexAtual];
        ListaVitorias[indexAtual] = valorAtual+1;
    } 
    else
    {
        int indexAtual = ListaDerrotas.Count();
        indexAtual = indexAtual - 1;
        int valorAtual = ListaDerrotas[indexAtual];
        ListaVitorias[indexAtual] = valorAtual+1;
    }
}

static void Estatisticas(List<string> Users, List<int> Vitorias, List<int> Derrotas)
{
    for (int i = 0; i < Users.Count; i++)
    {
        Console.WriteLine("Usuário: " + Users[i]);
        Console.WriteLine("Vitórias: " + Vitorias[i] +"Derrotas: "+ Derrotas[i]);
        Console.WriteLine("-" + 15);
    }
}

static String NomeJogador(String UserAtual, List<string> listaUsers)
{
    if (listaUsers.Count >= 1)
    {
        Console.WriteLine("Deseja mudar de jogador?");
        Console.WriteLine("Escolha uma opção: 1 - Sim ou 2 - Não");

        var novoUser = Console.ReadKey().KeyChar;
        if (novoUser == '1')
        {
            Console.WriteLine("Diga o nome do seu novo usuário:");

            String nomeUser = Console.ReadLine();

            return nomeUser;
        }
        else if (novoUser == '2')
        {
            Console.WriteLine("Continuando como " + UserAtual);
            return UserAtual;
        }
    } 
    else
    {
        Console.WriteLine("Digite seu nome:");

        String User = Console.ReadLine();
        return User;
    }
}


List<string> listaUsers = new List<string>();
List<int> listaVitorias = new List<int>();
List<int> listaDerrotas = new List<int>();

String UserAtual = "NomeProvisório";

Console.WriteLine("😀 Olá! Vamos jogar Jokempo?");
Console.WriteLine("1 - Sim ou 0 - Não");

var continuar = Console.ReadKey().KeyChar;


while(continuar == '1')
{
    int VitoriaAtual = 0;
    int DerrotaAtual = 0;
    bool vitoria = false;

    Console.WriteLine("Então vamos começar...");
    UserAtual = NomeJogador("Nome", listaUsers);
    listaUsers.Add(UserAtual);

    var opcoes = Escolha(UserAtual);
    vitoria = ComparacaoEscolhas(opcoes.opcaoUser, opcoes.opcaoPC, vitoria);


    Console.WriteLine("\nEscolha o que fazer:");
    Console.WriteLine("0 - Ver placar  1 - Jogar de novo  2 - Sair do Programa");
    var escolha = Console.ReadKey().KeyChar;

    switch(escolha)
    {
        case '0':
            Estatisticas(listaUsers, listaVitorias, listaDerrotas);
            break;

        case '1':
            continuar = '1';
            break;

        case '2':
            continuar = '0';
            break;
    }
}
Console.WriteLine("👋 Tchau! Até a próxima");