using System;
using System.Windows.Forms;
using Computer_Parts_Store.Models;
using Computer_Parts_Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Forms
{
    public partial class PCBuilderForm : Form
    {
        private decimal totalPrice = 0;
        private readonly PrebuiltComputer PC;

        public PCBuilderForm()
        {
            InitializeComponent();
            LoadComponents();
        }

        public PCBuilderForm(PrebuiltComputer pc)
        {
            PC = pc;
            totalPrice = pc.TotalPrice;
            InitializeComponent();
            LoadComponents(PC);
        }

        private void LoadComponents()
        {
            // Завантаження комплектуючих з бази даних
            cmbCPU.Items.Add("-- Оберіть процесор --");
            cmbGPU.Items.Add("-- Оберіть відеокарту --");
            cmbMotherboard.Items.Add("-- Оберіть материнську плату --");
            cmbRAM.Items.Add("-- Оберіть оперативну пам'ять --");
            cmbStorage.Items.Add("-- Оберіть накопичувач --");
            cmbPSU.Items.Add("-- Оберіть блок живлення --");
            cmbCase.Items.Add("-- Оберіть корпус --");
            cmbCooling.Items.Add("-- Оберіть систему охолодження --");

            using (var db = new Computer_Parts_StoreContext())
            {
                var products = db.Products.Include(_ => _.Category).ToList();
                foreach (var product in products)
                {
                    switch (product.Category.Name)
                    {
                        case "Процесори (CPU)":
                            cmbCPU.Items.Add($"{product.Name}");
                            break;
                        case "Відеокарти (GPU)":
                            cmbGPU.Items.Add($"{product.Name}");
                            break;
                        case "Материнські плати":
                            cmbMotherboard.Items.Add($"{product.Name}");
                            break;
                        case "Оперативна пам'ять (RAM)":
                            cmbRAM.Items.Add($"{product.Name}");
                            break;
                        case "HDD накопичувачі":
                        case "SSD накопичувачі":
                            cmbStorage.Items.Add($"{product.Name}");
                            break;
                        case "Блоки живлення (PSU)":
                            cmbPSU.Items.Add($"{product.Name}");
                            break;
                        case "Корпуси":
                            cmbCase.Items.Add($"{product.Name}");
                            break;
                        case "Повітряне охолодження":
                        case "Рідинне охолодження":
                            cmbCooling.Items.Add($"{product.Name}");
                            break;
                        default:
                            break;
                    }
                }
            }
            cmbCPU.SelectedIndex = 0;
            cmbGPU.SelectedIndex = 0;
            cmbMotherboard.SelectedIndex = 0;
            cmbRAM.SelectedIndex = 0;
            cmbStorage.SelectedIndex = 0;
            cmbPSU.SelectedIndex = 0;
            cmbCase.SelectedIndex = 0;
            cmbCooling.SelectedIndex = 0;
        }
        private void LoadComponents(PrebuiltComputer pc)
        {
            LoadComponents();

            using (var db = new Computer_Parts_StoreContext())
            {
                var products = db.PrebuiltComputers.Include(_ => _.Products)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefault(_ => _.Id == pc.Id)?.Products;
                foreach (var product in products)
                {
                    switch (product.Category.Name)
                    {
                        case "Процесори (CPU)":
                            cmbCPU.SelectedItem = $"{product.Name}";
                            break;
                        case "Відеокарти (GPU)":
                            cmbGPU.SelectedItem = $"{product.Name}";
                            break;
                        case "Материнські плати":
                            cmbMotherboard.SelectedItem = $"{product.Name}";
                            break;
                        case "Оперативна пам'ять (RAM)":
                            cmbRAM.SelectedItem = $"{product.Name}";
                            break;
                        case "HDD накопичувачі":
                        case "SSD накопичувачі":
                            cmbStorage.SelectedItem = $"{product.Name}";
                            break;
                        case "Блоки живлення (PSU)":
                            cmbPSU.SelectedItem = $"{product.Name}";
                            break;
                        case "Корпуси":
                            cmbCase.SelectedItem = $"{product.Name}";
                            break;
                        case "Повітряне охолодження":
                        case "Рідинне охолодження":
                            cmbCooling.SelectedItem = $"{product.Name}";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Component_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBuildSummary();
        }

        private void UpdateBuildSummary()
        {
            txtBuildSummary.Clear();

            txtBuildSummary.AppendText("=== КОНФІГУРАЦІЯ ПК ===\n\n");



            if (cmbCPU.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Процесор: {cmbCPU.Text}\n");

            if (cmbGPU.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Відеокарта: {cmbGPU.Text}\n");

            if (cmbMotherboard.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Материнська плата: {cmbMotherboard.Text}\n");

            if (cmbRAM.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Оперативна пам'ять: {cmbRAM.Text}\n");

            if (cmbStorage.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Накопичувач: {cmbStorage.Text}\n");

            if (cmbPSU.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Блок живлення: {cmbPSU.Text}\n");

            if (cmbCase.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Корпус: {cmbCase.Text}\n");

            if (cmbCooling.SelectedIndex > 0)
                txtBuildSummary.AppendText($"Система охолодження: {cmbCooling.Text}\n");

            lblTotalPriceValue.Text = $"{totalPrice:F2} грн";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbCPU.SelectedIndex == 0)
            {
                MessageBox.Show("Виберіть принаймні процесор для збірки!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Збірку додано до кошика!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearBuild_Click(object sender, EventArgs e)
        {
            cmbCPU.SelectedIndex = 0;
            cmbGPU.SelectedIndex = 0;
            cmbMotherboard.SelectedIndex = 0;
            cmbRAM.SelectedIndex = 0;
            cmbStorage.SelectedIndex = 0;
            cmbPSU.SelectedIndex = 0;
            cmbCase.SelectedIndex = 0;
            cmbCooling.SelectedIndex = 0;

            UpdateBuildSummary();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PCBuilderForm_Resize(object sender, EventArgs e)
        {
            FormResize();
        }

        private void FormResize()
        {
            panelSummary.Location = new Point(
                ClientSize.Width - panelSummary.Width - 20,
                panelSummary.Location.Y);
            panelComponents.Size = new Size(
                ClientSize.Width - panelSummary.Width - 60,
                panelComponents.Height);
            btnClose.Location = new Point(
                ClientSize.Width - btnClose.Width - 20,
                btnClose.Location.Y);
            foreach (ComboBox cmb in panelComponents.Controls.OfType<ComboBox>())
            {
                cmb.Width = panelComponents.ClientSize.Width - 50;
            }
        }
    }
}