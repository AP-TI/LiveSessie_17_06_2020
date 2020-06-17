using Deel4Oefening1.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deel4Oefening1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ServiceReference.Service1Client service1Client = new ServiceReference.Service1Client("BasicHttpBinding_IService1");
            List<Speler> spelers = service1Client.GetSpelers("Elfring", new DateTime(1948, 9, 1)).ToList();
            dataGridViewResultaat.DataSource = spelers;
        }
    }
}
