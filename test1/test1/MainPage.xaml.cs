using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using Android.Widget;

namespace Math_Game
{
    public partial class MainPage : ContentPage
    {
        NumberGenerator numberGenerator = new NumberGenerator();
        Score score = new Score();
        public MainPage()
        {
            InitializeComponent();
            init(numberGenerator);
            CorrectLBL.IsVisible = false;
            InputTB.Completed += SubmetBTN_Click;
        }

        List<NumberGenerator> LostNumbers = new List<NumberGenerator>();

        private void SubmetBTN_Click(object sender, EventArgs e)
        {
            try
            {
                bool Correct = false;
                Correct = CheckAnswer();
                if (!Correct)
                {
                    LostNumbers.Add(numberGenerator);
                }
                else
                {
                    numberGenerator = new NumberGenerator();
                    init(numberGenerator);
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Android.App.Application.Context, "Wrong input", ToastLength.Long).Show();
            }
        }
        public void init(NumberGenerator number)
        {
            FirstNumberTB.Text = number.first.ToString();
            SecondNumberTB.Text = number.second.ToString();
        }

        public bool CheckAnswer()
        {
            int result = numberGenerator.sum;
            int inputFromUser = int.Parse(InputTB.Text);
            if (inputFromUser == result)
            {
                InputTB.Text="";
                score.score++;
                ScoreLBL.Text = score.score.ToString();
                Toast.MakeText(Android.App.Application.Context, "Correct", ToastLength.Long).Show();
                return true;
            }
            score.score--;
            CorrectLBL.Text = "Wrong!!";
            InputTB.Text = "";
            ScoreLBL.Text = score.score.ToString();
            Toast.MakeText(Android.App.Application.Context, "Wrong", ToastLength.Long).Show();
            return false;
        }
    }
}
