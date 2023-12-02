using System;

namespace Ckopopehatonie
{
    public class UserInterface
    {
        public void ShowMainMenu()
        {
            bool isRunning = true;
            int selectedButton = 0;

            while (isRunning)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Разминай свои пальчики, будет жарко!");
                Console.ForegroundColor = ConsoleColor.White;
                
                DisplayButton("Начать тест", 0, selectedButton == 0);
                DisplayButton("Таблица рекордов", 1, selectedButton == 1);
                DisplayButton("Выйти", 2, selectedButton == 2);

                
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedButton = Math.Max(0, selectedButton - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedButton = Math.Min(2, selectedButton + 1);
                        break;
                    case ConsoleKey.Enter:
                        ExecuteButtonAction(selectedButton, ref isRunning);
                        break;
                }
            }
        }

        static void DisplayButton(string text, int position, bool isSelected)
        {
            if (isSelected)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.SetCursorPosition(0, position + 2);
            Console.WriteLine(text);

            Console.ResetColor();
        }

        static void ExecuteButtonAction(int buttonIndex, ref bool isRunning)
        {
            switch (buttonIndex)
            {
                case 0:
                    
                    TypingTest typingTest = new TypingTest();
                    typingTest.StartTest();
                    break;
                case 1:
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.DisplayLeaderboard();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ДАМЫ И ГОСПОДА, \n\nЧУШПАН.exe ТЕПЕРЬ ВЛАСТЕЛИН ПК (#_#)");
                    Console.WriteLine("");
                    isRunning = false;
                    break;
            }
        }
    }
}
