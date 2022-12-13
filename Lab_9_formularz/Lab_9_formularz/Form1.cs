using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;

namespace Lab_9_formularz
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
            
        }
        public class Info
        {
            public string kpd { get; set; }
            public string kierunek { get; set; }
            public string studiawzakresie { get; set; }
            public string profilstudiow { get; set; }
            public string formastudiow { get; set; }
            public string poziomstudiow { get; set; }
            public string student1 { get; set; }
            public string indeks1 { get; set; }
            public string data1 { get; set; }
            public string student2 { get; set; }
            public string indeks2 { get; set; }
            public string data2 { get; set; }
            public string student3 { get; set; }
            public string indeks3 { get; set; }
            public string data3 { get; set; }
            public string student4 { get; set; }
            public string indeks4 { get; set; }
            public string data4 { get; set; }
            public string tytulpracy { get; set; }
            public string angielskitytul { get; set; }
            public string danewejsciowe { get; set; }
            public string zakrespracy { get; set; }
            public string promotor { get; set; }
            public string jednostkaorganizacyjna { get; set; }
            public string terminoddania { get; set; }
            public string datazatwierdzenia { get; set; }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.kpd = diploma_name.Text;
            info.kierunek= maskedTextBox1.Text;
            info.studiawzakresie = maskedTextBox2.Text;
            info.profilstudiow = comboBox1.Text;
            info.formastudiow= comboBox2.Text;
            info.poziomstudiow= comboBox3.Text;
            info.student1= maskedTextBox3.Text;
            info.student2= maskedTextBox4.Text;
            info.student3= maskedTextBox5.Text;
            info.student4= maskedTextBox6.Text;
            info.indeks1= maskedTextBox7.Text;
            info.indeks2= maskedTextBox8.Text;
            info.indeks3= maskedTextBox9.Text;
            info.indeks4= maskedTextBox10.Text;
            info.data1= maskedTextBox11.Text;
            info.data2= maskedTextBox12.Text;
            info.data3= maskedTextBox13.Text;
            info.data4= maskedTextBox14.Text;
            info.tytulpracy= maskedTextBox15.Text;
            info.angielskitytul= maskedTextBox16.Text;
            info.danewejsciowe= maskedTextBox17.Text;
            info.zakrespracy= maskedTextBox18.Text;
            info.promotor=maskedTextBox20.Text; 
            info.jednostkaorganizacyjna= maskedTextBox21.Text;
            info.terminoddania = maskedTextBox23.Text;
            info.datazatwierdzenia = maskedTextBox22.Text;
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Info));
            var xml = "";
            using(var sww = new StringWriter())
            {
                using(XmlWriter writer= new XmlTextWriter(sww))
                {
                    xsSubmit.Serialize(writer, info);
                    xml= sww.ToString();
                }
            }
            SaveFileDialog saveFileDialog= new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.RestoreDirectory= true;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {                                
                File.WriteAllText(saveFileDialog.FileName, xml);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 0;
            openFileDialog.DefaultExt = "xml";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Info));
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog.FileName);
                Info info = (Info)reader.Deserialize(file);
                file.Close();
                diploma_name.Text = info.kpd;
                maskedTextBox1.Text = info.kierunek;
                maskedTextBox2.Text = info.studiawzakresie;
                comboBox1.Text = info.profilstudiow;
                comboBox2.Text = info.formastudiow;
                comboBox3.Text = info.poziomstudiow;
                maskedTextBox3.Text = info.student1;
                maskedTextBox4.Text = info.student2;
                maskedTextBox5.Text = info.student3;
                maskedTextBox6.Text = info.student4;
                maskedTextBox7.Text = info.indeks1;
                maskedTextBox8.Text = info.indeks2;
                maskedTextBox9.Text = info.indeks3;
                maskedTextBox10.Text = info.indeks4;
                maskedTextBox11.Text = info.data1;
                maskedTextBox12.Text = info.data2;
                maskedTextBox13.Text = info.data3;
                maskedTextBox14.Text = info.data4;
                maskedTextBox15.Text = info.tytulpracy;
                maskedTextBox16.Text = info.angielskitytul;
                maskedTextBox17.Text = info.danewejsciowe;
                maskedTextBox18.Text = info.zakrespracy;
                maskedTextBox20.Text = info.promotor;
                maskedTextBox21.Text = info.jednostkaorganizacyjna;
                maskedTextBox23.Text = info.terminoddania;
                maskedTextBox22.Text = info.datazatwierdzenia;
            }   
        }
    }
}