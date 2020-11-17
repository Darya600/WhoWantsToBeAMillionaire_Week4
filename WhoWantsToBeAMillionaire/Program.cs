using System;

namespace WhoWantsToBeAMillionaire
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] rulesOfTheGame = new string[8];
            rulesOfTheGame[0] = "пт. 1 - для начала игры вы должны внести свое имя;";
            rulesOfTheGame[1] = "пт. 2 - после начала игры вам будет предложен ограниченный перечень вопросов по очереди;";
            rulesOfTheGame[2] = "пт. 3 - для каждого вопроса предоставляется 4 варианта ответа;";
            rulesOfTheGame[3] = "пт. 4 - для ответа на вопрос необходимо ввести номер в числовом представлении, н.п. '1';";
            rulesOfTheGame[4] = "пт. 5 - при выборе верного ответа на вопрос выйгрыш приумножается х 2, по выбору пользователя " +
                             "\n при помощи комманды 'Продолжить игру' игра может быть продолжена или завершена при вооде комманды 'Завершить игру';";
            rulesOfTheGame[5] = "пт. 6 - при выборе не верного ответа на вопрос, игра окончена, выйгрыш = 0;";
            rulesOfTheGame[6] = "пт. 7 - при условии верного ответа на все вопросы или при вооде комманды 'Завершить игру' игрок Выйграл и может забрать свои средства.";

            PrintArray("Уважаемый пользователь! Правила Игры 'Кто хочет стать Миллионером'следующие:", rulesOfTheGame, 0, 6);
            Player person = newPlayer(rulesOfTheGame);

            Qestions[] qestion = new Qestions[3];
            qestion[0] = new Qestions("Что называют областью пространства-времени, гравитационное притяжение чего настолько велико,\n" +
                                      "что покинуть его не могут даже объекты, движущиеся со скоростью света, в том числе кванты самого \n" +
                                      "света? Граница этой области называется горизонтом событий.",
                                      "1. Млечный путь;", "2. Космическое пространство;", "3. Центр галлактики;", "4. Черная дыра;", "4");
            qestion[1] = new Qestions("С именем какого изобретателя в области электротехники и радиотехники связывают появление 'Тугусского метеорита'.,\n" +
                                      "В э 30 июня 1908 года он ставил опыт по передаче энергии «по воздуху». \n ",
                                      "1. Никола Тесла;", "2. Вильгельм Рентген;", "3. Леонардо да Винчи;", "4. Стив Джобс;", "1");
            qestion[2] = new Qestions("Масса чего заниамет 99% массы солнечной системы?",
                                      "1. Эфира;", "2. Серого вещества;", "3. Солнца;", "4. Черной материи;", "3");

            playGame(qestion, person, rulesOfTheGame);

            static void PrintArray(string text, string[] textArray, int startIndex, int endIndex)
            {
                Console.WriteLine(text);
                for (; endIndex >= startIndex; startIndex++)
                {
                    Console.WriteLine(textArray[startIndex]);
                }
            }

            static Player newPlayer(string[] rule)
            {
                Console.Write("Введите сове имя:");

                string name = Console.ReadLine();

                if (name != "")
                {
                    return new Player(name);
                }
                PrintArray("Вы нарушили следующее правило №", rule, 0, 0);
                Console.WriteLine();
                return newPlayer(rule);
            }


            static void playGame(Qestions[] qestion, Player person, string[] rulesOfTheGame)
            {
                person.winningAmount = 50;
                int index = 0;

                do
                {
                    string userInput = null;
                    Console.WriteLine("\n" +
                        qestion[index].qestion + "\n" +
                        qestion[index].firstAnswer + "\n" +
                        qestion[index].secondAnswer + "\n" +
                        qestion[index].thirdAnswer + "\n" +
                        qestion[index].fourthAnswer + "\n" +
                        "Введите правельный ответ: ");
                    string correctAnswer = UserInput(rulesOfTheGame);
                    if (correctAnswer == qestion[index].correctAnswer)
                    {
                        person.winningAmount *= 2;
                        if (person.winningAmount == 400)
                        {
                            PrintArray("\nПоздраляем " + person.name + "!!! Вы Выйграли!!!", rulesOfTheGame, 6, 6);
                            Console.WriteLine("\nВаш выйгрыш составил: " + person.winningAmount);
                        }
                        else
                        {
                            while (!(string.Equals(userInput, "Продолжить игру", StringComparison.OrdinalIgnoreCase))
                                && (!(string.Equals(userInput, "Завершить игру", StringComparison.OrdinalIgnoreCase))))
                            {
                                PrintArray("\nВы ввели верный ответ!", rulesOfTheGame, 4, 4);
                                userInput = Console.ReadLine();
                            }

                            if (string.Equals(userInput, "Продолжить игру", StringComparison.OrdinalIgnoreCase))
                            {
                                PrintArray("\nВы выбрали продолжить игру: ", rulesOfTheGame, 4, 4);
                                Console.WriteLine("\nВаш выйгрыш составил: " + person.winningAmount);
                            }
                            if (string.Equals(userInput, "Завершить игру", StringComparison.OrdinalIgnoreCase))
                            {
                                index = 3;
                                PrintArray("\nВы выбрали завершить игру: ", rulesOfTheGame, 6, 6);
                                Console.WriteLine("\nПоздравляем " + person.name + "! Ваш выйгрыш составил: " + person.winningAmount);
                            }
                        }
                    }
                    else
                    {
                        person.winningAmount = 0;
                        PrintArray("\nВы нарушили пункт №", rulesOfTheGame, 5, 5);
                        Console.WriteLine("\nИгра окончена! Вы проиграли! Ваш выйгрыш составил: " + person.winningAmount);
                    }
                    index++;
                } while (person.winningAmount > 0 & index < qestion.Length);

            }
            static string UserInput(string[] rule)
            {
                string userInputText = Console.ReadLine();
                try
                {
                    if (int.Parse(userInputText) >= 1 & int.Parse(userInputText) <= 4)
                    {
                        return userInputText;
                    }
                    else
                    {
                        PrintArray("Вы нарушили следующее правило №", rule, 3, 3);
                        return UserInput(rule);
                    }
                }
                catch
                {
                    PrintArray("Вы нарушили следующее правило №", rule, 3, 3);
                    return UserInput(rule);
                }

            }

        }
    }
    class Player
    {
        public Player(string name)
        {
            this.name = name;
            winningAmount = 0;
        }
        public string name;
        public int winningAmount;

    }

    class Qestions
    {
        public Qestions(string qestion, string firstAnswer, string secondAnswer, string thirdAnswer, string fourthAnswer, string correctAnswer)
        {
            this.qestion = qestion;
            this.firstAnswer = firstAnswer;
            this.secondAnswer = secondAnswer;
            this.thirdAnswer = thirdAnswer;
            this.fourthAnswer = fourthAnswer;
            this.correctAnswer = correctAnswer;
        }
        public string qestion;
        public string firstAnswer;
        public string secondAnswer;
        public string thirdAnswer;
        public string fourthAnswer;
        public string correctAnswer;

    }
}

