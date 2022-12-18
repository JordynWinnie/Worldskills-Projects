using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class ConfirmArrivalDetails : Form
    {
        /// <summary>
        /// Global fields are all used to store info that will be updated dynamically
        /// </summary>
        string currentUserId = "";
        string arrivalTime = "";

        int _numberOfHead = -1;
        int _numberOfDele = -1;
        int _numberOfCompetitors = -1;

        int numberOf42Buses = 0;
        int numberOf19Buses = 0;

        public ConfirmArrivalDetails(string _userIdFk)
        {
            currentUserId = _userIdFk;
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmArrivalDetails_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                //Adds hidden columns to represent the time
                var columns = new List<string>
                {
                    "9am",
                    "10am",
                    "11am",
                    "12pm",
                    "1pm",
                    "2pm",
                    "3pm",
                    "4pm"
                };

                //Adds rows that are shown to the user as available times
                var timeArray = new string[]
                {  
                    "9am",
                    "10am",
                    "11am",
                    "12pm",
                    "1pm",
                    "2pm",
                    "3pm",
                    "4pm" 
                };

                //Populate columns:
                foreach (var column in columns)
                {
                    arrivalDGV.Columns.Add(column, column);
                }

                arrivalDGV.Rows.Add(timeArray);

                //Avaiable times for 22nd Jul:
                var availableTimes = new List<string>
            {
                "9am","11am","12pm","3pm","4pm"
            };

                ChangeGridTimes(availableTimes);

                //Deselects a cell, incase one is already selected
                arrivalDGV.CurrentCell.Selected = false;

                //Gets the user information (Test):
                var getUserIdInfo = context.Users.Where(x => x.userId.Equals(currentUserId)).Select(x => x.userId).FirstOrDefault();

                this.Text = getUserIdInfo.ToString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Updates when head of delegation is changed:
            try
            {
                #region Validation of HODs
                delegateHODErrorLbl.Visible = false;
                var number = Convert.ToInt32(numberOfHODTb.Text);

                if (number == 1)
                {

                    _numberOfHead = 1;
                    carsForHeadLbl.Text = $"{_numberOfHead} Car for head of delegation";
                }
                else if (number == 0)
                {
                    _numberOfHead = 0;
                    carsForHeadLbl.Text = $"{_numberOfHead} Cars for head of delegation";

                }
                else
                {
                    carsForHeadLbl.Text = $"Number should be either zero or one. Assuming 0";
                    _numberOfHead = 0;
                }
                #endregion

            }
            catch (Exception)
            {
                //If Int32Convert fails, it defaults to zero, informs user:
                delegateHODErrorLbl.Visible = true;
                carsForHeadLbl.Text = $"Unrecognised number/text in field. Assuming 0";
                _numberOfHead = 0;
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Updates when the number of delegates is changed:
            try
            {

                delegateErrorLbl.Visible = false;
                _numberOfDele = Convert.ToInt32(numberOfDeleTb.Text);

                updateBusTimes(_numberOfDele, _numberOfCompetitors);

                //Sets label to current number of 19 and 42 buses
                seaterBuses19lbl.Text = $"{numberOf19Buses} 19-seater bus";
                seaterBus42lbl.Text = $"{numberOf42Buses} 42-seater bus";


            }
            catch (Exception)
            {
                //If Int32Convert fails, it defaults to zero, informs user, also updates bus count 
                delegateErrorLbl.Visible = true;
                _numberOfDele = 0;

                updateBusTimes(_numberOfDele, _numberOfCompetitors);

                seaterBuses19lbl.Text = $"{numberOf19Buses} 19-seater bus";
                seaterBus42lbl.Text = $"{numberOf42Buses} 42-seater bus";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Updates when the number of competitors is changed:
            try
            {
                competitorErrorLbl.Visible = false;
                _numberOfCompetitors = Convert.ToInt32(numberOfCompetitorsTb.Text);

                updateBusTimes(_numberOfDele, _numberOfCompetitors);

                //Sets label to current number of 19 and 42 buses
                seaterBuses19lbl.Text = $"{numberOf19Buses} 19-seater bus";
                seaterBus42lbl.Text = $"{numberOf42Buses} 42-seater bus";
            }
            catch (Exception)
            {
                //If Int32Convert fails, it defaults to zero, informs user, also updates bus count 
                competitorErrorLbl.Visible = true;
                _numberOfCompetitors = 0;

                updateBusTimes(_numberOfDele, _numberOfCompetitors);

                seaterBuses19lbl.Text = $"{numberOf19Buses} 19-seater bus";
                seaterBus42lbl.Text = $"{numberOf42Buses} 42-seater bus";
            }
        }

        private void confirmBooking_Click(object sender, EventArgs e)
        {

            while (true)
            {
                Arrival insertArrival = new Arrival();

                //Sets the date based on RadioButton Selected:
                insertArrival.userIdFK = currentUserId;
                if (july22radio.Checked)
                {
                    insertArrival.arrivalDate = DateTime.Parse("22 July 2020");
                }
                if (july23Radio.Checked)
                {
                    insertArrival.arrivalDate = DateTime.Parse("23 July 2020");
                }


                //Checks if arrival time globalVariable has been updated. 
                //It is initialised with a empty string, this is used to check if the user has clicked on the cell.
                if (arrivalTime.Equals(string.Empty))
                {
                    MessageBox.Show("Please select a time");
                    break;
                }
                else
                {
                    insertArrival.arrivalTime = arrivalTime;
                }

                //Checks if numberOfHead globalVariable has been updated. 
                //It is initialised with -1, this is used to check if the user has clicked on the cell.
                if (_numberOfHead == -1)
                {
                    MessageBox.Show("Please enter number of Head of Delegations Coming");
                    break;
                }
                else
                {
                    insertArrival.numberHead = _numberOfHead;
                    insertArrival.numberCars = _numberOfHead;
                }

                //Checks if _numberOfCompetitors && _numberOfDele globalVariable has been updated. 
                //It is initialised with -1, this is used to check if the user has clicked on the cell.
                if (_numberOfCompetitors == -1 || _numberOfDele == 1)
                {
                    MessageBox.Show("Please enter number of Competitors and Delegates coming");
                    break;
                }
                else
                {
                    insertArrival.numberCompetitors = _numberOfCompetitors;
                    insertArrival.numberDelegate = _numberOfDele;
                }



                insertArrival.number19seat = numberOf19Buses;
                insertArrival.number42seat = numberOf42Buses;

                //Saves arrival info into database
                using (var context = new Session3Entities())
                {
                    context.Arrivals.Add(insertArrival);

                    context.SaveChanges();
                    MessageBox.Show("Arrival Confirmed");
                    this.Close();
                    break;
                }

            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Reflect Change to date of 22 Jul
            //9am, 11am, 12pm, 3pm and 4pm
            arrivalDGV.CurrentCell.Selected = false;

            var availableTimes = new List<string>
            {
                "9am","11am","12pm","3pm","4pm"
            };

            ChangeGridTimes(availableTimes);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Reflect Change to date of 23 Jul
            //For 23 July, the available timeslots are 10am, 11am, 1pm, 2pm and 3pm.
            arrivalDGV.CurrentCell.Selected = false;

            arrivalDGV.Rows[0].DefaultCellStyle.BackColor = Color.White;

            var availableTimes = new List<string>
            {
                "10am", "11am", "1pm", "2pm", "3pm"
            };

            ChangeGridTimes(availableTimes);
        }

        void ChangeGridTimes(List<string> availableTimes)
        {
            //Method accepts a List Of Avaiable times:
            //Sets unavailable times to BackColourBlack
            foreach (DataGridViewCell cell in arrivalDGV.Rows[0].Cells)
            {
                cell.Style.BackColor = Color.White;
                cell.Style.SelectionBackColor = Color.Yellow;

                if (!availableTimes.Contains(cell.Value))
                {
                    cell.Style.BackColor = Color.Black;
                }
            }
        }

        private void arrivalDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Check if user has picked an unavailable time based on back colour:
                if (arrivalDGV.Rows[0].Cells[e.ColumnIndex].Style.BackColor == Color.Black)
                {
                    MessageBox.Show("Arrival time is not available. Please select another");
                    arrivalDGV.CurrentCell.Selected = false;
                    arrivalTime = "";
                }
                else
                {
                    arrivalTime = arrivalDGV.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                    Console.WriteLine(arrivalTime);
                }

            }
        }


        /// <summary>
        ///  Takes in number of delegates and number of competitors, adds them up
        ///  Does a division of 42 FIRST, checks remainder.
        ///  Add whatever number of buses came out of the division
        ///  
        ///  Check the remainder of the division. If the reminder is above zero, do the following checks:
        ///  If the remainder is 19 or below, one extra 19 bus is needed
        ///  If it is between 19 and 38, two 19 buses are needed
        ///  If it is above 38, one extra 42 bus is needed
        ///  This method does not return anything, but updates the global variables numberOf19Buses & numberOf42Buses
        /// </summary>
        /// <param name="noOfDelegate"></param>
        /// <param name="noOfCompetitors"></param>
        void updateBusTimes(int noOfDelegate, int noOfCompetitors)
        {
           
            int total = noOfDelegate + noOfCompetitors;
            numberOf19Buses = 0;
            numberOf42Buses = 0;

            var bus42Initial = total / 42;
            var initialRemainder = total % 42;

            if (initialRemainder > 0)
            {
                numberOf42Buses += bus42Initial;
                //Continue Division
                //Determine if 2 19-seater buses, or 1 extra 42 seater bus:

                if (initialRemainder <= 19)
                {
                    numberOf19Buses += 1;
                }
                else if (initialRemainder > 19 && initialRemainder <= 38)
                {
                    numberOf19Buses += 2;
                }
                else
                {
                    numberOf42Buses += 1;
                }
            }
            else
            {
                //Only order number 42 buses
                numberOf42Buses = bus42Initial;
            }
        }
    }
}
