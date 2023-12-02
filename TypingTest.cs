using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Ckopopehatonie
{
    internal class TypingTest
    {
        private int WordsPerMinute = 0;
        private int TypingErrors = 0;
        private string FullName;
        private Stopwatch stopwatch = new Stopwatch();
        private List<TypingTestResult> testResults = new List<TypingTestResult>();

        public void StartTest()
        {
            Console.Write("Введите имя: ");
            FullName = Console.ReadLine();
            Console.Clear();

            char[] textToWrite = TextToWrite();
            foreach (char xz in textToWrite)
            {
                Console.Write(xz);
            }
            Console.ResetColor();
            ConsoleKeyInfo Key;
            do
            {
                Key = Console.ReadKey(true);
            } while (Key.Key != ConsoleKey.Enter);

            new Thread(Timer).Start();

            int i = 0;
            int j = 0;
            foreach (char letter in textToWrite)
            {
                if (60 - stopwatch.ElapsedMilliseconds / 1000 <= 0)
                    break;

                char userKey = Console.ReadKey(true).KeyChar;

                try
                {
                    Console.SetCursorPosition(i, j);
                }
                catch (ArgumentOutOfRangeException)
                {
                    j++;
                    i = 0;
                    Console.SetCursorPosition(i, j);
                }

                if (userKey == letter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(letter);
                    Console.ResetColor();
                    WordsPerMinute++;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(letter);
                    Console.ResetColor();
                    TypingErrors++;
                }
                i++;
            }

            stopwatch.Stop();
            Console.Clear();
            DisplayResults();
            ChooseNextAction();
        }

        private void Timer()
        {
            stopwatch.Start();

            do
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 15);
                Console.WriteLine($"Time Left: 0:{60 - stopwatch.ElapsedMilliseconds / 1000}");
                Thread.Sleep(1000);
            }
            while (60 - stopwatch.ElapsedMilliseconds / 1000 > 0);
        }

        private void DisplayResults()
        {
            Console.WriteLine($"Имя пользователя: {FullName}");
            Console.WriteLine($"Слов в минуту: {WordsPerMinute}");
            Console.WriteLine($"Ошибок: {TypingErrors}");

            testResults.Add(new TypingTestResult(FullName, WordsPerMinute, TypingErrors));
        }

        private void ChooseNextAction()
        {
            Console.WriteLine("Введите 'M' для возврата в главное меню, 'L' для просмотра таблицы рекордов или любую другую клавишу для выхода.");
            var choice = Console.ReadKey(true).KeyChar;
            if (choice == 'M' || choice == 'm')
            {
                UserInterface ui = new UserInterface();
                ui.ShowMainMenu();
            }
            else if (choice == 'L' || choice == 'l')
            {
                ShowLeaderboard();
            }
        }

        public void ShowLeaderboard()
        {
            Console.WriteLine("Таблица рекордов:");
            foreach (var result in testResults)
            {
                Console.WriteLine(result);
            }
        }

        private char[] TextToWrite()
        {
            string[] text = { "Автомобили с автопилотом становятся все более популярными, облегчая жизнь водителям и снижая риски на дорогах. Системы машинного обучения и искусственного интеллекта играют ключевую роль в развитии этой технологии, позволяя машинам анализировать окружающую среду и принимать решения на основе данных.",
                              "Электрические автомобили стали символом экологически чистой мобильности. Их рост популярности способствует снижению выбросов углерода и уменьшению зависимости от ископаемых топлив, что приносит пользу окружающей среде и обществу.",
                              "Технология самоуправляемых автомобилей меняет ландшафт городской мобильности. В будущем мы можем ожидать более эффективного использования дорожного пространства и уменьшения пробок благодаря автономным транспортным средствам.",
                              "С развитием интернета вещей (IoT) и связанных с ним автомобильных технологий появляются новые возможности для мониторинга состояния автомобилей и оптимизации их обслуживания. Это помогает увеличить надежность и безопасность автомобилей.",
                              "3D-печать транспортных деталей и компонентов становится все более распространенной практикой в автомобильной индустрии. Эта инновация позволяет сократить затраты на производство и ускорить процесс разработки новых моделей автомобилей."
            };
            Random random = new Random();
            char[] result = text[random.Next(0, text.Length)].ToCharArray();

            return result;
        }
    }

    public class TypingTestResult
    {
        public string UserName { get; set; }
        public int WordsPerMinute { get; set; }
        public int TypingErrors { get; set; }

        public TypingTestResult(string userName, int wordsPerMinute, int typingErrors)
        {
            UserName = userName;
            WordsPerMinute = wordsPerMinute;
            TypingErrors = typingErrors;
        }

        public override string ToString()
        {
            return $"Имя: {UserName}, Слов в минуту: {WordsPerMinute}, Ошибок: {TypingErrors}";
        }
    }
}
