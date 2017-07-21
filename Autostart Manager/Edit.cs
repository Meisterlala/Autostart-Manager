using System;
using System.Windows.Forms;

namespace Autostart_Manager
{
    public partial class Edit : Form
    {
        #region Constructors

        public Edit(StartItem si)
        {
            NewStartItem = si;
            InitializeComponent();

            // Set Default textbox strings
            DefaultName = textBoxName.Text;
            DefaultPath = textBoxPath.Text;
            DefaultCommandline = textBoxCommandline.Text;

            // Set Fields from Passed StartItem
            textBoxName.Text = si.Name;
            textBoxPath.Text = si.Path;
            textBoxCommandline.Text = si.Commandline;
            checkBoxKeepRunning.Checked = si.KeepAlive;
            ReplaceText();

            // Change to Add or Edit
            Text = (si.Name == "") ? Autostart_Manager.Properties.Resources.Edit_Edit_AddNewItem : Autostart_Manager.Properties.Resources.Edit_Edit_Edit + si.Name;
            buttonAdd.Text = (si.Name == "") ? Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Add : Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Edit;
        }

        #endregion Constructors

        #region Properties

        public StartItem NewStartItem { get; set; }
        private string DefaultCommandline { get; set; }
        private string DefaultName { get; set; }
        private string DefaultPath { get; set; }

        #endregion Properties

        #region Methods

        private void Button_Add(object sender, EventArgs e)
        {
            UpdateStartItemFromFields();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Button_cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_choose(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxPath.Text = openFileDialog1.FileName;
        }

        private void ReplaceText(object sender)
        {
            switch (((TextBox)sender).Name)
            {
                case "textBoxName":
                    textBoxName.Text = (DefaultName == textBoxName.Text) ? "" : ("" == textBoxName.Text) ? DefaultName : textBoxName.Text;
                    break;

                case "textBoxPath":
                    textBoxPath.Text = (DefaultPath == textBoxPath.Text) ? "" : ("" == textBoxPath.Text) ? DefaultPath : textBoxPath.Text;
                    break;

                case "textBoxCommandline":
                    textBoxCommandline.Text = (DefaultCommandline == textBoxCommandline.Text) ? "" : ("" == textBoxCommandline.Text) ? DefaultCommandline : textBoxCommandline.Text;
                    break;

                default:
                    break;
            }
        }

        private void ReplaceText()
        {
            // Replace default values with empty space
            ReplaceText(textBoxName);
            ReplaceText(textBoxPath);
            ReplaceText(textBoxCommandline);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            ReplaceText(sender);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            ReplaceText(sender);
        }

        private void UpdateStartItemFromFields()
        {
            ReplaceText();

            // Set propertys of startItem
            NewStartItem.Name = textBoxName.Text;
            NewStartItem.Path = textBoxPath.Text;
            NewStartItem.Commandline = textBoxCommandline.Text;
            NewStartItem.KeepAlive = checkBoxKeepRunning.Checked;

            // Get Image from exe
            NewStartItem.DisplayedImage = Helper.GetImageFromPath(textBoxPath.Text);
        }

        #endregion Methods
    }
}