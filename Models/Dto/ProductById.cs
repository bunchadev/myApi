using myApi.Models.Domain;

namespace myApi.Models.Dto
{
    public class ProductById
    {
        public string? statusCode { get; set; }
        public Product? data { get; set; }
        public bool check { get; set; }
        public bool checkType { get; set; }
    }
}