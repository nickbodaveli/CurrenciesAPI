namespace CurrencyAPI.Models
{
    public class Currency
    {
        public string code { get; set; }
        public int quantity { get; set; }
        public string rateFormated { get; set; }
        public string diffFormated { get; set; }
        public double rate { get; set; }
        public string name { get; set; }
        public double diff { get; set; }
        public DateTime date { get; set; }
        public DateTime validFromDate { get; set; }
    }
}
