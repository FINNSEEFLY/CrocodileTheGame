using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrocodileTheGame
{
    public partial class GameForm : Form
    {
        int UserMode;


        public GameForm(int usermode)
        {
            InitializeComponent();
            UserMode = usermode;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            if (UserMode == PlayerTypes.TYPE_USER)
            {

            }
        }

    }
}
