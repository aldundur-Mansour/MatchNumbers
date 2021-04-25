using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchNumbers
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        List<string> numbers = new List<string>()
        {
            "1" , "1" , "2" , "2" , "3" ,"3" , "4" , "4",
            "5" , "5" , "6" , "6" ,"7","7", "8" , "8"
        };

        Label firstLabel, secondLabel; 


        public Form1()
        {
            InitializeComponent();
            AssignNumbersTotheBoard();
        }


        private void AssignNumbersTotheBoard()
        {
            Label label;
            int randomNumber; 

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }else
                {
                    continue; 
                }
                randomNumber = random.Next(0, numbers.Count);
                label.Text = numbers[randomNumber];
                numbers.RemoveAt(randomNumber); 
            }
            

        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (firstLabel != null && secondLabel != null)
            {
                return; 
            }
            
            if(clickedLabel == null)
            {
                return;
            }
            if (clickedLabel.ForeColor == Color.White)
            {
                return;
            }
                 
            if (firstLabel == null )
            {
                firstLabel = clickedLabel;
                firstLabel.ForeColor = Color.White;
                return;
            }

            secondLabel = clickedLabel;
            secondLabel.ForeColor = Color.White;
            checkForWinner();

            if ( firstLabel.Text == secondLabel.Text)
            {
                firstLabel = null;
                secondLabel = null;
            } else
            {
                timer1.Start();
            }
            
        }


        private void checkForWinner()
        {
            Label label; 

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label; 
                if(label !=null && label.ForeColor == label.BackColor)
                {
                    return; 
                }
            }
            MessageBox.Show("You win");
            Close(); 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstLabel.ForeColor = firstLabel.BackColor;
            secondLabel.ForeColor = secondLabel.BackColor;

            firstLabel = null;
            secondLabel = null; 

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
