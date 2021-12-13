using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Transport.forms;
using Transport.models;

namespace Transport
{
    public partial class MainMenu : Form, IUpdate
    {
        public MainMenu()
        {
            InitializeComponent();

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Таблицы");

            foreach (Post p in ConstantLinks.posts)
            {
                if (p.post_name == "admin")
                {
                    fileItem.DropDownItems.Clear();
                    fileItem.DropDownItems.Add("Модель");
                    fileItem.DropDownItems.Add("Транспорт");
                    fileItem.DropDownItems.Add("Город");
                    fileItem.DropDownItems.Add("Офис");
                    fileItem.DropDownItems.Add("Сотрудники офиса");
                    fileItem.DropDownItems.Add("Маршрут");
                    fileItem.DropDownItems.Add("Расписание");
                    fileItem.DropDownItems.Add("Пассажир");
                    fileItem.DropDownItems.Add("Билет");
                    fileItem.DropDownItems.Add("Должность");
                    fileItem.DropDownItems.Add("Должности сотрудников");
                    fileItem.DropDownItems.Add("Сотрудники");

                    break;
                }
                switch (p.post_name)
                {
                    case "mechanic":
                        {
                            fileItem.DropDownItems.Add("Модель");
                            fileItem.DropDownItems.Add("Транспорт");
                            break;
                        }
                    case "head_of_office":
                        {
                            fileItem.DropDownItems.Add("Город");
                            fileItem.DropDownItems.Add("Офис");
                            fileItem.DropDownItems.Add("Сотрудники офиса");
                            break;
                        }
                    case "logist":
                        {
                            fileItem.DropDownItems.Add("Маршрут");
                            fileItem.DropDownItems.Add("Расписание");
                            break;
                        }
                    case "cashier":
                        {
                            fileItem.DropDownItems.Add("Пассажир");
                            fileItem.DropDownItems.Add("Билет");
                            break;
                        }
                    case "hr":
                        {
                            fileItem.DropDownItems.Add("Должность");
                            fileItem.DropDownItems.Add("Должности сотрудников");
                            fileItem.DropDownItems.Add("Сотрудник");
                            break;
                        }
                }
            }

            foreach (ToolStripMenuItem tool in fileItem.DropDownItems)
            {
                tool.Click += Tool_Click;
            }

            this.menuStrip1.Items.Add(fileItem);
        }

        private string tableNameNow;

