using System;

namespace RepoHwConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program Vairables
            Random rand = new Random();
            bool programRun = true;
            int gameState = 0;
            string userInput = null;
            //Game Variables
            int eventState = 0;
            string gameLoseText = null;
            int eventSelector = 0;
            EventOption currentEvent = null;
            int stepEffort = 0;
            int distance = 0;
            int electrolytes = 50;
            int hydration = 50;
            int heartRate = 0;
            int fatigue = 0;
            //Event Options
                //Nothing
                EventOption eventNothing = new EventOption();
                eventNothing.optString = "You jog for a short time without interruption";
                eventNothing.optResult = "Keep on going, we beleive in you!";
                eventNothing.electroMod = 0;
                eventNothing.hydraMod = 0;
                eventNothing.heartMod = 0;
                eventNothing.fatiMod = 0;
                //Gatorade
                EventOption eventGatorade = new EventOption();
                eventGatorade.optString = "An extatic fan holds out gatorade as you pass them by";
                eventGatorade.optResult = "You gulp it down and boy was it refreshing";
                eventGatorade.electroMod = 10;
                eventGatorade.hydraMod = 5;
                eventGatorade.heartMod = 0;
                eventGatorade.fatiMod = 0;
                //Water
                EventOption eventWater = new EventOption();
                eventWater.optString = "An extatic fan holds out water as you pass them by";
                eventWater.optResult = "You gulp it down and boy was it refreshing";
                eventWater.electroMod = 0;
                eventWater.hydraMod = 15;
                eventWater.heartMod = 0;
                eventWater.fatiMod = 0;
                //Hill
                EventOption eventHill = new EventOption();
                eventHill.optString = "As you continue jogging, you reach an incline";
                eventHill.optResult = "Your calves are burning but you make it up the hill";
                eventHill.electroMod = -5;
                eventHill.hydraMod = -5;
                eventHill.heartMod = 5;
                eventHill.fatiMod = 5;
                //Mental
                EventOption eventMental = new EventOption();
                eventMental.optString = "You continue jogging uninterrupted, however you have a crisis of faith";
                eventMental.optResult = "Calm down, Jogging Simulator isn't real, Jogging Simulator can't hurt you";
                eventMental.electroMod = 0;
                eventMental.hydraMod = 0;
                eventMental.heartMod = 10;
                eventMental.fatiMod = 0;
            //Method Reset User Input
            void InputReset()
            {
                userInput = null;
            }
            //Program Loop
            while(programRun == true)
            {
                //Start Menu
                while (gameState == 0)
                {
                    //Menu Text
                    Console.WriteLine("||Jogging Simulator||");
                    Console.WriteLine();
                    Console.WriteLine("Start Game 's'");
                    Console.WriteLine("Exit Game 'e'");
                    Console.WriteLine();
                    Console.WriteLine("Enter a Command...");
                    //Menu Commands
                    userInput = Console.ReadLine();
                    if(userInput == "s")
                    {
                        gameState = 1;
                        InputReset();

                        distance = 0;
                        electrolytes = 50;
                        hydration = 50;
                        heartRate = 60;
                        fatigue = 0;
                    }
                    if (userInput == "e")
                    {
                        Environment.Exit(1);
                        InputReset();
                    }
                    Console.Clear();
                }
                //Game State
                while (gameState == 1)
                {
                    //Heads Up Display
                    Console.WriteLine("Distance Run: " + (distance/1000) + "km, Heart Rate: " + heartRate + ", Hydration: " + hydration + ", Electrolytes: " + electrolytes + ", Fatigue: " + fatigue);
                    Console.WriteLine("_________________________________________________________________________________________");
                    //Game Step
                    switch(eventState)
                    {
                        //Event
                        case 0:
                            //Select Event Type
                            eventSelector = rand.Next(4);
                            switch (eventSelector)
                            {
                                //Event Nothing
                                case 0:
                                    currentEvent = eventNothing;
                                    break;
                                //Event Gatorade
                                case 1:
                                    currentEvent = eventGatorade;
                                    break;
                                //Event Water
                                case 2:
                                    currentEvent = eventWater;
                                    break;
                                //Event Hill
                                case 3:
                                    currentEvent = eventHill;
                                    break;
                                //Event Mental
                                case 4:
                                    currentEvent = eventMental;
                                    break;
                            }
                            //Present Event
                            Console.WriteLine(currentEvent.optString);
                            Console.WriteLine(currentEvent.optResult);
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue");
                            Console.ReadLine();
                            //Change Stats
                            fatigue += currentEvent.fatiMod;
                            hydration += currentEvent.hydraMod;
                            electrolytes += currentEvent.electroMod;
                            heartRate += currentEvent.heartMod;
                            eventState = 1;
                            break;
                        //Effort
                        case 1:
                            //Effort Input
                            Console.WriteLine("How much effort will you put in to your jogging?");
                            Console.WriteLine("please enter a number between 0 and 110");
                            userInput = Console.ReadLine();
                            //Effort Calc
                            stepEffort = Convert.ToInt32(userInput);
                            distance += (stepEffort * 10);
                            fatigue += (stepEffort / 50);
                            hydration -= (stepEffort / 25);
                            electrolytes -= (stepEffort / 25);
                            heartRate += ((stepEffort - 50) / 25);
                            eventState = 0;
                            break;
                    }
                    //Check Game Lost
                    if (fatigue >= 100 || hydration <= 0 || electrolytes <= 0 || heartRate > 150)
                    {
                        gameState = 2;
                        if (fatigue >= 100) gameLoseText = "You fainted from exhaustion";
                        if (hydration < 0) gameLoseText = "You fainted from dehydration";
                        if (electrolytes < 0) gameLoseText = "You straight up died";
                        if (heartRate > 150) gameLoseText = "You had a heart attack";
                    }
                    Console.Clear();


                }
                //Lost Game
                if(gameState == 2)
                {
                    Console.WriteLine(gameLoseText);
                    Console.WriteLine();
                    Console.WriteLine("Total Distance: " + distance + " km");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to the menu");
                    Console.ReadLine();
                    gameState = 0;
                }
            }
        }
    }
}
