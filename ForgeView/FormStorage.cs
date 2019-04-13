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
    public partial class FormStorage : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public FormStorage()
        {
            InitializeComponent();
        }

        private void FormStorage_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = ApiClient.GetRequest<StorageViewModel>("api/Storage/Get/" + id.Value);
                    if (view != null)
                    {
                        nameTextBox.Text = view.StorageName;
                        dataGridView1.DataSource = view.StorageIngredients;
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].AutoSizeMode =
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
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    ApiClient.PostRequest<StorageBindingModel, bool>("api/Storage/UpdElement", new StorageBindingModel
                    {
                        StorageId = id.Value,
                        StorageName = nameTextBox.Text
                    });
                }
                else
                {
                    ApiClient.PostRequest<StorageBindingModel, bool>("api/Storage/AddElement", new StorageBindingModel
                    {
                        StorageName = nameTextBox.Text
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
