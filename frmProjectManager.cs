using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace TranslaTale_NG
{
    public partial class frmProjectManager : Form
    {
        public frmProjectManager()
        {
            InitializeComponent();
        }

        private void btnOpenPrj_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogTTP = new OpenFileDialog();
            openFileDialogTTP.InitialDirectory = @"C:\Users\Alex\Desktop\UTES\ttng";
            //openFileDialogTTP.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialogTTP.Filter = "TranslaTale Project files (*.ttp, *.ttpx, *.zip)|*.ttp;*.ttpx;*.zip|All files (*.*)|*.*";
            openFileDialogTTP.RestoreDirectory = true;

            if (openFileDialogTTP.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TTProject proj = projectHandler.loadProject(openFileDialogTTP.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Error loading project", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void frmProjectManager_Load(object sender, EventArgs e)
        {
            ImageList imgList = new ImageList();

            imgList.ImageSize = new Size(48, 48);  
            imgList.Images.Add((Image)new Bitmap(TranslaTale_NG.Properties.Resources.ttpfile_small));
            imgList.Images.Add((Image)new Bitmap(TranslaTale_NG.Properties.Resources.ttpxfile_small));
            imgList.Images.Add((Image)new Bitmap(TranslaTale_NG.Properties.Resources.ttprecovery_small));
            lsvProjects.SmallImageList = imgList;
            lsvProjects.LargeImageList = imgList;
            lsvProjects.View = View.Details;
            ColumnHeader cheader1 = new ColumnHeader();
            cheader1.Text = "Recent projects";
            lsvProjects.Columns.AddRange(new ColumnHeader[] { cheader1 });
            lsvProjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lsvProjects.Items.Add(new ListViewItem { ImageIndex = 0, Text = "Image 1" });
            lsvProjects.Items.Add(new ListViewItem { ImageIndex = 1, Text = "Image 2" });
            lsvProjects.Items.Add(new ListViewItem { ImageIndex = 2, Text = "Image 3" });
            lsvProjects.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}