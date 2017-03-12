using GeekStore.Warehouse.Model.Components;
using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Peripherals
{
    public class Monitor : Display, IItem
    {
        private readonly string _aspectRatio;
        private readonly string _manufacturer;
        private readonly int _maxRefreshRate;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly string _resolution;

        public Monitor(string aspectRatio, string manufacturer, int maxRefreshRate, string model, double price, string resolution)
                : base(aspectRatio, maxRefreshRate, resolution)
        {
            try
            {
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());
                    
                _manufacturer = manufacturer;
                _model = model;
                _price = price;
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
                sb.AppendLine($"\tResolution: {_resolution}");
                sb.AppendLine($"\tMax Refresh Rate: {_maxRefreshRate}Hz");
                sb.AppendLine($"\tAspect Ratio: {_aspectRatio}");
                return sb.ToString();
            }
        }

        public string Manufacturer { get { return _manufacturer; } }

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
