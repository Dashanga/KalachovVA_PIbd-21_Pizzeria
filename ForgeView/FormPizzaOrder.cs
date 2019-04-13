using ForgeServiceDAL.BindingModel;
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
namespace ForgeView
{
    public partial class FormPizzaOrder : Form
    {
        public FormPizzaOrder()
        {
            InitializeComponent();

        }

        private void CalcSum()
        {
            if (comboBoxPizza.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxPizza.SelectedValue);
                    PizzaViewModel pizza = ApiClient.GetRequest<PizzaViewModel>("api/Pizza/Get/" + id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxTotal.Text = (count * pizza.Cost).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void FormPizzaOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = ApiClient.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if (listC != null)
                {
                    comboBoxCustomer.DisplayMember = "FullName";
                    comboBoxCustomer.ValueMember = "CustomerId";
                    comboBoxCustomer.DataSource = listC;
                    comboBoxCustomer.SelectedItem = null;
                }
                List<PizzaViewModel> listP = ApiClient.GetRequest<List<PizzaViewModel>>("api/Pizza/GetList");
                if (listP != null)
                {
                    comboBoxPizza.DisplayMember = "PizzaName";
                    comboBoxPizza.ValueMember = "PizzaId";
                    comboBoxPizza.DataSource = listP;
                    comboBoxPizza.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPizza.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                ApiClient.PostRequest<PizzaOrderBindingModel, bool>("api/PizzaOrder/CreateOrder", new PizzaOrderBindingModel
                {
                    CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    PizzaId = Convert.ToInt32(comboBoxPizza.SelectedValue),
                    PizzaCount = Convert.ToInt32(textBoxCount.Text),
                    TotalCost = Convert.ToDecimal(textBoxTotal.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
