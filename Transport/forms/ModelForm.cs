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
    public partial class ModelForm : Form
    {
        private int id;
        private MainMenu menu;

        RestClient client = new RestClient(ConstantLinks.domain);

        public ModelForm(MainMenu _menu, int _id)
        {
            id = _id;
            menu = _menu;

            InitializeComponent();

            this.Load += (sende, args) =>
            {
                client.Authenticator = new JwtAuthenticator(ConstantLinks.token);

                if (id != -1)
                {
                    var request = new RestRequest($"/models/{id}");
                    var response = client.Get(request);
                    var jsonUser = JObject.Parse(response.Content);

                    Model o = JsonConvert.DeserializeObject<Model>(jsonUser["data"].ToString());

                    textModel.Text = o.model_name;
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestRequest request = new RestRequest();
            IRestResponse response;
            if (id != -1)
            {
                request = new RestRequest($"/models/{id}");
                request.AddQueryParameter("model_name", textModel.Text);

                response = client.Put(request);
            }
            else
            {
                request = new RestRequest("/models");
                request.AddQueryParameter("model_name", textModel.Text);

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
