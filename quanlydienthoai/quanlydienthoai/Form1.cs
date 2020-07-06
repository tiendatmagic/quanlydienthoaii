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
        int cndl = 0;
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

            string sql;
            sql = "SELECT tenhang FROM HANGSX";
            comboBox1.DataSource = Functions.GetDataToTable(sql);
            comboBox1.DisplayMember = "tenhang";
        }



        private void btnxem_Click(object sender, EventArgs e)
        {
            LoadDataGridView2();
        }

        private void LoadDataGridView2()
        {
            string sql;
            sql = "select DIENTHOAI.ma, DIENTHOAI.ten, DIENTHOAI.dongia, DIENTHOAI.tonkho, DIENTHOAI.mahang from DIENTHOAI,HANGSX where DIENTHOAI.mahang = HANGSX.mahang and HANGSX.tenhang=" + "'" + comboBox1.Text + "'";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView2();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (cndl == 0)
            {
                MessageBox.Show("Chưa tích cập nhật giá");
            }

            else
            {
                string sql; //Lưu câu lệnh sql
                if (tblCL.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtgia.Text == "") //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtsoluong.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn chưa nhập hết thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sql = ("UPDATE DIENTHOAI SET dongia=N'" + txtgia.Text.ToString() + "' WHERE ma=N'" + txtma.Text + "'" +
                 "UPDATE DIENTHOAI SET tonkho=N'" + txtsoluong.Text.ToString() + "' WHERE ma=N'" + txtma.Text + "'");

                //update DIENTHOAI set dongia='2000',tonkho='1' where ma='M01' 
                /*
                 sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" +
                            txtsoluong.Text.ToString() +
                            "' WHERE Machatlieu=N'" + txtgia.Text + "'";
                 */
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                // ResetValue();

                //btnBoqua.Enabled = false;
            }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE DIENTHOAI WHERE ma=N'" + txtma.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                //ResetValue();
            }
        }

        private void ch_cn_Click(object sender, EventArgs e)
        {
            if (ch_cn.Checked == true)

                cndl = 1;

            if (ch_cn.Checked == false)

                cndl = 0;
        }
    }
}
