﻿string alelo1, alelo2, dominancia, confirmacao;

Console.WriteLine("------ Genética Mendeliana ------\n");
Console.WriteLine("Digite o genótipo dos dois indivíduos (AA, Aa ou aa):\n");

//seleçao dos genotipos
do
{
    Console.Write("Genótipo do 1º indivíduo: ");
    alelo1 = Console.ReadLine()!.Trim();

    if (alelo1 != "AA" && alelo1 != "Aa" && alelo1 != "aa")
    {
        Console.WriteLine("Entrada inválida. Escolha um genótipo válido: AA, Aa ou aa.\n");
    }

} while (alelo1 != "AA" && alelo1 != "Aa" && alelo1 != "aa");

do
{
    Console.Write("Genótipo do 2º indivíduo: ");
    alelo2 = Console.ReadLine()!.Trim();

    if (alelo2 != "AA" && alelo2 != "Aa" && alelo2 != "aa")
    {
        Console.WriteLine("Entrada inválida. Escolha um genótipo válido: AA, Aa ou aa.\n");
    }

} while (alelo2 != "AA" && alelo2 != "Aa" && alelo2 != "aa");
 
do
{
    Console.Write("Tipo de Dominância (C - completa / I - incompleta): ");
    dominancia = Console.ReadLine()!.Trim().ToUpper();

    if (dominancia != "C" && dominancia != "I")
    {
        Console.WriteLine("Dominância inválida. Use apenas 'C' ou 'I'.\n");
    }

} while (dominancia != "C" && dominancia != "I");

//confirmaçao do conteudo
Console.WriteLine("\n---Confirme os dados---");
Console.WriteLine($"\nGenótipo do 1º indivíduo: {alelo1}");
Console.WriteLine($"Genótipo do 2º indivíduo: {alelo2}");
Console.WriteLine($"Tipo de Dominância: {dominancia}");

 do
{
    Console.Write("Confirma? (S/N): ");
    confirmacao = Console.ReadLine()!.Trim().ToUpper();

    if (confirmacao != "S" && confirmacao != "N")
    {
        Console.WriteLine("Resposta inválida. Digite 'S' para confirmar ou 'N' para retornar.\n");
    }

} while (confirmacao != "S" && confirmacao != "N");

if (confirmacao == "N")
{
    Console.WriteLine("Operação cancelada pelo usuário.");
    return;
}

//tempo de espera
Console.WriteLine("Processando combinações genéticas, aguarde...\n");
Thread.Sleep(2000); 
//----------------------------------------------------------------------

string[] genotiposPossiveis = new string[] { "AA", "Aa", "aa" };

    
string[] alelos1 = ObterAlelos(alelo1);
string[] alelos2 = ObterAlelos(alelo2);

var resultado = new int[3]; 

foreach (var aleloPai1 in alelos1)
{
    foreach (var aleloPai2 in alelos2)
    {
        string genotipoFilho = aleloPai1 + aleloPai2;
        genotipoFilho = OrdenarGenotipo(genotipoFilho);

        if (genotipoFilho == "AA")
            resultado[0]++;
        else if (genotipoFilho == "Aa")
                resultado[1]++;
        else if (genotipoFilho == "aa")
                resultado[2]++;
    }
}

//Genotipo Individuos(visual)
Console.WriteLine($"\nGenótipo do 1º indivíduo----: {alelo1}");
Console.WriteLine($"Genótipo do 2º indivíduo----: {alelo2}");
Console.WriteLine($"Tipo de Dominância----------: {dominancia}");

//Tabela(visual)

Console.WriteLine();

Console.Write($"   |");
foreach (var alelo in alelos2)
{
    Console.Write($"  {alelo} ");
}
Console.WriteLine("\n-----------------");

foreach (var aleloLinha in alelos1)
{
    Console.Write($" {aleloLinha} |");
    foreach (var aleloColuna in alelos2)
    {
        string gen = OrdenarGenotipo(aleloLinha + aleloColuna);
        Console.Write($" {gen} ");
    }
    Console.WriteLine();

}

//tipo de dominancia(visual)
int total = resultado[0] + resultado[1] + resultado[2];
  
double porcentAA = 100.0 * resultado[0] / total;
double porcentAa = 100.0 * resultado[1] / total;
double porcentaa = 100.0 * resultado[2] / total;

Console.WriteLine();
Console.WriteLine("Resultado genótipo a genótipo:");
Console.WriteLine($"AA: {porcentAA,4:0}% - não apresenta a característica recessiva");
Console.WriteLine($"Aa: {porcentAa,4:0}% - não apresenta a característica recessiva");
Console.WriteLine($"aa: {porcentaa,4:0}% - apresenta a característica recessiva");

//mudança pra manter o console aberto
Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();

//subR(visual)
static string[] ObterAlelos(string genotipo)
{
    if (genotipo == "AA") return new string[] { "A", "A" };
    if (genotipo == "Aa") return new string[] { "A", "a" };
    if (genotipo == "aa") return new string[] { "a", "a" };
    return new string[] { };
}

static string OrdenarGenotipo(string genotipo)
{
    var alelos = genotipo.ToCharArray();
    Array.Sort(alelos);
    return new string(alelos);
}