using Praktika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Praktika_monsters
{
    internal class Program
    {
        //Функция обновления хп-бара героя
        static string Update_hp_hero(double max_hp_hero, string hp_bar_hero)
        {
            if (max_hp_hero == 500) hp_bar_hero = @"[█████]";
            else if (max_hp_hero < 500 && max_hp_hero >= 400) hp_bar_hero = @"[████_]";
            else if (max_hp_hero < 400 && max_hp_hero >= 300) hp_bar_hero = @"[███__]";
            else if (max_hp_hero < 300 && max_hp_hero >= 200) hp_bar_hero = @"[██___]";
            else if (max_hp_hero < 200 && max_hp_hero >= 100) hp_bar_hero = @"[█____]";
            else hp_bar_hero = @"[_____]";

            return hp_bar_hero;
        }

        //Функция обновления хп-бара монстра
        static string Update_hp_monsters(double max_hp_monsters, string hp_bar_monsters)
        {
            if (max_hp_monsters == 800) hp_bar_monsters = @"[████████]";
            else if (max_hp_monsters < 800 && max_hp_monsters >= 700) hp_bar_monsters = @"[███████_]";
            else if (max_hp_monsters < 700 && max_hp_monsters >= 600) hp_bar_monsters = @"[██████__]";
            else if (max_hp_monsters < 600 && max_hp_monsters >= 500) hp_bar_monsters = @"[█████___]";
            else if (max_hp_monsters < 500 && max_hp_monsters >= 400) hp_bar_monsters = @"[████____]";
            else if (max_hp_monsters < 400 && max_hp_monsters >= 300) hp_bar_monsters = @"[███_____]";
            else if (max_hp_monsters < 300 && max_hp_monsters >= 200) hp_bar_monsters = @"[██______]";
            else if (max_hp_monsters < 200 && max_hp_monsters >= 100) hp_bar_monsters = @"[█_______]";
            else hp_bar_monsters = @"[_____]";

            return hp_bar_monsters;
        }

        static void Main(string[] args)
        {
            //Создание объекта класса "Волшебники"
            Heroes shadow_magician = new Heroes();

            shadow_magician.name = "Теневой маг";
            shadow_magician.max_hp = 500;
            shadow_magician.weapon = "Книга заклинаний";
            shadow_magician.basic_attack = "Темная сфера";
            shadow_magician.basik_attack_damage = 50;
            shadow_magician.charged_attack = "Поглощающая буря";
            shadow_magician.charged_attack_damage = 100;
            shadow_magician.special_attack = "Призыв теневого бойца";
            shadow_magician.special_attack_damage = 200;
            shadow_magician.ultra_attack = "Усиление теневого бойца";
            shadow_magician.ultra_attack_damage =
                shadow_magician.special_attack_damage + shadow_magician.special_attack_damage / 4;

            //Создание объекта класса "Монстры"
            Monsters ice_dragon = new Monsters();

            ice_dragon.name = "Снежный дракон";

            ice_dragon.image = @"
   ████████████████████████████████████████
   █████████████████████▄▄▄░░░▀██▀█████████
   ██████▀▀▀▀░░░▀▀▀█████▀▀▀▀░░░░▀░░████████
   █████▄░░░░░░░▄██▀▀░░░░░░░░░▄░░░░░███████
   █████▀░░░░░▄██▀░░░░░░░░░░░░███▄░░▀██████
   ███▀░░▄█▄▄███▀░░░░░░░▄███▄░░░▀▀░░░░▀▀███
   ██▀░░████████░░░░░░░██████░░░░░░░░░░░░██
   ██░░▄████████▄░░░░░░░████████▄▄▄▄░░░░███
   █░░░██████████▄░░░░░░░▀█████████████████
   █░░░▀███████████░░░░░░░░░▀▀█████████████
   ██░░░████████████▄▄░░░░░░░░░░▀▀█████████
   ██░░░░██████████████▄░░░░░░░░░░░▀███████
   ██▄░░░░▀███████████████▄░░░░░░░░░░██████
   ███▄░░░░░▀███████████████░░░░░░░░░░█████
   ████▄░░░░░░▀▀████████████░░░░░░░░░▄█████
   █████▄░░░░░░░░░▀▀▀▀██▀▀▀░░░░░░░░░░██████
   ███████▄░░░░░░░░░░░░░░░░░░░░░░░░▄███████
   █████████▄▄░░░░░░░░░░░░░░░░░░░▄█████████
   ████████████▄▄░░░░░░░░░░░░▄▄████████████
   ████████████████████████████████████████";

            ice_dragon.max_hp = 800;
            ice_dragon.weapon = "Ледяное дыхание";
            ice_dragon.basik_attack_damage = 50;
            ice_dragon.third_attack_damage =
                ice_dragon.basik_attack_damage + ice_dragon.basik_attack_damage / 2;

            //Создание объекта класса "Зелья"
            Potions treatment = new Potions();

            treatment.title = "4-ех листный клевер";
            treatment.ability = "Восстанавливает HP";
            treatment.ability_plus = 100;

            //Запуск игры
            string header_game = "**!Добро пожаловать в игровую вселенную!**\r\n\r\n";

            //центр консоли по горизонтали
            int center_x = (Console.WindowWidth / 2) - (header_game.Length / 2);
            Console.SetCursorPosition(center_x, 1);
            Console.WriteLine(header_game);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(new string('_', Console.WindowWidth));  //рисование линии во всю ширину рабочего окна
            Console.SetCursorPosition(0, 5);

            //прохождение игры за "Теневого мага"

            Console.Write("     Легенда:\r\n\r\n");
            shadow_magician.print_Greetings();
            Console.Write("     Битва:\r\n");
            shadow_magician.print_data();
            ice_dragon.print_data();

            Console.Write("        *Встать на защиту королевства? (да/нет)*\r\n");
            Console.SetCursorPosition(8, 25);
            string start = Console.ReadLine();

            //условие начала боя
            if (start == "да")
            {
                Console.Clear();

                //характеристика хп
                string title_hp_bar_hero = "HP героя "; //хп героя
                string hp_bar_hero = @"[█████]";
                string title_hp_bar_monster = "HP монстра "; //хп монстра
                string hp_bar_monsters = @"[████████]";

                int count_attack_monsters = 0; //счетчик кол-ва аттак монстра
                int count_special_attack = 0; //счетчик использования "Призыва теневого воина"

                while ((shadow_magician.max_hp > 0) && (ice_dragon.max_hp > 0))
                {
                    double max_hp_hero = shadow_magician.max_hp;
                    double max_hp_monsters = ice_dragon.max_hp;

                    Console.SetCursorPosition(3, 1);        //вывод хп-бара героя
                    Console.WriteLine(title_hp_bar_hero);
                    Console.SetCursorPosition(12, 1);
                    Console.WriteLine(hp_bar_hero);
                    Console.SetCursorPosition(20, 1);
                    Console.WriteLine($"{(max_hp_hero * 100) / 500} %");

                    Console.SetCursorPosition(35, 1);         //вывод хп-бара монстра
                    Console.WriteLine(title_hp_bar_monster);
                    Console.SetCursorPosition(46, 1);
                    Console.WriteLine(hp_bar_monsters);
                    Console.SetCursorPosition(57, 1);
                    Console.WriteLine($"{(max_hp_monsters * 100) / 800} %");

                    Console.SetCursorPosition(0, 3);     //вывод картинки монстра
                    Console.WriteLine(ice_dragon.image);

                    shadow_magician.print_Instructions();  //вывод инструкция
                    treatment.print_Ability();

                    Console.SetCursorPosition(0, 25);

                    ice_dragon.print_Basic_attack(); //первый удар наносит монстр
                    shadow_magician.max_hp -= ice_dragon.basik_attack_damage;
                    count_attack_monsters++;

                    //выбор атаки
                    char attack = Convert.ToChar(Console.ReadLine()); //выбор атаки

                    switch (attack)
                    {
                        case '/':
                            shadow_magician.print_Basic_attack();
                            ice_dragon.max_hp -= shadow_magician.basik_attack_damage;
                            break;

                        case '*':
                            shadow_magician.print_Charged_attack();
                            ice_dragon.max_hp -= shadow_magician.charged_attack_damage;
                            break;

                        case '!':
                            shadow_magician.print_Special_attack();
                            ice_dragon.max_hp -= shadow_magician.special_attack_damage;
                            shadow_magician.max_hp -= 20;
                            count_special_attack++;
                            break;

                        case '#':
                            if (count_special_attack >= 1)
                            {
                                shadow_magician.print_Ultra_attack();
                                ice_dragon.max_hp -= shadow_magician.ultra_attack_damage;
                                count_special_attack = 0; ;
                            }
                            else Console.WriteLine("\r\n!! Призовите теневого бойца, чтобы использовать данное заклинание !!\r\n");
                            break;

                        case '+':
                            treatment.print_Get_potion();
                            shadow_magician.max_hp += treatment.ability_plus;
                            break;

                    }

                    if (count_attack_monsters >= 2) //условие, для усиления атаки монстра
                    {
                        ice_dragon.print_Third_attack();
                        shadow_magician.max_hp -= ice_dragon.third_attack_damage;
                        count_attack_monsters = 0;
                    }

                    //вывод информации хп
                    hp_bar_hero = Update_hp_hero(max_hp_hero, hp_bar_hero);
                    hp_bar_monsters = Update_hp_monsters(max_hp_monsters, hp_bar_monsters);

                    Thread.Sleep(5000);
                    Console.Clear();

                }

                //определение результата битвы
                if (shadow_magician.max_hp <= 0)
                {
                    string game_over = "GAME OVER...\r\n\r\n";

                    int centerX = (Console.WindowWidth / 2) - (game_over.Length / 2);
                    int centerY = (Console.WindowHeight / 2) - 1;
                    Console.SetCursorPosition(centerX, centerY);
                    Console.Write(game_over);

                }
                
                else if (shadow_magician.max_hp <= 0 && ice_dragon.max_hp <= 0)
                {
                    string restart = "СИЛЫ РАВНЫ...\r\n\r\n";

                    int centerX = (Console.WindowWidth / 2) - (restart.Length / 2);
                    int centerY = (Console.WindowHeight / 2) - 1;
                    Console.SetCursorPosition(centerX, centerY);
                    Console.Write(restart);

                }

                else
                {
                    string win = "YOUR WINNER! +10000000000 золота\r\n\r\n";

                    int centerX = (Console.WindowWidth / 2) - (win.Length / 2);
                    int centerY = (Console.WindowHeight / 2) - 1;
                    Console.SetCursorPosition(centerX, centerY);
                    Console.Write(win);

                }
            }
            else Console.Write("\r\n        **Необходимо быть храбрым, да бы победить свой страх**\r\n\r\n");
        }
    }
}
