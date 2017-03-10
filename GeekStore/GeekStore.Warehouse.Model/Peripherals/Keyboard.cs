using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Peripherals
{
    public class Keyboard : IItem
    {
        public enum KeyboardType { Membrane, Mechanical }
        private readonly bool _backLight;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly string _type;

        public Keyboard(bool backLight, string manufacturer, string model, double price, int quantity, KeyboardType type)
        {
            try
            {
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (quantity <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());

                _backLight = backLight;
                _manufacturer = manufacturer;
                _model = model;
                _price = price;
                _quantity = quantity;
                _type = type.ToString();
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
                sb.AppendLine($"\tBacklight: {_backLight}");
                sb.AppendLine($"\tType: {_type}");
                return sb.ToString();
            }
        }

        public bool BackLight { get { return _backLight; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Type { get { return _type; } }

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
