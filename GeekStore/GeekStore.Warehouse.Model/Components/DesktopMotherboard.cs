using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Components
{
    public class DesktopMotherboard : Motherboard, IItem
    {
        private readonly string _chipset;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _pcieSlots;
        private double _price;
        private int _quantity;
        private readonly string _socket;

        public DesktopMotherboard(string chipset, string manufacturer, string model, int pcieSlots, double price, int ramSlots, string socket)
                           : base(ramSlots)
        {
            try
            {
                if (string.IsNullOrEmpty(chipset) || string.IsNullOrWhiteSpace(chipset))
                    throw new ArgumentNullException(chipset);

                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (pcieSlots <= 1)
                    throw new ArgumentException("Motherboard cannot have less than one PCI-E slot. Entered value: " + pcieSlots);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());          

                if (string.IsNullOrEmpty(socket) || string.IsNullOrWhiteSpace(socket))
                    throw new ArgumentNullException(socket);

                _chipset = chipset;
                _manufacturer = manufacturer;
                _model = model;
                _pcieSlots = pcieSlots;
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
                sb.AppendLine($"\tManufacturer: {_manufacturer}");
                sb.AppendLine($"\tModel: {_model}");
                sb.AppendLine($"\tChipset: {_chipset}");
                sb.AppendLine($"\tSocket: {_socket}");
                sb.AppendLine($"\tPCI-E Slots: {_pcieSlots}");
                sb.AppendLine($"\tRAM Slots: {RamSlots}");
                return sb.ToString();
            }
        }

        public string Chipset { get { return _chipset; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public int PcieSlots { get { return _pcieSlots; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public string Socket { get { return _socket; } }

        public void AddToWarehouse(int incomingQuantity)
        {
            if (incomingQuantity <= 0)
                throw new ArgumentException("You cannot add less than one item to warehouse. Enterd value: " +  incomingQuantity.ToString());
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
