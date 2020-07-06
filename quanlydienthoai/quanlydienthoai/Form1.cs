using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlydienthoai.Class;
namespace quanlydienthoai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable tblCL;
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM DIENTHOAI";
            tblCL = Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridView1.DataSource = tblCL; //Nguồn dữ liệu            
            dataGridView1.Columns[0].HeaderText = "Mã điện thoại";
            dataGridView1.Columns[1].HeaderText = "Tên điện thoại";
            dataGridView1.Columns[2].HeaderText = "Đơn giá";
            dataGridView1.Columns[3].HeaderText = "Tồn kho";
            dataGridView1.Columns[4].HeaderText = "Mã hàng";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;

            dataGridView1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp}
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadDataGridView();
            //Load_Treeview();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
