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
    public partial class ScheduleForm : Form
    {
        private int id;
        private MainMenu menu;

        RestClient client = new RestClient(ConstantLinks.domain);

        public ScheduleForm(MainMenu _menu, int _id)
        {
            id = _id;
            menu = _menu;

            InitializeComponent();

            this.Load += (sende, args) =>
            {
                client.Authenticator = new JwtAuthenticator(ConstantLinks.token);
                List<models.Transport> list = JsonConvert.DeserializeObject<List<models.Transport>>(GetDataFromApi("/transports"));

                boxTransport.DataSource = list;
                boxTransport.DisplayMember = "car_number";
                boxTransport.ValueMember = "id";

                List<Route> list2 = JsonConvert.DeserializeObject<List<Route>>(GetDataFromApi("/routes"));

                boxRoute.DataSource = list2;
                boxRoute.DisplayMember = "id";
                boxRoute.ValueMember = "id";

                if (id != -1)
                {
                    var request = new RestRequest($"/schedules/{id}");
                    var response = client.Get(request);
                    var jsonObject = JObject.Parse(response.Content);

                    Schedule o = JsonConvert.DeserializeObject<Schedule>(jsonObject["data"].ToString());

                    textCost.Text = o.cost.ToString();
                    checkConfirmed.Checked = o.confirmed;
                    boxTransport.SelectedValue = o.transport.id;
                    boxRoute.SelectedValue = o.route.id;
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
                request = new RestRequest($"/schedules/{id}");
                request.AddQueryParameter("date", $"{dateTimePicker1.Value.Year}.{dateTimePicker1.Value.Month}.{dateTimePicker1.Value.Day}");
                request.AddQueryParameter("time", $"{dateTimePicker1.Value.Hour}:{dateTimePicker1.Value.Minute}");
                request.AddQueryParameter("cost", textCost.Text);
                request.AddQueryParameter("confirmed", checkConfirmed.Checked.ToString());
                request.AddQueryParameter("transport_id", boxTransport.SelectedValue.ToString());
                request.AddQueryParameter("route_id", boxRoute.SelectedValue.ToString());

                response = client.Put(request);
            }
            else
            {
                request = new RestRequest("/schedules");
                request.AddQueryParameter("date", $"{dateTimePicker1.Value.Year}.{dateTimePicker1.Value.Month}.{dateTimePicker1.Value.Day}");
                request.AddQueryParameter("time", $"{dateTimePicker1.Value.Hour}:{dateTimePicker1.Value.Minute}");
                request.AddQueryParameter("cost", textCost.Text);
                request.AddQueryParameter("confirmed", checkConfirmed.Checked.ToString());
                request.AddQueryParameter("transport_id", boxTransport.SelectedValue.ToString());
                request.AddQueryParameter("route_id", boxRoute.SelectedValue.ToString());

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