        private void Tool_Click(object sender, EventArgs e)
        {
            try
            {
                tableNameNow = sender.ToString();
                JsonToDataGrid(tableNameNow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tableNameNow) && !String.IsNullOrEmpty(searchTextBox.Text))
                {
                    JsonToDataGrid(tableNameNow, comboBoxSearh.Text, searchTextBox.Text);
                }
                else
                {
                    JsonToDataGrid(tableNameNow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void JsonToDataGrid(string modelName, string nColomn = "", string search = "")
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            comboBoxSearh.Items.Clear();
            comboBoxSearh.Items.Add("");

            List<string[]> columnName = new List<string[]>();

            switch (modelName)
            {
                case "Модель":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "model_name", "Название" });

                        List<Model> list = JsonConvert.DeserializeObject<List<Model>>(GetDataFromApi("/models"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Model>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Название":
                                    {
                                        list = new List<Model>(list.Where(l => l.model_name.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Model m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.model_name;
                            AddEditAndDelete(m.id, i, 2, "models/delete/");
                            i++;
                        }

                        break;
                    }
                case "Транспорт":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "car_number", "Номер" });
                        columnName.Add(new string[] { "total_seats", "Кол-во мест" });
                        columnName.Add(new string[] { "model_name", "Модель" });

                        List<models.Transport> list = JsonConvert.DeserializeObject<List<models.Transport>>(GetDataFromApi("/transports"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<models.Transport>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Номер":
                                    {
                                        list = new List<models.Transport>(list.Where(l => l.car_number.Contains(search)));
                                        break;
                                    }
                                case "Кол - во мест":
                                    {
                                        list = new List<models.Transport>(list.Where(l => l.total_seats.ToString().Contains(search)));
                                        break;
                                    }
                                case "Модель":
                                    {
                                        list = new List<models.Transport>(list.Where(l => l.model.model_name.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (models.Transport m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.car_number;
                            dataGrid.Rows[i].Cells[2].Value = m.total_seats;
                            dataGrid.Rows[i].Cells[3].Value = m.model.model_name;
                            AddEditAndDelete(m.id, i, 4, "transports/delete/");
                            i++;
                        }

                        break;
                    }
                case "Город":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "city_name", "Название" });

                        List<City> list = JsonConvert.DeserializeObject<List<City>>(GetDataFromApi("/cities"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<City>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Название":
                                    {
                                        list = new List<City>(list.Where(l => l.city_name.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (City m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.city_name;
                            AddEditAndDelete(m.id, i, 2, "cities/delete/");
                            i++;
                        }

                        break;
                    }
                case "Офис":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "phone", "Телефон" });
                        columnName.Add(new string[] { "address", "Адрес" });
                        columnName.Add(new string[] { "city", "Город" });

                        List<Office> list = JsonConvert.DeserializeObject<List<Office>>(GetDataFromApi("/offices"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Office>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Телефон":
                                    {
                                        list = new List<Office>(list.Where(l => l.phone.Contains(search)));
                                        break;
                                    }
                                case "Адрес":
                                    {
                                        list = new List<Office>(list.Where(l => l.address.Contains(search)));
                                        break;
                                    }
                                case "Город":
                                    {
                                        list = new List<Office>(list.Where(l => l.city.city_name.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Office m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.phone;
                            dataGrid.Rows[i].Cells[2].Value = m.address;
                            dataGrid.Rows[i].Cells[3].Value = m.city.city_name;
                            AddEditAndDelete(m.id, i, 4, "offices/delete/");
                            i++;
                        }

                        break;
                    }
                case "Сотрудники офиса":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "user", "Сотрудник" });
                        columnName.Add(new string[] { "office", "Офис" });

                        List<OfficeUser> list = JsonConvert.DeserializeObject<List<OfficeUser>>(GetDataFromApi("/office_user"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<OfficeUser>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Сотрудник":
                                    {
                                        list = new List<OfficeUser>(list.Where(l => l.user.email.Contains(search)));
                                        break;
                                    }
                                case "Офис":
                                    {
                                        list = new List<OfficeUser>(list.Where(l => l.office.address.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (OfficeUser m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.user.email;
                            dataGrid.Rows[i].Cells[2].Value = m.office.address;
                            AddEditAndDelete(m.id, i, 3, "office_user/delete/");
                            i++;
                        }

                        break;
                    }
                case "Маршрут":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "departure_city", "Город отправления" });
                        columnName.Add(new string[] { "arrival_city", "Город прибытия" });
                        columnName.Add(new string[] { "distance", "Дистанция" });
                        columnName.Add(new string[] { "user", "Работник" });

                        List<Route> list = JsonConvert.DeserializeObject<List<Route>>(GetDataFromApi("/routes"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Route>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Город отправления":
                                    {
                                        list = new List<Route>(list.Where(l => l.departure_city.city_name.Contains(search)));
                                        break;
                                    }
                                case "Город прибытия":
                                    {
                                        list = new List<Route>(list.Where(l => l.arrival_city.city_name.Contains(search)));
                                        break;
                                    }
                                case "Дистанция":
                                    {
                                        list = new List<Route>(list.Where(l => l.distance.ToString().Contains(search)));
                                        break;
                                    }
                                case "Работник":
                                    {
                                        list = new List<Route>(list.Where(l => l.user.surname.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Route m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.departure_city.city_name;
                            dataGrid.Rows[i].Cells[2].Value = m.arrival_city.city_name;
                            dataGrid.Rows[i].Cells[3].Value = m.distance;
                            dataGrid.Rows[i].Cells[4].Value = m.user.surname;
                            AddEditAndDelete(m.id, i, 5, "routes/delete/");
                            i++;
                        }

                        break;
                    }
                case "Расписание":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "date", "Дата" });
                        columnName.Add(new string[] { "time", "Время" });
                        columnName.Add(new string[] { "cost", "Стоимость" });
                        columnName.Add(new string[] { "confirmed", "Подтвержден" });
                        columnName.Add(new string[] { "transport", "Транспорт" });
                        columnName.Add(new string[] { "route", "Маршрут" });

                        List<Schedule> list = JsonConvert.DeserializeObject<List<Schedule>>(GetDataFromApi("/schedules"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Schedule>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Дата":
                                    {
                                        list = new List<Schedule>(list.Where(l => l.date.Contains(search)));
                                        break;
                                    }
                                case "Время":
                                    {
                                        list = new List<Schedule>(list.Where(l => l.time.Contains(search)));
                                        break;
                                    }
                                case "Стоимость":
                                    {
                                        list = new List<Schedule>(list.Where(l => l.cost.ToString().Contains(search)));
                                        break;
                                    }
                                case "Подтвержден":
                                    {
                                        list = new List<Schedule>(list.Where(l => l.confirmed.ToString().Contains(search)));
                                        break;
                                    }
                                case "Транспорт":
                                    {
                                        list = new List<Schedule>(list.Where(l => l.transport.car_number.ToString().Contains(search)));
                                        break;
                                    }
                                case "Маршрут":
                                    {
                                        list = new List<Schedule>(list.Where(l => (l.route.departure_city + " - " + l.route.arrival_city).ToString().Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Schedule m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.date;
                            dataGrid.Rows[i].Cells[2].Value = m.time;
                            dataGrid.Rows[i].Cells[3].Value = m.cost;
                            dataGrid.Rows[i].Cells[4].Value = m.confirmed;
                            dataGrid.Rows[i].Cells[5].Value = m.transport.car_number;
                            dataGrid.Rows[i].Cells[6].Value = m.route.departure_city + " - " + m.route.arrival_city;
                            AddEditAndDelete(m.id, i, 7, "schedules/delete/");
                            i++;
                        }

                        break;
                    }
                case "Пассажир":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "surname", "Фамилия" });
                        columnName.Add(new string[] { "first_name", "Имя" });
                        columnName.Add(new string[] { "second_name", "Отчество" });
                        columnName.Add(new string[] { "passport_series", "Серия паспорта" });
                        columnName.Add(new string[] { "passport_number", "Намер паспорта" });
                        columnName.Add(new string[] { "phone", "Телефон" });

                        List<Passenger> list = JsonConvert.DeserializeObject<List<Passenger>>(GetDataFromApi("/passengers"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Фамилия":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.surname.Contains(search)));
                                        break;
                                    }
                                case "Имя":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.first_name.Contains(search)));
                                        break;
                                    }
                                case "Отчество":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.second_name.ToString().Contains(search)));
                                        break;
                                    }
                                case "Серия паспорта":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.passport_series.ToString().Contains(search)));
                                        break;
                                    }
                                case "Намер паспорта":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.passport_number.ToString().Contains(search)));
                                        break;
                                    }
                                case "Телефон":
                                    {
                                        list = new List<Passenger>(list.Where(l => l.phone.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Passenger m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.surname;
                            dataGrid.Rows[i].Cells[2].Value = m.first_name;
                            dataGrid.Rows[i].Cells[3].Value = m.second_name;
                            dataGrid.Rows[i].Cells[4].Value = m.passport_series;
                            dataGrid.Rows[i].Cells[5].Value = m.passport_number;
                            dataGrid.Rows[i].Cells[6].Value = m.phone;
                            AddEditAndDelete(m.id, i, 7, "passengers/delete/");
                            i++;
                        }

                        break;
                    }
                case "Билет":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "passenger", "Пассажир" });
                        columnName.Add(new string[] { "schedule", "Маршрут" });

