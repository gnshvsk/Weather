using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace Weather.OpenWeather
{
    class weather
    {
        public int id;

        public string main;

        public string description;

        public string icon;

        public Bitmap Icon
        {
            get
            {
                return new Bitmap(Image.FromFile($"icons/{icon}.png")); //получаем нужную иконку погоды из папки Icons 
                                                                        //с возможностью менять имя иконки
            }
        }
    }
}
