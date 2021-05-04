using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Russian_Roullete
{
   public  class gun
    {
        //declare variables which will use in game logic
        public int lodedgunspin;
        public int shotawayBullete = 0;
        public int shot = 0;
        public int chance = 2; //Number of chances to save the player
        public int shotsremain = 6; // Total Number of bullets

        // Logic to change the position of the bullet in chamber
        public int bulletechange(int changebul)
        {
            if (changebul == 6)
            {
                changebul = 1;
            }
            else
            {
                changebul++;
            }
            return changebul;
        }

        //Logic to save the player when click on the shoot away button
        public int Shootaway()
        {

            if (lodedgunspin == 1 && chance == 2 && shotsremain > 0)
            {
                shotawayBullete = 10;
            }
            if (lodedgunspin == 1 && chance == 1 && shotsremain > 0)
            {
                shotawayBullete = 5;
            }
           else if (shotsremain > 0 && lodedgunspin != 1 && chance<=2)
            {
                shotawayBullete = 0;
                shotsremain -= 1;
                lodedgunspin = bulletechange(lodedgunspin);
                chance--;
            }
            return shotawayBullete;
        }

        //Logic for shoot button which checks how many chances are left.
        public int Shootbullete()
        {
            if (shotsremain > 0 && lodedgunspin == 1)
            {
                shot = 1;
            }
            else if (shotsremain > 0 && lodedgunspin != 1)
            {
                shot = 2;
            }
            return shot;
        }
    }
}
