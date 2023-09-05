using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandFireBall = "fireball";
            const string CommandBloodThirst = "bloodthirst";
            const string CommandRainDrop = "raindrop";
            const string CommandElectricity = "electricity";

            bool gameOver = true;
            bool isOnFire = false;
            bool isOnWater = false;
            int bossHP = 1000;
            int heroHP = 500;
            Random randomDamage = new Random();

            Console.WriteLine("Boss Fight\nУр'Шалах Повелитель демонов");

            while (gameOver)
            {
                Console.WriteLine($"\nЗдоровье Ур'Шалаха: {bossHP}\nЗдоровье героя: {heroHP}\n");

                if (isOnFire)
                {
                    Console.WriteLine("Статус: под огнем\n");
                }
                else if (isOnWater)
                {
                    Console.WriteLine("Статус: под дождем\n");
                }

                Console.WriteLine($"1. FireBall - запускает огненный шар в противника, отчего он получает урон огнем и заставляет гореть," +
                    $" получая продолжительный урон.\n2. BloodThirst (активен только при отсутствии половины здоровья) - " +
                    $"высасывает у противника часть здоровья и восстанавливает его вам.\n" +
                    $"3. RainDrop - заставляет тучи сгуститься над вами, выпуская ливень.\n4. Electricity (активен только после RainDrop) " +
                    $"- заставляет небеса развергнуться запуская из неба вспышки молний в противника.");
                Console.Write("Какое действие вы хотите выполнить? ");
                string chosenSpell = Console.ReadLine();

                switch (chosenSpell.ToLower())
                {
                    case CommandFireBall:
                        bossHP -= randomDamage.Next(120, 221);
                        isOnFire = true;
                        isOnWater = false;
                        Console.WriteLine("Вы запускаете огненный шар в противника...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case CommandBloodThirst:

                        if (heroHP <= 250)
                        {
                            bossHP -= randomDamage.Next(50, 101);
                            heroHP += randomDamage.Next(50, 101);
                            Console.WriteLine("Вы чувствуете вкус крови...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать заклинание!");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;

                    case CommandRainDrop:
                        isOnFire = false;
                        isOnWater = true;
                        Console.WriteLine("Пошел дождь...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case CommandElectricity:

                        if (isOnWater == true)
                        {
                            bossHP -= randomDamage.Next(250, 451);
                            isOnFire = true;
                            isOnWater = false;
                            Console.WriteLine("Молния застала вашего противника врасплох...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать заклинание!");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;

                    default:
                        Console.WriteLine("Неверное заклинание!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

                if (isOnFire)
                {
                    bossHP -= randomDamage.Next(10, 21);
                }

                if (isOnWater)
                {
                    heroHP += randomDamage.Next(10, 21);
                }

                if (heroHP > 500)
                {
                    heroHP = 500;
                }

                heroHP -= randomDamage.Next(50, 121);
            }
        }
    }
}
