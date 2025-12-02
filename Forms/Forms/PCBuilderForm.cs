using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;

namespace Computer_Parts_Store.Forms
{
    public partial class PCBuilderForm : Form
    {
        private Computer_Parts_StoreContext db = new();
        private Dictionary<string, Product> selectedProducts = new();
        private decimal totalPrice = 0m;

        FlowLayoutPanel categoryPanel;
        FlowLayoutPanel productListPanel;
        private Button backButton;

        private readonly string[] layerOrder = {
            "case", "motherboard", "ram", "psu", "ssd", "hdd", "cpu", "cooler", "gpu",
            "keyboard", "mouse", "monitor"
        };

        public PCBuilderForm()
        {
            InitializeComponent();
            InitializeCustomControls();
            SetupCategoryButtons();
        }
        public PCBuilderForm(PrebuiltComputer pc) : this()
        {
            LoadComponents(pc);
        }

        private void InitializeCustomControls()
        {
            categoryPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = false,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.Transparent 
            };

            panelComponents.Controls.Add(categoryPanel);
            categoryPanel.BringToFront();

            productListPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Visible = false,
                BackColor = Color.Transparent
            };

            panelComponents.Controls.Add(productListPanel);

            backButton = new Button
            {
                Text = "← Назад",
                Size = new Size(120, 40),
                Location = new Point((panelComponents.Width - 120) / 2, panelComponents.Height - 50),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Top,
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Visible = false
            };
            backButton.Click += (s, e) => ShowCategories();

            panelComponents.Controls.Add(backButton);
            backButton.BringToFront();
        }

        private void SetupCategoryButtons()
        {
            categoryPanel.Controls.Clear();

            var categories = db.Categories.ToList();

            foreach (var cat in categories)
            {
                string layerName = MapCategoryToLayer(cat.Name);
                if (!layerOrder.Contains(layerName)) continue;
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Categories", $"{layerName}.png");

                Panel panel = new Panel
                {
                    Size = new Size(140, 190),
                    BackColor = Color.FromArgb(52, 73, 94),
                    Cursor = Cursors.Hand,
                    Margin = new Padding(10)
                };

                PictureBox icon = new PictureBox
                {
                    Size = new Size(100, 100),
                    Location = new Point((panel.Width - 100) / 2, 15),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = LoadImageSafe(path)
                };

                Label label = new Label
                {
                    Text = cat.Name,
                    ForeColor = Color.White,
                    Size = new Size(panel.Width, 50),
                    Location = new Point(0, 125),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    AutoEllipsis = true
                };

                panel.Controls.Add(icon);
                panel.Controls.Add(label);
                categoryPanel.Controls.Add(panel);

                EventHandler clickEvent = (s, e) => ShowProductList(cat, layerName);
                panel.Click += clickEvent;
                icon.Click += clickEvent;
                label.Click += clickEvent;
            }
        }
        private void ShowProductList(Category category, string layerName)
        {
            categoryPanel.Visible = false;
            productListPanel.Visible = true;
            backButton.Visible = true;
            productListPanel.Controls.Clear();

            var products = db.Products.Where(p => p.CategoryId == category.Id).ToList();

            foreach (var product in products)
            {
                Panel item = new Panel
                {
                    Size = new Size(180, 220),
                    BackColor = Color.FromArgb(52, 73, 94),
                    Margin = new Padding(10)
                };

                PictureBox pic = new PictureBox
                {
                    Size = new Size(160, 120),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10),
                    Image = GetProductImage(product.Article) 
                };

                Label name = new Label
                {
                    Text = product.Name,
                    ForeColor = Color.White,
                    Location = new Point(10, 140),
                    Size = new Size(160, 20),
                    AutoEllipsis = true
                };

                Label price = new Label
                {
                    Text = $"{product.Price} грн",
                    ForeColor = Color.LightGreen,
                    Location = new Point(10, 160),
                    Size = new Size(160, 20)
                };

                Button select = new Button
                {
                    Text = "Вибрати",
                    Location = new Point(40, 185),
                    Size = new Size(100, 25),
                    BackColor = Color.White
                };

                select.Click += (s, e) =>
                {
                    selectedProducts[layerName] = product;
                    UpdateTotalPrice();
                    ShowCategories();
                };

                item.Controls.Add(pic);
                item.Controls.Add(name);
                item.Controls.Add(price);
                item.Controls.Add(select);
                productListPanel.Controls.Add(item);
            }
        }

        private void ShowCategories()
        {
            productListPanel.Visible = false;
            backButton.Visible = false;
            categoryPanel.Visible = true;
        }

        private void UpdateTotalPrice()
        {
            txtBuildSummary.Clear();
            foreach (var product in selectedProducts.Values)
            {
                txtBuildSummary.Clear();

                txtBuildSummary.AppendText("=== КОНФІГУРАЦІЯ ПК ===\n\n");
                foreach (var layer in layerOrder)
                {
                    if (selectedProducts.ContainsKey(layer))
                    {
                        var prod = selectedProducts[layer];
                        txtBuildSummary.AppendText($"{layer.ToUpper()}: {prod.Name} - {prod.Price} грн\n");
                    }
                }
            }
            totalPrice = selectedProducts.Values.Sum(p => p.Price);
            if (lblTotalPriceValue != null)
                lblTotalPriceValue.Text = totalPrice.ToString("N2");
        }

        private Image LoadImageSafe(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(fs);
                    }
                }
                catch { return new Bitmap(100, 100); } 
            }
            return new Bitmap(100, 100); 
        }

        private Image GetProductImage(string article)
        {
            string? safeArticle = article?.Trim();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Products", $"{safeArticle}.png");
            if (!File.Exists(path)) path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Products", "noimage.jpg");
            return LoadImageSafe(path);
        }

        private string MapCategoryToLayer(string category)
        {
            category = category.Trim().ToLower();
            if (category.Contains("корпус")) return "case";
            if (category.Contains("материн")) return "motherboard";
            if (category.Contains("оперативна")) return "ram";
            if (category.Contains("живлення") || category.Contains("psu")) return "psu";
            if (category.Contains("ssd")) return "ssd";
            if (category.Contains("hdd")) return "hdd";
            if (category.Contains("cpu") || category.Contains("процесор")) return "cpu";
            if (category.Contains("кулер") || category.Contains("охолодження")) return "cooler";
            if (category.Contains("gpu") || category.Contains("відеокарта")) return "gpu";
            if (category.Contains("клавіатура")) return "keyboard";
            if (category.Contains("миша")) return "mouse";
            if (category.Contains("монітор")) return "monitor";
            return "empty";
        }
        private void LoadComponents(PrebuiltComputer pc)
        {
            using (var db = new Computer_Parts_StoreContext())
            {
                var products = db.PrebuiltComputers
                    .Where(c => c.Id == pc.Id)
                    .SelectMany(c => c.Products)
                    .ToList();

                foreach (var product in products)
                {
                    string layerName = MapCategoryToLayer(product.Category.Name);
                    if (layerName != "empty" && !selectedProducts.ContainsKey(layerName))
                    {
                        selectedProducts[layerName] = product;
                    }
                }

                UpdateTotalPrice();
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Виберіть принаймні процесор для збірки!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Збірку додано до кошика!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearBuild_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете очистити збірку?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                selectedProducts.Clear();
                UpdateTotalPrice();
                MessageBox.Show("Збірку очищено", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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