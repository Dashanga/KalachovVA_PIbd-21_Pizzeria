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
using ForgeServiceDAL.ViewModel;

namespace ForgeView
{
    public partial class FormImplementer: Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormImplementer()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    ApiClient.PostRequest<ImplementerBindingModel, bool>("api/Implementer/UpdElement", new ImplementerBindingModel
                    {
                        Id = id.Value,
                        ImplementerFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    ApiClient.PostRequest<ImplementerBindingModel, bool>("api/Implementer/AddElement", new ImplementerBindingModel
                    {
                        ImplementerFIO = textBoxFIO.Text
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

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ImplementerViewModel view = ApiClient.GetRequest<ImplementerViewModel>("api/Implementer/Get/" + id.Value);
                    textBoxFIO.Text = view.ImplementerFIO;
                    if (view != null)
                    {
                        textBoxFIO.Text = view.ImplementerFIO;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
