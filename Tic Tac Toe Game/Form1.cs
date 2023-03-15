namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {

        public enum Player // Enum je custom tip podatka, da ne bi morali radit sa stringovima ili integerima 
        {
            X, O // Moze bit jedno ili drugo
        }


        Player currentPlayer; // Posto je tip podatka Player mozemo ga kreirat
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;

        List<Button> buttons; // Inicijacija liste dugmadi, a u reset funkciji ih kreira i poziva



        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUMove(object sender, EventArgs e)
        {

            if(buttons.Count > 0) // Recimo ukoliko su kliknuti svi buttoni nije potrebno igrati
            {
                int index = random.Next(buttons.Count); // Biramo random broj izmedju brojaca dugmadi
                buttons[index].Enabled = false;
                currentPlayer = Player.O; // Dodjeljujemo mu da je on O
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor= Color.DarkSalmon;
                buttons.RemoveAt(index); // Znaèi kada je selektiran disablea ga, doda mu O, promijeni boju i izbriše
                CheckGame();
                CPUTimer.Stop();



            }


        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false; // Kada se klikne da se ne može dvaput kliknuti
            button.BackColor = Color.Cyan;
            buttons.Remove(button); // Sklanjamo dugme koje je pritisnuto
            CheckGame();
            CPUTimer.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame(); // Dodijeljivanje funkcije restart dugmetu
            CPUTimer.Stop();

        }

        private void CheckGame()
        {

            // Sada pravimo funkciju koja provjerava igru, ako su odreðena polja odreðenim uzorkom
            // Igra je gotova

            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button5.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {

                CPUTimer.Stop();
                MessageBox.Show("Player wins!", "Congrats!");
                playerWinCount++;
                label1.Text = "Player wins " + playerWinCount;
                RestartGame();

            } else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button5.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU wins!", "Congrats!"); // Pop-up prozor, prvi je text drugi je naslov
                CPUWinCount++;
                label2.Text = "CPU wins " + CPUWinCount;
                RestartGame();

            }




        }

        private void RestartGame()
        {
            buttons = new List<Button> { button2, button1, button3, button5, button4, button6,
                button8, button7, button9 }; // Pozivanje svih buttona, stavljanje u listu i foreach poziva
            
            foreach (Button x in buttons) {

                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}