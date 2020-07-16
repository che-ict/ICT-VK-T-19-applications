using System;
using System.Linq;
using System.Windows.Forms;

namespace TestGalgje
{
    public partial class GalgjeForm : Form
    {
        private Spel Spel { get; }
        private Potje Potje { get; set; }

        public GalgjeForm()
        {
            InitializeComponent();
            Spel = new Spel();
            NieuwPotjeButton_Click(null, null);
        }

        private void NieuwPotjeButton_Click(object sender, EventArgs e)
        {
            Potje = Spel.CreatePotje();
            WerkBordBij();
        }

        private void Kies_Click(object sender, EventArgs e)
        {
            var letter = LetterInvoer.Text.Trim().SingleOrDefault();
            if (!Potje.AddLetter(letter))
            {
                ValidatieMelding.Text = Spel.ValiedatieMelding;
                return;
            }

            WerkBordBij();
        }

        private void WerkBordBij()
        {
            TeKiezenWoord.Text = Potje.ShowWoord();
            DeGalg.Text = VindPlaatje(Potje.AantalMissers+1);
            GoedeLetters.Text = Potje.GoedeLetters;
            FouteLetters.Text = Potje.FouteLetters;
            LetterInvoer.Text = "";
            var status = Potje.CurrentStatus();
            switch (status)
            {
                case Status.Gewonnen:
                    NieuwPotjeButton.Text = Spel.AfgelopenHerstartButtonTekst;
                    ValidatieMelding.Text = Spel.GewonnenMelding;
                    Kies.Visible = false;
                    break;
                case Status.Verloren:
                    NieuwPotjeButton.Text = Spel.AfgelopenHerstartButtonTekst;
                    ValidatieMelding.Text = Spel.VerlorenMelding;
                    Kies.Visible = false;
                    break;
                default:
                    NieuwPotjeButton.Text = Spel.NormaleHerstartButtonTekst;
                    ValidatieMelding.Text = "";
                    Kies.Visible = true;
                    break;
            }    
        }

        private string VindPlaatje(int index)
        {
            switch (index)
            {
                case 0:
                    throw new IndexOutOfRangeException("index loopt van 1 tot 10!");
                case 1:
                    return (string) Spel.Pics["voetstuk"];
                case 2:
                    return (string) Spel.Pics["toplat"];
                case 3:
                    return (string) Spel.Pics["touw"];
                case 4:
                    return (string) Spel.Pics["hoofd"];
                case 5:
                    return (string) Spel.Pics["lijf"];
                case 6:
                    return (string) Spel.Pics["linkerarm"];
                case 7:
                    return (string) Spel.Pics["rechterarm"];
                case 8:
                    return (string) Spel.Pics["linkerbeen"];
                case 10:
                    return (string) Spel.Pics["rechterbeen"];
                default:
                    return (string) Spel.Pics["voetstuk"];
            }
        }
    }
}