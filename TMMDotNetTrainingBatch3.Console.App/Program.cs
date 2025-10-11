// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Diagnostics;

string name = "ATE";

if (name == "A")
{
    
}
else
{

}

enumBank LL = enumBank.CB;
switch (LL)
{
    case enumBank.AYA:
        Console.WriteLine("A");
        break;
}
enum enumBank
{
    None = 0,
    KBZ = 1,
    CB = 2,
    AYA = 3,
    MAB = 4
}