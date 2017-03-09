using System.Text;

namespace Lesson4_Assignment
{
    class Intern
    {
        private string _name;
        private double _assignmentsAverageMark;

        public Intern(string name, double assignmentsAverageMark)
        {
            _name = name;
            _assignmentsAverageMark = assignmentsAverageMark;
        }

        public string Name { get { return _name; } }
        public double AssignmentsAverageMark { get { return _assignmentsAverageMark; } set { _assignmentsAverageMark = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Intern Name: " + Name);
            sb.AppendLine("Intern Average Mark:" + AssignmentsAverageMark);
            return sb.ToString();
        }

        public void ChangeAverageMark(double newAverageMark)
        {
            _assignmentsAverageMark = newAverageMark;
        }
    }
}
