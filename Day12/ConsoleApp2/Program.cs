using static TemperatureProg.Cooler;

namespace TemperatureProg
{
    public delegate void Del(int Temperature);

    public class Heater
    {
        private int _heaterTemp;

        public int HeaterTemp
        {
            set
            {
                _heaterTemp = value;
            }
            get
            { 
                return _heaterTemp;
            }
        }

        public void Hhandler(int Temperature)
        {
            if (Temperature < _heaterTemp) {
                Console.WriteLine("Heater : ON");
            }
            else
            {
                Console.WriteLine("Heater : OFF");
            }
        }
    }

    public class Cooler
    {
        private int _coolerTemp;

        public int CoolerTemp
        {
            set
            {
                _coolerTemp = value;
            }
            get 
            {
                return _coolerTemp;
            }
        }

        public void Chandler(int Temperature)
        {
            if (Temperature > _coolerTemp)
            {
                Console.WriteLine("Cooler : ON");
            }
            else
            {
                Console.WriteLine("Cooler : OFF");
            }
        }

        public class Thermostat
        {
            public event Del OnTempratureChange;

            private int _thermostatTemp;
            public int ThermostatTemp
            {
                set
                {
                    if (_thermostatTemp != value)
                    {
                        _thermostatTemp = value;


                        if (OnTempratureChange != null)
                        {
                            OnTempratureChange(_thermostatTemp);
                        }
                    }
                }
                get { return _thermostatTemp; }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Cooler cooler = new Cooler();
            Heater heater = new Heater();
            cooler.CoolerTemp = 20;
            heater.HeaterTemp = 10;

            thermostat.OnTempratureChange += cooler.Chandler;
            thermostat.OnTempratureChange += heater.Hhandler;

            thermostat.ThermostatTemp = 30;
        }
    }
}
