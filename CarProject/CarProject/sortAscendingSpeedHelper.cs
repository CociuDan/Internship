using System.Collections;

namespace CarProject
{
    class SortAscendingSpeedHelper : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Car a = (Car)x;
            Car b = (Car)y;
            if (a.MaxSpeed > b.MaxSpeed)
                return 1;
            else if (a.MaxSpeed < b.MaxSpeed)
                return -1;
            else return 0;
        }
    }
}
