
string welcomeMessage = "Bem vindo ao Screen Sound";
Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>
{
    { "The Beatles", new List<int> { 10, 9, 8 } },
    { "Queen", new List<int> { 10, 10, 9 } },
    { "Nirvana", new List<int> { 9, 8, 7 } },
    { "Pink Floyd", new List<int> { 10, 10 } }
};

void showLogo()
{

    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
}

void ShowMenuOptions()
{
    showLogo();
    Console.WriteLine("\nEscolha uma opção:\n");
    Console.WriteLine("1 - Registrar banda");
    Console.WriteLine("2 - Listar bandas");
    Console.WriteLine("3 - Avaliar banda");
    Console.WriteLine("4 - Exibir média das avaliações");
    Console.WriteLine("5 - Sair");

}

void ShowFormattedHeader(string title)
{
    string asterisks = String.Empty.PadLeft(title.Length, '*');

    Console.WriteLine(asterisks);
    Console.WriteLine(title);
    Console.WriteLine($"{asterisks}\n");
}

void RegisterBand()
{
    Console.Clear();
    ShowFormattedHeader("Registro de Bandas");
    string bandName = String.Empty;

    while (bandName == String.Empty)
    {
        Console.Write("Digite o nome da Banda: ");
        bandName = (Console.ReadLine() ?? String.Empty).Trim();

        if (bandName == String.Empty)
        {
            Console.WriteLine("\nNome inválido. Tente novamente.");
        }
        else
        {
            bandas.Add(bandName, new List<int>());
            Console.WriteLine($"\nA banda \"{bandName}\" foi registrada com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}

void ShowBandas()
{
    for (int i = 0; i < bandas.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {bandas.ElementAt(i).Key}");
    }
}

void ListBands()
{
    Console.Clear();
    ShowFormattedHeader("Bandas Registradas");

    if (bandas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada.");
    }
    else
    {
        ShowBandas();
    }
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

int getValidOption(int minOptionValue,int maxOptionValue, string mensagemDeErro = "Opção inválida. Tente novamente: ") 
{ 
    string opcao = Console.ReadLine() ?? string.Empty;

    while(!int.TryParse(opcao, out int option) || option < minOptionValue || option > maxOptionValue)
    {
        Console.Write(mensagemDeErro);
        opcao = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("\n");
    }

    return int.Parse(opcao);
}

void EvaluateBands()
{
    Console.Clear();
    ShowFormattedHeader("Avaliar Bandas");

    if (bandas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada.");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
    else
    {
        Console.WriteLine("Bandas disponíveis para avaliação:\n");
        ShowBandas();
        Console.Write("\nEscolha uma banda para avaliar: ");
        int bandaIndex = getValidOption(1,bandas.Count);

        Console.Write($"Digite a nota (0 a 10) para a banda {bandas.ElementAt(bandaIndex - 1).Key}: ");
        int nota = getValidOption(0,10, "Nota inválida, tente novamente: ");

        bandas.ElementAt(bandaIndex - 1).Value.Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda \"{bandas.ElementAt(bandaIndex - 1).Key}\"!");
        Thread.Sleep(2000);
        Console.Clear();
    }
}

void ShowAverage() {
    Console.Clear();
    ShowFormattedHeader("Média das Avaliações");
    string bandName = string.Empty;

    do { 
        Console.Write("Você quer a média de qual banda: ");
        bandName = (Console.ReadLine() ?? String.Empty).Trim();
        if (!bandas.ContainsKey(bandName)) { 
            Console.WriteLine("\nBanda não encontrada. Tente novamente.\n");
        }
    } while (!bandas.ContainsKey(bandName));

    if(bandas[bandName].Count == 0)
    {
        Console.WriteLine($"\nA banda \"{bandName}\" não possui avaliações registradas.");
    }else 
    {
        Console.WriteLine($"\nA média de avaliações da banda \"{bandName}\" é: {bandas[bandName].Average():F2}");
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

Console.WriteLine(welcomeMessage);

int opcao = 0;

while (opcao != 5)
{

    ShowMenuOptions();
    Console.Write("\nDigite o número da opção desejada: ");
    opcao = getValidOption(1,5);

    switch (opcao)
    {
        case 1:
            RegisterBand();
            break;
        case 2:
            ListBands();
            break;
        case 3:
            EvaluateBands();
            break;
        case 4:
            ShowAverage();
            break;
        case 5:
            Console.WriteLine("Saindo do programa...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}







