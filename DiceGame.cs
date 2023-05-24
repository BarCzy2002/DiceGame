using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] dice = new int[5];
        bool[] locked = new bool[5];
        int rollsLeft = 3;
        int [] remember = new int [5];
        int totalScore = 0;

        Console.WriteLine("Gra w kości!");

        while (true)
        {
            int x = 1;
            Console.WriteLine();
            Console.WriteLine("Wyrzucone kości:");
            for (int i = 0; i < 5; i++)
            {
                if (!locked[i])
                {
                    dice[i] = random.Next(1, 7);
                    remember[i] = dice[i];
                }
                Console.WriteLine("Kość " + (i + 1) + ": " + dice[i] + (locked[i] ? " (zablokowana)" : ""));
            }

            Console.WriteLine("Rzuty pozostałe: " + rollsLeft);

           
            next_roll:
            if(x<=0){
            for (int i = 0; i < 5; i++){
                Console.WriteLine("Kość " + (i + 1) + ": " + remember[i] + (locked[i] ? " (zablokowana)" : ""));
            }
            }
            x--;
            Console.WriteLine("Naciśnij klawisz 1-5, aby zablokować lub odblokować odpowiednią kostkę.");
            Console.WriteLine("Naciśnij klawisz R, aby rzucić ponownie niezablokowane kostki.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            if (keyInfo.Key == ConsoleKey.R)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!locked[i])
                    {
                        dice[i] = random.Next(1, 7);
                    }
                }
                rollsLeft--;
            }
            else if (keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D5)
            {
                int a = (int)keyInfo.Key - (int)ConsoleKey.D1;
                locked[a] = !locked[a];
                goto next_roll;
            }
            else
            {
                Console.WriteLine("Niepoprawny klawisz. Spróbuj jeszcze raz.");
                goto next_roll;
            }

             if (rollsLeft == 0)
            {
                Console.WriteLine("Koniec rzutów.");
                break;
            }
        }

        for (int i = 0; i < 5; i++){
                Console.WriteLine("Kość " + (i + 1) + ": " + dice[i] + (locked[i] ? " (zablokowana)" : ""));
            }

        for (int i = 0; i < 5; i++)
        {
            totalScore += dice[i];
        }
        Console.WriteLine();
        Console.WriteLine("Wynik końcowy: " + totalScore);
    }
}
