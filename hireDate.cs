using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public struct hireDate
    {
        public int year;
        public int month;
        public int day;

        public hireDate()
        {
            year = 0;
            month = 0;
            day = 0;
        }

        public hireDate(int _year, int _month, int _day)
        {
            year = _year;
            day = _day;
            month = _month;
        }
        public void setDay(int _s)
        {
            day = _s;
        }
        public void setMonth(int _s)
        {
            month = _s;
        }
        public void setYear(int _s)
        {
            year = _s;
        }
        public string gethireDate()
        {
            return year + "/" + month + "/" + day;
        }
        public int getYear()
        {
            return year;
        }

        public int getMonth()
        {
            return month;
        }

        public int getDay()
        {
            return day;
        }


      
        public override string ToString()
        {
            return $"{day} / {month} /{year}";
        }

    }
}
