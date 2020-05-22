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
    public partial class LobbyHostForm : Form
    {
        public event OpenLatest OpenMainWindow;
        public delegate void OpenLatest();
        public LobbyHostForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            OpenMainWindow();
            Dispose();
        }
    }
}
