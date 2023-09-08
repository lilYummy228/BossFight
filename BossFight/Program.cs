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
            bool isGameOver = true;
            bool isOnFire = false;
            bool isOnWater = false;
            bool canCastSpell = true;
            int currentBossHP = 1000;
            int bossHP = currentBossHP;
            int currentHeroHP = 500;
            int heroHP = currentHeroHP;
            int partOfHP = 2;
            int heroWounded = currentHeroHP / partOfHP;
            int burningDamage = 0;
            int waterHealing = 0;

            Console.WriteLine("Boss Fight\nУр'Шалах Повелитель демонов\n");

            while (isGameOver)
            {
                Console.WriteLine($"\nЗдоровье Ур'Шалаха: {currentBossHP}/{bossHP} HP\nЗдоровье героя: {currentHeroHP}/{heroHP} HP\n");

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

                Console.WriteLine($"1. {CommandFireBall} - запускает огненный шар в противника, отчего он получает урон огнем и заставляет гореть," +
                    $" получая продолжительный урон.\n2. {CommandBloodThirst} (активен только при отсутствии половины здоровья) - " +
                    $"высасывает у противника часть здоровья и восстанавливает его вам.\n" +
                    $"3. {CommandRainDrop} - заставляет тучи сгуститься над вами, выпуская ливень.\n4. {CommandElectricity} (активен только после RainDrop) " +
                    $"- заставляет небеса развергнуться запуская из неба вспышки молний в противника.");
                Console.Write("\nКакое действие вы хотите выполнить? ");
                string chosenSpell = Console.ReadLine();

                switch (chosenSpell.ToLower())
                {
                    case CommandFireBall:
                        int fireballMinDamage = 120;
                        int fireballMaxDamage = 201;
                        int fireballDamage = random.Next(fireballMinDamage, fireballMaxDamage);
                        currentBossHP -= fireballDamage;
                        isOnFire = true;
                        isOnWater = false;
                        Console.WriteLine($"\nВы запускаете огненный шар в противника...\n({fireballDamage} урона огнем)");
                        break;

                    case CommandBloodThirst:

                        if (currentHeroHP <= heroWounded)
                        {
                            int bloodMinDamage = 50;
                            int bloodMaxDamage = 91;
                            int bloodDamage = random.Next(bloodMinDamage, bloodMaxDamage);
                            currentBossHP -= bloodDamage;
                            currentHeroHP += bloodDamage;
                            Console.WriteLine($"\nВы чувствуете вкус крови...\n({bloodDamage} урона и лечения кровью)");
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать заклинание!");
                            canCastSpell = false;
                        }
                        break;

                    case CommandRainDrop:
                        isOnFire = false;
                        isOnWater = true;
                        Console.WriteLine("\nПошел дождь...");
                        break;

                    case CommandElectricity:

                        if (isOnWater == true)
                        {
                            int elecroMinDamage = 250;
                            int electroMaxDamage = 401;
                            int electroDamage = random.Next(elecroMinDamage, electroMaxDamage);
                            currentBossHP -= electroDamage;
                            isOnFire = true;
                            isOnWater = false;
                            Console.WriteLine($"\nМолния застала вашего противника врасплох...\n({electroDamage} урона электричеством)");
                        }
                        else
                        {
                            Console.WriteLine("Невозможно использовать заклинание!");
                            canCastSpell = false;
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Неверное заклинание!");
                        canCastSpell = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();

                if (canCastSpell)
                {
                    int bossMinDamage = 80;
                    int bossMaxDamage = 121;
                    int bossDamage = random.Next(bossMinDamage, bossMaxDamage);
                    currentHeroHP -= bossDamage;
                    Console.Write($"Ур'Шалах нанес вам {bossDamage} урона\n");
                    Console.ReadKey();

                    if (isOnFire)
                    {
                        int burningMinDamage = 20;
                        int burningMaxDamage = 41;
                        burningDamage = random.Next(burningMinDamage, burningMaxDamage);
                        currentBossHP -= burningDamage;
                    }
                    else if (isOnWater)
                    {
                        int waterMinHealing = 20;
                        int waterMaxHealing = 41;
                        waterHealing = random.Next(waterMinHealing, waterMaxHealing);
                        currentHeroHP += waterHealing;
                    }
                }
                else
                {
                    canCastSpell = true;
                }

                if (currentHeroHP <= 0 && currentBossHP <= 0)
                {
                    Console.WriteLine("Вы убили Ур'Шалаха, но погибли сами...");
                    isGameOver = false;
                }
                else if (currentHeroHP > 0 && currentBossHP <= 0)
                {
                    Console.WriteLine("Вы уничтожили Повелителя демонов Ур'Шалаха!");
                    isGameOver = false;
                }
                else if (currentHeroHP <= 0 && currentBossHP > 0)
                {
                    Console.WriteLine("Вы стали очередной жертвой Повелителя демонов...");
                    isGameOver = false;
                }
            }
        }
    }
}
