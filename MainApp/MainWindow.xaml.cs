using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace MainApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            var text = TextInput.Text;
            var filePath = "text.json";

            File.WriteAllText(filePath, text);

            MessageBox.Show("Текст сохранен в файле text.json");
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;

                var text = File.ReadAllText(filePath);

                TextInput.Text = text;

                MessageBox.Show("Текст успешно загружен из файла");
            }
        }
    }
}
