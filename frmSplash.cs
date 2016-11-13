using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.IO;

namespace TranslaTale_NG
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            int tempProjCounter = 0;
            var tempProjects = projectHandler.getTempProjects();
            IEnumerable tempProjEnumerable = (IEnumerable)tempProjects;

            foreach (object tempProject in tempProjEnumerable)
            {
                tempProjCounter++;
            }

            if (tempProjCounter > 0)
            {
                DialogResult msgTempProjFound = MessageBox.Show("TranslaTale have found a temporary project.\nDo you want to recover it?", "Temporary project found", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (msgTempProjFound == DialogResult.Yes)
                {

                }
                else
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "TranslaTale"));
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
            }

            tmrClose.Enabled = false;
            this.Hide();
            frmProjectManager frmPrjMan = new frmProjectManager();
            frmPrjMan.Closed += (s, args) => this.Close();
            frmPrjMan.Show();
        }
    }
}