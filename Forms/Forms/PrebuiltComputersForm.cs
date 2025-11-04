using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Computer_Parts_Store.Models;
using Computer_Parts_Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Forms
{
    public partial class PrebuiltComputersForm : Form
    {
        public PrebuiltComputersForm()
        {
            InitializeComponent();
            LoadPrebuiltComputers();
            LoadImages();
        }

        private void LoadPrebuiltComputers()
        {
            try
            {
                using (var db = new Computer_Parts_StoreContext())
                {
                    var prebuiltPCs = db.PrebuiltComputers.Include(_ => _.Products);
                    foreach (var pc in prebuiltPCs)
                    {
                        dataGridViewPrebuilt.Rows.Add(
                            pc.Name,
                            pc.Description,
                            pc.TotalPrice,
                            "В наявності"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadImages()
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(64, 64);

            string imagePath = Path.Combine(Application.StartupPath, "IMG", "0.png");
            if (File.Exists(imagePath))
            {
                imageList.Images.Add(Image.FromFile(imagePath));
            }
            else
            {
                Bitmap placeholder = new Bitmap(64, 64);
                using (Graphics g = Graphics.FromImage(placeholder))
                {
                    g.Clear(Color.SteelBlue);
                    g.DrawRectangle(Pens.Black, 0, 0, 63, 63);
                }
                imageList.Images.Add(placeholder);
            }
        }

        private void dataGridViewPrebuilt_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridViewPrebuilt.Columns["colViewDetails"]?.Index)
            {
                using (var db = new Computer_Parts_StoreContext())
                {
                    var prebuiltPCs = db.PrebuiltComputers.Include(_ => _.Products).ToList();
                    var selectedPC = prebuiltPCs[e.RowIndex];
                    var EditForm = new PCBuilderForm(selectedPC);
                    EditForm.ShowDialog();
                }
            }
            else if (e.ColumnIndex == dataGridViewPrebuilt.Columns["colAddToCart"]?.Index)
            {
                MessageBox.Show("Готовий ПК додано до кошика!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void PrebuiltComputersForm_Resize(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void ResizeForm()
        {
            btnClose.Location = new Point(
                ClientSize.Width - btnClose.Width - 20,
                btnClose.Location.Y);
            dataGridViewPrebuilt.Width = ClientSize.Width - 40;
            dataGridViewPrebuilt.Height = ClientSize.Height - 80;
        }
    }
}