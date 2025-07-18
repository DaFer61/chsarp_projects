﻿    /*
    ███╗░░░███╗██╗███╗░░██╗███████╗░██████╗░██╗░░░░░░░██╗███████╗███████╗██████╗░███████╗██████╗░
    ████╗░████║██║████╗░██║██╔════╝██╔════╝░██║░░██╗░░██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗
    ██╔████╔██║██║██╔██╗██║█████╗░░╚█████╗░░╚██╗████╗██╔╝█████╗░░█████╗░░██████╔╝█████╗░░██████╔╝
    ██║╚██╔╝██║██║██║╚████║██╔══╝░░░╚═══██╗░░████╔═████║░██╔══╝░░██╔══╝░░██╔═══╝░██╔══╝░░██╔══██╗
    ██║░╚═╝░██║██║██║░╚███║███████╗██████╔╝░░╚██╔╝░╚██╔╝░███████╗███████╗██║░░░░░███████╗██║░░██║
    ╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝
    */
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
public static class Global
{
    public static int width;
    public static int height;
    public static int start_x;
    public static int start_y;
    public static int current_x;
    public static int current_y;
    public static int flag;
    public static int flag_x;
    public static int flag_y;
    public static int bomb_count;
    public static int bomb_near;
    public static bool game_over = false;
    public static int[] coords = new int[2];
    public static string[] check_coords = new string[2];
    public static string[] field_coords = new string[2];
    public static string[] majom_coords = new string[2];
    public static string[,] field;
    public static string[,] bomb_field;
    public static int[,] list_convert;
    public static int remaining_bombs;
    public static HashSet<string> mines = new HashSet<string>();
    public static HashSet<string> field_check = new HashSet<string>();
    public static HashSet<string> checked_fields = new HashSet<string>();
    public static Random randomx = new Random();
    public static Random randomy = new Random();
    //------------------------------------------------------------------------------//
    //FŐPROGRAM//
    static void Main()
    {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("▒█▀▄▀█ ▀█▀ ▒█▄░▒█ ▒█▀▀▀ ▒█▀▀▀█ ▒█░░▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀█");
        Console.WriteLine("▒█▒█▒█ ▒█░ ▒█▒█▒█ ▒█▀▀▀ ░▀▀▀▄▄ ▒█▒█▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▄▄█ ▒█▀▀▀ ▒█▄▄▀");
        Console.WriteLine("▒█░░▒█ ▄█▄ ▒█░░▀█ ▒█▄▄▄ ▒█▄▄▄█ ▒█▄▀▄█ ▒█▄▄▄ ▒█▄▄▄ ▒█░░░ ▒█▄▄▄ ▒█░▒█");
        Console.WriteLine("\n");
        Console.ResetColor();
        game_over = false;
        MineSweeper();
        BombCheck();
        /*Table();*/
        FieldCheck();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("▒█▀▄▀█ ▀█▀ ▒█▄░▒█ ▒█▀▀▀ ▒█▀▀▀█ ▒█░░▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀█");
        Console.WriteLine("▒█▒█▒█ ▒█░ ▒█▒█▒█ ▒█▀▀▀ ░▀▀▀▄▄ ▒█▒█▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▄▄█ ▒█▀▀▀ ▒█▄▄▀");
        Console.WriteLine("▒█░░▒█ ▄█▄ ▒█░░▀█ ▒█▄▄▄ ▒█▄▄▄█ ▒█▄▀▄█ ▒█▄▄▄ ▒█▄▄▄ ▒█░░░ ▒█▄▄▄ ▒█░▒█");
        Console.WriteLine("\n");
        Console.ResetColor();
        Table();
        while (!game_over)
        {
            BombStart();
            BombCheck();
            FieldCheck();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("▒█▀▄▀█ ▀█▀ ▒█▄░▒█ ▒█▀▀▀ ▒█▀▀▀█ ▒█░░▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀█");
            Console.WriteLine("▒█▒█▒█ ▒█░ ▒█▒█▒█ ▒█▀▀▀ ░▀▀▀▄▄ ▒█▒█▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▄▄█ ▒█▀▀▀ ▒█▄▄▀");
            Console.WriteLine("▒█░░▒█ ▄█▄ ▒█░░▀█ ▒█▄▄▄ ▒█▄▄▄█ ▒█▄▀▄█ ▒█▄▄▄ ▒█▄▄▄ ▒█░░░ ▒█▄▄▄ ▒█░▒█");
            Console.WriteLine("\n");
            Console.ResetColor();
            Table();
        }
        GameOver();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("▒█▀▄▀█ ▀█▀ ▒█▄░▒█ ▒█▀▀▀ ▒█▀▀▀█ ▒█░░▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▀▀█ ▒█▀▀▀ ▒█▀▀█");
        Console.WriteLine("▒█▒█▒█ ▒█░ ▒█▒█▒█ ▒█▀▀▀ ░▀▀▀▄▄ ▒█▒█▒█ ▒█▀▀▀ ▒█▀▀▀ ▒█▄▄█ ▒█▀▀▀ ▒█▄▄▀");
        Console.WriteLine("▒█░░▒█ ▄█▄ ▒█░░▀█ ▒█▄▄▄ ▒█▄▄▄█ ▒█▄▀▄█ ▒█▄▄▄ ▒█▄▄▄ ▒█░░░ ▒█▄▄▄ ▒█░▒█");
        Console.WriteLine("\n");
        Console.ResetColor();
        Table();
        NewGame();
    }
    //------------------------------------------------------------------------------//
    static void MineSweeper()
    {
        Console.Write("A tábla szélessége :");
        width = int.Parse(Console.ReadLine());
        Console.Write("A tábla magassága :");
        height = int.Parse(Console.ReadLine());

        Console.Write("Az induló mező X koordinátájának megadása:");
        start_y = int.Parse(Console.ReadLine());
        Console.Write("Az induló mező y koordinátájának megadása:");
        start_x = int.Parse(Console.ReadLine());

        bomb_count = (width * height) / 7;
        flag = 0;
        remaining_bombs = bomb_count;
        current_x = start_x;
        current_y = start_y;
        TableGen();
    }
    static void TableGen()
    {
        field = new string[height, width];
        bomb_field = new string[height, width];
        coords = new int[2];
        mines = new HashSet<string>();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                field[i, j] = "[ ]";
                bomb_field[i, j] = "[ ]";
            }
        }

        while (mines.Count < bomb_count)
        {
            coords[0] = randomx.Next(0, height);
            coords[1] = randomy.Next(0, width);
            
            if ((coords[0] == start_x - 1) & (coords[1] == start_y - 1))
            {
                continue;
            }
            if ((coords[0] == start_x - 2) & (coords[1] == start_y - 2))
            {
                continue;
            }
            if ((coords[0] == start_x - 2) & (coords[1] == start_y - 1))
            {
                continue;
            }
            if ((coords[0] == start_x - 2) & (coords[1] == start_y))
            {
                continue;
            }
            if ((coords[0] == start_x - 1) & (coords[1] == start_y - 2))
            {
                continue;
            }
            if ((coords[0] == start_x - 1) & (coords[1] == start_y))
            {
                continue;
            }
            if ((coords[0] == start_x) & (coords[1] == start_y - 2))
            {
                continue;
            }
            if ((coords[0] == start_x) & (coords[1] == start_y - 1))
            {
                continue;
            }
            if ((coords[0] == start_x) & (coords[1] == start_y))
            {
                continue;
            }
            else
            {
                mines.Add($"{coords[0] + 1};{coords[1] + 1}");               
            }            
        }
        /*
        foreach (string maom in mines)
        {
            Console.Write($"{maom} ");
        }
        Console.Write("\n");
        for (int i = 0; i < height; i++)
        {

            for (int j = 0; j < width; j++)
            {      
                if ((j == start_x - 1) & (i == start_y - 1))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(field[i, j]);
                }
            }
            Console.Write("\n");
        }*/
    }
    static void Table()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("    ");
        string color = "";  
        for (int i = 0; i < width; i++)
        {
            if (i < 9)
            {
                Console.Write($" {i + 1} ");

            }
            else
            {
                Console.Write($"{i + 1} ");
            }
            color += "   ";
        }
        Console.Write("\n");
        Console.Write("    ");
        Console.Write(color);
        Console.Write("\n");
        Console.ResetColor();
        for (int i = 0; i < height; i++)
        {
            if(i < 9)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($" {i + 1}  ");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{i + 1}  ");
                Console.ResetColor();
            }
            for (int j = 0; j < width; j++)
            {
                
                if (field[i, j] == "[1]")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[2]")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[3]")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[4]")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[5]")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[6]")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[7]")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[8]")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[*]")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else if (field[i, j] == "[Z]")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(field[i, j]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(field[i, j]);
                }
            }
            Console.Write("\n");
        }
    }
    static void BombCheck()
    {
        if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
        {
            if (!mines.Contains($"{current_x};{current_y}"))
            {
                // BAL FELSŐ SAROK
                if (current_y == 1 & current_x == 1)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x + 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y + 1};{current_x + 1}");
                        checked_fields.Add($"{current_y + 1};{current_x}");
                        checked_fields.Add($"{current_y};{current_x + 1}");
                    }
                }
                // JOBB FELSŐ SAROK
                else if (current_y == width & current_x == 1)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y};{current_x + 1}");
                        checked_fields.Add($"{current_y - 1};{current_x + 1}");
                        checked_fields.Add($"{current_y - 1};{current_x}");
                    }
                }
                // JOBB ALSÓ SAROK
                else if (current_y == width & current_x == height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x - 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y};{current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x}");
                    }
                }
                //BAL ALSÓ SAROK
                else if (current_y == 1 & current_x == height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x - 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y + 1};{current_x - 1}");
                        checked_fields.Add($"{current_y + 1};{current_x}");
                        checked_fields.Add($"{current_y};    {current_x - 1}");
                    }
                }
                // BALOLDALI ÉL
                else if (current_y == 1 & current_x != 1 & current_x != height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x - 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y + 1};{current_x - 1}");
                        checked_fields.Add($"{current_y + 1};{current_x + 1}");
                        checked_fields.Add($"{current_y + 1};{current_x}");
                        checked_fields.Add($"{current_y};{current_x + 1}");
                        checked_fields.Add($"{current_y};{current_x - 1}");
                    }
                }
                // JOBBOLDALI ÉL
                else if (current_y == width & current_x != 1 & current_x != height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x - 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y};    {current_x + 1}");
                        checked_fields.Add($"{current_y};    {current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x + 1}");
                        checked_fields.Add($"{current_y - 1};{current_x}");
                    }
                }
                // FELSŐ ÉL
                else if (current_x == 1 & current_y != 1 & current_y != width)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y + 1};{current_x + 1}");
                        checked_fields.Add($"{current_y + 1};{current_x}");
                        checked_fields.Add($"{current_y};    {current_x + 1}");
                        checked_fields.Add($"{current_y - 1};{current_x + 1}");
                        checked_fields.Add($"{current_y - 1};{current_x}");
                    }
                }
                // ALSÓ ÉL
                else if (current_x == height & current_y != 1 & current_y != width)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y + 1};{current_x - 1}");
                        checked_fields.Add($"{current_y + 1};{current_x}");
                        checked_fields.Add($"{current_y};    {current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x}");
                    }
                }
                else
                {
                    bomb_near = 0;
                    if (mines.Contains($"{current_x + 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x + 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{current_x - 1};{current_y - 1}"))
                    {
                        bomb_near++;
                    }
                    if (current_x - 1 >= 0 && current_x - 1 < height && current_y - 1 >= 0 && current_y - 1 < width)
                    {
                        bomb_field[current_x - 1, current_y - 1] = $"[{bomb_near.ToString()}]";
                        field[current_x - 1, current_y - 1] = bomb_field[current_x - 1, current_y - 1];
                    }
                    if (bomb_near == 0)
                    {
                        checked_fields.Add($"{current_y + 1};{current_x - 1}");
                        checked_fields.Add($"{current_y + 1};{current_x + 1}");
                        checked_fields.Add($"{current_y + 1};{current_x}");
                        checked_fields.Add($"{current_y}    ;{current_x + 1}");
                        checked_fields.Add($"{current_y}    ;{current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x - 1}");
                        checked_fields.Add($"{current_y - 1};{current_x + 1}");
                        checked_fields.Add($"{current_y - 1};{current_x}");
                    }
                }
            }
            else
            {
                field[current_x - 1, current_y - 1] = "[ ]";
            }
        }
        else
        {
            Console.WriteLine("Nem megfelelő koordináták!");
            Main();
        }
        
    }
    static void BombStart()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"Maradt bombák száma: {bomb_count - flag}");
        Console.Write("Zászló vagy Robbantás? : (z/r)");
        Console.ResetColor();
        string input = Console.ReadLine();
        
        if (input == "r")
        {
            Console.Write("X koordináta:");
            current_y = int.Parse(Console.ReadLine());
            Console.Write("Y koordináta:");
            current_x = int.Parse(Console.ReadLine());
            if (field[current_x - 1, current_y - 1] == "[Z]")
            {
                Console.WriteLine("Ezen a mezőn zászló van!, biztosan szeretne robbantani? (i/n)");
                string input1 = Console.ReadLine();
                if (input1 == "i")
                {
                    flag--;
                }
                else if (input1 == "n")
                {
                    BombStart();
                }
                else
                {
                    Console.WriteLine("Adjon meg helyes műveletet!");
                    BombStart();
                }
            }
            
            if (mines.Contains($"{current_x};{current_y}"))
            {
                game_over = true;
            }
        }
        else if (input == "z")
        {
            Console.Write("X koordináta:");
            flag_y = int.Parse(Console.ReadLine());
            Console.Write("Y koordináta:");
            flag_x = int.Parse(Console.ReadLine());
            
            if (field[flag_x - 1, flag_y - 1] == "[ ]")
            {
                field[flag_x - 1, flag_y - 1] = "[Z]";
                flag++;
                if (mines.Contains($"{flag_x};{flag_y}"))
                {
                    remaining_bombs--;
                }
            }
            else
            {
                field[flag_x - 1, flag_y - 1] = bomb_field[flag_x - 1, flag_y - 1];
            }
            if (remaining_bombs == 0)
            {
                game_over = true;
            }
        }
        else
        {
            Console.WriteLine("Adjon meg helyes műveletet!");
            BombStart();
        }
    }

    static void FieldCheck()
    {
        List<string> checking = new List<string>();
        while (checked_fields.Count > field_check.Count)
        {           
            checking = checked_fields.Except(field_check).ToList();
            checking.Sort();

            check_coords = checking[0].Split(";");
            current_y = int.Parse(check_coords[0]);
            current_x = int.Parse(check_coords[1]);

            field_check.Add($"{check_coords[0]};{check_coords[1]}");
            BombCheck();
            /*Console.Write($"{checking[0]} ");*/
            checking.RemoveAt(0);
        }
        /*
        foreach (string item in field_check)
        {
            Console.Write($"{item} ");
        }
        */

        Console.WriteLine("\n\n");
        checked_fields.Clear();
        field_check.Clear();
    }
    static void GameOver()
    {
        Console.WriteLine("\n\n\n");
        for (int i = 1; i <= height; i++)
        {
            for (int j = 1; j <= width; j++)
            {
                // BAL FELSŐ SAROK
                if (i == 1 & j == 1)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                // JOBB FELSŐ SAROK
                else if (i == width & j == 1)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i - 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                // JOBB ALSÓ SAROK
                else if (i == width & j == height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i - 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                //BAL ALSÓ SAROK
                else if (i == 1 & j == height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                // BALOLDALI ÉL
                else if (i == 1 & j != 1 & j != height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                // JOBBOLDALI ÉL
                else if (i == width & j != 1 & j != height)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i - 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                // FELSŐ ÉL
                else if (j == 1 & i != 1 & i != width)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i - 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                // ALSÓ ÉL
                else if (j == 1 & i != 1 & i != width)
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i - 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                else
                {
                    bomb_near = 0;
                    if (mines.Contains($"{i + 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i + 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j + 1}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j}"))
                    {
                        bomb_near++;
                    }
                    if (mines.Contains($"{i - 1};{j - 1}"))
                    {
                        bomb_near++;
                    }
                    bomb_field[i - 1, j - 1] = $"[{bomb_near.ToString()}]";
                }
                field[i - 1, j - 1] = bomb_field[i - 1, j - 1];
            }
        }
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (mines.Contains($"{i + 1};{j + 1}"))
                {
                    field[i, j] = "[*]";
                }
            }
        }
    }
    static void NewGame()
    {
        if (remaining_bombs == 0)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Nyertél");
            Console.ResetColor();
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Vesztettél");
            Console.ResetColor();
        }
        Console.WriteLine("\nÚj játék? (i/n)");
        string input2 = Console.ReadLine();
        if (input2 == "i")
        {
            Main();
        }
        else if (input2 == "n")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Adjon meg helyes műveletet!");
            NewGame();
        }
    }
}     