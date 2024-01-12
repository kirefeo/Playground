using System.ComponentModel.DataAnnotations;

namespace Lambda.InputDb.Models
{
    public class TestTable
    {
        public int Id { get; set; }

        public decimal DecimalA { get; set; }
        public decimal DecimalB { get; set; }
        [MaxLength(10)]
        public string Text { get; set; }
    }
}
