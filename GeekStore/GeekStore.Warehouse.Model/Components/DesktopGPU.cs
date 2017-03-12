using System;
using System.Text;

namespace GeekStore.Warehouse.Model.Components
{
    public class DesktopGPU : GPU, IItem
    {
        private readonly string _architecture;
        private double _price;
        private int _quantity;
        private readonly int _tdp;

        public DesktopGPU(string architecture, int interfaceWidth, string manufacturer, string memoryInterface, string model, double price, int tdp, int vram)
                   : base(interfaceWidth, manufacturer, memoryInterface, model, vram)
        {
            try
            {
                if (string.IsNullOrEmpty(architecture) || string.IsNullOrWhiteSpace(architecture))
                    throw new ArgumentNullException(architecture);

                if (price <= 0)
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());

                if (tdp <= 0)
                    throw new ArgumentException("TDP cannot be less or equal to 0. Entered value: " + tdp.ToString());

                _architecture = architecture;
                _price = price;
                _tdp = tdp;
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
                sb.AppendLine($"\tArchitecture: {_architecture}");
                sb.AppendLine($"\tInterface Width: {InterfaceWidth}bit");
                sb.AppendLine($"\tMemory Interface: {MemoryInterface}");
                sb.AppendLine($"\tVRAM: {Vram}GB");
                sb.AppendLine($"\tTDP: {_tdp}W");
                return sb.ToString();
            }
        }

        public string Architecture { get { return _architecture; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public int Tdp { get { return _tdp; } }


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