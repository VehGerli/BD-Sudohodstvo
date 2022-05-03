using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public bool changeAccount = false;
        public Form1()
        {
            changeAccount = false;
            InitializeComponent();

            if (!Login.isAdmin)
            {
                bindingNavigatorAddNewItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
                рейсBindingNavigatorSaveItem.Enabled = false;
               panel4.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton7.Enabled = false;
                splitContainer2.Panel2.Enabled = false;
                toolStripButton8.Enabled = false;
                toolStripButton9.Enabled = false;
                toolStripButton14.Enabled = false;
                splitContainer4.Panel2.Enabled = false;
                toolStripButton15.Enabled = false;
                toolStripButton16.Enabled = false;
                toolStripButton21.Enabled = false;
                splitContainer5.Panel2.Enabled = false;
                toolStripButton22.Enabled = false;
                toolStripButton23.Enabled = false;
                toolStripButton28.Enabled = false;
                panel2.Enabled = false;
                toolStripButton29.Enabled = false;
                toolStripButton30.Enabled = false;
                toolStripButton35.Enabled = false;
                panel3.Enabled = false;
                toolStripButton36.Enabled = false;
                toolStripButton37.Enabled = false;
                toolStripButton42.Enabled = false;
                splitContainer8.Panel2.Enabled = false;
                toolStripButton43.Enabled = false;
                toolStripButton44.Enabled = false;
                toolStripButton49.Enabled = false;

                panel1.Enabled = false;
                tabPage2.Enabled = false;
            }

            List<TextBoxBase> notNullTextBoxes = new List<TextBoxBase>()
            {
                названиеTextBox, названиеTextBox1, фИОTextBox, телефонMaskedTextBox, грузоподъёмность_в_тоннахTextBox,
                названиеTextBox2, количествоTextBox, цена_за_1_единицуTextBox, названиеTextBox3
            };

            foreach (var item in notNullTextBoxes)
            {
                item.Tag = new ErrorProvider();
                item.Validating += Item_Not_Null_Validating;
            }
        }

        private void Item_Not_Null_Validating(object sender, CancelEventArgs e)
        {
            var tb = sender as TextBoxBase;
            var ep = tb.Tag as ErrorProvider;
            if (string.IsNullOrWhiteSpace(tb.Text) || tb.Text.Equals(" (   )    -")) tb.Focus();
            ep.SetError(tb, string.IsNullOrWhiteSpace(tb.Text) || tb.Text.Equals(" (   )    -") ? "Данное поле является обязательным" : null);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Судоходство_1_0DataSet1.Порт". При необходимости она может быть перемещена или удалена.
            this.портTableAdapter.Fill(this._Судоходство_1_0DataSet1.Порт);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Судоходство_1_0DataSet1.Рейс". При необходимости она может быть перемещена или удалена.
            this.рейсTableAdapter.Fill(this._Судоходство_1_0DataSet1.Рейс);

            this.ошибкаTableAdapter.Fill(this._Судоходство_1_0DataSet.Ошибка);
            this.странаTableAdapter.Fill(this._Судоходство_1_0DataSet.Страна);
            this.кор_грузTableAdapter.Fill(this._Судоходство_1_0DataSet.Кор_груз);
            this.грузTableAdapter.Fill(this._Судоходство_1_0DataSet.Груз);
            this.характеристикаTableAdapter.Fill(this._Судоходство_1_0DataSet.Характеристика);
            this.капитанTableAdapter.Fill(this._Судоходство_1_0DataSet.Капитан);
            this.портTableAdapter.Fill(this._Судоходство_1_0DataSet.Порт);
            this.корабльTableAdapter.Fill(this._Судоходство_1_0DataSet.Корабль);
            this.рейсTableAdapter.Fill(this._Судоходство_1_0DataSet.Рейс);

        }

        private void рейсBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.рейсBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.корабльBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.портBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.капитанBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }

        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.характеристикаBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.грузBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton42_Click(object sender, EventArgs e)
        {

            try
            {
                this.Validate();
                this.кор_грузBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton49_Click(object sender, EventArgs e)
        {
           
            try
            {
                this.Validate();
                this.странаBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._Судоходство_1_0DataSet);
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }

        }

        private void количествоTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void количествоTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void цена_за_1_единицуTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void грузоподъёмность_в_тоннахTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void телефонMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!(Char.IsDigit(number) && number != '-'&& number != ' '))
            {
                e.Handled = true;
            }
        }

        private void названиеTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBoxBase;
            if (e.KeyChar.Equals('\b') || Char.IsLetter(e.KeyChar) || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        private void названиеTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBoxBase;
            if (e.KeyChar.Equals('\b') || Char.IsLetter(e.KeyChar) || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        private void фИОTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBoxBase;
            if (e.KeyChar.Equals('\b') || Char.IsLetter(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == ' ')
                return;
            e.Handled = true;
        }

        private void названиеTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBoxBase;
            if (e.KeyChar.Equals('\b') || Char.IsLetter(e.KeyChar) || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        private void названиеTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBoxBase;
            if (e.KeyChar.Equals('\b') || Char.IsLetter(e.KeyChar) || e.KeyChar == '-')
                return;
            e.Handled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.рейсBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
            finally
            {
                дата_отправленияDateTimePicker.Value = дата_отправленияDateTimePicker.MinDate;
                дата_прибытияDateTimePicker.Value = дата_прибытияDateTimePicker.MinDate;
            }
        }

        private void рейсDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        // FILTER
        private void button1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            this.рейсTableAdapter.FillBy(this._Судоходство_1_0DataSet.Рейс, dateTimePicker1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            this.рейсTableAdapter.FillBy1(this._Судоходство_1_0DataSet.Рейс, dateTimePicker2.Value);
        }

        private void рейсDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.рейсTableAdapter.Fill(this._Судоходство_1_0DataSet.Рейс);
        }

        private void toolStripButton50_Click(object sender, EventArgs e)
        {
            DGVPrinter dGVPrinter = new DGVPrinter();
            dGVPrinter.Title = "Report"; // Header
            dGVPrinter.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString().Remove(DateTime.Now.Date.ToString().Length - 8));
            dGVPrinter.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            dGVPrinter.PageNumbers = true;
            dGVPrinter.PageNumberInHeader = false;
            dGVPrinter.PorportionalColumns = true;
            dGVPrinter.Footer = "List"; // Footer
            dGVPrinter.FooterSpacing = 15;
            dGVPrinter.PrintPreviewDataGridView(рейсDataGridView);
        }

        private void toolStripButton61_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton61_Click_1(object sender, EventArgs e)
        {
            this.ошибкаTableAdapter.trunc_errors();
            this.ошибкаTableAdapter.Fill(_Судоходство_1_0DataSet.Ошибка);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                this.капитанBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнено студентом 19ПРИ Кузьминой Ю.В.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeAccount = true;
            this.Close();
        }

        private void toolStripButton62_Click(object sender, EventArgs e)
        {
            this.ошибкаTableAdapter.Fill(_Судоходство_1_0DataSet.Ошибка);
        }

        private void цена_за_1_единицуTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ошибкаDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            this.корабльTableAdapter.FillBy(this._Судоходство_1_0DataSet.Корабль, textBox1.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.корабльTableAdapter.Fill(this._Судоходство_1_0DataSet.Корабль);
            textBox1.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            this.грузTableAdapter.FillBy(this._Судоходство_1_0DataSet.Груз, textBox2.Text);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.грузTableAdapter.Fill(this._Судоходство_1_0DataSet.Груз);
            textBox2.Text = "";
        }

        private void toolStripButton58_Click(object sender, EventArgs e)
        {
            DGVPrinter dGVPrinter = new DGVPrinter();
            dGVPrinter.Title = "Report"; // Header
            dGVPrinter.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString().Remove(DateTime.Now.Date.ToString().Length - 8));
            dGVPrinter.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            dGVPrinter.PageNumbers = true;
            dGVPrinter.PageNumberInHeader = false;
            dGVPrinter.PorportionalColumns = true;
            dGVPrinter.Footer = "List"; // Footer
            dGVPrinter.FooterSpacing = 15;
            dGVPrinter.PrintPreviewDataGridView(грузDataGridView);
        }

        private void toolStripButton51_Click(object sender, EventArgs e)
        {
            DGVPrinter dGVPrinter = new DGVPrinter();
            dGVPrinter.Title = "Report"; // Header
            dGVPrinter.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString().Remove(DateTime.Now.Date.ToString().Length - 8));
            dGVPrinter.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            dGVPrinter.PageNumbers = true;
            dGVPrinter.PageNumberInHeader = false;
            dGVPrinter.PorportionalColumns = true;
            dGVPrinter.Footer = "List"; // Footer
            dGVPrinter.FooterSpacing = 15;
            dGVPrinter.PrintPreviewDataGridView(корабльDataGridView);
        }

        private void toolStripButton43_Click(object sender, EventArgs e)
        {
            try
            {
                this.странаBindingSource.AddNew();

            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены");
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);

            }
            finally
            {
               
            }
           
        }

        private void toolStripButton44_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton36_Click(object sender, EventArgs e)
        {
        
            try
            {
                this.кор_грузBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {

                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }

            
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            try
            {
                this.грузBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            try
            {
                this.характеристикаBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
            finally
            {
               год_спуска_на_водуDateTimePicker.Value = год_спуска_на_водуDateTimePicker.MinDate;
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            try
            {
                this.капитанBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error("Не все обязательные поля заполнены!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.корабльBindingSource.AddNew();
            }
            catch (NoNullAllowedException)
            {
                MessageBox.Show("Не все обязательные поля заполнены!!");
                this.ошибкаTableAdapter.add_error( "Не все обязательные поля заполнены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.ошибкаTableAdapter.add_error( ex.Message);
            }
        }

        private void splitContainer7_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button7_Click(sender, e);
            button6_Click_1(sender, e);
        }

        private void корабльDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                if (e.Exception is NoNullAllowedException)
                {
                    MessageBox.Show("Не все обязательные поля заполнены!!");
                  //  this.ошибкаTableAdapter.add_error(_Судоходство_1_0DataSet.Ошибка, "Не все обязательные поля заполнены");
                }
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

        }
    }
}
