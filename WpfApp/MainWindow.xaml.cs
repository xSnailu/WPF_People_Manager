using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using pomidorek;
using System.Reflection;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum SEX
    {
        Male,
        Female,
    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Contacts = Contact.GetContacts();

            // to ze stacka 
            validations = CreatePlugin(@"..\..\..\Validation");

        }

        public IValidation[] validations { get; set; }

        public bool state = false;
        public bool State
        {
            get { return state; }   // get method
            set { state = value; OnPropertyChanged("State"); }  // set method
        }


        public ObservableCollection<Contact> Contacts { get; set; }

        // tutaj ten schemat z dokumentacji Microsoft
        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                TextWriter writer = new StreamWriter(saveFileDialog.FileName);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));
                serializer.Serialize(writer, Contacts);
                writer.Close(); 
            }
        }


        // tutaj ten schemat z dokumentacji Microsoft
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML-File | *.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));

                using (Stream reader = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    try
                    {

                        var data = (ObservableCollection<Contact>)serializer.Deserialize(reader);
                        Contacts.Clear();
                        foreach (var p in data)
                            Contacts.Add(p);
                        MessageBox.Show("Sukces wczytywania danych!");
                    }
                    catch(System.InvalidOperationException)
                    {
                        MessageBox.Show("Błąd wczytywania danych!");
                    }
                   
                    
                }

            }

        }

        // to ze stacka
        // https://stackoverflow.com/questions/1315621/implementing-inotifypropertychanged-does-a-better-way-exist
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //https://stackoverflow.com/questions/9549231/how-to-right-click-on-item-from-listbox-and-open-menu-on-wpf
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (contactsList.SelectedIndex == -1) return;

            Contacts.RemoveAt(contactsList.SelectedIndex);

        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddContactsMenu_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Window2(this);
            newWindow.Owner = this;

            this.GrayRectangle.Visibility = Visibility.Visible;
            
            newWindow.ShowDialog();
            if (newWindow.add_contact)
                Contacts.Add(new Contact(newWindow.NameBox.Text, newWindow.SurnameBox.Text, newWindow.EmailBox.Text, newWindow.PhoneBox.Text, (newWindow.SexBox.SelectedItem.ToString())));
            this.IsEnabled = true;

            this.GrayRectangle.Visibility = Visibility.Hidden;

        }

        private void ClearContactsMenu_Click(object sender, RoutedEventArgs e)
        {

            Contacts.Clear();
            
            dataGrid.ItemsSource = Contacts;
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This is simple contact manager.", "Contact Manager", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, System.Windows.MessageBoxOptions.DefaultDesktopOnly);
        }

        private void StateButton_Click1(object sender, RoutedEventArgs e)
        {
            State = true;
        }

        private void StateButton_Click2(object sender, RoutedEventArgs e)
        {
            State = false;
        }

        // wszystko zwiazane z wczytywaniem ddlek ze stacka
        // https://stackoverflow.com/questions/5751844/how-to-reference-a-dll-on-runtime?fbclid=IwAR0xFW0nWDhBQ2qEG1qacsnvxyXQ258k5IYZLe7ehekq6YHd17mY55N0XKw
        public IValidation[] CreatePlugin(string path)
        {
            List<IValidation> rules = new List<IValidation>();
            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                foreach (Type assemblyType in Assembly.LoadFrom(file).GetTypes())
                {
                    Type interfaceType = assemblyType.GetInterface(typeof(IValidation).FullName);

                    if (interfaceType != null)
                    {
                        rules.Add((IValidation)Activator.CreateInstance(assemblyType));
                    }
                }
            }

            return rules.ToArray();
        }

    }

    // https://www.tutorialspoint.com/wpf/wpf_datagrid.htm
    public class Contact : INotifyPropertyChanged
    {
       public Contact() { }
       public Contact(string name, string surname, string email, string phone, string sex)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phone;
            switch (sex)
            {
                case "Female":
                    Sex = SEX.Female;
                    break;
                case "Male":
                    Sex = SEX.Male;
                    break;
                 default:
                    Sex = SEX.Male;
                    break;
            }
        } 


        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaiseProperChanged();
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                RaiseProperChanged();
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaiseProperChanged();
            }
        }

        private string phonenumber;
        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;
                RaiseProperChanged();
            }
        }

        private SEX sex;

        public SEX Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                RaiseProperChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static ObservableCollection<Contact> GetContacts()
        {
            var contacts = new ObservableCollection<Contact>();
            return contacts;
        }

    }

    



}
