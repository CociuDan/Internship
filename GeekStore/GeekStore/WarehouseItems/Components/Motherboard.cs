﻿using System;
using System.Text;

namespace GeekStore.WarehouseItems.Components
{
    class Motherboard : IItem
    {
        private readonly string _chipset;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _pcieSlots;
        private double _price;
        private int _quantity;
        private readonly int _ramSlots;
        private readonly string _socket;

        public Motherboard(string chipset, string manufacturer, string model, int pcieSlots, double price, int quantity, int ramSlots, string socket)
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

                if (quantity <= 0)
                    throw new ArgumentException("Quantity cannot be less or equal to 0. Entered value: " + quantity.ToString());

                if (ramSlots <= 0)
                    throw new ArgumentException("Motherboard cannot have less than one RAM slot. Entered value: " + ramSlots);

                if (string.IsNullOrEmpty(socket) || string.IsNullOrWhiteSpace(socket))
                    throw new ArgumentNullException(socket);

                _chipset = chipset;
                _manufacturer = manufacturer;
                _model = model;
                _pcieSlots = pcieSlots;
                _price = price;
                _quantity = quantity;
                _ramSlots = ramSlots;
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
                sb.AppendLine($"\tManufacturer: {_manufacturer}");
                sb.AppendLine($"\tModel: {_model}");
                sb.AppendLine($"\tChipset: {_chipset}");
                sb.AppendLine($"\tSocket: {_socket}");
                sb.AppendLine($"\tPCI-E Slots: {_pcieSlots}");
                sb.AppendLine($"\tRAM Slots: {_ramSlots}");
                return sb.ToString();
            }
        }

        public string Chipset { get { return _chipset; } }

        public string Manufacturer { get { return _manufacturer; } }

        public string Model { get { return _model; } }

        public int PcieSlots { get { return _pcieSlots; } }

        public double Price { get { return _price; } }

        public int Quantity { get { return _quantity; } }

        public int RamSlots { get { return _ramSlots; } }

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
