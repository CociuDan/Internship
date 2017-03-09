using System;
using System.Text;

namespace GeekStore.WarehouseItems.Components
{
    class Disk : IItem
    {
        public enum DiskType { HDD, SSD, SSHD }
        private readonly int _capacity;
        private readonly string _diskType;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly int _readSpeed;
        private readonly int _rpm;
        private readonly int _writeSpeed;

        public Disk(int capacity, DiskType diskType, string manufacturer, string model, double price, int quantity, int readSpeed, int rpm, int writeSpeed)
        {
            try
            {
                if (capacity <= 0)
                {
                    throw new ArgumentException("Disk Capacity cannot be less or equal to 0. Entered value: " + capacity.ToString());
                }
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                {
                    throw new ArgumentNullException(manufacturer);
                }
                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                {
                    throw new ArgumentNullException(model);
                }
                if (price <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());
                }
                if (quantity <= 0)
                {
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());
                }
                if (readSpeed <= 0)
                {
                    throw new ArgumentException("Disk Read Speed cannot be less or equal to 0. Entered value: " + readSpeed.ToString());
                }
                if (diskType == DiskType.SSD && rpm != 0)
                {
                    throw new ArgumentException("SSDs does not have moving parts, RPM have to be equal to 0. Entered value: " + rpm.ToString());
                }
                if ((diskType == DiskType.HDD || diskType == DiskType.SSHD) && rpm <= 0)
                {
                    throw new ArgumentException("HDDs or SSHDs RPM cannot be less or equal to 0. Entered value: " + rpm.ToString());
                }
                if (writeSpeed <= 0)
                {
                    throw new ArgumentException("Disk Write Speed cannot be less or equal to 0. Entered value: " + writeSpeed.ToString());
                }
                _capacity = capacity;
                _manufacturer = manufacturer;
                _model = model;
                _price = price;
                _quantity = quantity;
                _readSpeed = readSpeed;
                _rpm = rpm;
                _diskType = diskType.ToString();
                _writeSpeed = writeSpeed;
            }
            catch (ArgumentNullException exception)
            {
                throw exception;
            }
            catch (ArgumentException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static explicit operator Disk(string v)
        {
            string[] diskInString = v.Split(' ');
            DiskType diskType;
            if(diskInString[1] == "SSD")
            {
                diskType = DiskType.SSD;
            }
            else if (diskInString[1] == "SSHD")
            {
                diskType = DiskType.SSD;
            }
            else
            {
                diskType = DiskType.HDD;
            }
            return new Disk(int.Parse(diskInString[0]), diskType, diskInString[2], diskInString[3], double.Parse(diskInString[4]),
                            int.Parse(diskInString[5]), int.Parse(diskInString[6]), int.Parse(diskInString[7]), int.Parse(diskInString[8]));
        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\tManufacturer: " + _manufacturer);
                sb.AppendLine("\tModel: " + _model);
                sb.AppendLine("\tCapacity: " + _capacity + "GB");
                sb.AppendLine("\tDisk Type: " + _diskType);
                sb.AppendLine("\tRead Speed: " + _readSpeed + "Mbs");
                sb.AppendLine("\tWrite Speed: " + _writeSpeed + "Mbs");
                sb.AppendLine("\tRPM: " + _rpm);
                return sb.ToString();
            }
        }

        public int Capacity { get { return _capacity; } }

        public string Type { get { return _diskType; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public int ReadSpeed { get { return _readSpeed; } }

        public int Rpm { get { return _rpm; } }

        public int WriteSpeed { get { return _writeSpeed; } }

        public void AddToWarehouse(int incomingQuantity)
        {
            _quantity += incomingQuantity;
        }

        public void SellQuantity(int sellingQuantity)
        {
            _quantity -= sellingQuantity;
        }

        public void ChangePrice(double newPrice)
        {
            _price = newPrice;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Capacity, Type, Manufacturer, Model, Price, Quantity, ReadSpeed, Rpm, WriteSpeed));
            return sb.ToString();
        }
    }
}
