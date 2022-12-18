using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_QR_Paper3_7_19_2020
{
    public partial class ArrivalSummaryAdmin : Form
    {
        private Session3Entities context = new Session3Entities();

        public ArrivalSummaryAdmin()
        {
            InitializeComponent();
        }

        private void ArrivalSummaryAdmin_Load(object sender, EventArgs e)
        {
            var july22 = DateTime.Parse("22 July 2020");
            var july23 = DateTime.Parse("23 July 2020");
            var july22Arrivals = from x in context.Arrivals
                                 where x.arrivalDate == july22
                                 group x by x.arrivalTime into y
                                 select y;
            var row = new List<string>();
            foreach (var arrival in july22Arrivals)
            {
                july22DGV.Columns.Add(arrival.Key, arrival.Key);
                var stringToAdd = $"{string.Join($" ({arrival.Sum(x => x.number19seat) + arrival.Sum(x => x.number42seat)} vehicles) ", arrival.Select(x => x.User.countryName))}";

                row.Add(stringToAdd + $"({arrival.Last().number19seat + arrival.Last().number42seat} vehicles) ");
            }

            var july23Arrivals = from x in context.Arrivals
                                 where x.arrivalDate == july23
                                 group x by x.arrivalTime into y
                                 select y;
            var row23Jul = new List<string>();
            foreach (var arrival in july23Arrivals)
            {
                july23DGV.Columns.Add(arrival.Key, arrival.Key);
                var stringToAdd = $"{string.Join($" ({arrival.Sum(x => x.number19seat) + arrival.Sum(x => x.number42seat)} vehicles) ", arrival.Select(x => x.User.countryName))}";

                row23Jul.Add(stringToAdd + $"({arrival.Last().number19seat + arrival.Last().number42seat} vehicles) ");
            }

            if (july22Arrivals.Count() != 0)
            {
                july22DGV.Rows.Add(row.ToArray());
            }
            if (july23Arrivals.Count() != 0)
            {
                july23DGV.Rows.Add(row23Jul.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}