using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System;
using System.Windows.Forms;

namespace ForgeView
{
    public partial class FormCustomer : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel view = ApiClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + id.Value);
                    maskedTextBoxInitials.Text = view.FullName;
                    if (view != null)
                    {
                        maskedTextBoxInitials.Text = view.FullName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxInitials.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    ApiClient.PostRequest<CutstomerBindingModel, bool>("api/Customer/UpdElement", new CutstomerBindingModel
                    {
                        CustomerId = id.Value,
                        FullName = maskedTextBoxInitials.Text
                    });
                }
                else
                {
                    ApiClient.PostRequest<CutstomerBindingModel, bool>("api/Customer/AddElement", new CutstomerBindingModel
                    {
                        FullName = maskedTextBoxInitials.Text
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
