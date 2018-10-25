using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alchemint.Bar;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection;

namespace BarWindowsTestRig
{

    public partial class frmBarTestRig : Form
    {

        public frmBarTestRig()
        {
            InitializeComponent();
        }


        private void frmBarTestRig_Load(object sender, EventArgs e)
        {
            btnFillValues_Click(sender, e);

            //this.btnLogout.Click += new System.EventHandler(btnLogout_Click);
            //this.btnLogout.Click += btnLogout_Click;
            LogoutClicker loggerOuterFunction = Logout;

            //this.btnLogout.Click +=  (s,a) => {Logout(); };
            //this.btnLogout.Click += (s, a) => { loggerOuterFunction(); };
            this.btnLogout.Click += this.Logout;

        }


        delegate void LogoutClicker(object s, EventArgs e);

        private void Logout(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Clicked");
        }

        private I CreateInstance<I>() where I : class
        {
            string assemblyPath = Environment.CurrentDirectory + "\\BarClasses.dll";

            Assembly assembly;

            assembly = Assembly.LoadFrom(assemblyPath);
            Type type = assembly.GetType("Alchemint.Bar.BarUser");
            return Activator.CreateInstance(type) as I;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {


            try
            {
                if (radUseSqlite.Checked == true)
                {
                    DbAccess().CreateEntity (new BarUser { Id = Guid.NewGuid().ToString(), UserName = txtUserName.Text, Password = txtPassword.Text, Email = txtEmail.Text, Telephone = txtTelephone.Text });
                }
                else if (radUseWebApi.Checked == true)
                {
                    BarUser entity = new BarUser { Id = Guid.NewGuid().ToString(), UserName = txtUserName.Text, Password = txtPassword.Text, Email = txtEmail.Text, Telephone = txtTelephone.Text }; 
                    FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
                    BarUser entityCreated = (BarUser)AsyncHelpers.RunSync<object>(() => jsonAccess.CreateEntity(entity));

                    string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                    txtOutput.Text = entityJson;


                    //DataService ds = new DataService();
                    ////string queryString = "http://localhost:51925/api/User";
                    //string queryString = "http://localhost:51925/api/Fabric";

                    //dynamic json = AsyncHelpers.RunSync<JObject>(() => DataService.PostAsync(queryString, barUser));


                    //if (json != null)
                    //    txtOutput.Text = (string)((Newtonsoft.Json.Linq.JObject)json).ToString();
                    //else
                    //    txtOutput.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(((ExclusiveSynchronizationContext)SynchronizationContext.Current).InnerException.Message);
            }



        }

        private void btnCreateInstitution_Click(object sender, EventArgs e)
        {
            if (radUseSqlite.Checked == true)
            {
                DbAccess().CreateEntity(new BarInstitution { Id = Guid.NewGuid().ToString(), Name = txtInstitutionName.Text,  Password = txtInstitutionPassword.Text, Email = txtInstitutionEmail.Text, Telephone = txtInstitutionTel.Text });
            }
            else if (radUseWebApi.Checked == true)
            {
                BarInstitution entity = new BarInstitution { Id = Guid.NewGuid().ToString(),Name= txtInstitutionName.Text, Password = txtInstitutionPassword.Text, Email = txtInstitutionEmail.Text, Telephone = txtInstitutionTel.Text };
                FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
                BarInstitution entityCreated = (BarInstitution)AsyncHelpers.RunSync<object>(() => jsonAccess.CreateEntity(entity));

                string entityJson = JsonConvert.SerializeObject(entity,Formatting.Indented);
                txtOutput.Text = entityJson;
            }
        }

        private void btnFillValues_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "Test User";
            txtPassword.Text = "TestPassword";
            txtEmail.Text = "TestEmailXXXXXXX.com";
            txtTelephone.Text = "082-555-555555";

            txtInstitutionName.Text = "Test User";
            txtInstitutionPassword.Text = "TestPassword";
            txtInstitutionEmail.Text = "TestEmailXXXXXXX.com";
            txtInstitutionTel.Text = "082-555-555555";

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (radUseSqlite.Checked == true)
            {
                DataTable ret = (DataTable)DbAccess().GetEntity(new BarUser { UserName = txtUserName.Text, Password = txtPassword.Text }, DbAccess().BuildFilterList("UserName,Password"));  

                //BarUser outputObject = null;
                //System.Type type1 = (new BarClasses.BarUser()).GetType();

                //IBarUser outputObject = JsonConvert.DeserializeObject<BarUser>(ret.DataSetToJsonString());
                //var outputObject = JsonConvert.DeserializeObject(ret.DataSetToJsonString(), type1);

                IBarUser outputObject = (IBarUser)ret.DataSetRowToBarBusinessObject((new BarUser()).GetType());

                string ser = JsonConvert.SerializeObject(outputObject, Formatting.Indented);

                txtOutput.Text = ser;

                BarBusinessObjectAccess boa = new BarBusinessObjectAccess(DbAccess());
                BarUser bu = (BarUser) boa.GetEntity(new BarUser { UserName = txtUserName.Text, Password = txtPassword.Text }, boa.BuildFilterList("UserName,Password"));


                string ser2 = JsonConvert.SerializeObject(bu, Formatting.Indented);

                txtOutput.Text = ser2;
                lblIdValue.Text = bu.Id;
            }
            else if (radUseWebApi.Checked == true)
            {

                BarUser entity = new BarUser { UserName = txtUserName.Text, Password = txtPassword.Text};
                FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
                BarUser entityCreated = (BarUser)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntity(entity, jsonAccess.BuildFilterList("UserName,Password")));

                string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);
                txtOutput.Text = entityJson;

                lblIdValue.Text = entityCreated.Id;

                //DataService ds = new DataService();
                //string _iisServer = "http://DESKTOP-OLP9HIG:51925";
                ////string queryString = "http://localhost:51925/api/User/" + txtUserName.Text + "/" + txtPassword.Text;
                //string queryString = _iisServer + "/api/User/" + txtUserName.Text + "/" + txtPassword.Text;


                //dynamic json = AsyncHelpers.RunSync<dynamic>(() => DataService.GetAsync(queryString));

                //if (json != null)
                //    txtOutput.Text = (string)((Newtonsoft.Json.Linq.JObject)json).ToString();
                //else
                //    txtOutput.Text = "";


            }
        }






        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (radUseSqlite.Checked == true)
            {
                string Id = lblIdValue.Text;
                DbAccess().UpdateEntity(new BarUser { Id = Id, UserName = txtUserName.Text, Password = txtPassword.Text, Email = txtEmail.Text, Telephone = txtTelephone.Text });
            }
            else if (radUseWebApi.Checked == true)
            {
                string Id = lblIdValue.Text;
                BarUser entity = new BarUser { Id = Id, UserName = txtUserName.Text, Password = txtPassword.Text, Email = txtEmail.Text, Telephone = txtTelephone.Text };
                FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
                BarUser entityCreated = (BarUser)AsyncHelpers.RunSync<object>(() => jsonAccess.UpdateEntity (entity));

                string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                txtOutput.Text = entityJson;

            }

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

