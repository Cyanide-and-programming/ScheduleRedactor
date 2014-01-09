using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SRUI
{


    public partial class Form1 : Form
    {
        private List<ControlPair<ComboBox>> mondaySubjectList;
        private List<ControlPair<ComboBox>> tuesdaySubjectList;
        private List<ControlPair<ComboBox>> wednesdaySubjectList;
        private List<ControlPair<ComboBox>> thursdaySubjectList;
        private List<ControlPair<ComboBox>> fridaySubjectList;

        private List<ControlPair<ComboBox>> mondayTypeList;
        private List<ControlPair<ComboBox>> tuesdayTypeList;
        private List<ControlPair<ComboBox>> wednesdayTypeList;
        private List<ControlPair<ComboBox>> thursdayTypeList;
        private List<ControlPair<ComboBox>> fridayTypeList;

        private List<ControlPair<ComboBox>> mondayTeacherList;
        private List<ControlPair<ComboBox>> tuesdayTeacherList;
        private List<ControlPair<ComboBox>> wednesdayTeacherList;
        private List<ControlPair<ComboBox>> thursdayTeacherList;
        private List<ControlPair<ComboBox>> fridayTeacherList;

        private List<ControlPair<ComboBox>> mondayAudienceList;
        private List<ControlPair<ComboBox>> tuesdayAudienceList;
        private List<ControlPair<ComboBox>> wednesdayAudienceList;
        private List<ControlPair<ComboBox>> thursdayAudienceList;
        private List<ControlPair<ComboBox>> fridayAudienceList;


        public Form1()
        {
            InitializeComponent();
            this.mondaySubjectList = new List<ControlPair<ComboBox>>();
            this.tuesdaySubjectList = new List<ControlPair<ComboBox>>();
            this.wednesdaySubjectList = new List<ControlPair<ComboBox>>();
            this.thursdaySubjectList = new List<ControlPair<ComboBox>>();
            this.fridaySubjectList = new List<ControlPair<ComboBox>>();

            this.mondayTypeList = new List<ControlPair<ComboBox>>();
            this.tuesdayTypeList = new List<ControlPair<ComboBox>>();
            this.wednesdayTypeList = new List<ControlPair<ComboBox>>();
            this.thursdayTypeList = new List<ControlPair<ComboBox>>();
            this.fridayTypeList = new List<ControlPair<ComboBox>>();

            this.mondayTeacherList = new List<ControlPair<ComboBox>>();
            this.tuesdayTeacherList = new List<ControlPair<ComboBox>>();
            this.wednesdayTeacherList = new List<ControlPair<ComboBox>>();
            this.thursdayTeacherList = new List<ControlPair<ComboBox>>();
            this.fridayTeacherList = new List<ControlPair<ComboBox>>();

            this.mondayAudienceList = new List<ControlPair<ComboBox>>();
            this.tuesdayAudienceList = new List<ControlPair<ComboBox>>();
            this.wednesdayAudienceList = new List<ControlPair<ComboBox>>();
            this.thursdayAudienceList = new List<ControlPair<ComboBox>>();
            this.fridayAudienceList = new List<ControlPair<ComboBox>>();
            this.InitComp();
            this.FillComponents();
        }

        private void InitComp()
        {
            this.AddComp(this.mondayTabPage, "monday", 
                this.mondaySubjectList, this.mondayTypeList,
                this.mondayTeacherList, this.mondayAudienceList);
            this.AddComp(this.tuesdayTabPage, "tuesday",
                this.tuesdaySubjectList, this.tuesdayTypeList,
                this.tuesdayTeacherList, this.tuesdayAudienceList);
            this.AddComp(this.wednesdayTabPage, "wednesday",
                this.wednesdaySubjectList, this.wednesdayTypeList,
                this.wednesdayTeacherList, this.wednesdayAudienceList);
            this.AddComp(this.thursdayTabPage, "thursday",
                this.thursdaySubjectList, this.thursdayTypeList,
                this.thursdayTeacherList, this.thursdayAudienceList);
            this.AddComp(this.fridayTabPage, "friday",
                this.fridaySubjectList, this.fridayTypeList,
                this.fridayTeacherList, this.fridayAudienceList);
            

        }

        private void AddComp(Control page, String day,
            ICollection<ControlPair<ComboBox>> subjectList, ICollection<ControlPair<ComboBox>> typeList, 
            ICollection<ControlPair<ComboBox>> teacherList, ICollection<ControlPair<ComboBox>> audienceList)
        {

            this.AddSpecType(50, 50, "Subject", day, subjectList, page);
            this.AddSpecType(170, 50, "Type", day, typeList, page);
            this.AddSpecType(290, 50, "Teacher", day, teacherList, page);
            this.AddSpecType(410, 50, "Audience", day, audienceList, page);
        }

        private void AddSpecType(int left, int bottom, string type, string day,
            ICollection<ControlPair<ComboBox>> list, Control page)
        {
            const int down = 60;
            for (int i = 1; i < 8; i++, bottom += down)
            {
                ComboBox first = new ComboBox
                    {
                        FormattingEnabled = true,
                        Location = new System.Drawing.Point(left, bottom),
                        Name = String.Format("{0}{1}{2}{3}{4}", day, type, "Num", "ComboBox", i),
                        Size = new System.Drawing.Size(100, 20)
                    };

                ComboBox second = new ComboBox()
                    {
                        FormattingEnabled = true,
                        Location = new System.Drawing.Point(left, bottom + 25),
                        Name = String.Format("{0}{1}{2}{3}{4}", day, type, "Den", "ComboBox", i),
                        Size = new System.Drawing.Size(100, 20)
                    };
                
                page.Controls.Add(first);
                page.Controls.Add(second);

                ControlPair<ComboBox> temp = new ControlPair<ComboBox> { First = first, Second = second };
                list.Add(temp);
            }
        }


        private void FillComponents()
        {
            this.FillSubjects();
            this.FillTypes();
            this.FillTeachers();
            this.FillAudiences();
        }

        private void FillSubjects()
        {
            var subjects = (IEnumerable<String>)Serializer.ObjectSerializer.DeserializeFrom(Constants.SUBJECTS);
            this.AddValues(this.mondaySubjectList, subjects);
            this.AddValues(this.tuesdaySubjectList, subjects);
            this.AddValues(this.wednesdaySubjectList, subjects);
            this.AddValues(this.thursdaySubjectList, subjects);
            this.AddValues(this.fridaySubjectList, subjects);
        }

        private void FillTypes()
        {
            var types = new List<String>();
            
            types.Add("Лекція");
            types.Add("Практика");
            types.Add("Лабораторна");

            this.AddValues(this.mondayTypeList, types);
            this.AddValues(this.tuesdayTypeList, types);
            this.AddValues(this.wednesdayTypeList, types);
            this.AddValues(this.thursdayTypeList, types);
            this.AddValues(this.fridayTypeList, types);
        }

        private void FillTeachers()
        {
            var teachers = (IEnumerable<String>)Serializer.ObjectSerializer.DeserializeFrom(Constants.TEACHERS);
            this.AddValues(this.mondayTeacherList, teachers);
            this.AddValues(this.tuesdayTeacherList, teachers);
            this.AddValues(this.wednesdayTeacherList, teachers);
            this.AddValues(this.thursdayTeacherList, teachers);
            this.AddValues(this.fridayTeacherList, teachers);
        }

        private void FillAudiences()
        {
            var audiences = (IEnumerable<SheduleRedactor.Audience>) Serializer
                .ObjectSerializer.DeserializeFrom(Constants.AUDIENCES);
            var numbers = from audience in audiences select audience.Number;

            this.AddValues(this.mondayAudienceList, numbers);
            this.AddValues(this.tuesdayAudienceList, numbers);
            this.AddValues(this.wednesdayAudienceList, numbers);
            this.AddValues(this.thursdayAudienceList, numbers);
            this.AddValues(this.fridayAudienceList, numbers);
        }

        private void AddValues(IEnumerable<ControlPair<ComboBox>> list, IEnumerable<String> values)
        {
            foreach (var pair in list)
                foreach (var subject in values)
                {
                    pair.First.Items.Add(subject);
                    pair.Second.Items.Add(subject);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


    }
}
