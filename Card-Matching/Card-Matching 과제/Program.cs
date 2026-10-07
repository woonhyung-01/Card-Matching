using System;
using System.Threading;

Console.WriteLine("=== 카드 짝 맞추기 게임===");
Console.WriteLine("아무 키나 눌러 게임 시작하기.");
Console.ReadKey(true);
Console.Clear();
Console.WriteLine("카드 섞는 중");
Thread.Sleep(0);
Console.Clear();

int[,] card = new int[4, 4];

for (int i = 0; i < 16; i++)
{
    card[i / 4, i % 4] = (i / 2) + 1; 
}
bool[,] isOpened = new bool[4, 4];

int count = 0;
int success = 0;

Shuffle(card);

while (count < 20 || success < 8)
{
    int row1, col1;
    while (true)
    {
        PrintBoard();
        Console.WriteLine($"시도 횟수: {count}/20 | 찾은 쌍: {success}");
        Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
        string[] input = Console.ReadLine().Split(' ');

        if (int.TryParse(input[0], out row1) && int.TryParse(input[1], out col1))
        {
            row1--; col1--;
            if (row1 >= 0 && row1 < 4 && col1 >= 0 && col1 < 4)
            {
                if (!isOpened[row1, col1])
                {
                    break;
                }
                if (isOpened[row1, col1])
                {
                    Console.WriteLine("짝이 맞지 않습니다.!");
                }
            }
        }
    }

    isOpened[row1, col1] = true;
    int row2, col2;
    while (true)
    {
        PrintBoard();
        Console.WriteLine($"시도 횟수: {count}/20 | 찾은 쌍: {success}");
        Console.Write("첫 번째 카드를 선택하세요 (행 열): ");
        string[] input = Console.ReadLine().Split(' ');

        if (int.TryParse(input[0], out row2) && int.TryParse(input[1], out col2))
        {
            row2--; col2--;
            if (row2 >= 0 && row2 < 4 && col2 >= 0 && col2 < 4)
            {
                if (!isOpened[row2, col2])
                {
                    break;
                }
                if (isOpened[row2, col2])
                {
                    Console.WriteLine("짝이 맞지 않습니다.!");
                }
            }
        }
    }
    isOpened[row2, col2] = true;
}

void PrintBoard()
{
    Console.Clear();
    Console.WriteLine("=== 카드 짝 맞추기 게임===");
    Console.Write($"{"",3}");

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
}


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
