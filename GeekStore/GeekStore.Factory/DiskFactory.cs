using GeekStore.Model.Components;

namespace GeekStore.Factory
{
    public class DiskFactory
    {
        public static Disk CreateDisk()
        {
            return new Disk(240, Disk.DiskType.SSD, "Crucial", "BX100", 70.0, 550, 0, 530);
        }

        public static Disk CreateDisk(int capacity, Disk.DiskType diskType, string manufacturer, string model, double price, int readspeed, int rpm, int writespeed)
        {
            return new Disk(capacity, diskType, manufacturer, model, price, readspeed, rpm, writespeed);
        }
    }
}