            if (radUseSqlite.Checked == true)
            {
                DbAccess().DeleteEntity(new BarUser { Id = Guid.NewGuid().ToString() });
            }
            else if (radUseWebApi.Checked == true)
            {
                string Id = lblIdValue.Text;
                BarUser entity = new BarUser {Id = Id, UserName = txtUserName.Text};
                FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
                BarUser entityCreated = (BarUser)AsyncHelpers.RunSync<object>(() => jsonAccess.DeleteEntity(entity));

                string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                txtOutput.Text = entityJson;

                //txtOutput.Text = Deleted;
                //string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
                //txtOutput.Text = entityJson;

                //BarUser barUser = new BarUser { Id = Guid.NewGuid().ToString(), UserName = txtUserName.Text, Password = txtPassword.Text, Email = txtEmail.Text, Telephone = txtTelephone.Text };

                //DataService ds = new DataService();
                //string queryString = "http://localhost:51925/api/User/" + barUser.Id;


                ////await DataService.PostAsync(queryString, user);

                //dynamic json = AsyncHelpers.RunSync<dynamic>(() => DataService.DeleteAsync(queryString));

                //if (json != null)
                //    txtOutput.Text = (string)((Newtonsoft.Json.Linq.JObject)json).ToString();
                //else
                //    txtOutput.Text = "";
            }

        }

        private void btnGetInstitution_Click(object sender, EventArgs e)
        {

            BarJsonAccess barAccess = new BarJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");

            BarInstitution entity = AsyncHelpers.RunSync<BarInstitution>(() => barAccess.GetInstitution(txtInstitutionName.Text, txtInstitutionPassword.Text));

            string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
            txtOutput.Text = entityJson;

            //var ret = .Result;

            //DataService ds = new DataService();
            //string queryString = "http://localhost:51925/api/Institution/" + txtInstitutionName.Text + "/" + txtInstitutionPassword.Text;

            ////0           dynamic results = 
            ////               await DataService.getDataFromService(queryString).ConfigureAwait(false);

            //dynamic json = AsyncHelpers.RunSync<dynamic>(() => DataService.GetAsync(queryString));


            //barAccess

            //if (json != null)
            //    txtOutput.Text = (string)((Newtonsoft.Json.Linq.JObject)json).ToString();
            //else
            //    txtOutput.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            BarToken entity = new BarToken { Id = Guid.NewGuid().ToString(), IssueTime = DateTime.UtcNow, OriginatorWalletAddress = Guid.NewGuid().ToString(), CurrentWallet = Guid.NewGuid().ToString() };
            FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
            BarToken entityCreated = (BarToken)AsyncHelpers.RunSync<object>(() => jsonAccess.CreateEntity(entity));

            string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
            txtOutput.Text = entityJson;

        }

        private void btnGetTokenBalance_Click(object sender, EventArgs e)
        {


            BarJsonAccess barJsonAccess = new BarJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
            BarTokenBalance entity = AsyncHelpers.RunSync<BarTokenBalance>(() => barJsonAccess.GetTokenBalance("0b64e418-fcdb-4dea-b43c-927aa4915303"));
            string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
            txtOutput.Text = entityJson;

            //BarTok
            //DataService ds = new DataService();
            //string queryString = "http://localhost:51925/api/Token/balance/" + "0b64e418-fcdb-4dea-b43c-927aa4915303";

            ////0           dynamic results = 
            ////               await DataService.getDataFromService(queryString).ConfigureAwait(false);

            //dynamic json = AsyncHelpers.RunSync<dynamic>(() => DataService.GetAsync(queryString));

            //if (json != null)
            //    txtOutput.Text = (string)((Newtonsoft.Json.Linq.JObject)json).ToString();
            //else
            //    txtOutput.Text = "";
        }

        private void btnSendTokens_Click(object sender, EventArgs e)
        {


            DataService ds = new DataService();
            string queryString = "http://localhost:51925/api/Token/send/" + "0b64e418-fcdb-4dea-b43c-927aa4915303" + "/" + "a183b66b-728d-42be-bb79-3f6a952e997e" + "/" + "1";

            //0           dynamic results = 
            //               await DataService.getDataFromService(queryString).ConfigureAwait(false);

            JObject json = AsyncHelpers.RunSync<JObject>(() => DataService.PostAsync(queryString, "33c35730-2deb-44ae-9a16-1dec27960052"));

            txtOutput.Text = (string)((Newtonsoft.Json.Linq.JObject)json).ToString();


        }

        private void btnGetAllInstitutions_Click(object sender, EventArgs e)
        {
            if (radUseSqlite.Checked == true)
            {
                DataTable ret = (DataTable)DbAccess().GetEntities(new BarInstitution(), null); 
                //.GetInstitutions();


                //BarUser outputObject = null;
                //System.Type type1 = (new BarClasses.BarUser()).GetType();

                //IBarUser outputObject = JsonConvert.DeserializeObject<BarUser>(ret.DataSetToJsonString());
                //var outputObject = JsonConvert.DeserializeObject(ret.DataSetToJsonString(), type1);

                var outputObject = ret.DataSetToBarBusinessObjectList((new BarInstitution()).GetType());

                string ser = JsonConvert.SerializeObject(outputObject, Formatting.Indented);

                txtOutput.Text = ser;

            }
            else if (radUseWebApi.Checked == true)
            {

                BarInstitution entity = new BarInstitution  {};
                FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
                List<object> entityCreated = (List<object>)AsyncHelpers.RunSync<List<object>>(() => jsonAccess.GetEntities(entity, null));
                List<BarInstitution> institutions = entityCreated.Cast<BarInstitution>().ToList();
                string entityJson = JsonConvert.SerializeObject(institutions, Formatting.Indented);
                txtOutput.Text = entityJson;

            }

            }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
            ApiKey entity = new ApiKey { Id = Guid.NewGuid().ToString(), ApiKeyValue = "33c35730-2deb-44ae-9a16-1dec27960052", TenantCode = "TR1" };
            ApiKey entityCreated = (ApiKey)await jsonAccess.CreateEntity(entity);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Patient entity = new Patient { IdNumber = "p"};
            FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
            Patient entityCreated = (Patient)AsyncHelpers.RunSync<object>(() => jsonAccess.GetEntity(entity, jsonAccess.BuildFilterList("IdNumber")));

            string entityJson = JsonConvert.SerializeObject(entityCreated, Formatting.Indented);
            txtOutput.Text = entityJson;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BarBusinessObjectAccess boa = new BarBusinessObjectAccess(
                new BarDatabaseAccess(
                    BarStaticFunctions.GetDMLExecutionRoviderSQLite(),
                    BarStaticFunctions.GetTenant()));

            boa.StoreEntity(new PatientConsult { Id = Guid.NewGuid().ToString(), PatientIdNumber = "9", ConsultDate = DateTime.UtcNow, Comments = "Very sick" });
                
        }


        //public void CreateApiKey()
        //{
        //    ApiKey entity = new BarToken { Id = Guid.NewGuid().ToString(), IssueTime = DateTime.UtcNow, OriginatorWalletAddress = Guid.NewGuid().ToString(), CurrentWallet = Guid.NewGuid().ToString() };
        //    FabricJsonAccess jsonAccess = new FabricJsonAccess("33c35730-2deb-44ae-9a16-1dec27960052");
        //    BarToken entityCreated = (BarToken)AsyncHelpers.RunSync<object>(() => jsonAccess.CreateEntity(entity));

        //    string entityJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
        //    txtOutput.Text = entityJson;
        //}
    }
}
