using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication11
{
    public class Word
    {
        int x;
        int y;
        int l;
        bool isVertical;
        string wrd;
        string question;
        int number;
        List<Word> list;
        public Word()
        {
          x=0;
           y=0;
           l=0;
           wrd = null;
           question = null;
           number = 0;
            isVertical=true;
        }
        public Word(List<Word> l)
        {
            list = l;
           
        }
       public int L
        {
            get { return l; }
        }
       public int X
       {
           get { return x; }
       }
       public int Y
       {
           get { return y; }
       }
       public bool IsVertical
       {
           get { return isVertical; }
       }
       public string Wrd
       {
           get { return wrd; }
       }
       public string Q
       {
           get { return question; }
       }
       public int Num
       {
           get { return number; }
       }
      
        public void WordRead(XmlTextReader reader)
        {
            Word wrd = new Word();

            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {

                        case "x":
                            reader.Read();
                            wrd.x = Convert.ToInt32(reader.Value);
                            break;
                        case "y":
                            reader.Read();
                            wrd.y = Convert.ToInt32(reader.Value);
                            break;
                        case "l":
                            reader.Read();
                            wrd.l = Convert.ToInt32(reader.Value);
                            break;
                        case "isVertical":
                            reader.Read();
                            wrd.isVertical = Convert.ToBoolean(reader.Value);
                           
                            break;
                        case "wrd":
                            reader.Read();
                            wrd.wrd = reader.Value;
                           //  list.Add(wrd);
                           //// listBox1.Items.Add(wrd);
                           // wrd = new Word();
                            break;
                        case "question":
                            reader.Read();
                            wrd.question = Convert.ToString(reader.Value);
                            break;
                        case "number":
                            reader.Read();
                            wrd.number = Convert.ToInt32(reader.Value);
                             list.Add(wrd);
                           // listBox1.Items.Add(wrd);
                            wrd = new Word();
                            break;
                    }

                }
            }
            reader.Close();
        }

    }
}
