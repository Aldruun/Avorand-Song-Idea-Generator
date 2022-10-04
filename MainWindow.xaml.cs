using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avorand_Song_Idea_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] list_keys = new string[] { "C", "D", "E", "F", "G", "A", "B", "C#", "Cb", "D#", "Db", "E#", "Eb", "F#", "G#", "Gb", "A#", "Ab", "Bb" };

        private string[] list_rhythms = new string[] { "3/4", "4/4", "5/4", "6/4" };

        private string[] list_moods = new string[]
        {
            "Sad ",
            "Relaxing ",
            "Happy ",
            "Spooky ",
            "Erotic ",
            "Mean ",
            "Triumphant ",
            "Psychodelic ",
            "Heroic ",
            "Sacred "
        };

        private string[] list_styles = new string[]
        {
            "8-bit ",
            //"Emo ",
            "Lo-Fi ",
            "Industrial ",
            "Progressive ",
            "Liquid ",
            "Orchestral ",
            "Melodic ",
            "Country ",
            "Medieval ",
            "Old West ",
            "Post-Apocalyptic "
        };

        private string[] list_genres = new string[]
        {
            "Chillout",
            "Ambience",
            "Downtempo",
            "Hiphop",
            "Dubstep",
            "Dub Techno",
            "Techno",
            "RnB",
            "Pop",
            "Folk",
            //"Hard Rock",
            "DnB"
        };

        private string[] list_instruments = new string[]
        {
            "Accordian",
            "Kalimba",
            "Piano",
            "Electric guitar",
            "Harmonica",
            "80s bass synth",
            "Bass guitar",
            "Vocals",
            "Female Vocals",
            "Male Vocals",
            "Flute",
            "Trumpet",
            "Trombone",
            "Music Box",
            "Acid Bass",
            "Supersaw Arp",
            "Harp",
            "Acoustic Guitar",
            "Sitar",
            "French Horn",
            "Xylophone",
            "Theremin",
            "Banjo",
            "Fender Rhodes",
            "Key Instrument",
            "String Instrument"
            //"Only 1 Synth",
            //"Only 1 Vocal Sample"
        };


        //private string[] list_keys_sharpsflats = new string[] { "C#", "Cb", "D#", "Db", "E#", "Eb", "F#", "G#", "Gb", "A#", "Ab", "Bb" };
        private bool inMinor;

        public MainWindow()
        {
            InitializeComponent();

            btn_generate.Click += GenerateRandomSongIdea;
        }

        private void GenerateRandomSongIdea(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int rndVal = 0;

            if(checkbox_genre.IsChecked == true)
            {
                rndVal = random.Next(0, list_genres.Length);
                lbl_genre.Content = list_genres[rndVal];
            }
            else
            {
                lbl_genre.Content = null;
            }

            if(checkbox_key.IsChecked == true)
            {
                rndVal = random.Next(0, list_keys.Length);
                lbl_key.Content = list_keys[rndVal];
            }
            else
            {
                lbl_key.Content = null;
            }

            if(checkbox_mood.IsChecked == true)
            {
                rndVal = random.Next(0, list_moods.Length);
                lbl_mood.Content = list_moods[rndVal];
            }
            else
            {
                lbl_mood.Content = null;
            }

            if(checkbox_style.IsChecked == true)
            {
                rndVal = random.Next(0, list_styles.Length);
                lbl_style.Content = list_styles[rndVal];
            }
            else
            {
                lbl_style.Content = null;
            }

            if(checkbox_instrument.IsChecked == true)
            {
                rndVal = random.Next(0, list_instruments.Length);
                lbl_instrument.Content = list_instruments[rndVal];
            }
            else
            {
                lbl_instrument.Content = null;
            }

            if(checkbox_rhythm.IsChecked == true)
            {
                rndVal = random.Next(0, list_rhythms.Length);
                lbl_rhythm.Content = list_rhythms[rndVal];
            }
            else
            {
                lbl_rhythm.Content = null;
            }

            if(checkbox_bpm.IsChecked == true)
            {
                rndVal = random.Next(80, 160);
                lbl_bpm.Content = rndVal;
            }
            else
            {
                lbl_bpm.Content = null;
            }

            if(checkbox_minor.IsChecked == true)
            {

                inMinor = random.NextDouble() >= 0.5;

                lbl_minor.Content = inMinor ? "Yes" : "No";
            }
            else
            {
                inMinor = false;
                lbl_minor.Content = null;
            }

            CreateSummary();
        }

        private void CreateSummary()
        {
            textblock_summary.Text = $"Create some " +
                $"{(lbl_mood.Content != null ? lbl_mood.Content : "")}" +
                $"{(lbl_style.Content != null ? lbl_style.Content : "")}" +
                $"{(lbl_genre.Content != null ? lbl_genre.Content : "")}" +
                $"{(lbl_key.Content != null ? " in the key of " + lbl_key.Content : "")}" +
                $"{((lbl_minor.Content != null && inMinor) ? " minor" : "")}" +
                $"{(lbl_bpm.Content != null ? " at " + lbl_bpm.Content : "")} BPM" +
                $"{((lbl_rhythm.Content != null) ? " in the " + lbl_rhythm.Content + " time signature" : "")}." +
                $"{(lbl_instrument.Content != null ? " Make sure to add a good portion of " + lbl_instrument.Content + " to the mix." : "")}";
        }
    }
}
