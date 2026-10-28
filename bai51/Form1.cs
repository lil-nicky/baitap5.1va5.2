using System;
using System.Windows.Forms;

namespace BaiTap41_LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(
            object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(
                    txtUsername, "Vui lòng nhập tên đăng nhập.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(
                    txtPassword, "Vui lòng nhập mật khẩu.");
                valid = false;
            }

            if (!valid)
                return;

            try
            {
                bool success = DatabaseHelper.ValidateLogin(
                    txtUsername.Text.Trim(),
                    txtPassword.Text);

                if (success)
                {
                    MessageBox.Show(
                        "Đăng nhập thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Tên đăng nhập hoặc mật khẩu không đúng.",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi truy cập SQL Server:\n" + ex.Message,
                    "Lỗi",
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