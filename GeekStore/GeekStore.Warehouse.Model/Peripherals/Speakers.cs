using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Peripherals
{
    public class Speakers : IItem
    {
        private readonly string _configuration;
        private readonly string _manufacturer;
        private readonly int _maxVolume;
        private readonly string _model;
        private double _price;
        private int _quantity;

        public Speakers(string configuration, string manufacturer, int maxVolume, string model, double price, int quantity)
        {
            try
            {
                if (configuration != "1.0" && configuration != "2.0" && configuration != "2.1" && configuration != "3.1" && configuration != "4.0"
                    && configuration != "4.1" && configuration != "5.1" && configuration != "6.1" && configuration != "7.1")
                    throw new ArgumentException("Speakers unkown configuration. Entered value: " + configuration.ToString());

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

                _configuration = configuration;
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

        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"\tManufacturer: {_manufacturer}");
                sb.AppendLine($"\tModel: {_model}");
                sb.AppendLine($"\tConfiguration: {_configuration}");
                sb.AppendLine($"\tMax Volume: {_maxVolume}Db");
                return sb.ToString();
            }
        }

        public string Configuration { get { return _configuration; } }

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
