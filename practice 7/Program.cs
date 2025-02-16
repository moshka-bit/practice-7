using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace practice_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>
            {
                {"Доход", new List<double>{ }},
                {"Продукты", new List<double>{ }},
                {"Транспорт", new List<double>{ }},
                {"Развлечения", new List<double>{ }}

            };

            while (true)
            {
                Console.Write("Добро пожаловать в систему управления финансами!\n\n1. Добавить доход/расход  \n2. Показать отчет  \r\n3. Рассчитать баланс  \r\n4. Прогноз на следующий месяц  \r\n5. Статистика\r\n6. Выход  \r\n\nВыберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("\r\nВведите категорию (Доход, Продукты, Транспорт, Развлечения): \r\n");
                            string choice_category = Console.ReadLine();
                            Console.Write("Введите сумму: ");
                            int sum = Convert.ToInt32(Console.ReadLine());
                            AddTransaction(dict, choice_category, sum);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Финансовый отчет:\n");
                            PrintFinanceReport(dict);
                            break;
                        }
                    case "3":
                        {
                            CalculateBalance(dict);
                            break;
                        }
                    case "4":
                        {
                            double result_func = GetAverageExpense(dict);
                            PredictNextMonthExpenses(result_func);
                            break;
                        }
                    case "5":
                        {
                            PrintStatistics(dict);
                            break;
                        }
                    case "6":
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

                Console.ReadKey();
            }
        }
        public static void AddTransaction(Dictionary<string, List<double>> dict, string choice_category, int sum)
        {

            switch (choice_category)
            {
                case "Доход":
                {
                    dict["Доход"].Add(sum);
                    Console.WriteLine("Запись добавлена.");

                    break;
                }
                case "Продукты":
                {
                    dict["Продукты"].Add(sum);
                    Console.WriteLine("Запись добавлена.");
                    break;
                }
                case "Транспорт":
                {
                    dict["Транспорт"].Add(sum);
                    Console.WriteLine("Запись добавлена.");
                    break;
                }
                case "Развлечения":
                {
                    dict["Развлечения"].Add(sum);
                    Console.WriteLine("Запись добавлена.");
                    break;
                }
                default:
                {
                    Console.WriteLine("Ошибка распознавания запроса, данной категории не существует");
                    break;
                }
            }
        }

        public static void PrintFinanceReport(Dictionary<string, List<double>> dict)
        {

            if (dict["Доход"].Count() != 0)
            {
                double sum = 0;
                foreach (double i in dict["Доход"])
                {
                    sum += i;
                }

                Console.WriteLine($"Доход: {sum} руб. - {dict["Доход"].Count()} операций");
            }
            if (dict["Продукты"].Count() != 0)
            {
                double sum2 = 0;
                foreach (double i in dict["Продукты"])
                {
                    sum2 += i;
                }

                Console.WriteLine($"Продукты: {sum2} руб. - {dict["Продукты"].Count()} операций");
            }
            if (dict["Транспорт"].Count() != 0)
            {
                double sum3 = 0;
                foreach (double i in dict["Транспорт"])
                {
                    sum3 += i;
                }

                Console.WriteLine($"Транспорт: {sum3} руб. - {dict["Транспорт"].Count()} операций");
            }
            if (dict["Развлечения"].Count() != 0)
            {
                double sum4 = 0;
                foreach (double i in dict["Развлечения"])
                {
                    sum4 += i;
                }

                Console.WriteLine($"Развлечения: {sum4} руб. - {dict["Развлечения"].Count()} операций");
            }
        }

        public static void CalculateBalance(Dictionary<string, List<double>> dict)
        {
            double sum = 0;
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;

            foreach (double i in dict["Доход"])
            {
                sum += i;
            }

            foreach (double i in dict["Продукты"])
            {
                sum2 += i;
            }

            foreach (double i in dict["Транспорт"])
            {
                sum3 += i;
            }

            foreach (double i in dict["Развлечения"])
            {
                sum4 += i;
            }
            Console.WriteLine($"Текущий баланс: {sum - (sum2 + sum3 + sum4)} руб.");
        }

        public static double GetAverageExpense(Dictionary<string, List<double>> dict)
        {
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;

            foreach (double i in dict["Продукты"])
            {
                sum2 += i;
            }

            foreach (double i in dict["Транспорт"])
            {
                sum3 += i;
            }

            foreach (double i in dict["Развлечения"])
            {
                sum4 += i;
            }
            List<double> lst = new List<double>();
            lst.Add(sum2 / dict["Продукты"].Count());
            lst.Add(sum3 / dict["Транспорт"].Count());
            lst.Add(sum4 / dict["Развлечения"].Count());
            double sum_lst = 0;
            foreach (double i in lst)
            {
                sum_lst += i;
            }
            return sum_lst;
        }

        public static void PredictNextMonthExpenses(double result_func)
        {
            Console.WriteLine($"Прогнозируемые расходы на следующий месяц: {result_func * 10} руб.  ");
        }

        public static void PrintStatistics(Dictionary<string, List<double>> dict)
        {
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;

            foreach (double i in dict["Продукты"])
            {
                sum2 += i;
                count2 += 1;
            }

            foreach (double i in dict["Транспорт"])
            {
                sum3 += i;
                count3 += 1;
            }

            foreach (double i in dict["Развлечения"])
            {
                sum4 += i;
                count4 += 1;
            }
            Console.WriteLine($"Статистика расходов: \nОбщая сумма расходов: {sum2 + sum3 + sum4} руб.");

            if (new[] { sum2, sum3, sum4 }.Max() == sum2)
            {
                Console.WriteLine($"Самая затратная категория: Продукты ({sum2} руб.)");
            }
            if (new[] { sum2, sum3, sum4 }.Max() == sum3)
            {
                Console.WriteLine($"Самая затратная категория: Транспорт ({sum3} руб.)");
            }
            if (new[] { sum2, sum3, sum4 }.Max() == sum4)
            {
                Console.WriteLine($"Самая затратная категория: Развлечения ({sum4} руб.)");
            }

            if (new[] { count2, count3, count4 }.Max() == count2)
            {
                Console.WriteLine($"Самая частая категория: Продукты ({count2} операций)");
            }
            if (new[] { count2, count3, count4 }.Max() == count3)
            {
                Console.WriteLine($"Самая частая категория: Транспорт ({count3} операций)");
            }
            if (new[] { count2, count3, count4 }.Max() == count4)
            {
                Console.WriteLine($"Самая частая категория: Развлечения ({count4} операций)");
            }

            double total_sum = sum2 + sum3 + sum4;
            double percent2 = (sum2 / total_sum) * 100;
            double percent3 = (sum3 / total_sum) * 100;
            double percent4 = (sum4 / total_sum) * 100;
            Console.WriteLine($"Процентное распределение расходов:\nПродукты: {sum2} руб. ({percent2}%) \r\nТранспорт: {sum3} руб. ({percent3}%) \r\nРазвлечения: {sum4} руб. ({percent4}%)\r\n");
        }
    }
}
