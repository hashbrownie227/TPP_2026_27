using System;
using System.ComponentModel.DataAnnotations;
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
        Console.WriteLine($"Я, {this.Name}, остановлю злодея {target.Name}! Его текущее HP - {target.Hp}");
    }
}

class Enemy: Character
{
    public Enemy(string name="Alexey", int hp=100, int power=10): base(name, hp, power){}

    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"Мухехехехе какой я, {this.Name}, злой. Я атаковал {target.Name}. Его текущее HP - {target.Hp}");
    }

}



class Program
{
    static void Main()
    {
        List<Character> characters = new List<Character>
        {
            new Player("Алексей", 100, 15),
            new Enemy("Очень плохой", 110, 10),
            new Player("Леонид", 98, 16),
            new Enemy("Плохой", 111, 25)
        };

        Console.WriteLine($"Бой начинается! Все бьют друг друга по кругу\n");
        foreach (Character el in characters)
        {
            Console.WriteLine(el);
        }
        Console.WriteLine();

        while (characters.Count > 1)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters.Count == 1) break;
                if (i == characters.Count - 1)
                {
                    characters[i].Attack(characters[0]);
                    Console.WriteLine();
                    if (!characters[0].IsAlive())
                    {
                        Console.WriteLine($"{characters[0].Name} пал!\n");
                        characters.RemoveAt(0);
                        i--; 
                    }
                }
                else
                {
                    characters[i].Attack(characters[i+1]);
                    Console.WriteLine();
                    if (!characters[i+1].IsAlive())
                    {
                        Console.WriteLine($"{characters[i+1].Name} пал!\n");
                        characters.RemoveAt(i+1);
                        i--; 
                    }
                }
            }
        }
        if (characters.Count == 1)
        {
            Console.WriteLine($"{characters[0].Name} победил!!!");
        }
    }
}