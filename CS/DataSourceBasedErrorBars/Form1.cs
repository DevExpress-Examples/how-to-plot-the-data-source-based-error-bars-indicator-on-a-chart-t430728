using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ErrorBarsWin {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public class AggregatedCategoryData {
            public object CategoryName { get; set; }
            public double MeanProductPrice { get; set; }
            public double MaxProductPrice { get; set; }
            public double MinProductPrice { get; set; }
        }
        List<AggregatedCategoryData> GetData() {
            List<AggregatedCategoryData> result = new List<AggregatedCategoryData>();
            using (var context = new NwindDbContext()) {
                foreach (Category category in context.Categories) {
                    var productUnitPrices = category.Products.Select(p => p.UnitPrice);
                    result.Add(new AggregatedCategoryData {
                        CategoryName = category.CategoryName,
                        MeanProductPrice = Convert.ToDouble(productUnitPrices.Aggregate((p1, p2) => p1 + p2) / category.Products.Count),
                        MinProductPrice = Convert.ToDouble(productUnitPrices.Min()),
                        MaxProductPrice = Convert.ToDouble(productUnitPrices.Max())
                    });
                }
            }
            return result;
        }
        Series series { get { return chartControl.Series[0]; } }
        #region #DateSourceBasedErrorBars
        private void FormOnLoad(object sender, EventArgs e) {
            PointSeriesView view = new PointSeriesView();
            view.Indicators.Add(new DataSourceBasedErrorBars {
                ShowInLegend = true,
                Name = "Prices Range",
                NegativeErrorDataMember = "MinProductPrice",
                PositiveErrorDataMember = "MaxProductPrice"
            });
            series.View = view;
            series.ArgumentDataMember = "CategoryName";
            series.ValueDataMembers.AddRange(new string[] { "MeanProductPrice" });
            series.DataSource = GetData();
        }
        #endregion #DateSourceBasedErrorBars
    }
}
