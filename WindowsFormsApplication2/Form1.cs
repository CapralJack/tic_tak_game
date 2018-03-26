using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
       
    {
        Logic logic = new Logic();
        bool comp_x = false;
        bool comp_o = false;


        public Form1()
        {
            InitializeComponent();
            start_game();

        }

        private void start_game()
        {
            logic.Init();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void playToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            start_game();
        }

        private void menu_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            make_move((PictureBox)sender);
        }

        private void make_move(PictureBox box)
        {
            int x, y;
            string tag = box.Tag.ToString();

            x = int.Parse(tag.Substring(0, 1));
            y = int.Parse(tag.Substring(1, 1));

            int side = logic.side;
            if (logic.Place(x, y))
            {

                box.Image = (side == 1) ? Properties.Resources.krest : Properties.Resources.nolik;
            }

            if (logic.finish != "play") { game_over(); return; }
        }


            private void make_Comp()
        {
            int x, y;
            int side = logic.side;
            logic.Comp(out x, out y);

            picture(x, y).Image = (side == 1) ? Properties.Resources.krest : Properties.Resources.nolik;

            if (logic.finish != "play") { game_over(); return; }
        }



        private void game_over()
        {
            switch (logic.finish)
            {
                case "winx": MessageBox.Show ("Победили крестики"); return;
                case "wino": MessageBox.Show ("Победили нолики"); return;
                case "draw": MessageBox.Show ("Ничья"); return;
                default: return;
            }
        }

        private void menu_start_comp_Click(object sender, EventArgs e)
        {
            start_game();
            comp_o = false;
            comp_x = true;
            make_Comp();
        
       

        }

        private void menu_play_With_comp_x_Click(object sender, EventArgs e)
        {
            comp_o = true;
            comp_x = false;
        }

       private PictureBox picture (int x, int y)
        {
            if (x == 0 && y == 0) return pictureBox1;
            if (x == 0 && y == 1) return pictureBox2;
            if (x == 0 && y == 2) return pictureBox3;
            if (x == 1 && y == 0) return pictureBox4;
            if (x == 1 && y == 1) return pictureBox5;
            if (x == 1 && y == 2) return pictureBox6;
            if (x == 2 && y == 0) return pictureBox7;
            if (x == 2 && y == 1) return pictureBox8;
            if (x == 2 && y == 2) return pictureBox9;
            return null;

        }

    }
}
