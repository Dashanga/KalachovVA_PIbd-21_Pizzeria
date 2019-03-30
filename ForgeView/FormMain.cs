using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ForgeView
{
    public partial class FormMain : Form
    {
        [Dependency]

        public new IUnityContainer Container { get; set; }

        private readonly IPizzaOrderService service;

        private readonly IReportService reportService;

        public FormMain(IPizzaOrderService service, IReportService reportService)
        {
            InitializeComponent();
            this.service = service;
            this.reportService = reportService;
        }

        private void LoadData()
        {
        try
        {
            List<PizzaOrderViewModel> list = service.GetList();
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
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredients>();
            form.ShowDialog();
        }

        private void pizzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPizzas>();
            form.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPizzaOrder>();
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
                    service.TakeOrderInWork(new PizzaOrderBindingModel { PizzaOrderId = id });
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
                    service.FinishOrder(new PizzaOrderBindingModel { PizzaOrderId = id });
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
                    service.PayOrder(new PizzaOrderBindingModel { PizzaOrderId = id });
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
            var form = Container.Resolve<FormStorages>();
            form.ShowDialog();
        }

        private void putOnStorageItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPutOnStorage>();
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
                    reportService.SaveProductPrice(new ReportBindingModel
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
            var form = Container.Resolve<FormStorageLoad>();
            form.ShowDialog();

        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }
    }
}
