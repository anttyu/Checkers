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

        TableLayoutPanel tableLayoutPanel;

        public Game()
        {
            InitializeComponent();
            tableLayoutPanel = this.Controls["tableLayoutPanel1"] as TableLayoutPanel;
        }

        public class Case_checker
        {
            public int x;
            public int y;
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

        public const string black_checker_image = @".\black.png";
        public const string white_checker_image = @".\white.png";

        private void Case_create() // Метод создания клеток
        {
            
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Cases[x, y] = new Case_checker() { x = y, y = x };
                    Cases[x, y].checker = tableLayoutPanel.GetControlFromPosition(y,x) as Button;
                     
                }
            }
        }

        private void Game_Rule()
        {
            CheckForRules rule;

            switch (GameRule)
            {
                
                case ("pcwhite"):
                    rule = CheckForRules.pcwhite;
                    White_checkers_create(rule);
                    break;

                case ("pcblack"):
                    rule = CheckForRules.pcblack;
                    Black_checkers_create(rule);
                    break;

                case ("playerwhite"):
                    rule = CheckForRules.playerwhite;
                    White_checkers_create(rule);
                    break;

                case ("playerblack"):
                    rule = CheckForRules.playerblack;
                    Black_checkers_create(rule);
                    break;

            }
        } //метод оперделения правил

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
                        Cases[x, y].checker.Click += new EventHandler(Button_click);
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(black_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click);
                    }
                }
            }
            White_checkers_create_for_black();
        } 
        private void White_checkers_create_for_black ()  // 2 Часть создания клеток для игры за черные
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
                        if ()
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
                        Cases[x, y].checker.Click += new EventHandler(Button_click);
                    }
                }
                else
                {
                    for (int y = 1; y < 8; y = y + 2)
                    {
                        Cases[x, y].checker.BackgroundImage = Image.FromFile(white_checker_image);
                        Cases[x, y].have_checker = true;
                        Cases[x, y].checker.Click += new EventHandler(Button_click);
                    }
                }
            }
            Black_checkers_create_for_white();
        } 
        private void Black_checkers_create_for_white()  // 2 Часть создания клеток для игры за белые
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

        private void Button_click (object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {
            Case_create();
            Game_Rule();
        }
    }
}
