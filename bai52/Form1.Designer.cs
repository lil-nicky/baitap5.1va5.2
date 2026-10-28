namespace BaiTap42_CourseRegistration
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.CheckBox chkMaterials;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.chkMaterials = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Form
            this.Text = "Bài 4.2 - Đăng ký khóa học";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(540, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.AcceptButton = this.btnRegister;
            this.CancelButton = this.btnExit;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(105, 20);
            this.lblTitle.Text = "PHIẾU ĐĂNG KÝ KHÓA HỌC";

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(45, 85);
            this.lblFullName.Text = "Họ và tên:";

            // txtFullName
            this.txtFullName.Location = new System.Drawing.Point(180, 80);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 23);

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(45, 130);
            this.lblPhone.Text = "Số điện thoại:";

            // mtxtPhone
            this.mtxtPhone.Location = new System.Drawing.Point(180, 125);
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Mask = "(000) 000-0000";
            this.mtxtPhone.Size = new System.Drawing.Size(300, 23);

            // lblBirthDate
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(45, 175);
            this.lblBirthDate.Text = "Ngày sinh:";

            // dtpBirthDate
            this.dtpBirthDate.Location = new System.Drawing.Point(180, 170);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.MaxDate = System.DateTime.Today;
            this.dtpBirthDate.Value = new System.DateTime(2005, 1, 1);
            this.dtpBirthDate.Size = new System.Drawing.Size(300, 23);

            // lblGender
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(45, 220);
            this.lblGender.Text = "Giới tính:";

            // rdoMale
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(180, 218);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Text = "Nam";
            this.rdoMale.Checked = true;

            // rdoFemale
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(260, 218);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Text = "Nữ";

            // lblCourse
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(45, 265);
            this.lblCourse.Text = "Khóa học:";

            // cboCourse
            this.cboCourse.Location = new System.Drawing.Point(180, 260);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(300, 23);
            this.cboCourse.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // chkMaterials
            this.chkMaterials.AutoSize = true;
            this.chkMaterials.Location = new System.Drawing.Point(180, 305);
            this.chkMaterials.Name = "chkMaterials";
            this.chkMaterials.Text = "Đăng ký nhận tài liệu học tập";

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(180, 350);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(125, 35);
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click +=
                new System.EventHandler(this.btnRegister_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(335, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 35);
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click +=
                new System.EventHandler(this.btnExit_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.chkMaterials);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}