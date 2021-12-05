using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppFirstHomework
{
    public partial class ReplacePhoneNumberForm : Form
    {
        private PhoneNumbersManager phoneNumbersManager;
        FormMain mainForms = new FormMain();

        public ReplacePhoneNumberForm()
        {
            InitializeComponent();
        }
        private void ReplacePhoneNumberForm_Load(object sender, EventArgs e)
        {
            phoneNumbersManager = new PhoneNumbersManager();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBoxIndex.Text);

            string number = textBoxNumber.Text;

            string name = textBoxName.Text;

            string info = textBoxInfo.Text;

            PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(textBoxGrade.Text);

            PhoneNumber pnum = new PhoneNumber(number, name, info, grade);

            phoneNumbersManager.ReplacePhoneNumber(index - 1, pnum);

            textBoxIndex.Clear();
            textBoxNumber.Clear();
            textBoxName.Clear();
            textBoxInfo.Clear();
            textBoxGrade.Clear();

        }
    }
}
