using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Peripherals
{
    public class Headphones : IItem
    {
        public enum HeadphonesType { InEar, OnEar, OverEar}
        private int _impendance;
        private readonly string _manufacturer;
        private readonly int _maxVolume;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private string _type;

        public Headphones(int impendance, string manufacturer, int maxVolume, string model, double price, int quantity, HeadphonesType type)
        {
            try
            {
                if (impendance <= 0)
                    throw new ArgumentException("Headphones Impendance cannot be less or equal to 0. Entered value: " + impendance.ToString());

                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (maxVolume <= 0)
                    throw new ArgumentException("Speakers Max Volume cannot be less or equal than 0 Db. Entered value: " + maxVolume.ToString());

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (quantity <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());

                _manufacturer = manufacturer;
                _maxVolume = maxVolume;
                _model = model;
                _price = price;
                _quantity = quantity;
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
            _impendance = impendance;
            _manufacturer = manufacturer;
            _model = model;
            _price = price;
            _quantity = quantity;
            _type = type.ToString();
        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"\tManufacturer: {_manufacturer}");
                sb.AppendLine($"\tModel: {_model}");
                sb.AppendLine($"\tType: {_type}");
                sb.AppendLine($"\tImpendance: {_impendance}Ω");
                return sb.ToString();
            }
        }

        public int Impendance { get { return _impendance; } }

        public string Manufacturer { get { return _manufacturer; } }

        public int MaxVolume { get { return _maxVolume; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

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
    }
}
