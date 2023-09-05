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

            Random random = new Random();
            bool gameOver = true;
            bool isOnFire = false;
            bool isOnWater = false;
            bool isRightSpell = true;
            int bossHP = 1000;
            int heroHP = random.Next(500, 601);
            int bossMinDamage = 80;
            int bossMaxDamage = 121;
            int heroWounded = heroHP / 2;
            int fireballMinDamage = 100;
            int fireballMaxDamage = 221;
            int burningMinDamage = 30;
            int burningMaxDamage = 51;
            int waterMinHealing = 20;
            int waterMaxHealing = 41;
            int bloodMinDamage = 60;
            int bloodMaxDamage = 91;
            int elecroMinDamage = 250;
            int electroMaxDamage = 401;


            Console.WriteLine("Boss Fight\nУр'Шалах Повелитель демонов");

            while (gameOver)
            {
                Console.WriteLine($"\nЗдоровье Ур'Шалаха: {bossHP} HP\nЗдоровье героя: {heroHP} HP\n");

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
                        bossHP -= random.Next(fireballMinDamage, fireballMaxDamage);
                        isOnFire = true;
                        isOnWater = false;
                        Console.WriteLine("Вы запускаете огненный шар в противника...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case CommandBloodThirst:

                        if (heroHP <= heroWounded)
                        {
                            int bloodDamage = random.Next(bloodMinDamage, bloodMaxDamage);
                            bossHP -= bloodDamage;
                            heroHP += bloodDamage;
                            Console.WriteLine("Вы чувствуете вкус крови...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать заклинание!");
                            isRightSpell = false;
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
                            bossHP -= random.Next(elecroMinDamage, electroMaxDamage);
                            isOnFire = true;
                            isOnWater = false;
                            Console.WriteLine("Молния застала вашего противника врасплох...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать заклинание!");
                            isRightSpell = false;
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;

                    default:
                        Console.WriteLine("Неверное заклинание!");
                        Console.ReadKey();
                        Console.Clear();
                        isRightSpell = false;
                        break;
                }

                if (isRightSpell)
                {
                    heroHP -= random.Next(bossMinDamage, bossMaxDamage);

                    if (isOnFire)
                    {
                        bossHP -= random.Next(burningMinDamage, burningMaxDamage);
                    }
                    else if (isOnWater)
                    {
                        heroHP += random.Next(waterMinHealing, waterMaxHealing);
                    }
                }
                else
                {
                    isRightSpell = true;
                }


                if (heroHP <= 0 && bossHP <= 0)
                {
                    Console.WriteLine("Вы убили Ур'Шалаха, но погибли сами...");
                    gameOver = false;
                }
                else if (heroHP > 0 && bossHP <= 0)
                {
                    Console.WriteLine("Вы уничтожили Повелителя демонов Ур'Шалаха!");
                    gameOver = false;
                }
                else if (heroHP <= 0 && bossHP > 0)
                {
                    Console.WriteLine("Вы стали очередной жертвой Повелителя демонов...");
                    gameOver = false;
                }
            }
        }
    }
}
