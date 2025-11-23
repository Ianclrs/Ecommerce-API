
namespace Domain.Helpers;
public static class Utilitarios
{
    //Mostra a mensagem pulando linha
    public static void Print(string mensagem)
    {
        Console.WriteLine(mensagem);
    }

    //Mostra a mensagem sem pular linha
    public static void PrintInLine(string mensagem)
    {
        Console.Write(mensagem);
    }

    //Interage com o usuario
    public static string Input(string mensagem = "")
    {
        if (mensagem != "")
            PrintInLine(mensagem);

        return Console.ReadLine();
    }

    //Le uma tecla
    public static void PressKey()
    {
        Console.ReadKey();
    }

    //Faz uma pausa. Exibindo um aviso, caso recebido algum,
    //e lendo uma tecla pra continuar a execucao do programa no final
    public static void AvisoEPressKey(string mensagem = "")
    {
        if (mensagem != "")
            Print(mensagem);
        PrintInLine("Digite qualquer coisa pra continuar...");
        PressKey();
        Clear();
    }

    //Limpa a tela
    public static void Clear()
    {
        Console.Clear();
    }
}
