using System;
using System.Collections.Generic;
class Bank
{
    private int Balance;
    private List<string> History = new List<string>();

    public Bank(int balance)
    {
        if (balance < 0)
        {
            Console.WriteLine("Начальный баланс не может быть отрицательным.");
            Balance=0;
            return;
        }
        Balance = balance;
    }

    public void Print(string currency="₽")
    {
        Console.WriteLine($"Нынешний баланс: {Balance} {currency}");
    }

    public void Add(int sum)
    {
        if (sum<=0){
             Console.WriteLine("Нельзя пополнить баланс на отрицательную сумму");
        }
        else{
            Balance += sum;
            History.Add($"Операция: баланс пополнен на {sum}. Нынешний баланс - {Balance}");
        }
    }
    
    public void Remove(int sum)
    {
        if (sum <= 0)
        {
            Console.WriteLine("Сумма должна быть больше нуля.");
        }
        else if (sum > Balance)
        {
            Console.WriteLine("Недостаточно средств на счёте.");
        }
        else
        {
            Balance -= sum;
            History.Add($"Операция: с баланса снято {sum}. Нынешний баланс - {Balance}");
        }
    }

    public void PrintHistory()
    {
        for (int i = 0; i < History.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {History[i]}");
        }
    }
}

partial class Program
{
    static void Main()
    {
        Console.Write("Введите стартовый баланс: ");
        int balance = int.Parse(Console.ReadLine());
        Bank UserBalance = new Bank(balance);
        Console.WriteLine($"Введите:\n0, чтобы выйти\n1, чтобы показать баланс\n2, чтобы пополнить баланс\n3, чтобы снять деньги\n4, чтобы вывести историю операций");
        int n = int.Parse(Console.ReadLine());
        while (n!=0){
            switch (n)
            {
                case 1:
                {
                    Console.WriteLine("Введите вашу валюту");
                    string cur = Console.ReadLine();
                    UserBalance.Print(cur);
                    Console.WriteLine($"Введите:\n0, чтобы выйти\n1, чтобы показать баланс\n2, чтобы пополнить баланс\n3, чтобы снять деньги\n4, чтобы вывести историю операций");
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                case(2):
                {
                    Console.WriteLine("Введите сумму, на которую вы хотите поплнить баланс");
                    int sum = int.Parse(Console.ReadLine());
                    UserBalance.Add(sum);
                    Console.WriteLine($"Введите:\n0, чтобы выйти\n1, чтобы показать баланс\n2, чтобы пополнить баланс\n3, чтобы снять деньги\n4, чтобы вывести историю операций");
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                case(3):
                {
                    Console.WriteLine("Введите сумму, которую вы хотите списать");
                    int sum = int.Parse(Console.ReadLine());
                    UserBalance.Remove(sum);
                    Console.WriteLine($"Введите:\n0, чтобы выйти\n1, чтобы показать баланс\n2, чтобы пополнить баланс\n3, чтобы снять деньги\n4, чтобы вывести историю операций");
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                case(4):
                {
                    Console.WriteLine("Ваша инстория операций:");
                    UserBalance.PrintHistory();
                    Console.WriteLine($"Введите:\n0, чтобы выйти\n1, чтобы показать баланс\n2, чтобы пополнить баланс\n3, чтобы снять деньги\n4, чтобы вывести историю операций");
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                default:
                {
                    Console.WriteLine("Неверный ввод, попробуйте еще раз");
                    Console.WriteLine($"Введите:\n0, чтобы выйти\n1, чтобы показать баланс\n2, чтобы пополнить баланс\n3, чтобы снять деньги\n4, чтобы вывести историю операций");
                    n = int.Parse(Console.ReadLine());
                    break; 
                }
               
            }
        }
    }
}