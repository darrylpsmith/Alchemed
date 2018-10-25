using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Rest;
using test.Models;
namespace test
{

    public class AnonymousCredential : ServiceClientCredentials
    {

    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            SamApi samApi = new SamApi(new AnonymousCredential());
            HttpClient cli = samApi.HttpClient;
            Patient pat = new Patient();
            var x  = samApi.ApiPatientGet();


            //SvcRestClient client =
            //    new SvcRestClient(new Uri("http://localhost/webDemo"),
            //        new AnonymousCredential());
            //var result = client.Values.Get();

            //foreach (var x in result)
            //{
            //    MessageBox.Show(x);
            //}
        }
    }
}
