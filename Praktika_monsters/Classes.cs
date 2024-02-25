using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Praktika
{
    //Объявление класса персонажей категории "Волшебники"
    class Wizards
    {
        //атрибуты класса
        public string name;  //имя
        public double max_hp;   //максимальное кол-во хп

        public string weapon;    //вид оружия

        public string basic_attack;  //название базовой атаки
        public double basik_attack_damage;  //урон базовой атаки

        public string charged_attack;  //название заряженной атаки
        public double charged_attack_damage;  //урон заряженной атаки

        public string special_attack;  //название особой атаки
        public double special_attack_damage;  //урон особой атаки атаки

        public string ultra_attack;  //название особой атаки
        public double ultra_attack_damage;  //урон особой атаки атаки

        //методы класса
        public void print_Greetings() //приветствие игрока
        {
            Console.WriteLine($"       Великий {name}, королевство нуждается в твоей помощи!\r\n" +
                $"       Каменные стены не в силах больше сдерживать натиск атак свирепого дракона.\r\n" +
                $"       Королевская палата обещает одарить спасителя несчитанным кол-вом золота\r\n\r\n");
        }

        public void print_Instructions() //инструкции
        {
            string instructions = $"  Для одержания победы над драконом используйте изученные заклинания:\r\n" +
                $"    / - {basic_attack} - наносит {basik_attack_damage}ед урона\r\n" +
                $"    * - {charged_attack} - наносит {charged_attack_damage}ед урона\r\n" +
                $"    ! - {special_attack} - наносит {special_attack_damage}ед урона, но отнимает 20 HP\r\n" +
                $"    # - {ultra_attack} - наносит {ultra_attack_damage}ед урона\r\n" +
                $"        (доступно только после {special_attack})\r\n" +
                $"\r\n  !! Важно: каждая 3 атака врага наносит на 5% урона больше !!\r\n";

            string[] lines = Regex.Split(instructions, "\r\n|\r|\n");
            int position_y = 7;

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(48, position_y);
                Console.WriteLine(lines[i]);
                position_y++;
            }
            
        }

        public void print_data() //характеристики игрока
        {
            Console.WriteLine($"\r\n        Вы: {name}\r\n" +
                $"            оружие - {weapon}\r\n" +
                $"            HP - {max_hp}\r\n");
        }
        public void print_Basic_attack() //вывод базовой атаки
        {
            Console.WriteLine($"\r\n  --> Вы нанесли {basik_attack_damage}ед урона\r\n");
        }
        public void print_Charged_attack() //вывод заряженной атаки
        {
            Console.WriteLine($"\r\n  --> Вы нанесли {charged_attack_damage}ед урона\r\n");
        }
        public void print_Special_attack() //вывод особой атаки
        {
            Console.WriteLine($"\r\n  --> Вы нанесли {special_attack_damage}ед урона (-20 HP)\r\n");
        }
        public void print_Ultra_attack() //вывод особой атаки
        {
            Console.WriteLine($"\r\n  --> Вы нанесли {ultra_attack_damage}ед урона\r\n");
        }
    }

    //Объявление класса зелий
    class Potions
    {
        //атрибуты класса
        public string title;  //название
        public string ability;   //способность
        public double ability_plus;  //результат применения 

        //методы класса
        public void print_Ability() //характеристики зелий
        {
            string ability_instructions = $"\r\n  Вам так же доступны волшебные зелья:\r\n" +
                $"    + - {title} - {ability} на {ability_plus}ед\r\n";

            string[] lines = Regex.Split(ability_instructions, "\r\n|\r|\n");
            int position_y = 17;

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(48, position_y);
                Console.WriteLine(lines[i]);
                position_y++;
            }
        }

        public void print_Get_potion() //вывод использования зелья
        {
            Console.WriteLine($"\r\n  +++ Вы восстановили здоровье на {ability_plus}ед +++\r\n");
        }
    }

    //Объявление класса монстров
    class Monsters
    {
        //атрибуты класса
        public string name;
        public string image;   //вид монстра
        public double max_hp;   //максимальное кол-во хп

        public string weapon;    //вид оружия

        public double basik_attack_damage;  //урон базовой атаки
        public double third_attack_damage;  //урон заряженной атаки

        //методы класса
        public void print_data() //характеристики монтсра
        {
            Console.WriteLine($"\r\n        Враг: {name}\r\n" +
                $"              оружие - {weapon}\r\n" +
                $"              HP - {max_hp}\r\n");
        }
        public void print_Basic_attack() //вывод базовой атаки
        {
            Console.WriteLine($"\r\n  --> Враг нанес {basik_attack_damage}ед урона\r\n");
        }
        public void print_Third_attack() //вывод заряженной атаки
        {
            Console.WriteLine($"\r\n  --> Враг нанес {third_attack_damage}ед урона\r\n");
        }
    }
}