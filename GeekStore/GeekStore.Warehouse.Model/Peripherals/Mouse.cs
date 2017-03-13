using GeekStore.Model.Infrastucture;
using System;
using System.Text;

namespace GeekStore.Model.Peripherals
{
    public class Mouse : IItem
    {
        public enum MouseType { Optical, Laser, Mechanical }
        private readonly int _dpi;
        private readonly int _id;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly string _type;

        public Mouse(int dpi, string manufacturer, string model, double price, MouseType type)
        {
            try
            {
                if (dpi <= 0)
                    throw new ArgumentException("Mouse cannot have a DPI less or equal to 0. Entered value: " + dpi.ToString());

                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                _dpi = dpi;
                _id = IDGenerator.NextID();
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
                sb.AppendLine($"\tDPI: {_dpi}");
                sb.AppendLine($"\tType: {_type}");
                return sb.ToString();
            }
        }

        public int Dpi { get { return _dpi; } }

        public int ID { get { return _id; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Type { get { return _type; } }

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
