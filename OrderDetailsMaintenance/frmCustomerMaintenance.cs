using OrderDetailsMaintenance.Models.DataLayer;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        private NorthwindContext _context;
        private Customer _customer;

        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _context = new NorthwindContext();
            string id = txtCustomerId.Text.Trim();
            _customer = _context.Customers.Find(id);

            if (_customer == null)
            {
                MessageBox.Show("Customer not found.");
                txtContact.Clear();
                txtAddress.Clear();
                txtCity.Clear();
                txtCountry.Clear();
            }
            else
            {
                txtContact.Text = _customer.ContactName;
                txtAddress.Text = _customer.Address;
                txtCity.Text = _customer.City;
                txtCountry.Text = _customer.Country;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_customer == null)
            {
                MessageBox.Show("Please find a customer first.");
                return;
            }

            _customer.ContactName = txtContact.Text;
            _customer.Address = txtAddress.Text;
            _customer.City = txtCity.Text;
            _customer.Country = txtCountry.Text;

            _context.Customers.Update(_customer);
            _context.SaveChanges();

            MessageBox.Show("Customer updated successfully!");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}