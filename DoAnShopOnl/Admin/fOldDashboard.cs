using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnShopOnl.Admin
{
    public partial class fOldDashboard : Form
    {
        public fOldDashboard()
        {
            InitializeComponent();
        }
        DataTable bill;
        DataTable allBillInfoDt;
        private void fOldDashboard_Load(object sender, EventArgs e)
        {
            cbBoxCategory.SelectedIndex = 1;
            allBillInfoDt = DataProvider.Instance.LoadAllBillInfoDataTableFromTextFile();

            // Set DateTimePicker values
            dateTimePickerFromTopSelling.Value = new DateTime(DateTime.Now.Year, 6, 1);
            dateTimePickerToTopSelling.Value = DateTime.Now;

            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, 6, 1);
            dateTimePickerTo.Value = DateTime.Now;

            InitializeChart();
        }

        private void InitializeChart()
        {
            InitializeRevenueChart();

            InitializeRevenuePieChart();

            InitializeAmountPieChart(chartTopSelling, cbBoxCategory.Text);
            LoadCategoryAmountPieChart(chartTopSelling, cbBoxCategory.Text);

            InitializeRevenuePieChart(chartTopRevenue, cbBoxCategory.Text);
            LoadCategoryRevenuePieChart(chartTopRevenue, cbBoxCategory.Text);
        }


        private void InitializeRevenueChart()
        {
            chartRevenue.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartRevenue.ChartAreas.Add(chartArea);
            chartArea.Position = new ElementPosition(1, 1, 10, 10);

            Series phoneSeries = new Series("Phone")
            {
                ChartType = SeriesChartType.StackedColumn
            };
            chartRevenue.Series.Add(phoneSeries);

            Series laptopSeries = new Series("Laptop")
            {
                ChartType = SeriesChartType.StackedColumn
            };
            chartRevenue.Series.Add(laptopSeries);

            Series ipadSeries = new Series("Ipad")
            {
                ChartType = SeriesChartType.StackedColumn
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
            chartRevenue.Titles.Add($"Doanh thu");

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

        private void InitializeAmountPieChart(Chart chart, string category)
        {
            chart.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(1, 1, 9, 9);
            chart.ChartAreas.Add(chartArea);

            Series series = new Series(category)
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            series["PieStartAngle"] = "270"; // Rotate the pie chart for better layout
            series.Palette = ChartColorPalette.Pastel;

            chart.Series.Add(series);

            chart.Legends.Clear();
            chart.Legends.Add(new Legend
            {
                Alignment = StringAlignment.Center,
                Docking = Docking.Bottom,
                Font = new Font("Arial", 10) // Adjust the legend font
            });

            chart.Titles.Clear();
            chart.Titles.Add($"Top Selling Products - {category}");

        }

        private void InitializeRevenuePieChart(Chart chart, string category)
        {
            chart.Series.Clear(); // Clear any existing series

            ChartArea chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(1, 1, 15, 15);
            chart.ChartAreas.Add(chartArea);

            Series series = new Series(category)
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}", // Show percentage
                LegendText = "#VALX" // Show category names in the legend
            };
            series["PieLabelStyle"] = "Outside"; // Place labels outside
            series["PieLineColor"] = "Black"; // Color of lines to labels
            series["PieStartAngle"] = "270"; // Rotate the pie chart for better layout
            series.Palette = ChartColorPalette.Pastel;

            chart.Series.Add(series);

            chart.Legends.Clear();
            chart.Legends.Add(new Legend());

            chart.Titles.Clear();
            chart.Titles.Add($"Top Selling Revenue - {category}");

        }


        private void LoadCategoryAmountPieChart(Chart chart, string category)
        {
            // Clear previous data
            chart.Series[category].Points.Clear();

            // Filter data based on selected date range and category
            var filteredRows = allBillInfoDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFromTopSelling.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerToTopSelling.Value &&
                row.Field<string>("category") == category);

            // Group data by device name and sum the total price
            var groupedData = filteredRows
                .GroupBy(row => row.Field<string>("deviceName"))
                .Select(g => new
                {
                    DeviceName = g.Key,
                    TotalAmount = g.Sum(row => row.Field<int>("quantity"))
                })
                .OrderByDescending(g => g.TotalAmount);

            // Add data to pie chart
            foreach (var item in groupedData)
            {
                chart.Series[category].Points.AddXY(item.DeviceName, item.TotalAmount);
            }
        }

        private void LoadCategoryRevenuePieChart(Chart chart, string category)
        {
            // Clear previous data
            chart.Series[category].Points.Clear();

            // Filter data based on selected date range and category
            var filteredRows = allBillInfoDt.AsEnumerable().Where(row =>
                row.Field<DateTime>("dateTime") >= dateTimePickerFromTopSelling.Value &&
                row.Field<DateTime>("dateTime") <= dateTimePickerToTopSelling.Value &&
                row.Field<string>("category") == category);

            // Group data by device name and sum the total price
            var groupedData = filteredRows
                .GroupBy(row => row.Field<string>("deviceName"))
                .Select(g => new
                {
                    DeviceName = g.Key,
                    TotalSales = g.Sum(row => row.Field<long>("totalPrice"))
                })
                .OrderByDescending(g => g.TotalSales);

            // Add data to pie chart
            foreach (var item in groupedData)
            {
                chart.Series[category].Points.AddXY(item.DeviceName, item.TotalSales);
            }
        }

        private void gnBtnRevenue_Click(object sender, EventArgs e)
        {
            LoadRevenueChartData();
        }

        private void gnBtn3_Click(object sender, EventArgs e)
        {
            LoadRevenuePieChartData();
        }

        private void gnBtnTopSelling_Click(object sender, EventArgs e)
        {
            string category = cbBoxCategory.Text;

            InitializeAmountPieChart(chartTopSelling, category);
            LoadCategoryAmountPieChart(chartTopSelling, category);

            InitializeRevenuePieChart(chartTopRevenue, category);
            LoadCategoryRevenuePieChart(chartTopRevenue, category);
        }
    }
}
