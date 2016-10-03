using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
namespace ElivThade
{
    public partial class Form1 : Form
    {
          public BoardNetwork Board;
          //bool gamePlaying = true;
          bool Solved = false;
          string input = " ";
          string original;
          Node currentSpot;

          int Space=0;
          string difficulty;  

          

        public Form1()
        {
           InitializeComponent();
           MaximizeBox = false;
           FormBorderStyle = FormBorderStyle.FixedDialog;
           Board   = new BoardNetwork();


           
           currentSpot = Board.Start;    // node current spot is going to be used to move the character
           Point tempPoint = new Point(currentSpot.LocX, currentSpot.LocY);
           pictureBox1.Location = tempPoint;

            pictureBox5.BackgroundImage = null;   // 4 key items for the game are null till acquired
            pictureBox6.BackgroundImage = null;
            pictureBox7.BackgroundImage = null;
            pictureBox8.BackgroundImage = null;

            System.Media.SoundPlayer creepy = new System.Media.SoundPlayer("Music.wav");
            creepy.PlayLooping();
            textBox1.Text = "";
            MessageBox.Show("Welcome to Eliv Thade, Get through all 4 rooms to get the keys to unlock the cellar. Move your character by selecting a question difficulty and then unscrambling the word");

        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Main picture box
        
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

           // pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
           // pictureBox9.Load("images.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Button Up
           if(currentSpot.Up != null)
                {
                      questionSolve();
                      if (Solved && Space == 0)
                    {
                        evaluateSpace();
                    Point tempPointUp = new Point(currentSpot.Up.LocX, currentSpot.Up.LocY);
                    pictureBox1.Location = tempPointUp;
                    currentSpot = currentSpot.Up;
                    CheckForKeyItem();
                    Solved = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    Space--;
                    }
                    else if (Space > 0)
                    {
                        Point tempPointUp = new Point(currentSpot.Up.LocX, currentSpot.Up.LocY);
                        pictureBox1.Location = tempPointUp;
                        currentSpot = currentSpot.Up;
                        CheckForKeyItem();
                        Space--;
                    }
                    else
                    {                   
                        Lose();
                    }
                }
                else
                {
                    MessageBox.Show("That is not a valid walk path");
                }
            }
           
        private void button2_Click(object sender, EventArgs e)
        {
            //Button Down
           // pictureBox5.BackgroundImage = ElivThade.Properties.Resources.Room1;
            
                if (currentSpot.Down != null)
                {
                      questionSolve();
                      if (Solved && Space == 0)
                      {
                          evaluateSpace();
                          Point tempPointDown = new Point(currentSpot.Down.LocX, currentSpot.Down.LocY);
                          pictureBox1.Location = tempPointDown;
                          currentSpot = currentSpot.Down;
                          CheckForKeyItem();
                          Solved = false;
                          textBox1.Clear();
                          textBox2.Clear();
                          Space--;
                      }
                      else if (Space > 0)
                      {
                          Point tempPointDown = new Point(currentSpot.Down.LocX, currentSpot.Down.LocY);
                          pictureBox1.Location = tempPointDown;
                          currentSpot = currentSpot.Down;
                          CheckForKeyItem();
                          Space--;
                      }
                      else
                      {
                          Lose();
                      }
                }
                else
                {
                    MessageBox.Show("That is not a valid walk path");
                }
            }
          
        private void button3_Click(object sender, EventArgs e)
        {
            // Button Left
        
                if (currentSpot.Left != null)
                {
                       questionSolve();
                  if (Solved && Space == 0)
                    {
                        evaluateSpace();
                    Point tempPointLeft = new Point(currentSpot.Left.LocX, currentSpot.Left.LocY);
                    pictureBox1.Location = tempPointLeft;
                    currentSpot = currentSpot.Left;
                    CheckForKeyItem();
                    Solved = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    Space--;
                       }
                    else if (Space > 0)
                    {
                        Point tempPointLeft = new Point(currentSpot.Left.LocX, currentSpot.Left.LocY);
                        pictureBox1.Location = tempPointLeft;
                        currentSpot = currentSpot.Left;
                        CheckForKeyItem();
                        Space--;
                    }
                    else
                    {                    
                        Lose();
                    }                 
                }
                else
                {
                    MessageBox.Show("That is not a valid walk path");
                }
            }
           
