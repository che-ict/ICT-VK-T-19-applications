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
            var letter = LetterInvoer.Text.SingleOrDefault();
            if (!Potje.AddLetter(letter))
            {
                ValidatieMelding.Text = Spel.ValiedatieMelding;
                return;
            }

            WerkBordBij();
        }

        private void WerkBordBij()
        {
            TeKiezenWoord.Text = Potje.ToonWoord();
            DeGalg.Text = Spel.Plaatjes[Potje.AantalMissers];
            GoedeLetters.Text = Potje.GoedeLetters;
            FouteLetters.Text = Potje.FouteLetters;
            LetterInvoer.Text = "";
            var status = Potje.HuidigeStatus();
            switch (status)
            {
                case Status.Gewonnen:
                    NieuwPotjeButton.Text = Spel.AfgelopenHerstartButtonTekst;
                    ValidatieMelding.Text = Spel.VerlorenMelding;
                    Kies.Visible = false;
                    break;
                case Status.Verloren:
                    NieuwPotjeButton.Text = Spel.AfgelopenHerstartButtonTekst;
                    ValidatieMelding.Text = Spel.VerlorenMelding;
                    Kies.Visible = true;
                    break;
                default:
                    NieuwPotjeButton.Text = Spel.NormaleHerstartButtonTekst;
                    ValidatieMelding.Text = "";
                    Kies.Visible = true;
                    break;
            }    
        }
    }
}