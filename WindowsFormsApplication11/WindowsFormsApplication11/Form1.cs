using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication11
{
     
    public partial class Form1 : Form
    {
        public List<Word> words ;
        TextBox [,] t;
        XmlTextReader reader ;
        Label[] lables;
        Label[] quest;
        Word w;
        Panel panel;
        ComboBox comboBox1;
        PictureBox pb;
        bool win = true;
        string[] pictures;
        bool check ;
        bool checkcombo = false;
        public Form1()
        {
            //this.Text = "para Esperanzita =)";
            check = false;
            words = new List<Word>();
            w = new Word(words);
            ListBox listBox1 = new ListBox();
            InitializeComponent();
            panel = new Panel();
            //panel.BackgroundImage = Image.FromFile(@"D:/map.jpg");
            //panel.BackgroundImageLayout = ImageLayout.Stretch;
            panel.Size = new Size(450, 450);
            panel.Location = new Point(10, 10);
            
            this.Controls.Add(panel);
           
        }
      
        public int Max()
        {
            int max = words[0].L;
            for (int i = 0; i < words.Count; i++)
            {
                if (max < words[i].L)
                    max = words[i].L;
            }
            return max+1;
        }
        public void Create(int max, string image, XmlTextReader reader, bool isKids)
        {
            check = true;
            if (checkcombo == false)
            {
                if (isKids == true)
                {
                    checkcombo = true;
                    int ind = 0;
                    pictures = new string[] { "g.jpg", "r.jpg", "e.jpg", "l.jpg", "sh.jpg", "k.jpg" };
                    pb = new PictureBox();
                    pb.Size = new Size(150, 180);

                    pb.Location = new Point(485, 250);
                    this.Controls.Add(pb);
                    comboBox1 = new ComboBox();
                    comboBox1.Size = new Size(80, 17);
                    comboBox1.Text = "1";
                    comboBox1.Location = new Point(640, 260);
                    this.Controls.Add(comboBox1);
                    pb.ImageLocation = pictures[ind];
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    comboBox1.Items.Add("1");
                    comboBox1.Items.Add("2");
                    comboBox1.Items.Add("3");
                    comboBox1.Items.Add("4");
                    comboBox1.Items.Add("5");
                    comboBox1.Items.Add("6");
                    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                }
            }
            else
            {
                comboBox1.Visible = true;
                pb.Visible = true;
            }
            //else
            //{
               
            //    comboBox1.Visible = false;
            //    pb.Visible = false;

            //}
                panel.BackgroundImage = Image.FromFile(image);
                panel.BackgroundImageLayout = ImageLayout.Stretch;

                w.WordRead(reader);
                t = new TextBox[25, 25];
                lables = new Label[words.Count];
           
            int x=0, y = 0;
            string tmp;
            bool ch=true;
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    t[i, j] = new TextBox();
                    t[i, j].Font = new Font("New Romans", 9F);
                    t[i, j].Location = new Point(i * 21+25, j * 21+25);
                    t[i, j].Size = new Size(20, 20);
                    t[i, j].Visible = false;
                    panel.Controls.Add(t[i, j]);
                    t[i, j].TextChanged +=Form1_TextChanged;
                }
            }
            
           
            lables = new Label[words.Count];
            quest = new Label[words.Count];
            Label across = new Label();
            across.Text = "ACROSS";
            across.Size = new Size(70, 20);
            across.Location = new Point(40, panel.Size.Height + 20 );
            this.Controls.Add(across);
            Label down = new Label();
            down.Text = "DOWN";
            down.Size = new Size(70, 20);
            down.Location = new Point(200, panel.Size.Height + 20);
            this.Controls.Add(down);
            int h = 1,hh=1;

                    for (int k = 0; k < words.Count; k++)
                    {
                       
                        if (words[k].IsVertical == true)
                        {
                          
                            x=words[k].X-1;
                            y = words[k].Y-1;
                            tmp = words[k].Wrd;

                            lables[k] = new Label();
                            lables[k].Text = words[k].Num+"";
                            lables[k].Size = new Size(20, 15);
                            lables[k].Location = new Point(t[x, y].Location.X, t[x, y].Location.Y - 15);
                            panel.Controls.Add(lables[k]);
                            quest[k] = new Label();
                            if(words[k].Q!="")
                            quest[k].Text = words[k].Num  + "  " + words[k].Q;
                            quest[k].Size = new Size(200, 20);
                            quest[k].Location = new Point(150, panel.Size.Height + 30 + 20 * hh);
                            hh++;
                            this.Controls.Add(quest[k]);
                            for (int l = 0; l < words[k].L; l++)
                            {
                                t[x, y++].Visible = true;
                            }
                        }
                        
                        if (words[k].IsVertical == false)
                        {
                            x = words[k].X-1;
                            y = words[k].Y-1;
                            tmp = words[k].Wrd;
                            lables[k] = new Label();
                            lables[k].Text = words[k].Num + "";
                            lables[k].Size = new Size(25, 15);
                            lables[k].Location = new Point(t[x, y].Location.X - 15, t[x, y].Location.Y );
                            panel.Controls.Add(lables[k]);

                            quest[k] = new Label();
                            if (words[k].Q != "")
                            quest[k].Text = words[k].Num + "  "+words[k].Q;
                            quest[k].Size = new Size(200, 20);
                            quest[k].Location = new Point(20, panel.Size.Height +30+ 20*h);
                            h++;
                            this.Controls.Add(quest[k]);
                            for (int l = 0; l < words[k].L; l++)
                            {
                                t[x++, y].Visible = true;
                               
                            }
                        }

                    }
                    
                        }

        public void Hider()
        {
            words.Clear();
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    this.Controls.Remove(t[i,j]);
                    t[i, j].Visible = false;
                }
            }
            for (int i = 0; i < lables.Count(); i++)
            {
                lables[i].Text = "";
                lables[i].Size = new Size(0, 0);
            }
            for (int i = 0; i < quest.Count(); i++)
            {
                quest[i].Text = "";
                quest[i].Size = new Size(0, 0);
            }
            int x = 0, y = 0;
            string tmp;
            for (int k = 0; k < words.Count; k++)
            {
                if (words[k].IsVertical == true)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        t[x, y].Text = "";
                        y++;
                    }
                }
                if (words[k].IsVertical == false)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        t[x, y].Text = "";
                        x++;
                    }
                }
            }
        }
        public void New()
        {

            int x = 0, y = 0;
            string tmp;
            for (int k = 0; k < words.Count; k++)
            {
                if (words[k].IsVertical == true)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        t[x, y].Text = "";
                        t[x, y].BackColor = Color.White;
                        y++;
                    }
                }
                if (words[k].IsVertical == false)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        t[x, y].Text = "";
                        t[x, y].BackColor = Color.White;
                        x++;
                    }
                }
            }
        }
        public void Checked()
        {
            int x = 0, y = 0;
            string tmp;
            for (int k = 0; k < words.Count; k++)
            {
                if (words[k].IsVertical == true)
                {
                    x = words[k].X-1;
                    y = words[k].Y-1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                       // if  (tmp.Substring(l + 1, 1).Contains(t[x, y].Text) == true)
                            if (t[x, y].Text == tmp.Substring(l+1,1))
                            {
                                t[x, y].BackColor = Color.Green;
                            }
                            else t[x, y].BackColor = Color.Red;
                            y++;
                    }
                }
                if (words[k].IsVertical == false)
                {
                    x = words[k].X-1;
                    y = words[k].Y-1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        //if (tmp.Substring(l + 1, 1).Contains(t[x, y].Text) == true)
                            if (t[x, y].Text == tmp.Substring(l+1,1))
                            {
                                t[x, y].BackColor = Color.Green;
                            }
                            else t[x, y].BackColor = Color.Red;
                            x++;
                    }
                }
            }

        }
       
        public void CheckedWord()
        {
            int x = 0, y = 0;
            string tmp;
            bool ch = true;
            for (int k = 0; k < words.Count; k++)
            {
                ch = true;
                if (words[k].IsVertical == true)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        //if (tmp.Substring(l + 1, 1).Contains(t[x, y].Text) == true)
                       if (t[x, y].Text == tmp.Substring(l + 1, 1))
                        {
                            ch = true;
                            
                        }
                        else
                        {
                            ch = false;
                        }
                        if (ch == false)
                            break;
                        y++;
                    }
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    if (ch != true)
                    {
                        
                        for (int l = 0; l < words[k].L; l++)
                        {
                            t[x, y].BackColor = Color.Red;
                            y++;
                        }
                    }
                    else
                    {
                        for (int l = 0; l < words[k].L; l++)
                        {
                            t[x, y].BackColor = Color.Green;
                            y++;
                        }
                    }
                }
                if (words[k].IsVertical == false)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                        //if (tmp.Substring(l + 1, 1).Contains(t[x, y].Text) == true)
                   if (t[x, y].Text == tmp.Substring(l + 1, 1))
                        {
                            ch = true;
                        }
                        else
                        {
                            ch = false;
                        }
                        if (ch == false)
                            break;
                          x++;;
                    }
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    if (ch != true)
                    {
                        
                        for (int l = 0; l < words[k].L; l++)
                        {
                            t[x, y].BackColor = Color.Red;
                              x++;
                        }
                    }
                    else
                    {
                        for (int l = 0; l < words[k].L; l++)
                        {
                            t[x, y].BackColor = Color.Green;
                             x++;
                        }
                    }
                }
            }

        }
        public void Winner()
        {
            int x = 0, y = 0;
            string tmp;
            win = true;
            for (int k = 0; k < words.Count; k++)
            {
                win = true;
                if (words[k].IsVertical == true)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                   
                        for (int l = 0; l < words[k].L; l++)
                        {
                            if(t[x, y++].BackColor == Color.Red)
                           win=false;
                        }
                   
                   
                }
                if (words[k].IsVertical == false)
                {
                    x = words[k].X - 1;
                    y = words[k].Y - 1;
                    tmp = words[k].Wrd;
                   
                        for (int l = 0; l < words[k].L; l++)
                        {
                            if (t[x++, y].BackColor == Color.Red)
                            win=false;
                        }
                }

            }
            if (win == true)
                MessageBox.Show("Congratilations!!!=)");
            else MessageBox.Show("Don`t worry");
        }

        public void Answer()
        {
            int x = 0, y = 0;
            string tmp;
            for (int k = 0; k < words.Count; k++)
            {
                if (words[k].IsVertical == true)
                {
                    x = words[k].X-1;
                    y = words[k].Y-1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                           t[x, y].Text = tmp.Substring(l+1,1);
                           t[x, y].BackColor = Color.White;
                            y++;
                    }
                }
                if (words[k].IsVertical == false)
                {
                    x = words[k].X-1;
                    y = words[k].Y-1;
                    tmp = words[k].Wrd;
                    for (int l = 0; l < words[k].L; l++)
                    {
                           t[x, y].Text = tmp.Substring(l+1,1);
                           t[x, y].BackColor = Color.White;
                            x++;
                    }
                }
            }

        }


        private void Form1_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;

            if (textbox.Text.Length == 2)
                textbox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                Checked();
            else CheckedWord();
            Winner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hider();
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
             button4.Enabled = true;
            Invalidate();
            XmlTextReader reader = new XmlTextReader("words.xml");
            XmlTextReader reader2 = new XmlTextReader("anim.xml");
            string im = "map.jpg";
            string im2 = "anim.jpg";
            if (radioButton3.Checked == true)
            {
                Create(10, im2, reader2, true);
                label1.Visible = true;
                label1.Text = "Animals";
            }
            if (radioButton4.Checked == true)
            {
                Create(17, im, reader, false);
                label1.Visible = true;
                label1.Text = "Countries/Capitals";
            }
            New();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (check == true)
            {
                Hider();
            }
            Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            pb.ImageLocation = pictures[comboBox1.SelectedIndex];
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                Answer();
            else New();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (check == true)
            {
                Hider();
            }
            Invalidate();
        }

                }
        }

