using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TP_QR_Session3_7_6_2020
{
    [Activity(Label = "ConfirmArrivalDetailsActivity")]
    public class ConfirmArrivalDetailsActivity : Activity
    {
        private RadioButton july22RadioButton;
        private RadioButton july23RadioButton;
        private Spinner arrivalTimeSpinner;
        private EditText headOfDeleEditText;
        private EditText delegatesEditText;
        private EditText competitorsEditText;
        private TextView numberOfCarsTextView;
        private TextView numberOf19SeatersTextView;
        private TextView numberOf42SeatersTextView;
        private Button confirmArrivalButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.confirm_arrival_details_layout);
            InitViews();
        }

        private void InitViews()
        {
            july22RadioButton = FindViewById<RadioButton>(Resource.Id.July22RadioBtnConfirmArr);
            july23RadioButton = FindViewById<RadioButton>(Resource.Id.July23RadioBtnConfirmArr);

            arrivalTimeSpinner = FindViewById<Spinner>(Resource.Id.arrivalTimeSpinnerConfirmArr);

            headOfDeleEditText = FindViewById<EditText>(Resource.Id.headOfDeleEditTextConfirmArr);
            delegatesEditText = FindViewById<EditText>(Resource.Id.delegatesEditTextConfirmArr);
            competitorsEditText = FindViewById<EditText>(Resource.Id.competitorsEditTextConfirmArr);

            numberOfCarsTextView = FindViewById<TextView>(Resource.Id.numberOfCarForHODTxtviewConfirmArr);
            numberOf19SeatersTextView = FindViewById<TextView>(Resource.Id.numberOf19SeaterTxtviewConfirmArr);
            numberOf42SeatersTextView = FindViewById<TextView>(Resource.Id.numberOf42SeaterTxtviewConfirmArr);

            confirmArrivalButton = FindViewById<Button>(Resource.Id.confirmBtnConfirmArr);

            confirmArrivalButton.Click += ConfirmArrivalButton_Click;
            headOfDeleEditText.AfterTextChanged += HeadOfDeleEditText_AfterTextChanged;
            delegatesEditText.AfterTextChanged += DelegatesEditText_AfterTextChanged;
            competitorsEditText.AfterTextChanged += CompetitorsEditText_AfterTextChanged;
            arrivalTimeSpinner.ItemSelected += ArrivalTimeSpinner_ItemSelected;
        }

        private void ArrivalTimeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CompetitorsEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DelegatesEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HeadOfDeleEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConfirmArrivalButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}