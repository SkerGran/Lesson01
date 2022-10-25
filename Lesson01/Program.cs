using System;

namespace GeniyIdiotConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            bool isOnPlay = true;
            string playerName;
            int countQuestions = 5;
            int countRightAnswers = 0;
            string[,] quiz = GetQuiz();
            string[,] randomQuiz;

            while (isOnPlay)
            {
                playerName = GetPlayerName();

                randomQuiz = ShuffleQuiz(quiz);

                countRightAnswers = RunQuiz(randomQuiz, countQuestions);

                MakeDiagnoses(countRightAnswers, playerName);

                isOnPlay = QuitQuiz(isOnPlay, playerName);
            }
        }

        static string GetPlayerName()
        {
            Console.Write("Игрок, введите Ваше имя: ");
            string playerName = Console.ReadLine();
            return playerName;
        }

        // Почему то выдает ошибку, если ставить countQuestions вместо количества строк. Скрин в корне "Скрин ошибки.png"
        // В причине не разобрался, но ошибку устранил убрав размерность массива
        static string[,] GetQuiz()
        {
            string[,] quiz = new string[,]  
            {
                { "Сколько будет два плюс два умноженное на два?" , "6"},
                { "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", "9" },
                { "На двух руках 10 пальцев. Сколько пальцев на 5 руках?", "25"},
                { "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", "60"},
                { "Пять свечей горело, две потухли. Сколько свечей осталось?", "2"}
            };
            return quiz;
        }

        // Перемешивание вопросов
        static string[,] ShuffleQuiz(string[,] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length / 2 - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                string tmpLeft = arr[j, 0];
                string tmpRight = arr[j, 1];
                arr[j, 0] = arr[i, 0];
                arr[j, 1] = arr[i, 1];
                arr[i, 0] = tmpLeft;
                arr[i, 1] = tmpRight;
            }
            return arr;

        }


        static int RunQuiz(string[,] randomQuiz, int countQuestions)
        {
            int countRightAnswers = 0;
            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));

                Console.WriteLine(randomQuiz[i, 0]);

                string userAnswer = Console.ReadLine();

                string rightAnswer = randomQuiz[i, 1];

                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
            }
            return countRightAnswers;

        }


        // Постановка диагноза
        static void MakeDiagnoses(int countRightAnswers, string playerName)
        {
            Console.WriteLine("Количество правильных ответов: " + countRightAnswers);

            string[] diagnoses = new string[6] { "кретин", "идиот", "дурак", "нормальный", "талант", "гений" };
            Console.WriteLine(playerName + " Вы " + diagnoses[countRightAnswers] + "!!!");
        }

        // Приводит ответ к нижнему регистру, но почему то isOnPlay не становится false
        // В причине не разобрался, ошибку устранил упростив цикл while
        static bool QuitQuiz(bool isOnPlay, string playerName)
        {
            Console.Write(playerName + ", Вы хотите продолжить игру? да/нет");
            string isOnQuit;
            while (true)
            {
                isOnQuit = Console.ReadLine().ToLower();
                if (isOnQuit == "да")
                {
                    isOnPlay = true;
                    break;
                }
                if (isOnQuit == "нет")
                {
                    isOnPlay = false;
                    break;
                }
            }

                return isOnPlay;
        }
    }
}