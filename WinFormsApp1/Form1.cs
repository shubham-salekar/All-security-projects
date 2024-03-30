
using System.Management;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");

            // Retrieve the first result (assuming there's only one result).
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                string identifyingNumber = obj["IdentifyingNumber"].ToString();
                string name = obj["Name"].ToString();
                string skuNumber = obj["SKUNumber"].ToString();
                string uuid = obj["UUID"].ToString();
                string vendor = obj["Vendor"].ToString();
                string version = obj["Version"].ToString();

                // Use the retrieved information as needed.
                // For example, you can display it in a label or manipulate it in some other way.
            }
        }
    }
}