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

namespace Transport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                Authorization();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Authorization()
        {
            var client = new RestClient(ConstantLinks.domain);
            var request = new RestRequest(ConstantLinks.authorization);

            request.AddQueryParameter("email", textBoxLogin.Text);
            request.AddQueryParameter("password", textBoxPassword.Text);

            var response = client.Post(request);

            dynamic results = JsonConvert.DeserializeObject<dynamic>(response.Content);

            if ((bool)results.status)
            {
                ConstantLinks.token = results.token;
                client.Authenticator = new JwtAuthenticator(ConstantLinks.token);

                request = new RestRequest($"/users/{results.user}");
                response = client.Get(request);
                var jsonUser = JObject.Parse(response.Content);

                User user = JsonConvert.DeserializeObject<User>(jsonUser["data"].ToString());
                ConstantLinks.user = user;

                request = new RestRequest($"/post_user/posts/{user.id}");
                response = client.Get(request);
                var jRole = JObject.Parse(response.Content);
                var jsonRoles = JArray.Parse(jRole["data"].ToString());

                foreach (JObject o in jsonRoles)
                {
                    ConstantLinks.posts.Add(JsonConvert.DeserializeObject<Post>(o["post"].ToString()));
                }

                if (!user.dismissed)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Ваш аккаунт был заблокирован!");
                }
            }
            else
            {
                email.Text = results.errors.email;
                password.Text = results.errors.password;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
