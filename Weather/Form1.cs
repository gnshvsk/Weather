﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;


namespace Weather
{
    public partial class Form1 : Form
    {
        string answer = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Omsk&APPID=1fb63a10a9c1ba5eee8d4615108eda44");

            request.Method = "POST";

            request.ContentType = "application/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();


            using (Stream s = response.GetResponseStream())          //получаем поток ответа и записываем в строковую переменную
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();



            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer); //десериализация класса и преведение к типу Openweather

            panel1.BackgroundImage = oW.weather[0].Icon;
            label1.Text = oW.weather[0].main;
            label2.Text = oW.weather[0].description;
            label3.Text = "Средняя температура (С): " + oW.main.temp.ToString("0.##");
            label6.Text = "Скорость (м/с) :" + oW.wind.speed.ToString();
            label7.Text = "Направление: " + oW.wind.deg.ToString();
            label4.Text = "Влажность (%): " + oW.main.humidity.ToString();
            label5.Text = "Давление (мм): " + ((int)oW.main.pressure).ToString();
            label9.Text = "Omsk";
            button1.Click += new EventHandler(BTN1_Click);
        }

        private async void BTN1_Click(object sender, EventArgs e)
        {
            string City = SelectCity.Text;
            if ( City == String.Empty)
            {
                City = "Omsk";
            }
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=" 
                + City + "&units=metric&appid=1fb63a10a9c1ba5eee8d4615108eda44");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";

            WebResponse respons = await request.GetResponseAsync();
            using (Stream s = respons.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            respons.Close();
            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);
            panel1.BackgroundImage = oW.weather[0].Icon;
            label1.Text = oW.weather[0].main;
            label2.Text = oW.weather[0].description;
            label3.Text = "Температура: " + oW.main.temp.ToString("0.##") + "*C";
            label6.Text = "Скорость: " + oW.wind.speed.ToString() + "m/sek";
            label7.Text = "Направление: " + oW.wind.deg.ToString() + "Grad";
            label4.Text = "Влажность: " + oW.main.humidity.ToString() + "%";
            label5.Text = "Давление: " + ((int)oW.main.pressure).ToString() + "мм ртут. столб.";
            label9.Text = City;
        }
    }
}
