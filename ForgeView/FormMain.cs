using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ForgeView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                List<PizzaOrderViewModel> list = ApiClient.GetRequest<List<PizzaOrderViewModel>>("api/PizzaOrder/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCustomers();
            form.ShowDialog();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormIngredients();
            form.ShowDialog();
        }

        private void pizzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPizzas();
            form.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormPizzaOrder();
            form.ShowDialog();
            LoadData();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    ApiClient.PostRequest<PizzaOrderBindingModel, bool>("api/PizzaOrder/TakeOrderInWork", new PizzaOrderBindingModel { PizzaOrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    ApiClient.PostRequest<PizzaOrderBindingModel, bool>("api/PizzaOrder/FinishOrder", new PizzaOrderBindingModel { PizzaOrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void buttonPaid_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    ApiClient.PostRequest<PizzaOrderBindingModel, bool>("api/PizzaOrder/PayOrder", new PizzaOrderBindingModel { PizzaOrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void storagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormStorages();
            form.ShowDialog();
        }

        private void putOnStorageItem_Click(object sender, EventArgs e)
        {
            var form = new FormPutOnStorage();
            form.ShowDialog();
        }

        private void прайсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ApiClient.PostRequest<ReportBindingModel, bool>("api/Report/SaveProductPrice", new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void storageLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormStorageLoad();
            form.ShowDialog();

        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReport();
            form.ShowDialog();
        }

        private void implementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormImplementers();
            form.ShowDialog();
        }

        private void startWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ApiClient.PostRequest<int?, bool>("api/PizzaOrder/StartWork",
                    null);
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
