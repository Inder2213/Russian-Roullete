using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Reflection;


namespace Russian_Roullete
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
            //disable all the buttons except Load so that at the start of the game player can only press load button
            buttonshhot.Enabled = false;
            Shootawaybt.Enabled = false;
            buttonspin.Enabled = false;
            Loadbt.Enabled = true;
        }
        //define the objects of the gun and Random classes
        gun gungame = new gun();
        Random random = new Random();

        private void Loadbt_Click(object sender, EventArgs e)
        {
            buttonspin.Enabled = true;
            Loadbt.Enabled = false;
            // below code helps to show the picbox
            Assembly myasses = Assembly.GetExecutingAssembly();
            Stream myst = myasses.GetManifestResourceStream("Russian_Roullete.Resources.load.gif");
            pictureBox1.Image = Russian_Roullete.Properties.Resources.load;
        }

        private void buttonspin_Click(object sender, EventArgs e)
        {
            gungame.lodedgunspin = random.Next(1, 6);
            buttonshhot.Enabled = true;
            Shootawaybt.Enabled = true;
            buttonspin.Enabled = false;
         
            // below code helps to show the picbox
            Assembly myasses = Assembly.GetExecutingAssembly();
            Stream myst = myasses.GetManifestResourceStream("Russian_Roullete.Resources.spin.gif");
            pictureBox1.Image = Russian_Roullete.Properties.Resources.spin;
        }

        private void buttonshhot_Click(object sender, EventArgs e)
        {
            //Play the sound
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Russian_Roullete.Properties.Resources.shoot1);
            player.Play();
          
            //play the gif file in picturebox
            Assembly myasses = Assembly.GetExecutingAssembly();
            Stream myst = myasses.GetManifestResourceStream("Russian_Roullete.Resources.shoot.gif");
            pictureBox1.Image = Russian_Roullete.Properties.Resources.shoot;
           
            //call the shootbullete function from gun class 
            int shootaway = gungame.Shootbullete();
            if (shootaway == 1)
            {
                MessageBox.Show("You loose the Game");
                buttonshhot .Enabled = false;
                Shootawaybt.Enabled = false;
                buttonspin .Enabled = false;
                Loadbt .Enabled = false;
            }
            if (shootaway == 2)
            {
                gungame.shotsremain = gungame.shotsremain - 1;
                gungame.lodedgunspin = gungame.bulletechange(gungame.lodedgunspin);
                MessageBox.Show("You missed the Shot");
            }
        }

        private void Shootawaybt_Click(object sender, EventArgs e)
        {
            // Call the shootaway function from gun class and check the win or loss of the player
            int winloss = gungame.Shootaway();
            if (winloss == 10)
            {
                MessageBox.Show("You win and your score is 100");
                buttonshhot.Enabled = false;
                Shootawaybt.Enabled = false;
                buttonspin.Enabled = false;
                Loadbt.Enabled = false;
            }
            if (winloss == 5)
            {
                MessageBox.Show("You win and your score is 50");
                buttonshhot.Enabled = false;
                Shootawaybt.Enabled = false;
                buttonspin.Enabled = false;
                Loadbt.Enabled = false;
            }
            if (winloss == 0)
            {
                MessageBox.Show("You missed the Shot");
            }
            if (gungame.shotsremain == 0)
            {
                MessageBox.Show("you don't have any chance left");
                Shootawaybt.Enabled = false;
            }
        }
        private void playagain_Click(object sender, EventArgs e)
        {
            //below logic is to restart the game again
            Application.Restart();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            // below logic is to close the game and all files 
            Application.Exit();
        }
    }
}
