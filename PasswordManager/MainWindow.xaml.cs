using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        string fileName = "dataBase.db";
        private IReadAndWriteToFile readerWriter = new FileReadAndWrite();
        private List<Service> services = new List<Service>();

        public MainWindow() {
            InitializeComponent();

            DataContext = this;

            if (File.Exists(fileName)) {
                string data = readerWriter.ReadFromFile(fileName);

                DeserializeObject(data);
            }
        }

        private void AddService_Click(object sender, RoutedEventArgs e) {
            Service service = new Service(serviceName.Text, serviceLogin.Text, servicePassword.Text);

            if (!CheckNameLoginPasswordEmpty(service))
            {
                if (!CheckNameAndLoginUnique(service))
                {
                    services.Add(service);
                    servicesGrid.Items.Add(service);
                }
                else
                {
                    MessageBox.Show("Service with the same name and login already exists.");
                }
            }
            else
            {
                MessageBox.Show("Error: Name, login, or password is empty.");
            }
        }

        private bool CheckNameLoginPasswordEmpty(Service service) {
            return string.IsNullOrEmpty(service.NameService) || 
                   string.IsNullOrEmpty(service.LoginService) || 
                   string.IsNullOrEmpty(service.PasswordService);
        }

        private bool CheckNameAndLoginUnique(Service service) {
            return services.Any(s => s.NameService == service.NameService && s.LoginService == service.LoginService);
        }

        private void WriteToFile_Click(object sender, RoutedEventArgs e) {
            try {
                string data = SerializeObject();

                readerWriter.WriteToFile(data, fileName);
            }
            catch (Exception ex) {
                MessageBox.Show($"Write error to file: {ex.Message}");
            }
        }

        private void RemoveService_Click(object sender, RoutedEventArgs e) {
            Service selectedService = (Service)servicesGrid.SelectedItem;

            if (selectedService != null) {
                services.Remove(selectedService);
                servicesGrid.Items.Remove(selectedService);
            }   
        }

        private string SerializeObject() {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Service service in services) {
                stringBuilder.AppendLine(JsonConvert.SerializeObject(service));
            }

            return stringBuilder.ToString();
        }

        private void DeserializeObject(string data) {
            if (data != null) {
                string[] lines = data.Split('\n');

                foreach (string line in lines) {
                    if (!string.IsNullOrEmpty(line)) {
                        Service service = JsonConvert.DeserializeObject<Service>(line);
                        services.Add(service);
                        servicesGrid.Items.Add(service);
                    }
                }
            }
        }
    }
}