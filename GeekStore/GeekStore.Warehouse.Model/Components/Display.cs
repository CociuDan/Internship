using System;

namespace GeekStore.Warehouse.Model.Components
{
    public abstract class Display
    {
        private readonly string _aspectRatio;
        private readonly int _maxRefreshRate;
        private readonly string _resolution;

        public Display(string aspectRatio, int maxRefreshRate, string resolution)
        {
            try
            {
                if (string.IsNullOrEmpty(aspectRatio) || string.IsNullOrWhiteSpace(aspectRatio))
                    throw new ArgumentNullException("aspectRatio");

                if (maxRefreshRate < 60)
                    throw new ArgumentException("Display Max Refresh Rate cannot be less than 60Hz. Entered value: " + maxRefreshRate);

                if (string.IsNullOrEmpty(resolution) || string.IsNullOrWhiteSpace(resolution))
                    throw new ArgumentNullException("resolution");

                _aspectRatio = aspectRatio;
                _maxRefreshRate = maxRefreshRate;
                _resolution = resolution;
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

        public string AspectRatio { get { return _aspectRatio; } }
        public int MaxRefreshRate { get { return _maxRefreshRate; } }
        public string Resolution { get { return _resolution; } }
    }
}
