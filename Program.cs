using System;
using System.Collections.Generic;

namespace Lab03
{
    class Program
    {
        //Lista que guarda las reservaciones
        public static List<Booking> Reservations = new List<Booking>();
        static void Main(string[] args)
        {
            var doNotExit = true; 
            //// MENU 
            Console.WriteLine("## WELCOME TO 'Gualterpistola Booking Services' ##");
            do
            {
                Console.WriteLine("Menu: ");
                var option = 0;
                Console.WriteLine("\tSelect a option:");
                Console.WriteLine("\t1) Make a Reservation");
                Console.WriteLine("\t2) Arrive to the reserved room");
                Console.WriteLine("\t3) Leave the reserved room");
                Console.WriteLine("\t4) Show all reserved rooms");
                Console.Write("Write your option: ");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:   
                        MakeAReservation();
                        break;
                    case 2:
                        ArriveToReservedRoom();
                        break;
                    case 3:
                        LeaveReservedRoom();
                        break;
                    case 4:
                        ShowAll();
                        break;
                    default:
                        Console.WriteLine("error: no option");
                        break; 
                }
            } while (doNotExit); 
        }

        static void LeaveReservedRoom()
        {
            Console.Write("\nWrite your reservation code: ");
            var BookingCode = Int32.Parse(Console.ReadLine());

            // Se debe buscar una reservacion que coincida con el codigo y que ya este en uso.
            var ArrivingBooking = Reservations.Find(Booking => {
                if(Booking.BookingCode == BookingCode && Booking.State == "Arrived")
                    return true;
                else 
                    return false;
                    //Si no se encuentra ninguna reservacion 
                    //entonces ArrivingBooking se convierte en null  
            });

             if(ArrivingBooking == null)
                Console.WriteLine("error: Code not found or not arrived yet");
            else 
                //Si no es null se piden las cosas dadas
                ArrivingBooking.TakeTheKey();
        }

        static void ArriveToReservedRoom()
        {

            //Se pide un codigo al usuario y se busca si 
            // se encuentra se da la llave de la habitacion
            Console.Write("\nWrite your code to enter your reservation: ");
            var BookingCode = Int32.Parse(Console.ReadLine());
            var ArrivingBooking = Reservations.Find(Booking => {
                if(Booking.BookingCode == BookingCode)
                    return true;
                else 
                    return false;
                     //Si no se encuentra ninguna reservacion 
                    //entonces ArrivingBooking se convierte en null  
            });

            if(ArrivingBooking == null)
                Console.WriteLine("error: Code not found");
            else 
                //Se da una llave
                ArrivingBooking.GiveAkey();

           
        }

        static void MakeAReservation(){
            var option = 0;
            //MENU DE LA RESERVACION 
            Console.WriteLine("\nHow many days your reservation will be for? ");
            Console.Write("Days: ");
            var BookingDuration = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("\nWhat kind of Booking are you looking for?");
            Console.WriteLine("\t1) Cabin"); 
            Console.WriteLine("\t2) Hotel"); 
            Console.WriteLine("\t3) Hut"); 
            
            // Se pide un tipo de reservacion y dependiendo se agrega a la lista
            var noExit = true;
            do
            {
                Console.Write("\t Write your answer: ");
                option = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    //Cabin case
                    case 1:
                        Reservations.Add(new CabinBooking(BookingDuration));
                        noExit = false;
                        break;

                    //Hut case
                    case 2:
                        Reservations.Add(new HutBooking(BookingDuration));
                        noExit = false;
                        break;

                    //Hotel case
                    case 3:
                        Reservations.Add(new HotelBooking(BookingDuration));
                        noExit = false;
                        break;

                    //Error case
                    default:
                        Console.WriteLine("error: no option selected");
                        break;
                }
            }
            while (noExit);
        }
        static void ShowAll(){

            Console.WriteLine("\n##### ALL RESERVATIONS ##### \n"); 

            //Todas las reservaciones
            Console.WriteLine("### Reservations \n");
            Reservations.ForEach(reservation=>{
                if(reservation.State.Equals("Reserved"))
                    reservation.ShowInfo();  
            });
            Console.WriteLine();
            //Todas las reservaciones que ya se han ocupado
            Console.WriteLine("### Arrived Reservations \n");
            Reservations.ForEach(reservation=>{
                if(reservation.State.Equals("Arrived"))
                    reservation.ShowInfo();  
            });
            Console.WriteLine();

            //Todas las reservaciones pasadas 
            Console.WriteLine("### Leaved Reservations \n");
            Reservations.ForEach(reservation=>{
                
                if(reservation.State.Equals("Leaved"))
                    reservation.ShowInfo();  
            });
            Console.WriteLine("#############################");

        }
    }
}   
