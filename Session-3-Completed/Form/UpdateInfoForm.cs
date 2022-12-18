using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class UpdateInfoForm : Form
    {

        string currentUserId = "";
        int numberOfSingleRooms = 0;
        int numberOfDoubleRooms = 0;

        int _numberOfHead = -1;
        int _numberOfDele = -1;
        int _numberOfCompetitors = -1;

        int numberOf42Buses = 0;
        int numberOf19Buses = 0;

        public UpdateInfoForm(string _userID)
        {
            currentUserId = _userID;
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void UpdateInfoForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                //Checks if they've booked an arrival, and booked a hotel:
                if (!context.Arrivals.Where(x => x.userIdFK == currentUserId).Any())
                {
                    MessageBox.Show("Please confirm your arrival time before editing");
                    this.Close();
                }

                if (!context.Hotel_Booking.Where(x => x.userIdFK == currentUserId).Any())
                {
                    MessageBox.Show("Please confirm your hotel booking before editing.");
                    this.Close();
                }
                else
                {
                    //Sets the Form name, for easier reference, and queries about the hotel and arrival info
                    var getHotelInfo = context.Hotel_Booking.Where(x => x.userIdFK == currentUserId).First();
                    var arrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).First();
                    this.Text = $"Modifying: {arrivalInfo.arrivalId} from {getHotelInfo.Hotel.hotelName}";

                    var daysSpentInHotel = (DateTime.Parse("30 July 2020") - arrivalInfo.arrivalDate).Days;

                    //Sets all labels to their corresponding information
                    numberOfHODTb.Text = arrivalInfo.numberHead.ToString();
                    numberOfDeleTb.Text = arrivalInfo.numberDelegate.ToString();
                    numberOfCompetitorsTb.Text = arrivalInfo.numberCompetitors.ToString();

                    _numberOfHead = arrivalInfo.numberHead;
                    _numberOfDele = arrivalInfo.numberDelegate;
                    _numberOfCompetitors = arrivalInfo.numberCompetitors;
                    lblHotelName.Text = getHotelInfo.Hotel.hotelName;

                    List<string> columns = new List<string>
                {
                    "Room Type", "Room Rate Per Night", "No. Of Available Rooms", "Rooms Booked", "New number of rooms Required", "Subtotal"
                };
                    foreach (var column in columns)
                    {
                        roomInfoDGV.Columns.Add(column, column);
                    }
                    //Only allow them to edit the Required Rooms:
                    roomInfoDGV.Columns[0].ReadOnly = true;
                    roomInfoDGV.Columns[1].ReadOnly = true;
                    roomInfoDGV.Columns[2].ReadOnly = true;
                    roomInfoDGV.Columns[3].ReadOnly = true;
                    roomInfoDGV.Columns[5].ReadOnly = true;

                    //Update global variables to the current number of Single and Double rooms booked
                    numberOfSingleRooms = getHotelInfo.numSingleRoomsRequired;
                    numberOfDoubleRooms = getHotelInfo.numDoubleRoomsRequired;

                    //Populate the row with the single rooms:
                    List<string> singlerow = new List<string>
                {
                    "Single",
                    getHotelInfo.Hotel.singleRate.ToString(),
                    (getHotelInfo.Hotel.numSingleRoomsTotal - getHotelInfo.Hotel.numSingleRoomsBooked).ToString(),
                    numberOfSingleRooms.ToString(),
                    numberOfSingleRooms.ToString(),
                    (numberOfSingleRooms * getHotelInfo.Hotel.singleRate * daysSpentInHotel).ToString()
                };

                    roomInfoDGV.Rows.Add(singlerow.ToArray());

                    //Populate the row with the double rooms:
                    List<string> doubleRow = new List<string>
                {
                    "Double",
                    getHotelInfo.Hotel.doubleRate.ToString(),
                   (getHotelInfo.Hotel.numDoubleRoomsTotal - getHotelInfo.Hotel.numDoubleRoomsBooked).ToString(),
                    numberOfDoubleRooms.ToString(),
                    numberOfDoubleRooms.ToString(),
                    (numberOfDoubleRooms * getHotelInfo.Hotel.doubleRate * daysSpentInHotel).ToString()
                };

                    roomInfoDGV.Rows.Add(doubleRow.ToArray());

                    //Sets total value label to the two subtotals in the table:
                    totalValueLbl.Text = (Convert.ToInt32(roomInfoDGV.Rows[0].Cells[5].Value) + Convert.ToInt32(roomInfoDGV.Rows[1].Cells[5].Value)).ToString();

                }
            }

        }

        private void roomInfoDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            #region Single Room Validation
            try
            {
                singleRoomErrorLbl.Visible = false;
                var singleRoomQuantity = Convert.ToInt32(roomInfoDGV.Rows[0].Cells[4].Value);
                numberOfSingleRooms = singleRoomQuantity;
            }
            catch (Exception)
            {
                singleRoomErrorLbl.Visible = true;
                singleRoomErrorLbl.Text = $"Number of single rooms not recognised. Using last recorded value: {numberOfSingleRooms}";
            }
            #endregion

            #region Double Room Validation
            try
            {
                doubleRoomErrorLbl.Visible = false;
                var doubleRoomQuantity = Convert.ToInt32(roomInfoDGV.Rows[1].Cells[4].Value);
                numberOfDoubleRooms = doubleRoomQuantity;
            }
            catch (Exception)
            {
                doubleRoomErrorLbl.Visible = true;
                doubleRoomErrorLbl.Text = $"Number of double rooms not recognised. Using last recorded value: {numberOfDoubleRooms}";
            }
            #endregion

            #region Updates Total Tb:
            using (var context = new Session3Entities())
            {
                var arrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).First();
                var daysSpentInHotel = (DateTime.Parse("30 July 2020") - arrivalInfo.arrivalDate).Days;

                var costOfSingleRoom = Convert.ToInt32(roomInfoDGV.Rows[0].Cells[1].Value);
                var costOfDoubleRoom = Convert.ToInt32(roomInfoDGV.Rows[1].Cells[1].Value);

                var singleSubTotal = numberOfSingleRooms * daysSpentInHotel * costOfSingleRoom;
                var doubleSubTotal = numberOfDoubleRooms * daysSpentInHotel * costOfDoubleRoom;

                roomInfoDGV.Rows[0].Cells[5].Value = singleSubTotal;
                roomInfoDGV.Rows[1].Cells[5].Value = doubleSubTotal;

                totalValueLbl.Text = (singleSubTotal + doubleSubTotal).ToString();
            }
            #endregion
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {

                var getHotelInfo = context.Hotel_Booking.Where(x => x.userIdFK == currentUserId).First();
                var arrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).First();

                var totalPeople = _numberOfDele + _numberOfCompetitors;
                var totalRoomCapacity = (numberOfSingleRooms) + (numberOfDoubleRooms * 2);
                Console.WriteLine(totalPeople);
                Console.WriteLine(totalRoomCapacity);

                while (true)
                {
                    #region Validation of whether enough rooms are given:
                    if (totalPeople > totalRoomCapacity)
                    {
                        MessageBox.Show("Not enough rooms catered to all competitors");
                        break;
                    }

                    if (numberOfSingleRooms > (Convert.ToInt32(roomInfoDGV.Rows[0].Cells[2].Value) + Convert.ToInt32(roomInfoDGV.Rows[0].Cells[3].Value)))
                    {
                        MessageBox.Show("Not enough single rooms available.");
                        break;
                    }

                    if (numberOfDoubleRooms > (Convert.ToInt32(roomInfoDGV.Rows[1].Cells[2].Value) + Convert.ToInt32(roomInfoDGV.Rows[1].Cells[3].Value)))
                    {
                        MessageBox.Show("Not enough double rooms available.");
                        break;
                    }
                    #endregion

                    #region Update all related records:

                    //Updates the Hotel side:
                    getHotelInfo.Hotel.numSingleRoomsBooked = (getHotelInfo.Hotel.numSingleRoomsBooked - getHotelInfo.numSingleRoomsRequired) + numberOfSingleRooms;
                    getHotelInfo.Hotel.numDoubleRoomsBooked = (getHotelInfo.Hotel.numDoubleRoomsBooked - getHotelInfo.numDoubleRoomsRequired) + numberOfDoubleRooms;

                    //Updates the user side:
                    getHotelInfo.numSingleRoomsRequired = numberOfSingleRooms;
                    getHotelInfo.numDoubleRoomsRequired = numberOfDoubleRooms;

                    //Update arrival side:
                    arrivalInfo.number19seat = numberOf19Buses;
                    arrivalInfo.number42seat = numberOf42Buses;
                    arrivalInfo.numberCars = _numberOfHead;

                    arrivalInfo.numberCompetitors = _numberOfCompetitors;
                    arrivalInfo.numberDelegate = _numberOfDele;
                    arrivalInfo.numberHead = _numberOfHead;
                    #endregion

                    #region Save to Database
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Changes updated c:");
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("An error occurred. Details: \n" + ex.Message);
                    }


                    break;
                    #endregion
                }


            }
        }

        private void headOfDelegatesTb_TextChanged(object sender, EventArgs e)
        {
            //tries to parse number of HODs added, defaults to zero if value is not correct
            try
            {
                delegateHODErrorLbl.Visible = false;
                var number = Convert.ToInt32(numberOfHODTb.Text);

                if (number == 1)
                {
                    _numberOfHead = 1;

                }
                else if (number == 0)
                {
                    _numberOfHead = 0;
                }
                else
                {
                    delegateHODErrorLbl.Text = "Delegate head number should be 1 or 0. Assuming 0";
                    delegateHODErrorLbl.Visible = true;
                    _numberOfHead = 0;
                }


            }
            catch (Exception)
            {
                delegateHODErrorLbl.Text = "Number of Head Of Delegation not recognised. Assuming 0";
                delegateHODErrorLbl.Visible = true;

                _numberOfHead = 0;
            }
        }

        private void delegatesTb_TextChanged(object sender, EventArgs e)
        {
            //tries to parse number of delegates, defaults to zero if value is not correct, informs user as well.
            try
            {
                delegateErrorLbl.Visible = false;
                _numberOfDele = Convert.ToInt32(numberOfDeleTb.Text);

                updateBusTimes(_numberOfDele, _numberOfCompetitors);
            }
            catch (Exception)
            {
                delegateErrorLbl.Visible = true;
                _numberOfDele = 0;

                updateBusTimes(_numberOfDele, _numberOfCompetitors);

            }
        }

        void updateBusTimes(int noOfDelegate, int noOfCompetitors)
        {
            //Same algorithm used as per the Confirm Arrival page
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

        private void competitorsTb_TextChanged(object sender, EventArgs e)
        {
            //tries to parse number of competitors, defaults to zero if value is not correct, informs user as well.
            try
            {
                competitorErrorLbl.Visible = false;
                _numberOfCompetitors = Convert.ToInt32(numberOfCompetitorsTb.Text);

                updateBusTimes(_numberOfDele, _numberOfCompetitors);
            }
            catch (Exception)
            {
                competitorErrorLbl.Visible = true;
                _numberOfCompetitors = 0;

                updateBusTimes(_numberOfDele, _numberOfCompetitors);
            }
        }
    }
}
