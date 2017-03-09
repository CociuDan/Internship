using System;
using System.Text;

namespace GeekStore.WarehouseItems.Components
{
    class GPU : IItem
    {
        private readonly string _architecture;
        private readonly int _interfaceWidth;
        private readonly string _manufacturer;
        private readonly string _memoryInterface;
        private readonly string _model;
        private double _price;
        private int _quantity;
        private readonly int _tdp;
        private readonly int _vram;

        public GPU(string architecture, int interfaceWidth, string manufacturer, string memoryInterface, string model, double price, int quantity, int tdp, int vram)
        {
            try
            {
                if (string.IsNullOrEmpty(architecture) || string.IsNullOrWhiteSpace(architecture))
                {
                    throw new ArgumentNullException(architecture);
                }
                if (interfaceWidth <= 0 || interfaceWidth % 2 != 0)
                {
                    throw new ArgumentException("GPU Interface Width cannot be less or equal to 0 or not divided by 2. Entered value: " + interfaceWidth);
                }
                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                {
                    throw new ArgumentNullException(manufacturer);
                }
                if (string.IsNullOrEmpty(memoryInterface) || string.IsNullOrWhiteSpace(memoryInterface))
                {
                    throw new ArgumentNullException(memoryInterface);
                }
                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                {
                    throw new ArgumentNullException(model);
                }
                if (price <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to 0. Entered value: " + price.ToString());
                }
                if (quantity <= 0)
                {
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());
                }
                if (tdp <= 0)
                {
                    throw new ArgumentException("TDP cannot be less or equal to 0. Entered value: " + tdp.ToString());
                }
                if (vram <= 0 || vram % 2 != 0)
                {
                    throw new ArgumentException("GPU VRAM cannot be less or equal to 0 or not divided by 2. Entered value: " + vram);
                }
                _architecture = architecture;
                _interfaceWidth = interfaceWidth;
                _manufacturer = manufacturer;
                _memoryInterface = memoryInterface;
                _model = model;
                _price = price;
                _quantity = quantity;
                _tdp = tdp;
                _vram = vram;
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

        public static explicit operator GPU(string v)
        {
            string[] gpuInString = v.Split(' ');
            return new GPU(gpuInString[0], int.Parse(gpuInString[1]), gpuInString[2], gpuInString[3], gpuInString[4], double.Parse(gpuInString[5]), int.Parse(gpuInString[6]), int.Parse(gpuInString[7]), int.Parse(gpuInString[8]));
        }

        public string Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\tManufacturer: " + _manufacturer);
                sb.AppendLine("\tModel: " + _model);
                sb.AppendLine("\tArchitecture: " + _architecture);
                sb.AppendLine("\tInterface Width: " + _interfaceWidth + "bit");
                sb.AppendLine("\tMemory Interface: " + _memoryInterface);
                sb.AppendLine("\tVRAM: " + _vram + "GB");
                sb.AppendLine("\tTDP: " + _tdp + "W");
                return sb.ToString();
            }
        }

        public string Architecture { get { return _architecture; } }

        public int InterfaceWidth { get { return _interfaceWidth; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string MemoryInterface { get { return _memoryInterface; } }

        public string Model { get { return _model; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public int Tdp { get { return _tdp; } }

        public int Vram { get { return _vram; } }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}", Architecture, InterfaceWidth, Manufacturer, MemoryInterface, Model, Price, Quantity, Tdp, Vram));
            return sb.ToString();
        }
    }
}
