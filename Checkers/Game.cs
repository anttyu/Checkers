using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            public string checker_ID;    
            public bool have_checker;
            public Color color_checker;
            public Button checker;
        }
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
                    Cases[x, y].checker = tableLayoutPanel.GetControlFromPosition(y,x) as Button;
                    Cases[x, y].checker.Name = (x +""+ y);
                    Cases[x, y].checker_ID = Cases[x, y].checker.Name;
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
                    White_checkers_create(rule);
                    For_PC_Black_checkers_create_for_white();
                    break;

                case ("pcblack"):
                    rule = CheckForRules.pcblack;
                    Black_checkers_create(rule);
                    For_PC_White_checkers_create_for_black();
                    break;

                case ("playerwhite"):
                    rule = CheckForRules.playerwhite;
                    White_checkers_create(rule);
                    For_Player2_Black_checkers_create_for_white();
                    break;

                case ("playerblack"):
                    rule = CheckForRules.playerblack;
                    Black_checkers_create(rule);
                    For_Player2_White_checkers_create_for_black();
                    break;

            }
            For_Clear_Cases();
        } 

        private void Black_checkers_create (CheckForRules rule)  // 1 Часть создания клеток для игры за черные
        {
            for (int x = 5; x < 8; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player);
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
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
            for (int x = 0; x < 3; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
            }

        }
        private void For_Player2_White_checkers_create_for_black()  // 2 Часть создания клеток для игры С ИГРОКОМ за черные
        {
            for (int x = 0; x < 3; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player2);
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
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
            for (int x = 5; x < 8; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player);
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
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
            for (int x = 0; x < 3; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                    }
                }
            }
        }
        private void For_Player2_Black_checkers_create_for_white()  // 2 Часть создания клеток для игры С ИГРОКОМ за белые
        {
            for (int x = 0; x < 3; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_player2);

                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
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
            for (int x = 3; x < 5; x++)
            {
                if (x % 2 == 1)
                {
                    for (int y = 0; y < 8; y = y + 2)
                    {
                        Cases[x, y].have_checker = false;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_clear_button);
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
                    {
                        Cases[x, y].have_checker = false;
                        Cases[x, y].checker.Click += new EventHandler(Button_click_clear_button);
                    }
                }
            }

        }

        private void Button_click_player (object sender, EventArgs e)  // Игрок выбрал 1 кнопку
        {
            Button clickedbutton = (Button)sender;

            int x = Convert.ToInt32(clickedbutton.Name) / 10;
            int y = Convert.ToInt32(clickedbutton.Name) % 10;

            if (secondbutton == null)
            {
                firstbutton = clickedbutton;
            }


        }
        private void Button_click_clear_button (object sender, EventArgs e)
        {
            Button clickedbutton = (Button)sender;
            int x = Convert.ToInt32(clickedbutton.Name) / 10;
            int y = Convert.ToInt32(clickedbutton.Name) % 10;

            if (firstbutton != null)
            {
                secondbutton = clickedbutton;
            }
        }
        private void Button_click_player2 (object sender, EventArgs e)
        {

        }

        private void Chec(Button clickedbutton, int x, int y) // Запонмить две выбранные кнопки
        {
            if (firstbutton == null)
            {
                firstbutton = clickedbutton;
                Button_Choice_Change_Color(firstbutton); // отобразить выбранную кнопку цветом
                Check_move_checker(firstbutton,x,y);
            }
            else
            {
                secondbutton = clickedbutton;
                Button_Choice_Back_Color(firstbutton); // вернуть цвет выбранной ранее кнопки
            }
            firstbutton = null;
            secondbutton = null;

        }
        private void Button_Choice_Change_Color(Button clickedbutton)
        {
            clickedbutton.BackColor = Color.Gray;
        }
        private void Button_Choice_Back_Color(Button clickedbutton)
        {
            clickedbutton.BackColor = Color.Black;
        }
        private void Check_move_checker (Button firstbutton,int x, int y)
        {
            if (x % 2 == 1)
            {
                if (Cases[x - 1, y - 1].have_checker == false)
                {
                    Cases[x - 1, y - 1].checker.BackColor = Color.Yellow;
                }
                if (Cases[x - 1, y + 1].have_checker == false)
                {
                    Cases[x - 1, y + 1].checker.BackColor = Color.Yellow;
                }
            }

            if (x % 2 == 0)
            {
                if (Cases[x - 1, y - 1].have_checker == false)
                {
                    Cases[x - 1, y - 1].checker.BackColor = Color.Yellow;
                }
                if (Cases[x - 1, y + 1].have_checker == false)
                {
                    Cases[x - 1, y + 1].checker.BackColor = Color.Yellow;
                }
            }
        }

    }
}
