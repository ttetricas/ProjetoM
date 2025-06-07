string alelo1, alelo2, dominancia;

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

//criar sub rotinas para a contagem dos alelos
//tentar criar somente 3 sub rotinas para as possibilidades 
//Esther quer comer macarao com feijao 
//