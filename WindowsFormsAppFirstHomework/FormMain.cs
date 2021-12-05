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
    public partial class FormMain : Form
    {
        private PhoneNumbersManager phoneNumbersManager;

        private void UpdatedataGridViewPhoneNumbers(List<PhoneNumber> phoneNumbers)
        {
            dataGridViewPhoneNumbers.Rows.Clear();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                dataGridViewPhoneNumbers.Rows.Add(
                    i + 1,
                    phoneNumbers[i].Number,
                    phoneNumbers[i].Name,
                    phoneNumbers[i].Info,
                    phoneNumbers[i].Grade
                    );
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            phoneNumbersManager = new PhoneNumbersManager();
        }

        private void buttonPhoneNumbersFromTxtFile_Click(object sender, EventArgs e)
        {
            phoneNumbersManager.LoadPhoneNumbersFromTxtFile();
            UpdatedataGridViewPhoneNumbers(phoneNumbersManager.GetPhoneNumbers());
        }

        private void buttonAddPhoneNumber_Click(object sender, EventArgs e)
        {
            string number = textBoxNumber.Text;

            string name = textBoxName.Text;

            string info = textBoxInfo.Text;
          
            PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(textBoxGrade.Text);

            PhoneNumber pnum = new PhoneNumber(number, name, info, grade);

            phoneNumbersManager.AddPhoneNumber(pnum);
            UpdatedataGridViewPhoneNumbers(phoneNumbersManager.GetPhoneNumbers());

            textBoxNumber.Clear();
            textBoxName.Clear();
            textBoxInfo.Clear();
            textBoxGrade.Clear();
        }

        private void buttonLoadPhoneNumbersFromBinFile_Click(object sender, EventArgs e)
        {
            phoneNumbersManager.LoadPhoneNumbersFromBinFile();
            UpdatedataGridViewPhoneNumbers(phoneNumbersManager.GetPhoneNumbers());
        }

        private void buttonSavePhoneNumbersBinToFile_Click(object sender, EventArgs e)
        {
            phoneNumbersManager.SavePhoneNumbersBinToFile();
        }

        private void buttonSavePhoneNumbersTxtToFile_Click(object sender, EventArgs e)
        {
            phoneNumbersManager.SavePhoneNumbersTxtToFile();
        }
        private void buttonDeletePhoneNumber_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBoxIndexForDelete.Text);
            phoneNumbersManager.DeletePhoneNumber(index-1);
            UpdatedataGridViewPhoneNumbers(phoneNumbersManager.GetPhoneNumbers());
            textBoxIndexForDelete.Clear();
        }

        private void butbuttonReplacePhoneNumber_Click(object sender, EventArgs e)
        {
            int index = int.Parse(textBoxReplaceIndex.Text);

            string number = textBoxReplaceNumber.Text;

            string name = textBoxReplaceName.Text;

            string info = textBoxReplaceInfo.Text;

            PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(textBoxReplaceGrade.Text);

            PhoneNumber pnum = new PhoneNumber(number, name, info, grade);

            phoneNumbersManager.ReplacePhoneNumber(index -1,pnum);
            UpdatedataGridViewPhoneNumbers(phoneNumbersManager.GetPhoneNumbers());

            textBoxReplaceIndex.Clear();
            textBoxReplaceNumber.Clear();
            textBoxReplaceName.Clear();
            textBoxReplaceInfo.Clear();
            textBoxReplaceGrade.Clear();
        }

        private void buttonPrintByGrade_Click(object sender, EventArgs e)
        {
            PhoneNumber.GradeList grade = (PhoneNumber.GradeList)int.Parse(textBoxByGrade.Text);

            phoneNumbersManager.GetPhoneNumbersByGrade(grade);
            UpdatedataGridViewPhoneNumbers(phoneNumbersManager.GetPhoneNumbers());
        }
    }
}
