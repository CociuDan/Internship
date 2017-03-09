using System;
using System.Text;

namespace GeekStore.WarehouseItems.Components
{
    public class RAM : IItem
    {
        public enum RAMGeneration { DDR, DDR2, DDR3, DDR4 }
        private readonly int _capacity;
        private readonly int _frequency;
        private readonly string _generation;
        private readonly string _manufacturer;
        private readonly string _model;
        private double _price;
        private int _quantity;

        public RAM(int capacity, int frequency, RAMGeneration generation, string manufacturer, string model, double price, int quantity)
        {
            try
            {
                if (capacity != 512 && capacity != 1024 && capacity != 2048 && capacity != 4096 && capacity != 8192 && capacity != 16384)
                    throw new ArgumentException("RAM Capacity cannot be less than 512MB and higher than 16GB(16384MB). Entered value: " + capacity.ToString());

                if (frequency <= 0)
                    throw new ArgumentException("RAM Frequency cannot be less or equal to 0. Entered value: " + frequency.ToString());

                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (quantity <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());

                _capacity = capacity;
                _frequency = frequency;
                _generation = generation.ToString();
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
                sb.AppendLine($"\tGeneration: {_generation}");
                sb.AppendLine($"\tCapacity: {_capacity}MB");
                sb.AppendLine($"\tFrequency: {_frequency}");
                return sb.ToString();
            }
        }

        public int Capacity { get { return _capacity; } }

        public int Frequency { get { return _frequency; } }

        public string Generation { get { return _generation; } }

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
