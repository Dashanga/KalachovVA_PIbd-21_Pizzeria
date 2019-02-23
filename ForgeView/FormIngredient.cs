﻿using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.BindingModel;
using System;
using System.Windows.Forms;
using Unity;

namespace ForgeView
{
    public partial class FormIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id
        {
            set { id = value; }
        }

        private readonly IIngredientService service;

        private int? id;


        public FormIngredient(IIngredientService service)
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
                    service.UpdElement(new IngredientBindingModel
                    {
                        IngredientId = id.Value,
                        IngredientName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new IngredientBindingModel
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