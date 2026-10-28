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

    public void Attack(Character target)
    {
        target.hp -= this.power;
        Console.WriteLine($"{target.name} атакован.  Текущее HP {target.name} - {target.hp}");
    }

    public void GetStatus()
    {
        Console.WriteLine($"Статус персонажа{this.name}:\nHP: {this.hp}");
    }
}


class Player: Character
{
    public Player(string name="Alexey", int hp=100, int power=10): base(name, hp, power){}
}

class Enemy: Character
{
    public Enemy(string name="Alexey", int hp=100, int power=10): base(name, hp, power){}

}