namespace MVC_Sepet.Models.Entity
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;

        }
        //Bir sepetin neleri olur?
        public int Id { get; set; }
        public short Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}
