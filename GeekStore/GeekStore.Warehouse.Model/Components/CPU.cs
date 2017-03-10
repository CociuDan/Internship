using System;

namespace GeekStore.Warehouse.Model.Components
{
    public abstract class CPU
    {
        public enum CPUCores { MonoCore = 1, DualCore = 2, TriCore = 3, QuadCore = 4, HexaCore = 6, OctaCore = 8, DecaCore = 10}
        private readonly double _baseFrequency;
        private readonly double _boostFrequency;
        private readonly CPUCores _cores;
        private readonly string _manufacturer;
        private readonly string _model;
        private readonly int _tdp;
        private readonly int _threads;

        public CPU(double baseFrequency, double boostFrequency, CPUCores cores, string manufacturer, string model, int tdp, int threads)
        {
            try
            {
                if (baseFrequency <= 0)
                    throw new ArgumentException("CPU Base Frequency cannot be less than 0. Entered value: " + baseFrequency.ToString());

                if (boostFrequency < baseFrequency)
                    throw new ArgumentException("CPU Boost Frequency cannot be less than Base Frequency. Entered value: " + boostFrequency.ToString());

                if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
                    throw new ArgumentNullException(manufacturer);

                if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                    throw new ArgumentNullException(model);

                if (tdp <= 0)
                    throw new ArgumentException("TDP cannot be less or equal to 0. Entered value: " + tdp.ToString());

                if (threads != (int)cores && threads != ((int)cores * 2))
                    throw new ArgumentException("Number of Threads have to be equal or double of number of cores. Entered value: " + threads.ToString() + ". Number of cores entered: " + cores.ToString());

                _baseFrequency = baseFrequency;
                _boostFrequency = boostFrequency;
                _cores = cores;
                _manufacturer = manufacturer;
                _model = model;
                _tdp = tdp;
                _threads = threads;
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

        public double BaseFrequency { get { return _baseFrequency; } }
        public double BoostFrequency { get { return _boostFrequency; } }
        public CPUCores Cores { get { return _cores; } }
        public string Manufacturer { get { return _manufacturer; } }
        public string Model { get { return _model; } }
        public int Tdp { get { return _tdp; } }
        public int Threads { get { return _threads; } }

        public override string ToString()
        {
            return $"{Manufacturer} {Model} {Cores}/{Threads} @{BaseFrequency}-{BoostFrequency} {Tdp}W";
        }
    }
}
