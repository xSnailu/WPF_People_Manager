using pomidorek;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public bool add_contact = false;
        public MainWindow mainWindowHook;
        public string NameW2 {  get; set; }
        public string SurnameW2 { get; set; }
        public string EmailW2 { get; set; }
        public string PhoneW2 { get; set; }


        public Object NameW2Validator { get; set; }
        public Object SurnameW2Validator { get; set; }
        public Object EmailW2Validator { get; set; }
        public Object PhoneW2Validator { get; set; }
        public enum SEX
        {
            Male,
            Female,
        }
        public Window2(MainWindow mainWindowHookC)
        {
            this.mainWindowHook = mainWindowHookC;
            NameW2Validator = mainWindowHook.NameValidationComboBox.SelectedItem;
            SurnameW2Validator = mainWindowHook.SurnameValidationComboBox.SelectedItem;
            EmailW2Validator = mainWindowHook.EmailValidationComboBox.SelectedItem;
            PhoneW2Validator = mainWindowHook.PhoneValidationComboBox.SelectedItem;

     
       

            DataContext = this;
            InitializeComponent();

            if (NameW2Validator != null)
            {
                NameBox.GetBindingExpression(TextBox.TextProperty).ParentBinding.ValidationRules.Add(NameW2Validator as ValidationRule);
            }
            if (SurnameW2Validator != null)
            {
                SurnameBox.GetBindingExpression(TextBox.TextProperty).ParentBinding.ValidationRules.Add(SurnameW2Validator as ValidationRule);
            }
            if (EmailW2Validator != null)
            {
                EmailBox.GetBindingExpression(TextBox.TextProperty).ParentBinding.ValidationRules.Add(EmailW2Validator as ValidationRule);
            }
            if (PhoneW2Validator != null)
            {
                PhoneBox.GetBindingExpression(TextBox.TextProperty).ParentBinding.ValidationRules.Add(PhoneW2Validator as ValidationRule);
            }
        }


        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            add_contact = true;
            this.Close();
        }

        private void NameBox_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = "";
        }
    }
}
