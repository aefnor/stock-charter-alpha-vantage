using Newtonsoft.Json.Linq;
using OxyPlot;
using Stocks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stocks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string key = APIKeys.AlphaVantageKey;
        public static string ticker = "";
        private string url = $"https://www.alphavantage.co/query?function={time}&symbol={ticker}&interval=5min&apikey={key}";
        private string url_balance_sheet = $"https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol={ticker}&apikey={key}";
        private static string time = "TIME_SERIES_INTRADAY";
        private List<StockDailyDataModel> StockDailyList = new List<StockDailyDataModel>();
        public MainWindow()
        {
            InitializeComponent();
            TickerPlot.ZoomAllAxes(4);
            DataContext = this;
            Title = "Example 2";
            Timeframe.Items.Add("Weekly");
            Timeframe.Items.Add("Daily");
            Timeframe.Items.Add("Monthly");
            Timeframe.Items.Add("Yearly");
            Timeframe.Items.Add("Hourly");

            PointsClose = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
            PointsOpen = new List<DataPoint>{};
            PointsHigh = new List<DataPoint> { };
            PointsLow = new List<DataPoint> { };
        }
        public new string Title { get; private set; }

        public IList<DataPoint> PointsClose { get; private set; }
        public IList<DataPoint> PointsOpen { get; private set; }
        public IList<DataPoint> PointsHigh { get; private set; }

        public IList<DataPoint> PointsLow { get; private set; }

        private void Ticker_TextChanged(object sender, TextChangedEventArgs e)
        {
            ticker = StockTicker.Text;
            TickerPlot.Title = StockTicker.Text.ToUpper();
            url = $"https://www.alphavantage.co/query?function={time}&symbol={ticker}&interval=5min&apikey={key}";
            url_balance_sheet = $"https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol={ticker}&apikey={key}";
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CallAlphaVantageAPI();
            TickerPlot.InvalidatePlot(true);
        }

        private void CallAlphaVantageAPI()
        {
            GetStockData();
            GetBalanceSheetData();
        }

        private void GetBalanceSheetData()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_balance_sheet);
            request.Method = "GET";
            //string postData = string.Format("param1=something&param2=something_else");
            //byte[] data = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            //request.ContentLength = data.Length;

            //using (Stream requestStream = request.GetRequestStream())
            //{
            //    //requestStream.Write(data, 0, data.Length);
            //}
            String[] spearator = { @"", "For" };
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    // Do something with response
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd(); // do something fun...
                        JObject o = JObject.Parse(result);
                        foreach (var x in o)
                        {
                            string name = x.Key;
                            JToken value = x.Value;
                            if (value.HasValues)
                            {
                                foreach (var i in value)
                                {
                                    AnnualReportsModel balanceAnnualSheet = new AnnualReportsModel();
                                    AnnualReportsModel balanceQuaterlySheet = new AnnualReportsModel();
                                    //string test = i.Key;
                                    JToken test2 = i;
                                    string[] trs = test2.First.ToString().Split('"');
                                    try
                                    {   
                                        
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private void GetStockData()
        {
            StockDailyList.Clear();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //string postData = string.Format("param1=something&param2=something_else");
            //byte[] data = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";
            //request.ContentLength = data.Length;

            //using (Stream requestStream = request.GetRequestStream())
            //{
            //    //requestStream.Write(data, 0, data.Length);
            //}
            String[] spearator = { @"", "For" };
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    // Do something with response
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd(); // do something fun...
                        JObject o = JObject.Parse(result);
                        foreach (var x in o)
                        {
                            string name = x.Key;
                            JToken value = x.Value;
                            if (value.HasValues)
                            {
                                foreach (var i in value)
                                {
                                    StockDailyDataModel dailyData = new StockDailyDataModel();
                                    StockDataModel data = new StockDataModel();
                                    //string test = i.Key;
                                    JToken test2 = i;
                                    string[] trs = test2.First.ToString().Split('"');
                                    try
                                    {
                                        string[] dateToConvert = i.ToString().Split('"');
                                        DateTime myDate = DateTime.ParseExact(dateToConvert[1].Trim('/'), "yyyy-MM-dd HH:mm:ss",
                                            System.Globalization.CultureInfo.InvariantCulture);
                                        dailyData.date = myDate;
                                        data.open = Convert.ToDouble(trs[3]);
                                        data.close = Convert.ToDouble(trs[15]);
                                        data.high = Convert.ToDouble(trs[7]);
                                        data.low = Convert.ToDouble(trs[11]);
                                        data.volume = Convert.ToDouble(trs[19]);
                                        dailyData.data = data;
                                        StockDailyList.Add(dailyData);

                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                UpdateChart();
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private void UpdateChart()
        {
            TickerPlot.InvalidatePlot(true);

            PointsClose.Clear();
            PointsOpen.Clear();
            PointsHigh.Clear();
            PointsLow.Clear();

            foreach (StockDailyDataModel data in StockDailyList){
                
                Volume_Per_Day.Items.Add(data.date +": " + data.data.volume);
                DataPoint newPoint = new DataPoint(data.date.Hour, data.data.close);
                if (time == "TIME_SERIES_WEEKLY")
                    newPoint = new DataPoint(data.date.ToOADate(), data.data.close);
                if (time == "TIME_SERIES_DAILY")
                    newPoint = new DataPoint(data.date.ToOADate(), data.data.close);
                if (time == "TIME_SERIES_MONTHLY")
                    newPoint = new DataPoint(data.date.ToOADate(), data.data.close);
                if (!PointsClose.Contains(newPoint))
                    PointsClose.Add(newPoint);
                if (!PointsOpen.Contains(newPoint))
                    PointsOpen.Add(newPoint);
                if (!PointsHigh.Contains(newPoint))
                    PointsHigh.Add(newPoint);
                if (!PointsLow.Contains(newPoint))
                    PointsLow.Add(newPoint);
            }
            
        }

        private void Button_Click_Zoom(object sender, RoutedEventArgs e)
        {

        }

        private void Timeframe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Timeframe.SelectedItem)
            {
                case "Weekly":
                    time = "TIME_SERIES_WEEKLY";
                    return;
                case "Daily":
                    time = "TIME_SERIES_DAILY";
                    return;
                case "Monthly":
                    time = "TIME_SERIES_MONTHLY";
                    return;
                case "Yearly":
                    return;
                case "Hourly":
                    return;
                default:
                    time = "TIME_SERIES_INTRADAY";
                    return;

            }         
        }             
    }                 
}                     
