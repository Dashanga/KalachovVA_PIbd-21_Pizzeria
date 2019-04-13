using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForgeServiceDAL.BindingModel;

namespace ForgeView
{
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CustomerViewModel> list = ApiClient.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if (list != null)
                {
                    dataGridViewCustomers.DataSource = list;
                    dataGridViewCustomers.Columns[0].Visible = false;
                    dataGridViewCustomers.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCustomer();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 1)
            {
                var form = new FormCustomer();
                form.Id = Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                    Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        ApiClient.PostRequest<CutstomerBindingModel, bool>("api/Customer/DelElement",
                            new CutstomerBindingModel {CustomerId = id});
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
