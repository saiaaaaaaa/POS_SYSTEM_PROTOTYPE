using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS_System_w_Price_and_Payment_PROTOTYPE
{
    public partial class Form1 : Form
    {
        // for visibility positioning
        int SELECTION_SPAWN, FLOW_SPAWN, FLOW_END;
        // for selected item
        int ITEM_INDEX = 0;

        string[] sample_data =
        {
            "Drinks",
            "Snacks",
            "Meals",
            "Desserts"
        };
        int[] sample_stock =
        {
            12,
            8,
            5,
            7
        };
        int[] sample_price =
        {
            25,
            20,
            50,
            30
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // for visibility positioning
            SELECTION_SPAWN = Topbar.Bottom + 16;
            FLOW_SPAWN = flowLayoutPanel1.Top - 16 - SELECTION_SPAWN;
            FLOW_END = flowLayoutPanel1.Bottom;
        }

        void Start()
        {
            // set default colors
            BackColor = Color.FromArgb(30, 30, 30);
            Sidebar.BackColor = Color.FromArgb(42, 42, 42);
            Selection.BackColor = Color.FromArgb(42, 42, 42);
            Topbar.BackColor = Color.FromArgb(68, 68, 68);
            RightPanel.BackColor = Color.FromArgb(48, 48, 48);
            AddButton.BorderColor = Color.FromArgb(68, 68, 68);
            AddItemButton.BorderColor = Color.FromArgb(68, 68, 68);

            // for visibility positioning
            SELECTION_SPAWN = Topbar.Bottom + 16;
            FLOW_SPAWN = flowLayoutPanel1.Top - 16 - SELECTION_SPAWN;
            FLOW_END = flowLayoutPanel1.Bottom;

            // for selected item
            CategoryLabel.Text = sample_data[ITEM_INDEX];
            StockLabel.Value = sample_stock[ITEM_INDEX];
            PriceLabel.Value = sample_price[ITEM_INDEX];

            Topbar.Click += (s, e) =>
            {
                HideSelection();
            };
            label1.Click += (s, e) =>
            {
                HideSelection();
            };
            AddButton.Click += (s, e) =>
            {
                ShowSelection();
            };
            AddItemButton.Click += (s, e) =>
            {
                HideSelection();

                // set new values
                sample_stock[ITEM_INDEX] = (int)StockLabel.Value;
                sample_price[ITEM_INDEX] = (int)PriceLabel.Value;

                RefreshData();
            };

            RefreshData();
        }

        void RefreshData()
        {
            flowLayoutPanel1.Controls.Clear();

            // for each item, add new panel with click event for item selection
            for (int a = 0; a < sample_data.Length; a++)
            {
                int f_a = a;
                RoundedPanel Item = new RoundedPanel();
                Item.Name = sample_data[a];
                Item.BackColor = Color.FromArgb(85, 85, 85);
                Item.Size = new Size(100, 100);
                Item.Cursor = Cursors.Hand;
                Item.Click += (s, e) =>
                {
                    ITEM_INDEX = f_a;
                    ShowSelection();
                };

                Label Title = new Label();
                Title.Text = sample_data[a];
                Title.ForeColor = Color.White;
                Title.TextAlign = ContentAlignment.BottomCenter;
                Title.Font = new Font("Arial", 10, FontStyle.Bold);
                Title.Location = new Point(13, 0);
                Title.Size = new Size(75, 40);

                Label Stock = new Label();
                Stock.Text = sample_stock[a].ToString() + " in stock";
                Stock.ForeColor = Color.White;
                Stock.TextAlign = ContentAlignment.MiddleCenter;
                Stock.Font = new Font("Arial", 8, FontStyle.Regular);
                Stock.Location = new Point(13, 40);
                Stock.Size = new Size(75, 25);

                Label Price = new Label();
                Price.Text = "₱" + sample_price[a].ToString();
                Price.ForeColor = Color.White;
                Price.TextAlign = ContentAlignment.TopCenter;
                Price.Font = new Font("Arial", 8, FontStyle.Regular);
                Price.Location = new Point(13, 65);
                Price.Size = new Size(75, 35);

                Title.Click += (s, e) =>
                {
                    ITEM_INDEX = f_a;
                    ShowSelection();
                };
                Stock.Click += (s, e) =>
                {
                    ITEM_INDEX = f_a;
                    ShowSelection();
                };
                Price.Click += (s, e) =>
                {
                    ITEM_INDEX = f_a;
                    ShowSelection();
                };

                Item.Controls.Add(Title);
                Item.Controls.Add(Stock);
                Item.Controls.Add(Price);
                flowLayoutPanel1.Controls.Add(Item);
            }
        }

        void HideSelection()
        {
            if (Selection.Visible)
            {
                Selection.Visible = false;
                flowLayoutPanel1.Location = new Point(flowLayoutPanel1.Location.X, SELECTION_SPAWN);
                flowLayoutPanel1.Size = new Size(flowLayoutPanel1.Width, flowLayoutPanel1.Height + FLOW_SPAWN + 16);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
            HideSelection();
        }

        void ShowSelection()
        {
            CategoryLabel.Text = sample_data[ITEM_INDEX];
            StockLabel.Value = sample_stock[ITEM_INDEX];
            PriceLabel.Value = sample_price[ITEM_INDEX];
            if (!Selection.Visible)
            {
                Selection.Visible = true;
                flowLayoutPanel1.Location = new Point(flowLayoutPanel1.Location.X, SELECTION_SPAWN + FLOW_SPAWN + 16);
                flowLayoutPanel1.Size = new Size(flowLayoutPanel1.Width, flowLayoutPanel1.Height - FLOW_SPAWN - 16);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Keys Key = e.KeyCode;

            if (Key == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
