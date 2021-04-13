using System; 

namespace Lab03 
{
    //El funcionamiento es el mismo que la clase CabinBooking
    public class HutBooking : Booking
    {
        public HutBooking(int pDuration){
            var ReservatedDate = DateTime.Today.AddDays(new Random().Next(3,29)); 
            InitDate = ReservatedDate.ToString("d");
            LastDate = ReservatedDate.AddDays(pDuration).ToString("d");
            Rooms = new Random().Next(2,4);
            Price = Math.Round(((new Random().NextDouble())* 25 * pDuration) + 20.99,2);

            //Se procede al pago
            this.Pay();
        }
        public override void GiveAkey(){
            Console.WriteLine("\n## Hey!!, Here are your keys, take some wood there and here are some aromatic oils. ");
            Console.WriteLine("## Be carefull!\n");
            this.State = "Arrived";
        }

        public override void TakeTheKey(){
            Console.WriteLine("\n Good Bye! ");
            Console.WriteLine("You MUST left the key given at arriving\n");            
            this.State = "Leaved";    
        }
    }
} 