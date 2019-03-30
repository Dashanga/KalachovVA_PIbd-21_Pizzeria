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
using Unity;

namespace ForgeView
{
    public partial class FormStorageLoad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IReportService service;

        public FormStorageLoad(IReportService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormStorageLoad_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = service.GetStocksLoad();
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView1.Rows.Add(new object[] { elem.StorageName, "", "" });
                        foreach (var listElem in elem.Ingredients)
                        {
                            dataGridView1.Rows.Add(new object[] { "", listElem.Item1,
                                listElem.Item2 });
                        }
                        dataGridView1.Rows.Add(new object[] { "Итого", "", elem.TotalCount
                        });
                        dataGridView1.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void buttonSave2Csv_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.SaveStocksLoad(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }
    }
}
