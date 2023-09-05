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
            int heroHP = 500;
            int bossMinDamage = 80;
            int bossMaxDamage = 121;
            int heroWounded = heroHP / 2;
            int fireballMinDamage = 120;
            int fireballMaxDamage = 201;
            int burningMinDamage = 20;
            int burningMaxDamage = 41;
            int burningDamage = 0;
            int waterMinHealing = 20;
            int waterMaxHealing = 41;
            int waterHealing = 0;
            int bloodMinDamage = 50;
            int bloodMaxDamage = 91;
            int elecroMinDamage = 250;
            int electroMaxDamage = 401;


            Console.WriteLine("Boss Fight\nУр'Шалах Повелитель демонов\n");

            while (gameOver)
            {
                Console.WriteLine($"\nЗдоровье Ур'Шалаха: {bossHP} HP\nЗдоровье героя: {heroHP} HP\n");

                if (isOnFire)
                {
                    Console.WriteLine("Статус: под огнем");
                    Console.WriteLine($"Урон горением: {burningDamage} урона\n");
                }
                else if (isOnWater)
                {
                    Console.WriteLine("Статус: под дождем");
                    Console.WriteLine($"Лечение от воды: {waterHealing} здоровья\n");
                }

                Console.WriteLine($"1. FireBall - запускает огненный шар в противника, отчего он получает урон огнем и заставляет гореть," +
                    $" получая продолжительный урон.\n2. BloodThirst (активен только при отсутствии половины здоровья) - " +
                    $"высасывает у противника часть здоровья и восстанавливает его вам.\n" +
                    $"3. RainDrop - заставляет тучи сгуститься над вами, выпуская ливень.\n4. Electricity (активен только после RainDrop) " +
                    $"- заставляет небеса развергнуться запуская из неба вспышки молний в противника.");
                Console.Write("\nКакое действие вы хотите выполнить? ");
                string chosenSpell = Console.ReadLine();

                switch (chosenSpell.ToLower())
                {
                    case CommandFireBall:
                        int fireballDamage = random.Next(fireballMinDamage, fireballMaxDamage);
                        bossHP -= fireballDamage;
                        isOnFire = true;
                        isOnWater = false;
                        Console.WriteLine($"\nВы запускаете огненный шар в противника...\n({fireballDamage} урона огнем)");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case CommandBloodThirst:

                        if (heroHP <= heroWounded)
                        {
                            int bloodDamage = random.Next(bloodMinDamage, bloodMaxDamage);
                            bossHP -= bloodDamage;
                            heroHP += bloodDamage;
                            Console.WriteLine($"\nВы чувствуете вкус крови...\n({bloodDamage} урона и лечения кровью)");
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
                        Console.WriteLine("\nПошел дождь...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case CommandElectricity:

                        if (isOnWater == true)
                        {
                            int electroDamage = random.Next(elecroMinDamage, electroMaxDamage);
                            bossHP -= electroDamage;
                            isOnFire = true;
                            isOnWater = false;
                            Console.WriteLine($"\nМолния застала вашего противника врасплох...\n({electroDamage} урона электричеством)");
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
                    int bossDamage = random.Next(bossMinDamage, bossMaxDamage);
                    heroHP -= bossDamage;
                    Console.Write($"Ур'Шалах нанес вам {bossDamage} урона\n");
                    Console.ReadKey();

                    if (isOnFire)
                    {
                        burningDamage = random.Next(burningMinDamage, burningMaxDamage);
                        bossHP -= burningDamage;
                    }
                    else if (isOnWater)
                    {
                        waterHealing = random.Next(waterMinHealing, waterMaxHealing);
                        heroHP += waterHealing;
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
