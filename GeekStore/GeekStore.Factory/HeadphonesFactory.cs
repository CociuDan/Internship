﻿using GeekStore.Warehouse.Model.Peripherals;

namespace GeekStore.Factory
{
    public class HeadphonesFactory
    {
        public static Headphones BuildHeadphones()
        {
            return new Headphones(16, "Philips", 126, "A5 PROi", 350, Headphones.HeadphonesType.OverEar);
        }

        public static Headphones BuildHeadphones(int impendance, string manufacturer, int maxVolume, string model, double price, Headphones.HeadphonesType headphonesType)
        {
            return new Headphones(impendance, manufacturer, maxVolume, model, price, headphonesType);
        }
    }
}
