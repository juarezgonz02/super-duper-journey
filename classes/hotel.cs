using System; 

namespace Lab03 
{
    //El funcionamiento es el mismo que la clase CabinBooking
    public class HotelBooking : Booking
    {
        public HotelBooking(int pDuration){
            var ReservatedDate = DateTime.Today.AddDays(new Random().Next(3,29)); 
            InitDate = ReservatedDate.ToString("d");
            LastDate = ReservatedDate.AddDays(pDuration).ToString("d");
            Rooms = new Random().Next(2,4);
            Price = Math.Round((new Random().NextDouble())*75 + 60.99,2);
            
            //Se procede al pago
            this.Pay();
        }
        public override void GiveAkey(){
            Console.WriteLine("\n## Hey!!, Here are your keys");
            Console.WriteLine("## Have a good day!\n");
            this.State = "Arrived";
        }
        public override void TakeTheKey(){
            Console.WriteLine("\n Good Bye! ");
            Console.WriteLine("You MUST left the key given at arriving\n");
            this.State = "Leaved";    
        }
    }
}