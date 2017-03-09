namespace Lesson4_Assignment
{
    class ClassWithStatic
    {
        public static int i = 5555;

        public static int IncreaseInt(int i)
        {
            return i + 1;
        }

        public static void DecreaseInt(ref int j)
        {
            j--;
        }

        public static void Add(int a, int b, out int c)
        {
            c = a + b;
        }
    }
}
