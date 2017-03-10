using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Components
{
    public class Case : IItem
    {
        public enum FormFactorTypes { FullTower, MidTower, MiniTower, SFF, MicroATX, MiniITX}
        private readonly string _formFactor;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;

        public Case(FormFactorTypes formFactor, string manufacturer, string model, double price, int quantity)
        {
            try
            {
                if(string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (quantity <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());

                    _formFactor = formFactor.ToString();
                    _manufacturer = manufacturer;
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
                sb.AppendLine($"\tForm Factor: {_formFactor}");
                return sb.ToString();
            }
        }

        public string FormFactor { get { return _formFactor; } }

        public string Manufacturer { get { return _manufacturer; } }

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
