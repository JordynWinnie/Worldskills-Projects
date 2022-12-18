using System;
using System.Linq;
using System.Windows.Forms;

namespace Covid19WebApp
{
    public partial class TemperatureRecording : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBoxes();
            }
             
        }

        
        private void PopulateBoxes()
        {
            using (var context = new CovidEntities())
            {
               
                foreach (var item in context.Locations.Select(x => x.LocationFloor).Distinct())
                {
                    DropDownList1.Items.Add(item.ToString());
                }

                
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (var context = new CovidEntities())
            {
                DropDownList2.Items.Clear();
                foreach (var item in context.Locations.Where(x=>x.LocationFloor.ToString() == DropDownList1.SelectedItem.Value).
                    Select(x => x.LocationUnitNumber).
                    Distinct())
                {
                    DropDownList2.Items.Add(item.ToString());
                }

                
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new CovidEntities())
            {
                Console.WriteLine("Method2 Called");
                var locationName = context.Locations.Where(x => x.LocationFloor.ToString() == DropDownList1.SelectedItem.Value
                && x.LocationUnitNumber.ToString() == DropDownList2.SelectedItem.Value).First();

                locationLabel.Text = $"Selected Location: {locationName.LocationName} ({locationName.ID})";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var context = new CovidEntities())
            {
                var newID = (context.ContactTracings.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault() + 1);
                var locationName = context.Locations.Where(x => x.LocationFloor.ToString() == DropDownList1.SelectedItem.Value
                && x.LocationUnitNumber.ToString() == DropDownList2.SelectedItem.Value).First();

                if (Convert.ToDecimal(temperatureTb.Text) > 38)
                {
                    MessageBox.Show("Temperature is over 38 degrees");
                }

                var insertContactTrace = new ContactTracing
                {
                    ID = newID,
                    FullName = nameTb.Text,
                    Contact = contactTb.Text,
                    Email = emailTb.Text,
                    RegisterDateTime = DateTime.Now,
                    LocationID = locationName.ID,
                    Temp = Convert.ToDecimal(temperatureTb.Text)

                };

                context.ContactTracings.Add(insertContactTrace);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Temperature Recorded!");
                    Page.Response.Redirect(Page.Request.Url.ToString(), false);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving to database. Details:\n" + ex.Message);
                    
                }
            }
           
        }
    }
}