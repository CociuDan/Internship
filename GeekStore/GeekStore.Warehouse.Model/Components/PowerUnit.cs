using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekStore.Warehouse.Model.Components
{
    public abstract class PowerUnit
    {
        private readonly int _output;

        public PowerUnit(int output)
        {
            try
            {
                if (output <= 0)
                    throw new ArgumentException("PSU cannot have an output less or equal to 0W. Entered value: " + output.ToString());
                _output = output;
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

        public int Output { get { return _output; } }
    }
}
