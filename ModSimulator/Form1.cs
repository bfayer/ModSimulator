using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ModSimulator
{
    public delegate void ErrorEventHandler (String data);


    public partial class Form1 : Form
    {
        //C# Type	.Net type    	Signed? Bytes   Possible Values
        //sbyte	    System.Sbyte	Yes	    1	    -128 to 127
        //short	    System.Int16	Yes	    2	    -32768 to 32767
        //int	    System.Int32	Yes 	4	    -2147483648 to 2147483647
        //long	    System.Int64	Yes	    8	    -9223372036854775808 to 9223372036854775807
        //byte	    System.Byte	    No	    1	    0 to 255
        //ushort	System.Uint16	No	    2   	0 to 65535
        //uint	    System.UInt32	No  	4	    0 to 4294967295
        //ulong	    System.Uint64	No	    8	    0 to 18446744073709551615
        //float	    System.Single	Yes	    4	    Approximately ±1.5 x 10-45 to ±3.4 x 1038 with 7 significant figures
        //double	System.Double	Yes	    8	    Approximately ±5.0 x 10-324 to ±1.7 x 10308 with 15 or 16 significant figures
        //decimal	System.Decimal	Yes	    12	    Approximately ±1.0 x 10-28 to ±7.9 x 1028 with 28 or 29 significant figures
        //char	    System.Char	    N/A	    2	    Any Unicode character (16 bit)
        //bool	    System.Boolean	N/A	    1 / 2?	true or false, don'tknow when you would have 2 bytes though.. 







        DR b = new DR();
        int counter = 0;
        PipeClient myPipeClient = new PipeClient();
        string source;

        int hp;
        int hpMax;
        bool onFire;
        sbyte testSByte;
        short testShort;
        long testLong;
        byte testByte;
        ushort testUShort;
        uint testUInt;
        ulong testULong;
        float testFloat;
        double testDouble;
        decimal testDecimal;
        char testChar;


        public Form1()
        {

            myPipeClient.myErrorLog += new ErrorEventHandler(reportToTextbox);
            b.dataPacks.Add(new DP());

            //setting up some bogus initial values
            hp = 0;
            hpMax = 100;
            onFire = true;
            testSByte = Convert.ToSByte(-90);
            testShort = -30000;
            testLong = -9223372036854775808;
            testByte = Convert.ToByte(240);
            testUShort = 65535;
            testUInt = 4294967295;
            testULong = 18446744073709551615;
            testFloat = 10.1234F;
            testDouble = 516516546513158138;
            testDecimal = 926516.2561615616M;
            testChar = Convert.ToChar("#");

            b.dataPacks[0].dataElement.Add(new DE("hp", hp.GetType().ToString(), hp.ToString() ));
            b.dataPacks[0].dataElement.Add(new DE("hpMax", hpMax.GetType().ToString(), hpMax.ToString()));
            b.dataPacks[0].dataElement.Add(new DE("onFire", onFire.GetType().ToString(), onFire.ToString()));
            b.dataPacks[0].dataElement.Add(DElement(testSByte));
            b.dataPacks[0].dataElement.Add(DElement(testShort));
            b.dataPacks[0].dataElement.Add(DElement(testLong));
            b.dataPacks[0].dataElement.Add(DElement(testByte));
            b.dataPacks[0].dataElement.Add(DElement(testUShort));
            b.dataPacks[0].dataElement.Add(DElement(testUInt));
            b.dataPacks[0].dataElement.Add(DElement(testULong));
            b.dataPacks[0].dataElement.Add(DElement(testFloat));
            b.dataPacks[0].dataElement.Add(DElement(testDouble));
            b.dataPacks[0].dataElement.Add(DElement(testDecimal));
            b.dataPacks[0].dataElement.Add(DElement(testChar));

            source= "ModSim_"+RandomSourceName(5);

            InitializeComponent();
            textBoxSourceName.Text = source;
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        private string RandomSourceName(int size) //generates a random string to append to the source name so you can create mulitple instances of the modsimulator without having to type different names in
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        public DE DElement(Object pizza)
        {
            DE newElement = new DE();
            newElement.N = RandomSourceName(5);
            newElement.T = pizza.GetType().ToString();
            newElement.V = pizza.ToString();
            return newElement;
        }

        static string Check<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return body.Member.Name;
        }

        private void buttonBeginSending_Click(object sender, EventArgs e)
        {
            b.dataPacks[0].Src = textBoxSourceName.Text; // sets the source name from user input in the textbox
            b.dataPacks[0].v = "0.01";
            b.TV = "1.00";
            
            textBoxSourceName.Enabled = false;
            numericUpDownTimeInterval.Enabled = false;
            timerDataGenerationTicker.Interval = Convert.ToInt16(numericUpDownTimeInterval.Value);
            timerDataGenerationTicker.Start();
        }
        public void reportToTextbox(string incoming)
        {
            //try
            //{
                this.Invoke((MethodInvoker)delegate()
                {
                    textBoxDebug.Text = incoming; //reports errors to the lower textbox 
                });
            //}
            //catch (System.ObjectDisposedException)
            //{ 
            //}
        }
        private void buttonStopSendingData_Click(object sender, EventArgs e)
        {
            textBoxSourceName.Enabled = true;
            numericUpDownTimeInterval.Enabled = true;
            timerDataGenerationTicker.Stop();
        }

        private void timerDataGenerationTicker_Tick(object sender, EventArgs e)
        {

            if (counter < 100)
            {
                counter++;
                b.dataPacks[0].dataElement[0].V = Convert.ToString(counter);
            }
            else
            {
                counter = 0;
                onFire=!onFire;
                b.dataPacks[0].dataElement[2].V = onFire.ToString();
            }



            Thread myThread = new Thread(myPipeClient.Transmit);
            myThread.Start(b);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myPipeClient.myErrorLog -= new ErrorEventHandler(reportToTextbox);
            Environment.Exit(0);
        }



    }
}
