using System; 

namespace Lab03 
{
    public class CabinBooking : Booking
    {
        
        ////// Constructor
        public CabinBooking(int pDuration){
            
            //La fecha de la reserva se genera aleatorimete
            var ReservatedDate = DateTime.Today.AddDays(new Random().Next(3,29)); //La fecha actual más un numero aleatorio  
            InitDate = ReservatedDate.ToString("d"); //Se convierte en un string la fecha
            //Se agregan los dias que decidío el usuario.
            LastDate = ReservatedDate.AddDays(pDuration).ToString("d");
            
            //El numero de habitaciones tambien es aleatorio xd
            Rooms = new Random().Next(2,4);

            //El precio minimo es de 35.99, segun cuantos dias se queda, el precio aumenta 
            Price = Math.Round(((new Random().NextDouble())* 50 * pDuration) + 35.99,2); 
           
            //Se procede al pago            
            this.Pay();
        }


        ////// Metodos
        public override void GiveAkey(){
            Console.WriteLine("\n## Hey!!, Here are your keys, take some wood there ");
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