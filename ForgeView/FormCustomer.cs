using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System;
using System.Text.RegularExpressions;
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
                        mailTextBox.Text = view.Mail;
                        dataGridView1.DataSource = view.Messages;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[4].AutoSizeMode =
                            DataGridViewAutoSizeColumnMode.Fill;

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
            string fio = maskedTextBoxInitials.Text;
            string mail = mailTextBox.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-
!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9az][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (id.HasValue)
            {
                ApiClient.PostRequest<CutstomerBindingModel,
                    bool>("api/Customer/UpdElement", new CutstomerBindingModel
                    {
                    CustomerId = id.Value,
                    FullName = fio,
                    Mail = mail
                });
            }
            else
            {
                ApiClient.PostRequest<CutstomerBindingModel,
                    bool>("api/Customer/AddElement", new CutstomerBindingModel
                    {
                    FullName = fio,
                    Mail = mail
                });
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
