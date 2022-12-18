using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session3_Jordan_Khong
{
    public partial class HotelBookingForm : Form
    {
        long currentHotelId = -1;
        string currentUserId = "";
        int numberOfSingleRooms = 0;
        int numberOfDoubleRooms = 0;

        public HotelBookingForm(long _hotelId, string _userID)
        {
            //Gets hotel ID and userId from previous screen
            currentUserId = _userID;
            currentHotelId = _hotelId;
            InitializeComponent();
            timer1.Start();
            Console.WriteLine(123 / 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = DateTime.Now.ToString();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HotelBookingForm_Load(object sender, EventArgs e)
        {
            using (var context = new Session3Entities())
            {
                //Checks if user has done their arrival, otherwise they cannot proceed:
                if (!context.Arrivals.Where(x => x.userIdFK == currentUserId).Any())
                {
                    MessageBox.Show("Please confirm your arrival time before booking a hotel.");
                    this.Close();
                }
                else
                {
                    //Sets the Form name, for easier reference:
                    var getHotelInfo = context.Hotels.Where(x => x.hotelId == currentHotelId).First();
                    var arrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).First();
                    this.Text = $" Booking of: {getHotelInfo.hotelName}";

                    var daysSpentInHotel = (DateTime.Parse("30 July 2020") - arrivalInfo.arrivalDate).Days;

                    //Sets all labels to their corresponding information
                    lblNoOfPaxDelegates.Text = arrivalInfo.numberDelegate.ToString();
                    numberofcompetitorsLbl.Text = arrivalInfo.numberCompetitors.ToString();
                    lblHotelName.Text = getHotelInfo.hotelName;


                    List<string> columns = new List<string>
                {
                    "Room Type", "Room Rate Per Night", "No. Of Available Rooms", "Required Rooms", "Subtotal"
                };

                    //Populates columns
                    foreach (var column in columns)
                    {
                        roomInfoDGV.Columns.Add(column, column);
                    }

                    //Only allow them to edit the Required Rooms:
                    roomInfoDGV.Columns[0].ReadOnly = true;
                    roomInfoDGV.Columns[1].ReadOnly = true;
                    roomInfoDGV.Columns[2].ReadOnly = true;
                    roomInfoDGV.Columns[4].ReadOnly = true;

                    #region Calculation of Single and Double Rooms:

                    //Add a single room per one delegate:
                    numberOfSingleRooms += arrivalInfo.numberDelegate;

                    //Add double rooms for all competitors / 2, if one remainder then add one extra single room
                    if (arrivalInfo.numberCompetitors % 2 == 0)
                    {
                        numberOfDoubleRooms += (arrivalInfo.numberCompetitors / 2);
                    }
                    else
                    {
                        numberOfDoubleRooms += (arrivalInfo.numberCompetitors / 2);
                        numberOfSingleRooms += 1;
                    }

                    //Calculate subtotal with relation to days spent in the hotel:
                    var singleSubTotal = numberOfSingleRooms * getHotelInfo.singleRate * daysSpentInHotel;
                    var doubleSubTotal = numberOfDoubleRooms * getHotelInfo.doubleRate * daysSpentInHotel;

                    //Add a row for single and Double:
                    List<string> singlerow = new List<string>
                {
                    "Single",
                    getHotelInfo.singleRate.ToString(),
                    (getHotelInfo.numSingleRoomsTotal - getHotelInfo.numSingleRoomsBooked).ToString(),
                    numberOfSingleRooms.ToString(),
                    singleSubTotal.ToString()
                };

                    roomInfoDGV.Rows.Add(singlerow.ToArray());

                    List<string> doubleRow = new List<string>
                {
                    "Double",
                    getHotelInfo.doubleRate.ToString(),
                   (getHotelInfo.numDoubleRoomsTotal - getHotelInfo.numDoubleRoomsBooked).ToString(),
                    numberOfDoubleRooms.ToString(),
                    doubleSubTotal.ToString()
                };

                    roomInfoDGV.Rows.Add(doubleRow.ToArray());

                    //Update total Value label:
                    totalValueLbl.Text = (singleSubTotal + doubleSubTotal).ToString();
                    #endregion
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //happens when user presses the book button
            using (var context = new Session3Entities())
            {
                var getHotelInfo = context.Hotels.Where(x => x.hotelId == currentHotelId).First();
                var arrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).First();

                var totalPeople = arrivalInfo.numberDelegate + arrivalInfo.numberCompetitors;

                while (true)
                {
                    //Gets total capacity of user set number of rooms
                    var totalRoomCapacity = (numberOfSingleRooms) + (numberOfDoubleRooms * 2);

                    //Checks if user set number of rooms can cater to total people arriving:
                    if (totalPeople > totalRoomCapacity)
                    {
                        MessageBox.Show("Not enough rooms catered to all competitors");
                        break;
                    }

                    //Checks with the hotel if they can provide enough single rooms
                    if (numberOfSingleRooms > Convert.ToInt32(roomInfoDGV.Rows[0].Cells[2].Value))
                    {
                        MessageBox.Show("Not enough single rooms available.");
                        break;
                    }

                    //Checks with the hotel if they can provide enough double rooms
                    if (numberOfDoubleRooms > Convert.ToInt32(roomInfoDGV.Rows[1].Cells[2].Value))
                    {
                        MessageBox.Show("Not enough double rooms available.");
                        break;
                    }

                    //Insert booking into db
                    Hotel_Booking insertBooking = new Hotel_Booking
                    {
                        hotelIdFK = getHotelInfo.hotelId,
                        userIdFK = currentUserId,
                        numSingleRoomsRequired = numberOfSingleRooms,
                        numDoubleRoomsRequired = numberOfDoubleRooms
                    };



                    context.Hotel_Booking.Add(insertBooking);

                    //Update Hotel table about number of rooms booked
                    getHotelInfo.numSingleRoomsBooked += numberOfSingleRooms;
                    getHotelInfo.numDoubleRoomsBooked += numberOfDoubleRooms;

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Booking made c:");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred when saving. Details:\n" + ex.InnerException);
                    }
                    

                    break;
                }
                

            }
            
        }

        private void roomInfoDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //When cell edit ends, try to parse all the entered values:
            #region Parsing SingleRoom values
            try
            {
                singleRoomErrorLbl.Visible = false;
                var singleRoomQuantity = Convert.ToInt32(roomInfoDGV.Rows[0].Cells[3].Value);
                Console.WriteLine(singleRoomQuantity);
                numberOfSingleRooms = singleRoomQuantity;
            }
            catch (Exception)
            {
                //If ConvertInt32 Fails, uses last value and lets user know:
                singleRoomErrorLbl.Visible = true;
                singleRoomErrorLbl.Text = $"Number of single rooms not recognised. Using last recorded value: {numberOfSingleRooms}";
            }
            #endregion

            #region Parsing DoubleRoom values:
            try
            {
                doubleRoomErrorLbl.Visible = false;
                var doubleRoomQuantity = Convert.ToInt32(roomInfoDGV.Rows[1].Cells[3].Value);
                Console.WriteLine(doubleRoomQuantity);
                numberOfDoubleRooms = doubleRoomQuantity;
            }
            catch (Exception)
            {
                //If ConvertInt32 Fails, uses last value and lets user know:
                doubleRoomErrorLbl.Visible = true;
                doubleRoomErrorLbl.Text = $"Number of double rooms not recognised. Using last recorded value: {numberOfDoubleRooms}";
            }
            #endregion

            #region Update Total Label by parsing subtotal values:
            using (var context = new Session3Entities())
            {
                var arrivalInfo = context.Arrivals.Where(x => x.userIdFK == currentUserId).First();
                var daysSpentInHotel = (DateTime.Parse("30 July 2020") - arrivalInfo.arrivalDate).Days;

                var costOfSingleRoom = Convert.ToInt32(roomInfoDGV.Rows[0].Cells[1].Value);
                var costOfDoubleRoom = Convert.ToInt32(roomInfoDGV.Rows[1].Cells[1].Value);

                var singleSubTotal = numberOfSingleRooms * daysSpentInHotel * costOfSingleRoom;
                var doubleSubTotal = numberOfDoubleRooms * daysSpentInHotel * costOfDoubleRoom;

                roomInfoDGV.Rows[0].Cells[4].Value = singleSubTotal;
                roomInfoDGV.Rows[1].Cells[4].Value = doubleSubTotal;

                totalValueLbl.Text = (singleSubTotal + doubleSubTotal).ToString();
            }
            #endregion


        }
    }
}
