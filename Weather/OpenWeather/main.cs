using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather.OpenWeather
{
    class main
    {
        private double _temp; //выводить погоду нужно в Цельсиях, но получена она в Кельвинах

        public double temp
        {
            get
            {
                return _temp;
            }
            set 
            {
                _temp = value - 273.15; //перевод температуры из Кельвинов в Цельсии
            }
        }

        private double _pressure;

        public double pressure
        {
            get
            {
                return _pressure; //получаем значение в килопаскалях
            }
            set
            {
                _pressure = value / 1.3332239;

            }
        }

        public double humidity;

        private double _temp_min; 

        public double temp_min
        {
            get
            {
                return _temp_min;
            }
            set
            {
                _temp_min = value - 273.15; 
            }
        }

        private double _temp_max;

        public double temp_max
        {
            get
            {
                return _temp_max;
            }
            set
            {
                _temp_max = value - 273.15;
            }
        }
    }
}
