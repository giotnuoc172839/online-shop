using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnShopOnl.Admin
{
    public partial class fDashboard : Form
    {
        public fDashboard()
        {
            InitializeComponent();
        }

        //DataTable billDt = new DataTable();

        DataTable billDt;
        DataTable allBillInfoDt;

        int totalProductSell = 0;
        long totalRevenues = 0;
        int totalBill = 0;

        private void fDashboard_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            allBillInfoDt = DataProvider.Instance.LoadAllBillInfoDataTableFromTextFile();
            billDt = DataProvider.Instance.LoadAllBillDataTableFromTextFileDateTime();

            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, 6, 1);       
            dateTimePickerTo.Value = DateTime.Now;

            InitializeChart();
            CalculateTotals();
        }
        private void InitializeChart()
        {
            InitializeRevenueChart();
            InitializeRevenuePieChart();
            InitializeTopSellingPieChart();
            InitializeBillColumnChart();
        }


        private void InitializeRevenueChart() 
        {
            chartRevenue.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartRevenue.ChartAreas.Add(chartArea);
            chartArea.Position = new ElementPosition(1, 1, 10, 10);

            chartRevenue.Palette = ChartColorPalette.BrightPastel;

            Series phoneSeries = new Series("Laptop")
            {
                ChartType = SeriesChartType.StackedColumn,
            };

            chartRevenue.Series.Add(phoneSeries);

            Series laptopSeries = new Series("Phone")
            {
                ChartType = SeriesChartType.StackedColumn,
            };
            chartRevenue.Series.Add(laptopSeries);

            Series ipadSeries = new Series("Ipad")
            {
                ChartType = SeriesChartType.StackedColumn,
            };
            chartRevenue.Series.Add(ipadSeries);

            chartRevenue.Legends.Clear();
            chartRevenue.Legends.Add(new Legend());

            // Initial data load
            LoadRevenueChartData();
        }

        private void LoadRevenueChartData()
        {
            // Clear previous data
            chartRevenue.Series["Phone"].Points.Clear();
            chartRevenue.Series["Laptop"].Points.Clear();
            chartRevenue.Series["Ipad"].Points.Clear();
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Filter data based on selected date range
            var filteredRows = allBillInfoDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFrom.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerTo.Value);

            // Group data by month and category
            var groupedData = filteredRows
                .GroupBy(row => new
                {
                    Month = row.Field<DateTime>("dateTime").ToString("MM-yyyy"),
                    Category = row.Field<string>("category")
                })
                .Select(g => new
                {
                    g.Key.Month,
                    g.Key.Category,
                    TotalAmount = g.Sum(row => row.Field<long>("totalPrice"))
                })
                .GroupBy(item => item.Month)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToDictionary(item => item.Category, item => item.TotalAmount)
                );

            chartRevenue.Titles.Clear();
            chartRevenue.Titles.Add($"DOANH THU THEO THÁNG");

            // Add data to chart
            foreach (var entry in groupedData)
            {
                var month = entry.Key;
                var categories = entry.Value;

                chartRevenue.Series["Phone"].Points.AddXY(month, categories.ContainsKey("Phone") ? categories["Phone"] : 0);
                chartRevenue.Series["Laptop"].Points.AddXY(month, categories.ContainsKey("Laptop") ? categories["Laptop"] : 0);
                chartRevenue.Series["Ipad"].Points.AddXY(month, categories.ContainsKey("Ipad") ? categories["Ipad"] : 0);
            }
        }

        private void InitializeRevenuePieChart()
        {
            chart3Category.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(1, 1, 10, 10);
            chart3Category.ChartAreas.Add(chartArea);

            Series series = new Series("Revenue by Category")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}", // Show percentage
                LegendText = "#VALX" // Show category names in the legend
            };
            series["PieLabelStyle"] = "Outside"; // Place labels outside
            series["PieLineColor"] = "Black"; // Color of lines to labels
            series["PieStartAngle"] = "270"; // Rotate the pie chart for better layout
        
            series.Palette = ChartColorPalette.Bright;

            chart3Category.Series.Add(series);

            chart3Category.Legends.Clear();
            chart3Category.Legends.Add(new Legend());

            chart3Category.Titles.Clear();
            chart3Category.Titles.Add("TỔNG DOANH THU");

            LoadRevenuePieChartData();
        }

        private void LoadRevenuePieChartData()
        {
            // Clear previous data
            chart3Category.Series["Revenue by Category"].Points.Clear();

            // Filter data based on selected date range and categories (phone, laptop, ipad)
            var filteredRows = allBillInfoDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFrom.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerTo.Value);

            // Group data by category and sum the total price
            var groupedData = filteredRows
                .GroupBy(row => row.Field<string>("category"))
                .Select(g => new
                {
                    Category = g.Key,
                    TotalRevenue = g.Sum(row => row.Field<long>("totalPrice")) // Adjust field name based on your data structure
                });

            // Add data to pie chart
            foreach (var item in groupedData)
            {
                chart3Category.Series["Revenue by Category"].Points.AddXY(item.Category, item.TotalRevenue);
            }
        }

        private void InitializeTopSellingPieChart()
        {
            chartTopSelling.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(1, 1, 9, 9);
            chartTopSelling.ChartAreas.Add(chartArea);

            Series series = new Series("Top selling")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LegendText = "#VALX" // Show category names in the legend
            };
            series["PieStartAngle"] = "270"; // Rotate the pie chart for better layout
            series.Palette = ChartColorPalette.Pastel;

            chartTopSelling.Series.Add(series);

            chartTopSelling.Legends.Clear();
            chartTopSelling.Legends.Add(new Legend 
            {
                MaximumAutoSize = 100,    // Set the maximum width to 30% of the chart area
                Docking = Docking.Bottom,
                Font = new Font("Arial", 12) // Adjust the legend font
            });

            chartTopSelling.Titles.Clear();

            LoadTopSellingPieChart();
        }

        private void LoadTopSellingPieChart()
        {
            // Clear previous data
            chartTopSelling.Series["Top selling"].Points.Clear();

            // Filter data based on selected date range and category
            var filteredRows = allBillInfoDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFrom.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerTo.Value);

            // Group data by device name and sum the total price
            var groupedData = filteredRows
                .GroupBy(row => row.Field<string>("deviceName"))
                .Select(g => new
                {
                    DeviceName = g.Key,
                    TotalAmount = g.Sum(row => row.Field<int>("quantity"))
                })
                .OrderByDescending(g => g.TotalAmount).Take(10);

            // Add data to pie chart
            foreach (var item in groupedData)
            {
                chartTopSelling.Series["Top selling"].Points.AddXY(item.DeviceName, item.TotalAmount);
            }
        }


        private void InitializeBillColumnChart()
        {
            chartBill.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(1, 1, 9, 9);
            chartBill.ChartAreas.Add(chartArea);

            Series series = new Series("Tổng hóa đơn")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                BorderWidth = 1,
                Color = Color.CornflowerBlue,
            };

            chartBill.Series.Add(series);

            chartBill.Legends.Clear();
            chartBill.Legends.Add(new Legend
            {
                Docking = Docking.Bottom,
                Font = new Font("Arial", 12) // Adjust the legend font
            });

            chartBill.Titles.Clear();

            LoadBillColumnChart();
        }

        private void LoadBillColumnChart()
        {
            // Clear previous data
            chartBill.Series["Tổng hóa đơn"].Points.Clear();
            chartBill.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartBill.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Filter data based on selected date range
            var filteredRows = billDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFrom.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerTo.Value);

            // Group data by date and count the number of bills
            var groupedData = filteredRows
                .GroupBy(row => row.Field<DateTime>("dateTime").ToString("dd-MM-yyyy"))
                .Select(g => new
                {
                    Date = g.Key,
                    BillCount = g.Count()
                })
                .OrderBy(g => DateTime.ParseExact(g.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture));

            // Add data to line chart
            foreach (var item in groupedData)
            {
                chartBill.Series["Tổng hóa đơn"].Points.AddXY(item.Date, item.BillCount);
            }
        }

        private void CalculateTotals()
        {
            // Filter data based on selected date range
            var filteredBillInfoRows = allBillInfoDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFrom.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerTo.Value);

            // Calculate totalProductSell (sum of all items sold)
            totalProductSell = filteredBillInfoRows.Sum(row => row.Field<int>("quantity"));

            var filteredBillRows = billDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFrom.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerTo.Value);

            // Calculate totalRevenues (sum of totalPrice for all items sold)
            totalRevenues = filteredBillRows.Sum(row => row.Field<long>("totalPrice"));

            // Calculate totalBill (count of distinct bills)
            totalBill = filteredBillRows.Count();

            lblTotalBill.Text = totalBill.ToString("N0", new CultureInfo("es-ES"));
            lblTotalQuantity.Text = totalProductSell.ToString("N0", new CultureInfo("es-ES"));
            lblTotalSales.Text = totalRevenues.ToString("N0", new CultureInfo("es-ES")) + "đ";
        }


        void DisableDateTimePicker()
        {
            dateTimePickerFrom.Enabled = false;
            dateTimePickerTo.Enabled = false;
        }

        void EnableDateTimePicker()
        {
            dateTimePickerFrom.Enabled = true;
            dateTimePickerTo.Enabled = true;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DisableDateTimePicker();
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today.AddDays(1).AddSeconds(-1);
            InitializeChart();
            CalculateTotals();
        }

        private void btn7day_Click(object sender, EventArgs e)
        {
            DisableDateTimePicker();
            // Set dateTimePickerTo to today (end of today)
            dateTimePickerTo.Value = DateTime.Today.AddDays(1).AddSeconds(-1);

            // Set dateTimePickerFrom to 7 days ago (start of that day)
            dateTimePickerFrom.Value = DateTime.Today.AddDays(-6);
            InitializeChart();
            CalculateTotals();
        }

        private void btn30day_Click(object sender, EventArgs e)
        {
            DisableDateTimePicker();
            // Set dateTimePickerTo to today (end of today)
            dateTimePickerTo.Value = DateTime.Today.AddDays(1).AddSeconds(-1);

            // Set dateTimePickerFrom to 30 days ago (start of that day)
            dateTimePickerFrom.Value = DateTime.Today.AddDays(-29);
            InitializeChart();
            CalculateTotals();
        }

        private void btnThisYear_Click(object sender, EventArgs e)
        {
            DisableDateTimePicker();
            // Set dateTimePickerTo to end of the current year
            dateTimePickerTo.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);

            // Set dateTimePickerFrom to beginning of the current year
            dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
            InitializeChart();
            CalculateTotals();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            EnableDateTimePicker();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            InitializeChart();
            CalculateTotals();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            InitializeChart();
            CalculateTotals();
        }
    }
}
