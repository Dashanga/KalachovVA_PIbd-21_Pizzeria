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
using Unity;

namespace ForgeView
{
    public partial class FormPizzaIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public ProductComponentViewModel Model
        {
            set { model = value; }
            get { return model; }
        }
        private readonly IComponentService service;
        private ProductComponentViewModel model;

        public FormPizzaIngredient(IComponentService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormPizzaIngredient_Load(object sender, EventArgs e)
        {
            try
            {
                List<ComponentViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxProductComponents.DisplayMember = "ComponentName";
                    comboBoxProductComponents.ValueMember = "Id";
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
                comboBoxProductComponents.SelectedValue = model.ComponentId;
                maskedTextBoxCount.Text = model.Count.ToString();
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
                    model = new ProductComponentViewModel
                    {
                        ComponentId = Convert.ToInt32(comboBoxProductComponents.SelectedValue),
                        ComponentName = comboBoxProductComponents.Text,
                        Count = Convert.ToInt32(maskedTextBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(maskedTextBoxCount.Text);
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
