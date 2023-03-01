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
            TableLayoutPanel tableLayoutPanel = this.Controls["tableLayoutPanel1"] as TableLayoutPanel;
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

        private const string black_checker = @"\black.png";
        private const string white_checker = @"\white.png";

        private void Case_create() // Метод создания клеток
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Cases[x, y].x = x;
                    Cases[x, y].y = y;
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
        }

        private void Black_checkers_create (CheckForRules rule)
        {

        }
        private void White_checkers_create(CheckForRules rule)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {
            Game_Rule();
        }
    }
}
