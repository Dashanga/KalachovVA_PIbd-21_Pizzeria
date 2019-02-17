using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.BindingModel;
using System;
using System.Windows.Forms;
using Unity;

namespace ForgeView
{
    public partial class FormCreateIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id
        {
            set { id = value; }
        }

        private readonly IComponentService service;

        private int? id;


        public FormCreateIngredient(IComponentService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormCreateIngredient_Load(object sender, EventArgs e)
        {
            if (!id.HasValue) return;
            try
            {
                var view = service.GetElement(id.Value);
                if (view != null)
                {
                    labelName.Text = view.ComponentName;
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
                    service.UpdElement(new ComponentBindingModel
                    {
                        Id = id.Value,
                        ComponentName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new ComponentBindingModel
                    {
                        ComponentName = textBoxName.Text
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