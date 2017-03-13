using GeekStore.Model.Infrastucture;
using System;
using System.Text;

namespace GeekStore.Model.Peripherals
{
    public class Headphones : IItem
    {
        public enum HeadphonesType { InEar, OnEar, OverEar}
        private int _id;
        private int _impendance;
        private readonly string _manufacturer;
        private readonly int _maxVolume;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private string _type;

        public Headphones(int impendance, string manufacturer, int maxVolume, string model, double price, HeadphonesType type)
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

                _id = IDGenerator.NextID();
                _impendance = impendance;
                _manufacturer = manufacturer;
                _model = model;
                _price = price;
                _type = type.ToString();

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
                sb.AppendLine($"\tType: {_type}");
                sb.AppendLine($"\tImpendance: {_impendance}Ω");
                return sb.ToString();
            }
        }

        public int ID { get { return _id; } }

        public int Impendance { get { return _impendance; } }

        public string Manufacturer { get { return _manufacturer; } }

        public int MaxVolume { get { return _maxVolume; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

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
