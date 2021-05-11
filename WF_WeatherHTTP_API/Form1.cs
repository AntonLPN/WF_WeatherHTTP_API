using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using System.Net.Http;


namespace WF_WeatherHTTP_API
{
    public partial class Form1 : Form
    {
        List<DateTime> time;
        List<double> temp;
        List<int> humidity;
        public Form1()
        {
            InitializeComponent();
            time = new List<DateTime>();
            temp = new List<double>();
            humidity = new List<int>();

        }

        private async  void Form1_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = await client.GetAsync("https://api.openweathermap.org/data/2.5/onecall?lat=47.5434&lon=33.2249&exclude=current,minutely,daily,alerts&appid=ef5ebfda74903c4b21316165b1c7b5de&units=metric&lang=ru");
                string body = await res.Content.ReadAsStringAsync();
                Whether_data data = JsonConvert.DeserializeObject<Whether_data>(body);

                data.hourly.Select(d => new { Time = new DateTime(1970, 1, 1).AddSeconds(d.dt), Temper = d.temp, Hundity = d.humidity });


                //время
                foreach (var item in data.hourly)
                {
                    time.Add(new DateTime(1970, 1, 1).AddSeconds(item.dt));
                }
                //температура
                foreach (var item in data.hourly)
                {
                    temp.Add(item.temp);
                }
                //влажность
                foreach (var item in data.hourly)
                {
                    humidity.Add(item.humidity);
                }


                //закидываем запросом короткую дату и время
                List<string> toShortDateString = time.ConvertAll(p => p.ToLongDateString()+p.ToShortTimeString());

                cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Температура",
                    Values = new ChartValues<double> (temp)
                },

               
            };

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Время",
                    Labels = toShortDateString,
                }) ;

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Температура",
                    LabelFormatter = val => $"{val} °С"
                });





                cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Температура",
                    Values = new ChartValues<int> (humidity)
                },


            };

                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Время",
                    Labels = toShortDateString,
                });
                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Влажность",
                    LabelFormatter =val => $"{val} %"
                });








                ///using*************************************
            }
            ///using*************************************
        }


         
        }









       
    }
    

