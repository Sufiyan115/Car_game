using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int score, speed;
       

        //declaring array to store objects
        PictureBox[] road = new PictureBox[8];
        private void Form1_Load(object sender, EventArgs e)
        {
            speed = 2;
            score = 0;
            //form size
            this.Width = 240;
            this.Height = 400;

            this.Text = "Car Race";

            //disabling maximize / minimize box
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //MinimumSize.Width = 240;
            //MinimumSize.Height = 240;

            //gameover label
            this.label1.BackColor = Color.White;
            this.label1.ForeColor = Color.Red;
            this.label1.Text = "Game Over";
            this.label1.Visible = false;
            this.label1.Font = new Font(label1.Font.FontFamily, 16,FontStyle.Bold);

            //score label1
            this.label2.Text = "Score: 0";
            this.label2.ForeColor = Color.White;
            this.label2.Font = new Font(label2.Font.FontFamily, 10, FontStyle.Bold);

            //speed label
            this.label4.Text = "Speed: " + speed;
            this.label4.ForeColor = Color.White;
            this.label4.Font = new Font(label4.Font.FontFamily, 10, FontStyle.Bold);


            //about label
            this.label3.Text = "Developed By: M.Sufiyan";
            
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.Font = new Font("Times", 10, FontStyle.Bold);
            this.label3.ForeColor = Color.Black;
            this.label3.Visible = false;

            //replay button
            this.button1.Text = "Replay";
            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.DarkBlue;
            this.button1.Visible = false;
            this.button1.Font = new Font(button1.Font.FontFamily, 10);

            //Quit game button
            this.button2.Text = "Quit Game";
            this.button2.ForeColor = Color.White;
            this.button2.BackColor = Color.Red;
            this.button2.Visible = false;
            this.button2.Font = new Font(button2.Font.FontFamily, 10);

            //color
            this.BackColor = Color.DarkGray;
            this.pictureBox1.BackColor = Color.White;
            this.pictureBox2.BackColor = Color.White;
            this.pictureBox3.BackColor = Color.White;
            this.pictureBox4.BackColor = Color.White;
            this.pictureBox5.BackColor = Color.White;
            this.pictureBox6.BackColor = Color.White;
            this.pictureBox7.BackColor = Color.White;
            this.pictureBox8.BackColor = Color.White;

            //road timer
            this.timer1.Interval=10;
            this.timer1.Enabled = true;

            //rightkey press timer
            this.timer2.Interval = 10;
            this.timer2.Enabled = false;

            //left key press timer
            this.timer3.Interval = 10;
            this.timer3.Enabled = false;

            //enemy car 1 timer
            this.car2_mover.Interval = 10;
            this.car2_mover.Enabled = true;

            //enemy car 2 timer
            this.car3_mover.Interval = 10;
            this.car3_mover.Enabled = true;

            //enemy car 3 timer
            this.car4_mover.Interval = 10;
            this.car4_mover.Enabled = true;

            this.AcceptButton = button1;
            this.CancelButton = button2;
            //assigning roadstraps into array
            road[0] = pictureBox1;
            road[1] = pictureBox2;
            road[2] = pictureBox3;
            road[3] = pictureBox4;
            road[4] = pictureBox5;
            road[5] = pictureBox6;
            road[6] = pictureBox7;
            road[7] = pictureBox8;

         }

        //moving road
        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int x = 0; x <= 7; x++)
            {
                road[x].Top += speed;

                //for repating road movement
                if (road[x].Top>=this.Height)
                {
                    road[x].Top = -road[x].Height;
                }
              
            }
            if (pictureBox9.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                gameover();
            }
            if (pictureBox9.Bounds.IntersectsWith(pictureBox11.Bounds))
            {
                gameover();
            }
            if (pictureBox9.Bounds.IntersectsWith(pictureBox12.Bounds))
            {
                gameover();
            }
            //increasing speed
            if(score>10 && score<20)
            {
                speed = 3;
                this.label4.Text = "Speed: " + speed;
            }
            if (score > 20 && score < 30)
            {
                speed = 4;
                this.label4.Text = "Speed: " + speed;
            }
            if (score > 30)
            {
                speed = 5;
                this.label4.Text = "Speed: " + speed;
            }
        }
        private void gameover()
        {
            this.label1.Visible = true;
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.timer1.Stop();
            this.label3.Visible = true;

            this.label2.ForeColor = Color.Yellow;
            
            this.car2_mover.Stop();
            this.car3_mover.Stop();
            this.car4_mover.Stop();
        }
        private void increseSpeed()
        {
            score += 1;
            label2.Text = "Score: " + score;
        }
 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //starting timer when user press right key
            if (e.KeyCode == Keys.Right)
            {
                timer2.Start();
            }

            //starting timer when user press left key
            if (e.KeyCode == Keys.Left)

            {
                timer3.Start();
            }
        }

        //moving player car to right on timer start
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(pictureBox9.Location.X<182)
            pictureBox9.Left += 5;
        }

        //moving player car to left on timer start
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox9.Location.X >5)
                pictureBox9.Left -= 5;

        }

        //stoping timer when user release right/left key
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
        }


        public  Random r = new Random();
        //moving enemy car 1
        private void car2_mover_Tick(object sender, EventArgs e)
        {
            pictureBox10.Top += speed * 3 / 2;

            //repeting when car cross the form (YELLOW CAR)
            if(pictureBox10.Top>=this.Height)
            {
                //    int x = r.Next(0, 240);
                //  int y = r.Next(0, 400);
                

                //increasing score when enemy car crosses the form every time , with the help on funtion
                increseSpeed();
                //moving car on random position 
                pictureBox10.Location = new Point((int)(new Random().Next(3,60)), -100);


                //pictureBox10.Top = -(y + pictureBox10.Height) * -1;
                //pictureBox10.Left = -(x * 240) + pictureBox10.Height;
               // pictureBox10.Top = -(new Random().Next(0,150)+pictureBox10.Height);
                //pictureBox10.Left = -(new Random().Next(0, 240));
                //pictureBox10.Top = ((int.Parse(Math.Ceiling(Random(1,240)) + pictureBox10.Height)* -1);
            }
        }

        //moving enemy car 2 (RED CAR)
        private void car3_mover_Tick(object sender, EventArgs e)
        {
            pictureBox11.Top += speed * 5 / 3;


            //repeting when car cross the form
            if (pictureBox11.Top >= this.Height)
            {
                increseSpeed();
                pictureBox11.Location = new Point((int)(new Random().Next(63, 127)), -100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //moving enemy car 3 (green car)
        private void car4_mover_Tick(object sender, EventArgs e)
        {
            pictureBox12.Top += speed * 3 / 2;

            //repeting when car cross the form
            if (pictureBox12.Top >= this.Height)
            {
                //increseSpeed();
                pictureBox12.Location = new Point((int)(new Random().Next(130, 190)), -100);
            }
        }
    }
}
