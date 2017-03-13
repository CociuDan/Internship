using System;

namespace GeekStore.Model.Components
{
    public abstract class Motherboard
    {
        private readonly int _ramSlots;
        public Motherboard(int ramSlots)
        {
            try
            {
                if (ramSlots < 1)
                    throw new ArgumentException("Motherboard cannot have less than one RAM slot. Entered value: " + ramSlots);

                _ramSlots = ramSlots;
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

        public int RamSlots { get { return _ramSlots; } }
    }
}
