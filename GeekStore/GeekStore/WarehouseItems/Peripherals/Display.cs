using System;
using System.Text;

namespace GeekStore.WarehouseItems.Peripherals
{
    class Display : IItem
    {
        private readonly string _aspectRatio;
        private readonly string _manufacturer;
        private readonly int _maxRefreshRate;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly string _resolution;

        public Display(string aspectRatio, string manufacturer, int maxRefreshRate, string model, double price, int quantity, string resolution)
        {
            try
            {
                if (string.IsNullOrEmpty(aspectRatio) || string.IsNullOrWhiteSpace(aspectRatio))
                {
                    throw new ArgumentNullException(aspectRatio);
                }
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                {
                    throw new ArgumentNullException(manufacturer);
                }
                if (maxRefreshRate <= 0)
                {
                    throw new ArgumentException("Display Max Refresh Rate cannot be less or equal to 0. Entered value: " + maxRefreshRate.ToString());
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
                if (string.IsNullOrEmpty(resolution) || string.IsNullOrWhiteSpace(resolution))
                {
                    throw new ArgumentNullException(resolution);
                }
                _aspectRatio = aspectRatio;
                _manufacturer = manufacturer;
                _maxRefreshRate = maxRefreshRate;
                _model = model;
                _price = price;
                _quantity = quantity;
                _resolution = resolution;
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
                sb.AppendLine("\tManufacturer: " + _manufacturer);
                sb.AppendLine("\tModel: " + _model);
                sb.AppendLine("\tResolution: " + _resolution);
                sb.AppendLine("\tMax Refresh Rate: " + _maxRefreshRate + "Hz");
                sb.AppendLine("\tAspect Ratio:" + _aspectRatio);
                return sb.ToString();
            }
        }

        public string AspectRatio { get { return _aspectRatio; } }

        public string Manufacturer { get { return _manufacturer; } }

        public int MaxRefreshRate { get { return _maxRefreshRate; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Resolution { get { return _resolution; } }

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
