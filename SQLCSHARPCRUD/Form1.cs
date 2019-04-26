using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCSHARPCRUD
{
    public partial class Form1 : Form
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = employeeRepository.GetAll();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAddFN.Text) && !string.IsNullOrEmpty(txtAddLN.Text))
            {
                employeeRepository.Add(new Employee
                {
                    FirstName = txtAddFN.Text,
                    LastName = txtAddLN.Text,
                });
                txtAddFN.Text = string.Empty;
                txtAddLN.Text = string.Empty;
                dataGridView1.DataSource = employeeRepository.GetAll();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var employee = (Employee)row.DataBoundItem;
                txtId.Text = employee.Id.ToString();
                txtFN.Text = employee.FirstName;
                txtLN.Text = employee.LastName;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text))
            {
                employeeRepository.Update(new Employee
                {
                    Id = int.Parse(txtId.Text),
                    FirstName = txtFN.Text,
                    LastName = txtLN.Text
                });
                dataGridView1.DataSource = employeeRepository.GetAll();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text))
            {
                employeeRepository.Delete(int.Parse(txtId.Text));
                txtId.Text = string.Empty;
                txtFN.Text = string.Empty;
                txtLN.Text = string.Empty;
                dataGridView1.DataSource = employeeRepository.GetAll();
            }
        }
    }
}