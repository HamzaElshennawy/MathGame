using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using Android.Widget;
using static System.Net.Mime.MediaTypeNames;
using static Android.App.Assist.AssistStructure;
using System.Collections.ObjectModel;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Android.App;
using System.Drawing.Drawing2D;



namespace Math_Game
{
    public partial class MainPage : ContentPage
    {


        List<NumberGenerator> LostNumbers = new List<NumberGenerator>();
        List<NumberGenerator> GeneratedNumbers = new List<NumberGenerator>();
        NumberGenerator numberGenerator = new NumberGenerator();
        Score score = new Score();
        int SelectedIndex;


        [Obsolete]
        public MainPage()
        {
            InitializeComponent();
            GenerateNumbers();
            DisplayNextSetOfNumbers();
            InputTB.Completed += SubmetBTN_Click;
        }

        

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
                    DisplayNextSetOfNumbers();
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
            int result = GeneratedNumbers.ElementAt(SelectedIndex).sum;
            int inputFromUser = int.Parse(InputTB.Text);
            if (inputFromUser == result)
            {
                InputTB.Text = "";
                score.score++;
                ScoreLBL.Text = score.score.ToString();
                Toast.MakeText(Android.App.Application.Context, "Correct", ToastLength.Long).Show();
                numberGenerator.SuccededTimesInARow++;
                return true;
            }
            if(!(score.score == 0))
            {
                score.score--;
            }
            InputTB.Text = "";
            ScoreLBL.Text = score.score.ToString();
            Toast.MakeText(Android.App.Application.Context, "Wrong", ToastLength.Long).Show();
            LostNumbers.Add(numberGenerator);
            numberGenerator.SuccededTimesInARow = 0;
            return false;
        }
        public void GenerateNumbers()
        {
            for(int i = 0;i<50;i++)
            {
                NumberGenerator number = new NumberGenerator();
                if(!GeneratedNumbers.Contains(number))
                {
                    GeneratedNumbers.Add(number); 
                }
            }
        }
        public void DisplayNextSetOfNumbers()
        {
            var random = new Random();
            int RandomIndex = random.Next(0, GeneratedNumbers.Count);
            init(GeneratedNumbers.ElementAt(RandomIndex));
            SelectedIndex = RandomIndex;
        }
    }
}
