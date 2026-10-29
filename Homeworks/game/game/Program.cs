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

    public void TakeDamage(int damage)
    {
        hp -= damage;         
    }

    public virtual void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"{target.Name} атакован.  Текущее HP {target.Name} - {target.Hp}");
    }

    public override string ToString()
    {
        return $"{Name}: (HP: {Hp}, урон: {Power})";
    }

    public override bool Equals(object? obj)
    {
        return obj is Character other && this.Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public static bool operator ==(Character obj1, Character obj2)
    {
        return Equals(obj1, obj2);
    }

    public static bool operator !=(Character obj1, Character obj2)
    {
        return !Equals(obj1, obj2);
    }

    public bool IsAlive()
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




class Program
{
    static void Main()
    {
        List<Character> characters = new List<Character>
        {
            new Player("Алексей", 100, 15),
            new Enemy("Рамен", 110, 10)
        };

        Character player1 = characters[0];
        Character enemy1  = characters[1];

        Console.WriteLine($"Бой начинается!\n");
        Console.WriteLine(player1);
        Console.WriteLine(enemy1);
        Console.WriteLine();

        while (player1.IsAlive() && enemy1.IsAlive())
        {
            player1.Attack(enemy1);
            Console.WriteLine();
            if (!enemy1.IsAlive()) break;
            enemy1.Attack(player1);
            Console.WriteLine();
        }

        if (player1.IsAlive())
            Console.WriteLine($"{player1.Name} победил!");
        else
            Console.WriteLine($"{enemy1.Name} победил!");
    }
}