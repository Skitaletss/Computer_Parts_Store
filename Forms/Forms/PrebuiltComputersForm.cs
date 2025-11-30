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
                using (var db = new Computer_Parts_StoreContext())
                {
                    if (!LoginSession.IsLoggedIn)
                    {
                        MessageBox.Show("Будь ласка, увійдіть до свого облікового запису, щоб додати ПК до кошика", "Необхідний вхід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int userID = LoginSession.CurrentCustomer.Id;
                    var order = db.Orders
                        .Include(o => o.OrderItems)
                        .FirstOrDefault(o => o.CustomerId == userID && o.Status == "Кошик");
                    if (order == null)
                    {
                        order = new Order
                        {
                            CustomerId = userID,
                            OrderDate = DateTime.Now,
                            Status = "Кошик"
                        };
                        db.Orders.Add(order);
                        db.SaveChanges();
                    }
                    var prebuiltPCs = db.PrebuiltComputers.ToList();
                    var selectedPC = prebuiltPCs[e.RowIndex];
                    var existingItem = order.OrderItems.FirstOrDefault(oi => oi.PrebuiltComputerId == selectedPC.Id);
                    if (existingItem != null)
                    {
                        existingItem.Quantity += 1;
                    }
                    else
                    {
                        var orderItem = new OrderItem
                        {
                            OrderId = order.Id,
                            PrebuiltComputerId = selectedPC.Id,
                            Quantity = 1,
                            UnitPrice = selectedPC.TotalPrice
                        };
                        db.OrderItems.Add(orderItem);
                    }
                    db.SaveChanges();
                }
                MessageBox.Show("Готовий ПК додано до кошика", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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