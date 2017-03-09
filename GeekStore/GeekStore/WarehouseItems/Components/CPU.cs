using System;

namespace GeekStore.WarehouseItems
{
    public abstract class CPU
    {
        private readonly double _baseFrequency;
        private readonly double _boostFrequency;
        private readonly int _cores;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _tdp;
        private readonly int _threads;

        public CPU(double baseFrequency, double boostFrequency, int cores, string manufacturer, string model, int tdp, int threads)
        {
            if (baseFrequency <= 0)
                throw new ArgumentException("CPU Base Frequency cannot be less than 0. Entered value: " + baseFrequency.ToString());

            if (boostFrequency < baseFrequency)
                throw new ArgumentException("CPU Boost Frequency cannot be less than Base Frequency. Entered value: " + boostFrequency.ToString());

            if (cores != 1 && cores != 2 && cores != 3 && cores != 4 && cores != 6 && cores != 8 && cores != 10)
                throw new ArgumentException("Number of cores entered is invalid. Entered value: " + cores.ToString());

            if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentNullException(manufacturer);

            if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException(model);

            if (tdp <= 0)
                throw new ArgumentException("TDP cannot be less or equal to 0. Entered value: " + tdp.ToString());

            if (threads != cores && threads != (cores * 2))
                throw new ArgumentException("Number of Threads have to be equal or double of number of cores. Entered value: " + threads.ToString() + ". Number of cores entered: " + cores.ToString());

            _baseFrequency = baseFrequency;
            _boostFrequency = boostFrequency;
            _cores = cores;
            _manufacturer = manufacturer;
            _model = model;
            _tdp = tdp;
            _threads = threads;
        }

        protected double BaseFrequency { get { return _baseFrequency; } }
        protected double BoostFrequency { get { return _boostFrequency; } }
        protected int Cores { get { return _cores; } }
        protected string Manufacturer { get { return _manufacturer; } }
        protected string Model { get { return _model; } }
        protected int Tdp { get { return _tdp; } }
        protected int Threads { get { return _threads; } }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} {Cores}/{Threads} @{BaseFrequency}-{BoostFrequency} {Tdp}W";
        }
    }
}