        private void button4_Click(object sender, EventArgs e)
        {
            //Button Right
           
                if (currentSpot.Right != null)
                {
                    questionSolve();
                    if (Solved && Space==0)
                    {
                        evaluateSpace();
                        Point tempPointRight = new Point(currentSpot.Right.LocX, currentSpot.Right.LocY);
                        pictureBox1.Location = tempPointRight;
                        currentSpot = currentSpot.Right;
                        CheckForKeyItem();
                        Solved = false;
                        textBox1.Clear();
                        textBox2.Clear();
                        Space--;
                    }
                    else if(Space>0)
                    {
                        Point tempPointRight = new Point(currentSpot.Right.LocX, currentSpot.Right.LocY);
                        pictureBox1.Location = tempPointRight;
                        currentSpot = currentSpot.Right;
                        CheckForKeyItem();
                        Space--;
                    }
                    else
                    {                  
                        Lose();
                    }                
                }

                else
                {
                    MessageBox.Show("That is not a valid walk path");
                }
            }
           

        void CheckForKeyItem()
        {
         if(currentSpot==Board.Room1)
         {
             pictureBox5.BackgroundImage = ElivThade.Properties.Resources.Room1;
         }
         if (currentSpot == Board.Room2)
         {
             pictureBox6.BackgroundImage = ElivThade.Properties.Resources.Room2;
         }
         if (currentSpot == Board.Room3)
         {
             pictureBox7.BackgroundImage = ElivThade.Properties.Resources.Room3;
         }
         if (currentSpot == Board.Room4)
         {
             pictureBox8.BackgroundImage = ElivThade.Properties.Resources.Room4;
         }
         if (currentSpot == Board.tail && pictureBox5.BackgroundImage != null && pictureBox6.BackgroundImage != null && pictureBox7.BackgroundImage != null && pictureBox8.BackgroundImage != null  )
         {
             MessageBox.Show("You Win!");
             Close();
         }
        }

        void questionSpawn(string text)
        {
            try
            {
                Random numReader = new Random();
                using (StreamReader sr = new StreamReader(text))
                {
                    String line = sr.ReadToEnd();
                    string[] questions = line.Split(',');

                    int arrNum = numReader.Next(0, questions.Length);
                    


                    // The source string
                    original = questions[arrNum];

                    // The random number sequence
                    Random num = new Random();

                    // Create new string from the reordered char array
                    string rand = new string(original.ToCharArray().
                        OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
                    if (rand == original)
                    {
                        questionSpawn(text);
                    }

                    else
                    {
                        // Write results
                        TextInfo example = new CultureInfo("en-US", false).TextInfo;
                        textBox1.Text = myTI.ToTitleCase(rand);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        void questionSolve()
        {
            input = textBox2.Text;


            if (input == original)
            {
                Solved = true;
            }
            else
            {
                Solved = false;
            }
        }

        void Lose()
        {
            //starts with picturebox4
            if (pictureBox4.BackgroundImage != null && pictureBox3.BackgroundImage != null && pictureBox2.BackgroundImage != null && textBox1.Text != string.Empty)
            {
                MessageBox.Show("You were wrong");
                pictureBox4.BackgroundImage = null;
            }
            else if (pictureBox4.BackgroundImage == null && pictureBox3.BackgroundImage != null && pictureBox2.BackgroundImage != null && textBox1.Text != string.Empty)
            {
                MessageBox.Show("You were wrong");
                pictureBox3.BackgroundImage = null;
            }
            else if (pictureBox4.BackgroundImage == null && pictureBox3.BackgroundImage == null && pictureBox2.BackgroundImage != null && textBox1.Text != string.Empty)
            {
                pictureBox2.BackgroundImage = null;

                MessageBox.Show("GAME OVER");
                Close();
            }
            else
            {
                MessageBox.Show("Please choose a question difficulty");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //easy
            if (textBox1.Text == string.Empty && Space == 0)
            {
                difficulty = "textFile.txt";
                questionSpawn(difficulty);
                
            }
            else
            {
                MessageBox.Show("Answer the question you fool");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //normal
            if (textBox1.Text == string.Empty && Space == 0)
            {
                difficulty = "textFile2.txt";
                questionSpawn(difficulty);
                
            }
            else
            {
                MessageBox.Show("Answer the question you fool");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //hard
            if (textBox1.Text == string.Empty && Space == 0)
            {
                difficulty = "textFile3.txt";
                questionSpawn(difficulty);
               
            }
            else
            {
                MessageBox.Show("Answer the question you fool");
            }
        }

        void evaluateSpace()
        {
            if (difficulty == "textFile.txt")
            {
                Space = 1;
            }
            else if (difficulty == "textFile2.txt")
            {
                Space = 2;
            }
            else if (difficulty == "textFile3.txt")
            {
                Space = 3;
            }
        }
    }
}


