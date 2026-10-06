using System;
using System.Threading;

Console.WriteLine("=== 카드 짝 맞추기 게임===");
Console.WriteLine("아무 키나 눌러 게임 시작하기.");
Console.ReadKey(true);
Console.Clear();
Console.WriteLine("카드 섞는 중");
Thread.Sleep(0);
Console.Clear();
Console.WriteLine("=== 카드 짝 맞추기 게임===");
Console.Write($"{"",3}");

int[,] card = new int[4, 4];

for (int i = 0; i < 16; i++)
{
    card[i / 4, i % 4] = (i / 2) + 1; 
}
bool[,] isOpened = new bool[4, 4];




Shuffle(card);
for (int col = 0; col < 4; col++)
{
    Console.Write($"{col + 1,2}열");
}
Console.WriteLine();
for (int row = 0; row < 4; row++)
{
    Console.Write($"{row + 1,2}행");
    for (int col = 0; col < 4; col++)
    {
        if (isOpened[row, col])
        {
            Console.Write($" {card[row, col],3}");
        }
        else
        {
            Console.Write($" {"** ",3}");
        }
    }
    Console.WriteLine();
}
Console.WriteLine();

//for (int col = 0; col < 4; col++)
//{
//    Console.Write($"{col + 1, 3}열");
//}
//Console.WriteLine();
//for (int row = 0; row < 4; row++)
//{
//    Console.Write($"{row + 1,2}행");
//    for (int col = 0; col < 4; col++)

//    {
//        Console.Write($" {"** ", 3}");

//    }
//    Console.WriteLine();
//}
//Console.WriteLine();


void Shuffle(int[,] array)
{
    for (int i = 0; i < 100; i++)
    {
        Random rnd = new Random();
        int randomIndex = rnd.Next(0, 16);
        int temp = array[randomIndex / 4, randomIndex % 4];
        array[randomIndex / 4, randomIndex % 4] = array[0, 0];
        array[0, 0] = temp;
    }
}
