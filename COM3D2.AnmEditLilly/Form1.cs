using AnmCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COM3D2.AnmEditLilly
{
    public partial class Form1 : Form
    {
        public AnmFile anmFile =null;
        public AnmFileLilly anmFileLilly=null;
        public string currentFilename =null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            this.handleInputFileSelected(array[0]);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            bool flag = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].EndsWith(".anm"))
                {
                    flag = false;
                    break;
                }
            }
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                flag = false;
            }
            e.Effect = (flag ? DragDropEffects.All : DragDropEffects.None);
        }

        private void handleInputFileSelected(string fname)
        {
            if (!fname.EndsWith(".anm"))
            {
                return;
            }
            anmFile = AnmFile.fromFile(fname);
            anmFileLilly = AnmFileLilly.fromFile(fname);

            this.currentFilename = fname;

            #region 텍스트로 출력

            StringBuilder stringBuilder = new StringBuilder();

            StringWriter stringWriter = new StringWriter(stringBuilder);
            if (DmpPmd.Dmp(fname, stringWriter) < 0)
            {
                return;
            }
            stringWriter.Close();
            this.textBox1.Text = stringBuilder.ToString();

            #endregion

            stringBuilder.Clear();


            #region Lilly개조판

            stringBuilder.AppendLine(anmFile.format.ToString());

            //AnmEdit.AnmOpen(anmFile,stringBuilder);
            AnmEdit.AnmOpen(anmFileLilly, stringBuilder);

            this.textBox2.Text = stringBuilder.ToString();

            #endregion

        }

        string outFileDialog()
        {
            if (this.currentFilename == null)
            {
                return null;
            }
            string result = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "save anm";
            saveFileDialog.Filter = "anm file|*.anm";
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(this.currentFilename) + "_undumped.anm";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                result = saveFileDialog.FileName;
            }
            saveFileDialog.Dispose();
            return result;
        }

        private void saveTop_Click_1(object sender, EventArgs e)
        {
            string text = this.outFileDialog();
            if (text == null)
            {
                return;
            }
            DmpPmd.Pmd(this.textBox1.Text, text);
        }

        private void saveBot_Click(object sender, EventArgs e)
        {
            string text = this.outFileDialog();
            if (text == null)
            {
                return;
            }
            DmpPmd.Pmd2(this.textBox2.Text, text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = this.fileDialog();
            if (text != "")
            {
                this.handleInputFileSelected(text);
            }
        }

        private string fileDialog()
        {
            string result = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "open file";
            openFileDialog.Filter = "anm file|*.anm";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                result = openFileDialog.FileName;
            }
            openFileDialog.Dispose();
            return result;
        }

        private void toolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ToolStripTextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ToolStripTextBox box = sender as ToolStripTextBox;
                    
                    Debug.WriteLine("toolStripTextBox_KeyDown Enter : " + box.Text);

                    float value = 0;
                    if (float.TryParse(box.Text, out value))
                    {
                        //Debug.WriteLine("toolStripTextBox_KeyDown Enter : " + (sender== toolStripTextBoxBot1));
                        //Debug.WriteLine("toolStripTextBox_KeyDown Enter : " + (sender== toolStripTextBoxBot2));
                        //Debug.WriteLine("toolStripTextBox_KeyDown Enter : " + (sender== toolStripTextBoxTop1));
                        //Debug.WriteLine("toolStripTextBox_KeyDown Enter : " + (sender== toolStripTextBoxTop2));
                        
                        //if (sender == toolStripTextBoxTop0 || sender == toolStripTextBoxBot0)
                        //{
                        //    AnmEdit.TimeEdit(anmFile,value);
                        //}                        
                        if (sender == toolStripTextBoxTop1 || sender == toolStripTextBoxBot1)
                        {
                            AnmEdit.Tan1Edit(anmFile,value);
                        }
                        if (sender == toolStripTextBoxTop2 || sender == toolStripTextBoxBot2)
                        {
                            AnmEdit.Tan2Edit(anmFile,value);
                        }


                        if (sender == toolStripTextBoxTop0 ||sender == toolStripTextBoxTop1 || sender == toolStripTextBoxTop2)
                        {
                            
                            this.textBox1.Text = DmpPmd.Dmp(anmFile);
                        }
                        
                        if (sender == toolStripTextBoxBot0 || sender == toolStripTextBoxBot1 || sender == toolStripTextBoxBot2)
                        {
                            //this.textBox2.Text = txt;
                        }
                    }
                }
            }
        }

        private void toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripTextBox)
            {
                ToolStripTextBox box=sender as ToolStripTextBox;
                float value = 0;                
                if (float.TryParse(box.Text, out value))
                {
                    
                }
                else
                {
                    box.Text = "";
                }
                Debug.WriteLine("toolStripTextBox_TextChanged : " + box.Text);
            }
        }
    }
}
