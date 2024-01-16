namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        EmployeeService employeeService;
        DepartmentService departmentService;
        List<Employee> employeeList;
        public Form1()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            employeeService.createConnection();
            var employeeList = employeeService.GetEmployees(null, null);

            listBox1.DataSource = employeeList;
            listBox1.DisplayMember = "name";
            tabControl1.TabPages[0].Text = "Empoyees";
            tabControl1.TabPages[1].Text = "Departments";

            departmentService = new DepartmentService();
            departmentService.createConnection();
            var departmentsList = departmentService.GetDepartments();
            listBox2.DataSource = departmentsList;
            listBox2.DisplayMember = "name";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long? departmentId = long.TryParse(textBox1.Text, out long result) ? result : (long?)null;

            var employeeList = employeeService.GetEmployees(departmentId, comboBox1.Text);

            listBox1.DataSource = employeeList;
            listBox1.DisplayMember = "name";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}