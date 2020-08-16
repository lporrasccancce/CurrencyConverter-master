
namespace CurrencyConverterLibreria
{
    public abstract class BaseCurrency
    {
        public abstract decimal InUS
        {
            get;
        }
    }

    public class UsdCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 1; }
        }

        public override string ToString()
        {
            return "USD";
        }
    }

    public class PenCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 3.53M; }
        }

        public override string ToString()
        {
            return "PEN";
        }
    }

    public class EurCurrency : BaseCurrency
    {
        public override decimal InUS
        {
            get { return 0.85M; }
        }

        public override string ToString()
        {
            return "EUR";
        }
    }

    public class ConvertibleCurrency
    {
        private readonly decimal amount;
        private readonly BaseCurrency currency;
        public ConvertibleCurrency(BaseCurrency type, decimal val)
        {
            currency = type;
            amount = val;
        }

        public static decimal CurrencyConvert(decimal amount, BaseCurrency fromCur,
                  BaseCurrency toCur)
        {
                        return new ConvertibleCurrency(fromCur, amount).ConvertTo(toCur);
        }

         public decimal ConvertTo(BaseCurrency type)
        {
            decimal converted = ConvertToUS();
            converted = ConvertFromUS(type, converted);
            return converted;
        }

        private decimal ConvertToUS()
        {
            decimal converted = 0;
            converted = amount / currency.InUS;
            return converted;
        }

        private decimal ConvertFromUS(BaseCurrency type, decimal USAmount)
        {
            decimal converted = 0;
            converted = USAmount * type.InUS;
            return converted;
        }
    }
}
