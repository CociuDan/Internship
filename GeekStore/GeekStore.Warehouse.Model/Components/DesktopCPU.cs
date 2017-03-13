using GeekStore.Model.Infrastucture;
using System;
using System.Text;

namespace GeekStore.Model.Components
{
    public class DesktopCPU : CPU, IItem
    {
        private readonly int _id;
        private double _price;
        private int _quantity;
        private string _socket;

        public DesktopCPU(double baseFrequency, double boostFrequency, CPUCores cores, string manufacturer, string model, double price, string socket, int tdp, int threads)
                   : base(baseFrequency, boostFrequency, cores, manufacturer, model, tdp, threads)
        {
            try
            {                
                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (string.IsNullOrEmpty(socket) || string.IsNullOrWhiteSpace(socket))
                    throw new ArgumentNullException("socket");

                _id = IDGenerator.NextID();
                _price = price;
                _socket = socket;

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

        public int ID { get { return _id; } }

        public string Manufacturer { get { return base.Manufacturer; } }

        public string Model { get { return base.Model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Socket { get { return _socket; } }

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
