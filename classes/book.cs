 using System; 
 
 namespace Lab03 
 {
     //Clase padre: es una reservacion en general, esta es la unica que toma las interfases
     //las demas solo las heredan
     public class Booking : IDoReservation, IDoArrive, IDoLeave
    {
         //Properties
        
            //todas las propiedades pueden ser modificadas por las clases hijas
            //y vistas desde todo el programa.
        public int BookingCode { get; protected set; }
        public string State { get; protected set; }
        public double Price {get; protected set;}
        public int Rooms {get; protected set;}
        public string InitDate {get; protected set;} //Primer día de la reservación 
        public string LastDate { get; protected set;}//Ultimo día de la reservación
        public string BookingType { get; protected set;} 

        // Metodos 
        public void Pay()
        {
            var noExit = true;
            var option = 0;
            Console.WriteLine($"\n--- Your payment will be: {this.Price}");
            Console.WriteLine("---- Select your payment method ");
            Console.WriteLine("\t1) Cash"); 
            Console.WriteLine("\t2) Card"); 
            Console.Write("\t Write an option: "); 
            
            do
            {
                option = Int32.Parse(Console.ReadLine());
                if(option==1){
                    //Si es efectivo entonces solo se procede al pago
                    Console.WriteLine("----- Payment succesfull!");
                    noExit = false;
                }
                else if(option == 2){
                    //Si es tarjeta entonces se piden los datos.
                    Console.WriteLine("---- Card method info: ");
                    Console.Write("Card number: "); Console.ReadLine();
                    Console.Write("CVC: "); Console.ReadLine();
                    Console.Write("Exp date: "); Console.ReadLine();
                    Console.WriteLine("----- Payment succesfull!");
                    noExit = false; 
                }
                else
                    Console.WriteLine("---- error: no option\n");
            }
            while(noExit);
            
            //Se da un codigo que luego se necesita para buscar la reservacion luego 
            this.BookingCode = new Random().Next(100000,199999);
            Console.WriteLine($"----- Your reservation code is: {BookingCode} \n");

            this.State = "Reserved";
            
        }
        //Estos metodos serán reescritos 
        public virtual void GiveAkey(){}
        public virtual void TakeTheKey(){}
        public void ShowInfo(){
            //Muestra toda la info de la reservacion.
            Console.WriteLine($"## Booking Info ## ");
            Console.WriteLine($"# Booking: {this.BookingType}");
            Console.WriteLine($"# Booking code: {this.BookingCode}");
            Console.WriteLine($"# Reserved rooms : {this.Rooms}");
            Console.WriteLine($"# Initial Date: {this.InitDate}"); 
            Console.WriteLine($"# Final Date: {this.LastDate}"); 
            Console.WriteLine(); 
        } 
    }
 } 