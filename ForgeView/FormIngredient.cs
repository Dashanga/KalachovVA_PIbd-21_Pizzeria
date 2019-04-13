using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.BindingModel;
using System;
using System.Windows.Forms;
using ForgeServiceDAL.ViewModel;

namespace ForgeView
{
    public partial class FormIngredient : Form
    {
        public int Id
        {
            set { id = value; }
        }


        private int? id;


        public FormIngredient()
        {
            InitializeComponent();
        }

        private void FormCreateIngredient_Load(object sender, EventArgs e)
        {
            if (!id.HasValue) return;
            try
            {
                var view = ApiClient.GetRequest<IngredientViewModel>("api/Ingredient/Get/" + id.Value); ;
                if (view != null)
                {
                    labelName.Text = view.IngredientName;
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (id.HasValue)
                {
                    ApiClient.PostRequest<IngredientBindingModel, bool>("api/Ingredient/UpdElement", new IngredientBindingModel
                    {
                        IngredientId = id.Value,
                        IngredientName = textBoxName.Text
                    });
                }
                else
                {
                    ApiClient.PostRequest<IngredientBindingModel, bool>("api/Ingredient/AddElement", new IngredientBindingModel
                    {
                        IngredientName = textBoxName.Text
                    });
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