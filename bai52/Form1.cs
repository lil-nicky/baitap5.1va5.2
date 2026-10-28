using System;
using System.Windows.Forms;

namespace BaiTap42_CourseRegistration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                cboCourse.DataSource = DatabaseHelper.GetCourses();
                cboCourse.DisplayMember = "CourseName";
                cboCourse.ValueMember = "CourseId";

                if (cboCourse.Items.Count > 0)
                    cboCourse.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách khóa học:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên.");
                txtFullName.Focus();
                return;
            }

            if (!mtxtPhone.MaskCompleted)
            {
                MessageBox.Show(
                    "Vui lòng nhập đủ số điện thoại theo định dạng (000) 000-0000.");
                mtxtPhone.Focus();
                return;
            }

            if (cboCourse.SelectedValue == null ||
                cboCourse.SelectedValue is System.Data.DataRowView)
            {
                MessageBox.Show("Vui lòng chọn khóa học.");
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string phone = mtxtPhone.Text;
            DateTime birthDate = dtpBirthDate.Value.Date;
            string gender = rdoMale.Checked ? "Nam" : "Nữ";
            int courseId = Convert.ToInt32(cboCourse.SelectedValue);
            string courseName = cboCourse.Text;
            bool wantsMaterials = chkMaterials.Checked;

            try
            {
                DatabaseHelper.SaveRegistration(
                    fullName,
                    phone,
                    birthDate,
                    gender,
                    courseId,
                    wantsMaterials);

                MessageBox.Show(
                    "ĐĂNG KÝ THÀNH CÔNG\n\n" +
                    "Họ và tên: " + fullName + "\n" +
                    "Số điện thoại: " + phone + "\n" +
                    "Ngày sinh: " + birthDate.ToString("dd/MM/yyyy") + "\n" +
                    "Giới tính: " + gender + "\n" +
                    "Khóa học: " + courseName + "\n" +
                    "Nhận tài liệu: " +
                    (wantsMaterials ? "Có" : "Không") +
                    "\n\nThông tin đã được lưu vào SQL Server.",
                    "Kết quả đăng ký",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lưu được đăng ký:\n" + ex.Message,
                    "Lỗi SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}