using GeekStore.Model.Infrastucture;
using System;
using System.Text;

namespace GeekStore.Model.Components
{
    public class Disk : IItem
    {
        public enum DiskType { HDD, SSD, SSHD }
        private readonly int _capacity;
        private readonly string _diskType;
        private readonly int _id;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly int _readSpeed;
        private readonly int _rpm;
        private readonly int _writeSpeed;

        public Disk(int capacity, DiskType diskType, string manufacturer, string model, double price, int readSpeed, int rpm, int writeSpeed)
        {
            try
            {
                if (capacity <= 0)
                    throw new ArgumentException("Disk Capacity cannot be less or equal to 0. Entered value: " + capacity.ToString());

                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (readSpeed <= 0)
                    throw new ArgumentException("Disk Read Speed cannot be less or equal to 0. Entered value: " + readSpeed.ToString());

                if (diskType == DiskType.SSD && rpm != 0)
                    throw new ArgumentException("SSDs does not have moving parts, RPM have to be equal to 0. Entered value: " + rpm.ToString());

                if ((diskType == DiskType.HDD || diskType == DiskType.SSHD) && rpm <= 0)
                    throw new ArgumentException("HDDs or SSHDs RPM cannot be less or equal to 0. Entered value: " + rpm.ToString());

                if (writeSpeed <= 0)
                    throw new ArgumentException("Disk Write Speed cannot be less or equal to 0. Entered value: " + writeSpeed.ToString());

                _capacity = capacity;
                _id = IDGenerator.NextID();
                _manufacturer = manufacturer;
                _model = model;
                _price = price;
                _readSpeed = readSpeed;
                _rpm = rpm;
                _diskType = diskType.ToString();
                _writeSpeed = writeSpeed;

                AddToWarehouse(1);
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

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"\tManufacturer: {_manufacturer}");
                sb.AppendLine($"\tModel: {_model}");
                sb.AppendLine($"\tCapacity: {_capacity}GB");
                sb.AppendLine($"\tDisk Type: {_diskType}");
                sb.AppendLine($"\tRead Speed: {_readSpeed}Mbs");
                sb.AppendLine($"\tWrite Speed: {_writeSpeed}Mbs");
                sb.AppendLine($"\tRPM: {_rpm}");
                return sb.ToString();
            }
        }

        public int Capacity { get { return _capacity; } }

        public int ID { get { return _id; } }

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
            if (incomingQuantity <= 0)
                throw new ArgumentException("You cannot add less than one item to warehouse. Enterd value: " + incomingQuantity.ToString());
            _quantity += incomingQuantity;
        }

        public void SellQuantity(int sellingQuantity)
        {
            if (sellingQuantity <= 0)
                throw new ArgumentException("You cannot sell less than one item from warehouse. Enterd value: " + sellingQuantity.ToString());
            _quantity -= sellingQuantity;
        }

        public void ChangePrice(double newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("New Price cannot be less or equal to 0. Entered value: " + newPrice.ToString());
            _price = newPrice;
        }
    }
}
