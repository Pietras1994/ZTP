namespace App1.Classes
{
    public class Factory
    {
        public static ISignals CreateSignal(string type)
        {
            ISignals sg;
            switch (type)
            {
                case "m": return new MavSignals();
                case "a": return new MacdSignals();
                default: return new RsiSignals();
            }
        }
    }
}
