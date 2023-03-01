namespace Checkers
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        Game game = new Game();

        private void button1_Click(object sender, EventArgs e)
        {
            game.GameRule = "pcwhite";
            this.Hide();
            game.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.GameRule = "pcblack";
            this.Hide();
            game.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.GameRule = "playerwhite";
            this.Hide();
            game.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            game.GameRule = "playerblack";
            this.Hide();
            game.Show();

        }
    }
}