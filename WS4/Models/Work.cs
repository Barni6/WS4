using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS3.Models
{
    public class Work : ObservableObject
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private int unit;
        public int Unit
        {
            get { return unit; }
            set { SetProperty(ref unit, value); }
        }

        private int cost;
        public int Cost
        {
            get { return cost; }
            set { SetProperty(ref cost, value); }
        }


        private int db;
        public int DB
        {
            get { return db; }
            set { SetProperty(ref db, value); }
        }

        public Work(string type, int unit, int cost, int dB)
        {
            Type = type;
            Unit = unit;
            Cost = cost;
            DB = dB;
        }

        public Work()
        {

        }

        public Work GetCopy()
        {
            return new Work()
            {
                Type = this.Type,
                Unit = this.Unit,
                Cost = this.Cost,
                DB = this.DB,
            };
        }


    }
}
