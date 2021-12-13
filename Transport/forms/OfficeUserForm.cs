using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transport.models;

namespace Transport.forms
{
    public partial class OfficeUserForm : Form
    {
        private int id;
        private MainMenu menu;

        RestClient client = new RestClient(ConstantLinks.domain);

        public OfficeUserForm(MainMenu _menu, int _id)
        {
            id = _id;
            menu = _menu;

            InitializeComponent();

            this.Load += (sende, args) =>
            {
                client.Authenticator = new JwtAuthenticator(ConstantLinks.token);
                List<User> list = JsonConvert.DeserializeObject<List<User>>(GetDataFromApi("/users"));

                boxUser.DataSource = list;
                boxUser.DisplayMember = "surname";
                boxUser.ValueMember = "id";

                List<Office> list2 = JsonConvert.DeserializeObject<List<Office>>(GetDataFromApi("/offices"));

                boxOffice.DataSource = list2;
                boxOffice.DisplayMember = "address";
                boxOffice.ValueMember = "id";

                if (id != -1)
                {
                    var request = new RestRequest($"/office_user/{id}");
                    var response = client.Get(request);
                    var jsonObject = JObject.Parse(response.Content);

                    OfficeUser o = JsonConvert.DeserializeObject<OfficeUser>(jsonObject["data"].ToString());

                    boxOffice.SelectedValue = o.office.id;
                    boxUser.SelectedValue = o.user.id;
                }
            };
        }

        private string GetDataFromApi(string name)
        {
            var _client = new RestClient(ConstantLinks.domain);
            _client.Authenticator = new JwtAuthenticator(ConstantLinks.token);

            var _request = new RestRequest(name);
            var _response = client.Get(_request);
            var _jsonObject = JObject.Parse(_response.Content);
            return _jsonObject["data"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestRequest request = new RestRequest();
            IRestResponse response;
            if (id != -1)
            {
                request = new RestRequest($"/office_user/{id}");
                request.AddQueryParameter("user_id", boxUser.SelectedValue.ToString());
                request.AddQueryParameter("office_id", boxOffice.SelectedValue.ToString());

                response = client.Put(request);
            }
            else
            {
                request = new RestRequest("/office_user");
                request.AddQueryParameter("user_id", boxUser.SelectedValue.ToString());
                request.AddQueryParameter("office_id", boxOffice.SelectedValue.ToString());

                response = client.Post(request);
            }

            var jsonObject = JObject.Parse(response.Content);

            if (jsonObject.ContainsKey("errors"))
            {
                MessageBox.Show(jsonObject["errors"].ToString());
            }
            else
            {
                IUpdate up = menu;
                up.Update();

                this.Close();
            }
        }
    }
}
