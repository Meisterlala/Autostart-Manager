using System;
using System.Drawing;
using System.Windows.Forms;
using Autostart_Manager.Properties;

namespace Autostart_Manager
{
    public partial class Main : Form
    {
        #region Fields

        private const int StatusWidht = 65;

        #endregion Fields

        #region Constructors

        public Main()
        {
            InitializeComponent();
            InitilizeListView();
            ResizeColumns();
            LoadListViewItems();
            SizeForm();

            /*
            StartItem si = new StartItem();
            si.Name = "Test";
            si.Path = "C:/sdasad/sad.exe";
            AddItem(si);
            */
        }

        #endregion Constructors

        #region Methods

        public void UpdateListView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { UpdateListView(); }));
                return;
            }

            foreach (ListViewItem item in listViewMain.Items)
            {
                string newText;
                switch ((Status)item.SubItems[1].Tag)
                {
                    case Status.running:
                        newText = Autostart_Manager.Properties.Resources.Main_UpdateListView_Running;
                        break;

                    case Status.stopped:
                        newText = Autostart_Manager.Properties.Resources.Main_UpdateListView_Stopped;
                        break;

                    default:
                        newText = Autostart_Manager.Properties.Resources.Main_UpdateListView_Running;
                        break;
                }

                item.SubItems[1].Text = newText;

                Color newColor;
                switch ((Status)item.SubItems[1].Tag)
                {
                    case Status.running:
                        newColor = Color.FromArgb(0, 180, 0);
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

        public void UpdateListViewFull()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { UpdateListViewFull(); }));
                return;
            }

            foreach (ListViewItem item in listViewMain.Items)
            {
                StartItem si = ((StartItem)(item.Tag));
                item.Text = si.Name;
                item.ToolTipText = si.Name + "\n" + si.Path + "\n" + si.Commandline;
                item.SubItems[1].Tag = si.CurrentStatus;

                if (si.Name == "" || si.Path == "")
                {
                    item.BackColor = Color.FromArgb(255, 0, 0);
                }
                else
                {
                    item.BackColor = Color.Transparent;
                }
            }
            UpdateListView();
        }

        private void AddItem(StartItem si)
        {
            ListViewItem newItem = new ListViewItem();
            newItem.Tag = si;
            // newItem.Text = ((StartItem)(newItem.Tag)).Name;
            // newItem.ToolTipText = ((StartItem)(newItem.Tag)).Name + "\n" + ((StartItem)(newItem.Tag)).Path + "\n" + ((StartItem)(newItem.Tag)).Commandline;
            var Key = ((StartItem)(newItem.Tag)).GUID.ToString();
            newItem.ImageKey = Key;
            newItem.Name = Key;
            listViewMain.SmallImageList.Images.Add(Key, ((StartItem)(newItem.Tag)).DisplayedImage);
            newItem.UseItemStyleForSubItems = false;

            ListViewItem.ListViewSubItem statusItem = new ListViewItem.ListViewSubItem();
            statusItem.Tag = ((StartItem)(newItem.Tag)).CurrentStatus;

            newItem.SubItems.Add(statusItem);
            listViewMain.Items.Add(newItem);

            UpdateListViewFull();
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem LVitem in listViewMain.SelectedItems)
            {
                RemoveItem((StartItem)LVitem.Tag);
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listViewMain.SelectedItems.Count != 1)
            {
                MessageBox.Show(Autostart_Manager.Properties.Resources.Main_ButtonEdit_Click_PleaseSelectOneItem);
                return;
            }

            var si = (StartItem)listViewMain.SelectedItems[0].Tag;
            Edit ed = new Edit(si);
            ed.ShowDialog();

            UpdateListViewFull();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            StartItem newItem = new StartItem();
            Edit addWindow = new Edit(newItem);
            addWindow.ShowDialog();
            switch (addWindow.DialogResult)
            {
                case DialogResult.OK:
                    AddItem(newItem);
                    break;

                default:
                    break;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            var selected = listViewMain.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                var SI = item.Tag as StartItem;
                if (!Program.ProcessIsRunning(SI))
                    Program.RunProcess(SI);
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            var selected = listViewMain.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                var SI = item.Tag as StartItem;
                Program.StopProcess(SI);
            }
        }

        private void InitilizeListView()
        {
            listViewMain.Columns.Add(Resources.Main_InitilizeListView_Name);
            listViewMain.Columns.Add(Resources.Main_InitilizeListView_Status);

            listViewMain.SmallImageList = new ImageList();
        }

        private void LoadListViewItems()
        {
            foreach (StartItem item in Helper.StartItemList)
            {
                AddItem(item);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveWindowSize();
            SaveList();

            Environment.Exit(0);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    buttonDelete.PerformClick();
                    break;
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void NotifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void RemoveItem(StartItem si)
        {
            listViewMain.Items[si.GUID.ToString()].Remove();
            Helper.StartItemList.Remove(si);
            UpdateListView();
        }

        private void ResizeColumns()
        {
            listViewMain.Columns[1].Width = StatusWidht;
            var remainder = listViewMain.Width - StatusWidht - 5;
            listViewMain.Columns[0].Width = remainder - 18;
        }

        private void SaveList()
        {
            Helper.SaveStartItemList(Helper.StartItemList);
        }

        private void SaveWindowSize()
        {
            // Copy window location to app settings
            Properties.Settings.Default.WindowLocation = this.Location;

            // Copy window size to app settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowSize = this.Size;
            }
            else
            {
                Properties.Settings.Default.WindowSize = this.RestoreBounds.Size;
            }
        }

        private void SizeForm()
        {
            // Set window location
            if (Properties.Settings.Default.WindowLocation != new Point(-2, -2))
            {
                this.Location = Properties.Settings.Default.WindowLocation;
            }
            else
            {
                this.Location = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            }

            // Set window size
            this.Size = Properties.Settings.Default.WindowSize;
        }

        #endregion Methods
    }
}