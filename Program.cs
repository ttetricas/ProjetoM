string alelo1, alelo2, dominancia, confirmacao;

Console.WriteLine("------ Genética Mendeliana ------\n");
Console.WriteLine("Digite o genótipo dos dois indivíduos (AA, Aa ou aa):\n");

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

Console.WriteLine("Processando combinações genéticas, aguarde...\n");
Thread.Sleep(2000); 

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

int total = resultado[0] + resultado[1] + resultado[2];
Console.WriteLine("\nResultado do cruzamento:");
Console.WriteLine($"AA: {100.0 * resultado[0] / total}%");
Console.WriteLine($"Aa: {100.0 * resultado[1] / total}%");
Console.WriteLine($"aa: {100.0 * resultado[2] / total}%");

  
if (dominancia == "C")
{
    Console.WriteLine("\nTipo de Dominância: Completa");
    Console.WriteLine($"Fenótipo dominante (AA ou Aa): {100.0 * (resultado[0] + resultado[1]) / total}%");
    Console.WriteLine($"Fenótipo recessivo (aa): {100.0 * resultado[2] / total}%");
}
else if (dominancia == "I")
{
    Console.WriteLine("\nTipo de Dominância: Incompleta");
    Console.WriteLine($"Fenótipo intermediário (Aa): {100.0 * resultado[1] / total}%");
    Console.WriteLine($"Fenótipo dominante (AA): {100.0 * resultado[0] / total}%");
    Console.WriteLine($"Fenótipo recessivo (aa): {100.0 * resultado[2] / total}%");
}
    // tabela do codigo
    
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