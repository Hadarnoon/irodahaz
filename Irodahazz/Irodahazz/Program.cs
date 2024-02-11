using Irodahazz;

var irodak = new List<Iroda>();
using var sr = new StreamReader(@"..\..\..\src\irodahaz.txt");
try
{
	while (!sr.EndOfStream)
	{
		irodak.Add(new Iroda(sr.ReadLine()));
	}
}
catch
{
    Console.WriteLine("Hiba a fájl beolvasása során!");
}

Kiiras(irodak);

Console.WriteLine("\n8.feladat:");
var legtobbendolgozok = LegtobbenDolgozok(irodak);
Console.WriteLine(legtobbendolgozok);


Console.WriteLine("\n9.feladat:");
var kilencen = KilencenVannak(irodak);
if (kilencen != null) Console.WriteLine(kilencen);
else Console.WriteLine("Nincs olyan iroda ahol 9en vannak");


Console.WriteLine("\n10.feladat:");
var otneltobben = Otneltobben(irodak);
Console.WriteLine($"Ennyi irodában vannak ötnél többen: {otneltobben}");


Console.WriteLine("\n11.feladat:");
UresIroda(irodak);
Console.WriteLine("kiirva");


Console.WriteLine("\n12.feladat:");
var atlagdolgozok = LogmeinAtlagDolgozok(irodak);
Console.WriteLine($"A Logmein cégnél átlagosan ennyien dolgoznak: {atlagdolgozok}");


Console.WriteLine("\n13.feladat:");
Kiirasfolytatas(irodak);
Console.WriteLine("kiirva");


Console.WriteLine("\n14.feladat:");
var osszesdolgozo = Osszesdolgozo(irodak);
Console.WriteLine($"Összesen ennyien vannak az irodaházban: {osszesdolgozo}");

Console.WriteLine("\n15.feladat:");
var elsoberles = ElsoBerles(irodak);
Console.WriteLine($"Az első bérlés ekkor történt: {elsoberles}");
static void Kiiras(List<Iroda> emelet)
{
    Console.WriteLine($"   Kód | Beköltözés | 1. 2. 3. 4. 5. 6. 7. 8. 9. 10. 11. 12.");
	for (int i = 0; i < emelet.Count; i++)
	{
		Console.WriteLine($"{i + 1}. {emelet[i]}");
    }
}

static int LegtobbenDolgozok(List<Iroda> emelet)
{
	int sorszam = 0;
	var legtobbendologozok = emelet.Max(e => e.Letszamok.Sum());
	for (int i = 0; i < emelet.Count; i++)
	{
		if (legtobbendologozok == emelet[i].Letszamok.Sum())
		{
			sorszam = i + 1;
		}
	}
	return sorszam;
}

static Iroda KilencenVannak(List<Iroda> emelet)
{
	var kilencen = emelet.Where(e => e.Letszamok.Contains(9)).First();
	return kilencen;
}

static int Otneltobben(List<Iroda> emelet)
{
	var otneltobben = emelet.SelectMany(e => e.Letszamok).Where(e => e > 5).Count();
	return otneltobben;
}

static void UresIroda(List<Iroda> emelet)
{	using (var sw = new StreamWriter(@"..\..\..\src\kiiras.txt")) 
	{

		for (int i = 0; i < emelet.Count; i++)
		{
			var indexek = new List<int>();
				for (int j = 0; j < emelet[i].Letszamok.Count; j++)
				{
					if (emelet[i].Letszamok[j] == 0)
					{
							indexek.Add(j + 1);
					}
				}
				if (indexek.Count > 0) 
				{
					sw.WriteLine($"{emelet[i].Kod} {string.Join(" ", indexek)}");
				}
		}
	}
}

static int LogmeinAtlagDolgozok(List<Iroda> emelet)
{
	var atlagdolgozok = emelet.Where(e => e.Kod == "LOGMEIN").SelectMany(e => e.Letszamok).Average();
	return Convert.ToInt32(atlagdolgozok);
}

static void Kiirasfolytatas(List<Iroda> emelet)
{
	using (var sw = new StreamWriter(@"..\..\..\src\kiiras.txt", true))
	{
		sw.WriteLine("\n13.feladat: ");
		for(int i = 0;i < emelet.Count; i++)
		{
			sw.WriteLine($"{i+1}. {emelet[i].Letszamok.Sum()}");
		}
	}
}

static int Osszesdolgozo(List<Iroda> emelet)
{
	var osszesdolgozo = emelet.SelectMany(e => e.Letszamok).Sum();
	return osszesdolgozo;
}

static int ElsoBerles(List<Iroda> emelet)
{
	var elsoberles = emelet.Min(e => e.Kezdet);
	return elsoberles;
}