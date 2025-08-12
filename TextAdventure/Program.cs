namespace TextAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Room entrance = new Room
            {
                Name = "Cave Entrance",
                Description = "You are at the dark entrance of a spooky cave. A cool breeze comes from the north."
            };

            Room mainCavern = new Room
            {
                Name = "Main Cavern",
                Description = "You are in a vast cavern. You see a small passage to the east and the way you came to the south."
            };

            Room darkPassage = new Room
            {
                Name = "Dark Passage",
                Description = "It's a tight, dark passage. It smells of damp earth. The main cavern is to the west."
            };

            entrance.North = mainCavern;
            mainCavern.South = entrance;
            mainCavern.East = darkPassage;
            darkPassage.West = mainCavern;

            // GAME SETUP 

            // Create the player and place them in the starting room.
            Player player = new Player();
            player.CurrentRoom = entrance;

            Console.WriteLine("Welcome to the Text Adventure!");

            Console.WriteLine("These are the command types: ");
            Console.WriteLine("go north");
            Console.WriteLine("go south");
            Console.WriteLine("go east");
            Console.WriteLine("go west");

            while (true)
            {
                // 1. Display current location
                Console.WriteLine("\n--------------------"); 
                Console.WriteLine("You are in: " + player.CurrentRoom.Name);
                Console.WriteLine(player.CurrentRoom.Description);

                // 2. Get user command
                
                Console.Write("> ");
                string command = Console.ReadLine().ToLower(); 

                // 3. Process the command
                if (command == "go north")
                {
                    if (player.CurrentRoom.North != null) // Check if an exit exists
                    {
                        player.CurrentRoom = player.CurrentRoom.North; // Move the player
                    }
                    else
                    {
                        Console.WriteLine("You can't go that way.");
                    }
                }
                else if (command == "go south")
                {
                    if (player.CurrentRoom.South != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.South;
                    }
                    else
                    {
                        Console.WriteLine("You can't go that way.");
                    }
                }
                else if (command == "go east")
                {
                    if (player.CurrentRoom.East != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.East;
                    }
                    else
                    {
                        Console.WriteLine("You can't go that way.");
                    }
                }
                else if (command == "go west")
                {
                    if (player.CurrentRoom.West != null)
                    {
                        player.CurrentRoom = player.CurrentRoom.West;
                    }
                    else
                    {
                        Console.WriteLine("You can't go that way.");
                    }
                }
                else if (command == "quit" || command == "exit")
                {
                    Console.WriteLine("Thanks for playing!");
                    break; // Exit the while loop
                }
                else
                {
                    Console.WriteLine("I don't understand that command.");
                }
            }

        }
    }
}

public class Room {
    public string Name { get; set; }
    public string Description { get; set; }

    //  properties will hold references to other Room objects.
    public Room North { get; set; }
    public Room South { get; set; }
    public Room East  { get; set; }
    public Room West { get; set;}
}

public class Player
{
    public Room CurrentRoom { get; set; }
}



