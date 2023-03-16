using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Game : Form
    {
        public string GameRule { get; set; }

        public Game()
        {
            InitializeComponent();
            tableLayoutPanel = this.Controls["tableLayoutPanel1"] as TableLayoutPanel;
        }

        public class Case_checker
        {
            public bool have_checker;
            public Button checker;
        }
        public string temp_checker_Name;
        public bool temp_have_checker;
        public Color temp_color_checker;
        public Button temp_checker;
        public bool my_step;
        

        enum CheckForRules
        {
            pcblack,
            pcwhite,
            playerblack,
            playerwhite,
        }

        Case_checker[,] Cases = new Case_checker[8, 8];
        TableLayoutPanel tableLayoutPanel;
        public const string black_checker_image = @".\black.png";
        public const string white_checker_image = @".\white.png";
        Button firstbutton = null;
        Button secondbutton = null;

        private void Game_Load(object sender, EventArgs e)
        {
            Case_create();
            Game_Rule();
        }

        private void Case_create() // Метод создания клеток
        {
            
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Cases[x, y] = new Case_checker();                    
                    Cases[x, y].checker = tableLayoutPanel.GetControlFromPosition(x,y) as Button;
                    Cases[x, y].checker.Name = (x +""+ y);
                }
            }
        }

        private void Game_Rule() //метод оперделения правил
        {
            CheckForRules rule;

            switch (GameRule)
            {
                
                case ("pcwhite"):
                    rule = CheckForRules.pcwhite;
                    my_step = true;
                    White_checkers_create(rule);
                    For_PC_Black_checkers_create_for_white();
                    break;

                case ("pcblack"):
                    my_step = false;
                    rule = CheckForRules.pcblack;
                    Black_checkers_create(rule);
                    For_PC_White_checkers_create_for_black();
                    break;

                case ("playerwhite"):
                    my_step = true;
                    rule = CheckForRules.playerwhite;
                    White_checkers_create(rule);
                    For_Player2_Black_checkers_create_for_white();
                    break;

                case ("playerblack"):
                    my_step = false;
                    rule = CheckForRules.playerblack;
                    Black_checkers_create(rule);
                    For_Player2_White_checkers_create_for_black();
                    break;

            }
            For_Clear_Cases();
        } 

        private void Black_checkers_create (CheckForRules rule)  // 1 Часть создания клеток для игры за черные
        {
            for (int y = 5; y < 8; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player);
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player);
                    }
                }
            }
        } 
        private void For_PC_White_checkers_create_for_black ()  // 2 Часть создания клеток для игры С КОМПЬЮТЕРОМ  за черные
        {
            for (int y = 0; y < 3; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
            }

        }
        private void For_Player2_White_checkers_create_for_black()  // 2 Часть создания клеток для игры С ИГРОКОМ за черные
        {
            for (int y = 0; y < 3; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player2);
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player2);
                    }
                }
            }

        }

        private void White_checkers_create(CheckForRules rule)  // 1 Часть создания клеток для игры за белые
        {
            for (int y = 5; y < 8; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player);
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player);
                    }
                }
            }
        } 
        private void For_PC_Black_checkers_create_for_white()  // 2 Часть создания клеток для игры С КОМПЬЮТЕРОМ за белые
        {
            for (int y = 0; y < 3; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
            }
        }
        private void For_Player2_Black_checkers_create_for_white()  // 2 Часть создания клеток для игры С ИГРОКОМ за белые
        {
            for (int y = 0; y < 3; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player2);

                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player2);
                    }
                }
            }
        }

        private void For_Clear_Cases()  // Пустые кнопки
        {
            for (int y = 3; y < 5; y++)
            {
                if (y % 2 == 1)
                {
                    for (int x = 0; x < 8; x = x + 2)
                    {
                        Cases[x, y].have_checker = false;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_clear_button);
                    }
                }
                else
                {
                    for (int x = 1; x < 8; x = x + 2)
                    {
                        Cases[x, y].have_checker = false;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_clear_button);
                    }
                }
            }

        }

        private void Button_click_player (object sender, EventArgs e)  // Игрок выбрал 1 кнопку
        {
            if (my_step == true)
            {
                Button clickedbutton = (Button)sender;

                if (firstbutton != null)
                {
                    Check_move_checker_Color(firstbutton, Color.Black);
                }

                int x = Convert.ToInt32(clickedbutton.Name) / 10;
                int y = Convert.ToInt32(clickedbutton.Name) % 10;

                firstbutton = clickedbutton;
                Check_move_checker_Color(clickedbutton, Color.Yellow);
            }
            
        }

        private void Button_click_clear_button (object sender, EventArgs e)
        {   
                Check_move_checker_Color(firstbutton, Color.Black);

                Button clickedbutton = (Button)sender;
                int x = Convert.ToInt32(clickedbutton.Name) / 10;
                int y = Convert.ToInt32(clickedbutton.Name) % 10;

                if (firstbutton != null)
                {
                    secondbutton = clickedbutton;
                    if (Check_Move_Checker() == true)
                    {

                    Swap_Two_Button();

                    }
                }
                  
        }

        private void Button_click_player2 (object sender, EventArgs e)
        {
            if (my_step == false)
            {
                Button clickedbutton = (Button)sender;

                if (firstbutton != null)
                {
                    Check_move_checker_Color(firstbutton, Color.Black);
                }

                int x = Convert.ToInt32(clickedbutton.Name) / 10;
                int y = Convert.ToInt32(clickedbutton.Name) % 10;

                firstbutton = clickedbutton;
                Check_move_checker_Color(clickedbutton, Color.Yellow);

            }

        }
        private void Button_Choice_Change_Color(Button clickedbutton)
        {
            clickedbutton.BackColor = Color.Gray;
        }
        private void Button_Choice_Back_Color(Button clickedbutton)
        {
            clickedbutton.BackColor = Color.Black;
        }

        private void Check_move_checker_Color (Button clickedbutton, Color temp_clr) // метод покраски кнопок с возможным ходом для шашки
        {
            int x = Convert.ToInt32(clickedbutton.Name) / 10;
            int y = Convert.ToInt32(clickedbutton.Name) % 10;

            if (my_step = true)
            {
                if (x == 0)
                {
                    if (Cases[x + 1, y - 1].have_checker == false)
                    {
                        Cases[x + 1, y - 1].checker.BackColor = temp_clr;
                    }
                }
                else if (x == 7)
                {
                    if (Cases[x - 1, y - 1].have_checker == false)
                    {
                        Cases[x - 1, y - 1].checker.BackColor = temp_clr;
                    }
                }
                else
                {

                    if (Cases[x - 1, y - 1].have_checker == false)
                    {
                        Cases[x - 1, y - 1].checker.BackColor = temp_clr;
                    }
                    if (Cases[x + 1, y - 1].have_checker == false)
                    {
                        Cases[x + 1, y - 1].checker.BackColor = temp_clr;
                    }

                }
            }
            else
            {
                if (x == 0)
                {
                    if (Cases[x + 1, y + 1].have_checker == false)
                    {
                        Cases[x + 1, y + 1].checker.BackColor = temp_clr;
                    }
                }
                else if (x == 7)
                {
                    if (Cases[x - 1, y + 1].have_checker == false)
                    {
                        Cases[x - 1, y + 1].checker.BackColor = temp_clr;
                    }
                }
                else
                {

                    if (Cases[x - 1, y + 1].have_checker == false)
                    {
                        Cases[x - 1, y + 1].checker.BackColor = temp_clr;
                    }
                    if (Cases[x + 1, y + 1].have_checker == false)
                    {
                        Cases[x + 1, y + 1].checker.BackColor = temp_clr;
                    }

                }
            }
            
        }
        private bool Check_Move_Checker()
        {
            int x = Convert.ToInt32(firstbutton.Name) / 10;
            int y = Convert.ToInt32(firstbutton.Name) % 10;

            if (my_step == true)
            {
                if (x == 0)
                {
                    if (Cases[x + 1, y - 1].checker == secondbutton)
                    {
                        return true;
                    }
                }
                else if (x == 7)
                {
                    if (Cases[x - 1, y - 1].checker == secondbutton)
                    {
                        return true;
                    }
                }
                else
                {

                    if (Cases[x - 1, y - 1].checker == secondbutton)
                    {
                        return true;
                    }
                    if (Cases[x + 1, y - 1].checker == secondbutton)
                    {
                        return true;
                    }

                }
                return false;

            }
            else
            {
                if (x == 0)
                {
                    if (Cases[x + 1, y + 1].checker == secondbutton)
                    {
                        return true;
                    }
                }
                else if (x == 7)
                {
                    if (Cases[x - 1, y + 1].checker == secondbutton)
                    {
                        return true;
                    }
                }
                else
                {

                    if (Cases[x - 1, y + 1].checker == secondbutton)
                    {
                        return true;
                    }
                    if (Cases[x + 1, y + 1].checker == secondbutton)
                    {
                        return true;
                    }

                }
                return false;
            }
        }

        private void Swap_Two_Button()
        {
            
            int x1 = Convert.ToInt32(firstbutton.Name) / 10;
            int y1 = Convert.ToInt32(firstbutton.Name) % 10;

            int x2 = Convert.ToInt32(secondbutton.Name) / 10;
            int y2 = Convert.ToInt32(secondbutton.Name) % 10;

            Swap_Two_Button_Location(x1,y1,x2,y2);
            
        }
        private void Swap_Two_Button_Location(int x1,int y1,int x2, int y2)
        {

            int b1_row = tableLayoutPanel.GetRow(Cases[x1, y1].checker);
            int b1_col = tableLayoutPanel.GetColumn(Cases[x1, y1].checker);
            int b2_row = tableLayoutPanel.GetRow(Cases[x2, y2].checker);
            int b2_col = tableLayoutPanel.GetColumn(Cases[x2, y2].checker);

            tableLayoutPanel.SetRow(Cases[x1, y1].checker, b2_row);
            tableLayoutPanel.SetColumn(Cases[x1, y1].checker, b2_col);
            tableLayoutPanel.SetRow(Cases[x2, y2].checker, b1_row);
            tableLayoutPanel.SetColumn(Cases[x2, y2].checker, b1_col);


            Cases[x1, y1].have_checker = !Cases[x1, y1].have_checker;
            Cases[x2, y2].have_checker = !Cases[x2, y2].have_checker;

            temp_checker_Name = Cases[x1, y1].checker.Name ;
            Cases[x1, y1].checker.Name = Cases[x2, y2].checker.Name;
            Cases[x2, y2].checker.Name = temp_checker_Name;

            temp_checker = Cases[x1, y1].checker;
            Cases[x1, y1].checker = Cases[x2, y2].checker;
            Cases[x2, y2].checker = temp_checker;

            firstbutton = null;
            secondbutton = null;
            my_step = !my_step;
        }
    }
}
