using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autostart_Manager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitilizeListView();
            ResizeColumns();
            // LoadList();

            StartItem si = new StartItem();
            si.Name = "Test";
            si.Path = "C:/sdasad/sad.exe";

            AddItem(si);
        }

        public void AddItem(StartItem si)
        {
            ListViewItem newItem = new ListViewItem();
            newItem.Text = si.Name;
            newItem.ToolTipText = si.Name + "\n" + si.Path + "\n" + si.Commandline;
            var ImageKey = si.GUID.ToString();
            newItem.ImageKey = ImageKey;
            listViewMain.SmallImageList.Images.Add(ImageKey, si.DisplayedImage);
            newItem.UseItemStyleForSubItems = false;

            ListViewItem.ListViewSubItem statusItem = new ListViewItem.ListViewSubItem();
            statusItem.Tag = si.CurrentStatus;

            newItem.SubItems.Add(statusItem);
            listViewMain.Items.Add(newItem);

            UpdateListView();
        }

        private void InitilizeListView()
        {
            listViewMain.Columns.Add("Name");
            listViewMain.Columns.Add("Status");

            listViewMain.SmallImageList = new ImageList();
        }

        public void UpdateListView()
        {
            foreach (ListViewItem item in listViewMain.Items)
            {
                string newText;
                switch ((Status)item.SubItems[1].Tag)
                {
                    case Status.running:
                        newText = "Running";
                        break;

                    case Status.stopped:
                        newText = "Stopped";
                        break;

                    default:
                        newText = "Running";
                        break;
                }

                item.SubItems[1].Text = newText;

                Color newColor;
                switch ((Status)item.SubItems[1].Tag)
                {
                    case Status.running:
                        newColor = Color.FromArgb(0, 255, 0);
                        break;

                    case Status.stopped:
                        newColor = Color.FromArgb(255, 0, 0);
                        break;

                    default:
                        newColor = Color.FromArgb(255, 0, 0);
                        break;
                }

                item.SubItems[1].ForeColor = newColor;
                item.ForeColor = SystemColors.WindowText;
            }
        }

        public void LoadList()
        {
            // Properties.Settings.Default.ProgramList
        }

        public void SaveList()
        {
            throw new NotImplementedException();
        }

        private const int StatusWidht = 100;

        public void ResizeColumns()
        {
            listViewMain.Columns[1].Width = StatusWidht;
            var remainder = listViewMain.Width - StatusWidht - 5;
            listViewMain.Columns[0].Width = remainder;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void buttonShortcuts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }
    }
}