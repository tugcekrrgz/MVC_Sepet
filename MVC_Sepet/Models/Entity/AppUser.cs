namespace MVC_Sepet.Models.Entity
{
    public class AppUser
    {
        public AppUser() 
        {
            Random rnd=new Random();
            Id=rnd.Next(10000,99999).ToString();
        }
        public string Id { get; set; }
        public string AdSoyad { get; set; }
        public string KrediKart { get; set; }
        public string KrediKartTarih { get; set; }
        public string CVV { get; set; }
    }
}
