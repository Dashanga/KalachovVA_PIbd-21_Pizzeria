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
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;

namespace ForgeView
{
    public partial class FormPutOnStorage : Form
    {
        public FormPutOnStorage()
        {
            InitializeComponent();
        }

        private void FormPutOnStorage_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> listC = ApiClient.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                if (listC != null)
                {
                    comboBoxIngredients.DisplayMember = "IngredientName";
                    comboBoxIngredients.ValueMember = "IngredientId";
                    comboBoxIngredients.DataSource = listC;
                    comboBoxIngredients.SelectedItem = null;
                }
                List<StorageViewModel> listS = ApiClient.GetRequest<List<StorageViewModel>>("api/Storage/GetList");
                if (listS != null)
                {
                    comboBoxStorages.DisplayMember = "StorageName";
                    comboBoxStorages.ValueMember = "StorageId";
                    comboBoxStorages.DataSource = listS;
                    comboBoxStorages.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIngredients.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorages.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                ApiClient.PostRequest<StorageIngredientBindingModel, bool>("api/PizzaOrder/PutComponentOnStock", new StorageIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(comboBoxIngredients.SelectedValue),
                    StorageId = Convert.ToInt32(comboBoxStorages.SelectedValue),
                    StorageIngredientCount = Convert.ToInt32(textBoxCount.Text)
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
