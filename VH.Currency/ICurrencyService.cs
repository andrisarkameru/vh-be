using System.Threading.Tasks;

namespace VH.Currency
{
    public interface ICurrencyService
    {
        Task<decimal> Convert(decimal ammount, string from, string to);
        Task<decimal> GetRate(string from, string to);
    }
}