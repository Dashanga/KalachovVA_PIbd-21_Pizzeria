using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ForgeView
{
    public partial class FormAddIngredient : Form
    {
        public PizzaIngredientViewModel Model
        {
            set { model = value; }
            get { return model; }
        }
        private PizzaIngredientViewModel model;

        public FormAddIngredient()
        {
            InitializeComponent();
        }

        private void FormPizzaIngredient_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> list =
                    ApiClient.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                if (list != null)
                {
                    comboBoxProductComponents.DisplayMember = "IngredientName";
                    comboBoxProductComponents.ValueMember = "IngredientId";
                    comboBoxProductComponents.DataSource = list;
                    comboBoxProductComponents.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxProductComponents.Enabled = false;
                comboBoxProductComponents.SelectedValue = model.IngredientId;
                maskedTextBoxCount.Text = model.PizzaIngredientCount.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProductComponents.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new PizzaIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(comboBoxProductComponents.SelectedValue),
                        IngredientName = comboBoxProductComponents.Text,
                        PizzaIngredientCount = Convert.ToInt32(maskedTextBoxCount.Text)
                    };
                }
                else
                {
                    model.PizzaIngredientCount = Convert.ToInt32(maskedTextBoxCount.Text);
                }
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
