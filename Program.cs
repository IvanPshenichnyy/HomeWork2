using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        //Описание меню программы 
        static void refreshMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=====================");
            Console.WriteLine("Пшеничный Иван, Практика 2");
            Console.WriteLine("1 - Метод, возвращающий минимальное из трёх чисел.");
            Console.WriteLine("2 - Метод подсчета количества цифр числа.");
            Console.WriteLine("3 - С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.");
            Console.WriteLine("4 - Метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.");
            Console.WriteLine("0 - Завершение работы приложения.");
            Console.WriteLine("=====================");
            Console.WriteLine("Введите номер задачи: ");
            Console.ResetColor();
        }
        static void errorMenu()
        {
            refreshMenu();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы ввели некорректный номер задачи.\nПовторите попытку ввода.");
            Console.ResetColor();
            Console.ReadKey();
        }

        // Обработчики ошибок
        static int returnNumber()
        {
            //int number = 0;
            //string number = Console.ReadLine();
            bool isNum = int.TryParse(Console.ReadLine(), out int number);
            if (!isNum)
            {
                
                Console.WriteLine("Пожалуйста введите число. ");
                number = returnNumber();
            };
            return number;
        }

        // Основные функции 
        static void minimumOfThreeValues()
        {
            Console.Clear();
            Console.WriteLine("Метод, возвращающий минимальное из трёх чисел.");
            Console.Write("Ввдите первое число. ");
            int number1 = returnNumber();
            Console.Write("Ввдите второе число. ");
            int number2 = returnNumber();
            Console.Write("Ввдите третье число. ");
            int number3 = returnNumber();
            int min;
            min = number1 < number2 ? number1 : (number2 < number3 ? number2 : number3);
            if (min == number1 && min == number2 && min == number3)
            {
                Console.WriteLine($"Минимальное число отсутствует, все числа равны {min}");
            }
            else
            {
                Console.WriteLine("Минимальное число {0}", min);
            }
            Console.WriteLine("Для возврата в меню нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        static void numberOfcharacters()
        {
            Console.Clear();
            Console.WriteLine("Метод подсчета количества цифр числа.");
            Console.Write("Ввдите произвольное число. ");
            int number = returnNumber();
            int i = 1;
            while (i < number.ToString().Length)
            {
                i++;
            }
            Console.WriteLine($"Количестово символов в числе = {i}");
            Console.WriteLine("Для возврата в меню нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        static void waitZero()
        {
            Console.Clear();
            Console.WriteLine("С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.");
            Console.Write("Ввдите произвольное число. ");
            int number = returnNumber();
            while (number != 0)
            {
                Console.Write("Ввдите произвольное число. ");
                number = returnNumber();
            };
            Console.WriteLine($"Введено число {number}.\nКонец работы. ");
            Console.WriteLine("Для возврата в меню нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        static void authorization()
        {
            Console.Clear();
            string login;
            string password;
            bool isOk = false;
            int i = 1;
            do
            {
                Console.Write("Ввдите логин. ");
                login = Console.ReadLine();
                Console.Write("Ввдите пароль. ");
                password = Console.ReadLine();
                isOk = authorizationVerification(login, password);
                if (!isOk)
                {
                    Console.Clear();
                    Console.WriteLine("погин и пароль введены не верно. Осталось попыток {0}", 3 - i);
                } 
                if (i >= 3) break;
                i++;
            }
            while (!isOk);
            if(i == 3 && !isOk)
            {
                Console.WriteLine("Вы исчерпали три попытки ввода логина и пароля.");
            }
            else
            {
                Console.WriteLine("Успешно!");
            }
            Console.WriteLine("Для возврата в меню нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }
        static bool authorizationVerification(string login, string password)
        {

            bool isOk = false;
            if (login == "root" && password == "GeekBrains")
            {
                isOk = true;
            }

            return isOk;
        }


        static void Main(string[] args)
        {
            bool flag = true;

            while (flag)
            {

                  
                refreshMenu();
               
                int taskNumber = returnNumber();

                switch (taskNumber)
                {
                    case 1:
                        //1. Написать метод, возвращающий минимальное из трёх чисел.
                        minimumOfThreeValues(); 
                        break;
                    case 2:
                        numberOfcharacters();
                        break;
                    case 3:
                        waitZero();
                        break;
                    case 4:
                        authorization();
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        errorMenu();
                        break;
                }
            }


            Console.WriteLine("Завершение работы приложения.");
            Console.ReadKey();

        }
    }
}
