using System;
using System.Text;

namespace GeekStore.WarehouseItems.Components
{
    class DesktopCPU : CPU, IItem
    {
        private double _price;
        private int _quantity;
        private string _socket;

        public DesktopCPU(double baseFrequency, double boostFrequency, int cores, string manufacturer, string model, double price, int quantity, string socket, int tdp, int threads)
                   : base(baseFrequency, boostFrequency, cores, manufacturer, model, tdp, threads)
        {
            try
            {                
                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (quantity <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());

                if (string.IsNullOrEmpty(socket) || string.IsNullOrWhiteSpace(socket))
                    throw new ArgumentNullException("socket");

                _price = price;
                _quantity = quantity;
                _socket = socket;
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
                sb.AppendLine($"\tManufacturer: {Manufacturer}");
                sb.AppendLine($"\tModel: {Model}");
                sb.AppendLine($"\tCores: {Cores}");
                sb.AppendLine($"\tThreads: {Threads}");
                sb.AppendLine($"\tBaseClock: {BaseFrequency}");
                sb.AppendLine($"\tBoostClock: {BoostFrequency}");
                sb.AppendLine($"\tSocket: {Socket}");
                sb.AppendLine($"\tTDP: {Tdp}W");
                return sb.ToString();
            }
        }

        public string Manufacturer { get { return base.Manufacturer; } }

        public string Model { get { return base.Model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Socket { get { return _socket; } }

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