                        List<Ticket> list = JsonConvert.DeserializeObject<List<Ticket>>(GetDataFromApi("/tickets"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Ticket>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Пассажир":
                                    {
                                        list = new List<Ticket>(list.Where(l => l.passenger.surname.Contains(search)));
                                        break;
                                    }
                                case "Билет":
                                    {
                                        list = new List<Ticket>(list.Where(l => (l.schedule.date + " " + l.schedule.time + " " + l.schedule.route.departure_city + " - " + l.schedule.route.arrival_city).ToString().Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Ticket m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.passenger.surname;
                            dataGrid.Rows[i].Cells[2].Value = m.schedule.date + " " + m.schedule.time + " " + m.schedule.route.departure_city + " - " + m.schedule.route.arrival_city;
                            AddEditAndDelete(m.id, i, 3, "tickets/delete/");
                            i++;
                        }

                        break;
                    }
                case "Должность":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "post_name", "Название" });

                        List<Post> list = JsonConvert.DeserializeObject<List<Post>>(GetDataFromApi("/posts"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<Post>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Название":
                                    {
                                        list = new List<Post>(list.Where(l => l.post_name.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (Post m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.post_name;
                            AddEditAndDelete(m.id, i, 2, "posts/delete/");
                            i++;
                        }

                        break;
                    }
                case "Должности сотрудников":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "user", "Сотрудник" });
                        columnName.Add(new string[] { "post", "Должность" });

                        List<PostUser> list = JsonConvert.DeserializeObject<List<PostUser>>(GetDataFromApi("/post_user"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<PostUser>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Сотрудник":
                                    {
                                        list = new List<PostUser>(list.Where(l => l.user.email.Contains(search)));
                                        break;
                                    }
                                case "Должность":
                                    {
                                        list = new List<PostUser>(list.Where(l => l.post.post_name.Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (PostUser m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.user.email;
                            dataGrid.Rows[i].Cells[2].Value = m.post.post_name;
                            AddEditAndDelete(m.id, i, 3, "post_user/delete/");
                            i++;
                        }

                        break;
                    }
                case "Сотрудники":
                    {
                        columnName.Add(new string[] { "id", "Код" });
                        columnName.Add(new string[] { "email", "Почта" });
                        columnName.Add(new string[] { "surname", "Фамилия" });
                        columnName.Add(new string[] { "first_name", "Имя" });
                        columnName.Add(new string[] { "second_name", "Отчество" });
                        columnName.Add(new string[] { "passport_series", "Серия паспорта" });
                        columnName.Add(new string[] { "passport_number", "Намер паспорта" });
                        columnName.Add(new string[] { "inn", "ИНН" });
                        columnName.Add(new string[] { "birthday", "День рождения" });
                        columnName.Add(new string[] { "dismissed", "Уволен" });

                        List<User> list = JsonConvert.DeserializeObject<List<User>>(GetDataFromApi("/users"));

                        foreach (string[] s in columnName)
                        {
                            dataGrid.Columns.Add(s[0], s[1]);
                            comboBoxSearh.Items.Add(s[1]);
                        }

                        dataGrid.Columns.Add(new DataGridViewButtonColumn());
                        dataGrid.Columns.Add(new DataGridViewButtonColumn());

                        if (!String.IsNullOrEmpty(nColomn))
                        {
                            switch (nColomn)
                            {
                                case "Код":
                                    {
                                        list = new List<User>(list.Where(l => l.id.ToString().Contains(search)));
                                        break;
                                    }
                                case "Почта":
                                    {
                                        list = new List<User>(list.Where(l => l.email.Contains(search)));
                                        break;
                                    }
                                case "Фамилия":
                                    {
                                        list = new List<User>(list.Where(l => l.surname.Contains(search)));
                                        break;
                                    }
                                case "Имя":
                                    {
                                        list = new List<User>(list.Where(l => l.first_name.Contains(search)));
                                        break;
                                    }
                                case "Отчество":
                                    {
                                        list = new List<User>(list.Where(l => l.second_name.Contains(search)));
                                        break;
                                    }
                                case "Серия паспорта":
                                    {
                                        list = new List<User>(list.Where(l => l.passport_series.Contains(search)));
                                        break;
                                    }
                                case "Намер паспорта":
                                    {
                                        list = new List<User>(list.Where(l => l.passport_number.Contains(search)));
                                        break;
                                    }
                                case "ИНН":
                                    {
                                        list = new List<User>(list.Where(l => l.inn.Contains(search)));
                                        break;
                                    }
                                case "День рождения":
                                    {
                                        list = new List<User>(list.Where(l => l.birthday.Contains(search)));
                                        break;
                                    }
                                case "Уволен":
                                    {
                                        list = new List<User>(list.Where(l => l.dismissed.ToString().Contains(search)));
                                        break;
                                    }
                            }
                        }

                        int i = 0;
                        foreach (User m in list)
                        {
                            dataGrid.Rows.Add();
                            dataGrid.Rows[i].Cells[0].Value = m.id;
                            dataGrid.Rows[i].Cells[1].Value = m.email;
                            dataGrid.Rows[i].Cells[2].Value = m.surname;
                            dataGrid.Rows[i].Cells[3].Value = m.first_name;
                            dataGrid.Rows[i].Cells[4].Value = m.second_name;
                            dataGrid.Rows[i].Cells[5].Value = m.passport_series;
                            dataGrid.Rows[i].Cells[6].Value = m.passport_number;
                            dataGrid.Rows[i].Cells[7].Value = m.inn;
                            dataGrid.Rows[i].Cells[8].Value = m.birthday;
                            dataGrid.Rows[i].Cells[9].Value = m.dismissed;
                            AddEditAndDelete(m.id, i, 10, "users/delete/");
                            i++;
                        }

                        break;
                    }
            }
        }
        private void AddEditAndDelete(int id, int _positionR, int _positionC, string message)
        {
            dataGrid.Rows[_positionR].Cells[_positionC + 1].Value = "Удалить";
            dataGrid.Rows[_positionR].Cells[_positionC].Value = "Изменить";

            RemoveClickEvent(dataGrid);

            dataGrid.CellClick += (object sende, DataGridViewCellEventArgs args) =>
            {
                if (args.RowIndex == _positionR && args.ColumnIndex == _positionC)
                {
                    SelectModel(id);
                }
                if (args.RowIndex == _positionR && args.ColumnIndex == _positionC + 1)
                {
                    try
                    {
                        var client = new RestClient(ConstantLinks.domain);
                        client.Authenticator = new JwtAuthenticator(ConstantLinks.token);

                        var request = new RestRequest(message + id.ToString());
                        var response = client.Put(request);

                        JsonToDataGrid(tableNameNow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };
        }

        private void RemoveClickEvent(DataGridView b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private string GetDataFromApi(string name)
        {
            var client = new RestClient(ConstantLinks.domain);
            client.Authenticator = new JwtAuthenticator(ConstantLinks.token);

            var request = new RestRequest(name);
            var response = client.Get(request);
            var jsonObject = JObject.Parse(response.Content);
            return jsonObject["data"].ToString();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SelectModel(-1);
        }

        public void SelectModel(int id)
        {
            switch (tableNameNow)
            {
                case "Модель":
                    {
                        ModelForm form = new ModelForm(this, id);
                        form.ShowDialog();
                        break;
                    }
                case "Транспорт":
                    {
                        TransportForm form = new TransportForm(this, id);
                        form.ShowDialog();
                        break;
                    }
                case "Город":
                    {
                        CityForm form = new CityForm(this, id);
                        form.ShowDialog();
                        break;
                    }
                case "Офис":
                    {
                        OfficeForm form = new OfficeForm(this, id);
                        form.ShowDialog();
                        break;
                    }
                case "Сотрудники офиса":
                    {
                        OfficeUserForm form = new OfficeUserForm(this, id);
                        form.ShowDialog();
                        break;
                    }
                case "Маршрут":
                    {
                        OfficeUserForm form = new OfficeUserForm(this, id);
                        form.ShowDialog();
                        break;
                    }
                case "Расписание":
                    {
                        ScheduleForm form = new ScheduleForm(this, id);
                        form.ShowDialog();
                        break;
                    }
            }
        }

        public void Update()
        {
            try
            {
                JsonToDataGrid(tableNameNow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
