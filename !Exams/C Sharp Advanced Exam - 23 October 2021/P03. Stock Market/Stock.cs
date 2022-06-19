using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        public string CompanyName { get => companyName; set => companyName = value; }

        public string Director { get => director; set => director = value; }

        public decimal PricePerShare { get => pricePerShare; set => pricePerShare = value; }

        public int TotalNumberOfShares { get => totalNumberOfShares; set => totalNumberOfShares = value; }

        public decimal MarketCapitalization { get => marketCapitalization; set => marketCapitalization = value; }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
            this.MarketCapitalization = PricePerShare * TotalNumberOfShares;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Price per share: ${PricePerShare}");
            sb.AppendLine($"Market capitalization: ${MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
