using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Components
{
    public class Cooler : IItem
    {
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly string _socket;
        private readonly int _maxTdp;

        public Cooler(string manufacturer, string model, double price, string socket, int maxTdp)
        {
            try
            {
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (string.IsNullOrEmpty(socket) || string.IsNullOrWhiteSpace(socket))
                    throw new ArgumentNullException(socket);

                if (maxTdp <= 0)
                    throw new ArgumentException("MaxTDP is less or equal to 0. Entered value: " + maxTdp.ToString());

                _manufacturer = manufacturer;
                _model = model;
                _price = price;
                _socket = socket;
                _maxTdp = maxTdp;
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
                sb.AppendLine($"\tSocket: {_socket}");
                sb.AppendLine($"\tMax TDP: {_maxTdp}W");
                return sb.ToString();
            }
        }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Socket { get { return _socket; } }

        public int Tdp { get { return _maxTdp; } }

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
