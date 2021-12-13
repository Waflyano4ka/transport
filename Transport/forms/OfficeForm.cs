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
    public partial class OfficeForm : Form
    {
        private int id;
        private MainMenu menu;

        RestClient client = new RestClient(ConstantLinks.domain);

        public OfficeForm(MainMenu _menu, int _id)
        {
            id = _id;
            menu = _menu;

            InitializeComponent();

            this.Load += (sende, args) =>
            {
                client.Authenticator = new JwtAuthenticator(ConstantLinks.token);
                List<City> list = JsonConvert.DeserializeObject<List<City>>(GetDataFromApi("/cities"));

                boxCity.DataSource = list;
                boxCity.DisplayMember = "city_name";
                boxCity.ValueMember = "id";

                if (id != -1)
                {
                    var request = new RestRequest($"/offices/{id}");
                    var response = client.Get(request);
                    var jsonObject = JObject.Parse(response.Content);

                    Office o = JsonConvert.DeserializeObject<Office>(jsonObject["data"].ToString());

                    textNumber.Text = o.phone;
                    textAddress.Text = o.address;
                    boxCity.SelectedValue = o.city.id;
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
                request = new RestRequest($"/offices/{id}");
                request.AddQueryParameter("phone", textNumber.Text);
                request.AddQueryParameter("address", textAddress.Text);
                request.AddQueryParameter("city_id", boxCity.SelectedValue.ToString());

                response = client.Put(request);
            }
            else
            {
                request = new RestRequest("/offices");
                request.AddQueryParameter("phone", textNumber.Text);
                request.AddQueryParameter("address", textAddress.Text);
                request.AddQueryParameter("city_id", boxCity.SelectedValue.ToString());

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
