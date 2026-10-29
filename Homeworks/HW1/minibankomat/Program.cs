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
        Console.WriteLine($"\nНынешний баланс: {Balance} {currency}\n");
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








using System;
class Character
{
    string name;
    int hp;
    int power;
    static int count;

    public static int HowMany()
    {
        return count;
    }

    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }

    public Character(string name="Alexey", int hp=100, int power=10)
    {
        if (Character.IsValidStats(hp, power))
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
        }
        else
        {
            Console.WriteLine("Неверные параметры персонажа. Задаю параметры hp и power по умолчанию");
            this.name = name;
            this.hp = 100;
            this.power = 10;
        }
        count++;
    }
    public string Name
    {
        get{return name; }
    }

    public int Hp
    {
        get{return hp; }
    }

    public int Power
    {
        get{return power; }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;         
    }

    public virtual void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"{target.Name} атакован.  Текущее HP {target.Name} - {target.Hp}");
    }

    public void GetStatus()
    {
        Console.WriteLine($"Статус персонажа{Name}:\nHP: {Hp}");
    }

    public bool IsALive()
    {
        if (Hp > 0) return true;
        else return false;
    }
}


class Player: Character
{
    public Player(string name="Alexey", int hp=100, int power=10): base(name, hp, power){}

    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"Я остановлю злодея {target.Name}! Его текущее HP - {target.Hp}");
    }
}

class Enemy: Character
{
    public Enemy(string name="Alexey", int hp=100, int power=10): base(name, hp, power){}

    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"Мухехехехе какой я злой. Я атаковал {target.Name}. Его текущее HP - {target.Hp}");
    }

}