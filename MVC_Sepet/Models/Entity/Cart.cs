namespace MVC_Sepet.Models.Entity
{
    public class Cart
    {
        //public List<CartItem> CartItems=new List<CartItem>();

        /*
        public Dictionary<int,string> Plakalar=new Dictionary<int,string>();
        public Cart()
        {
            Plakalar.Add(34,"İstanbul");
            Plakalar.Add(6,"Ankara");
        }
        */

        public Dictionary<int,CartItem> _myCart=new Dictionary<int,CartItem>();
        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.Id))
            {
                _myCart[cartItem.Id].Quantity += 1;
                return;
            }
            _myCart.Add(cartItem.Id,cartItem);
        }
    }
}
