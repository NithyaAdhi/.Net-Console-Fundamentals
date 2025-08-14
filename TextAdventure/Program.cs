namespace TextAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WORLD CREATION 
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

            mainCavern.ItemsInRoom.Add("a rusty key");

            Room darkPassage = new Room
            {
                Name = "Dark Passage",
                Description = "It's a tight, dark passage. It smells of damp earth. The main cavern is to the west."
            };

            Room treasureRoom = new Room
            {
                Name = "Treasure Room",
                Description = "You've found it! A hidden chamber filled with glittering gold and jewels."
            };
            treasureRoom.ItemsInRoom.Add("the ancient treasure");

            // --- LINK ROOMS ---
            entrance.North = mainCavern;
            mainCavern.South = entrance;
            mainCavern.East = darkPassage;
            darkPassage.West = mainCavern;
            darkPassage.East = treasureRoom; 

            // --- GAME SETUP ---
            Player player = new Player();
            player.CurrentRoom = entrance;

            Console.WriteLine("Welcome to the Text Adventure!");

            // --- MAIN GAME LOOP ---
                while (true)
                {
                    // 1. Display current location
                    Console.WriteLine("\n--------------------");
                    Console.WriteLine("You are in: " + player.CurrentRoom.Name);
                    Console.WriteLine(player.CurrentRoom.Description);
                    if (player.CurrentRoom.ItemsInRoom.Count > 0)
                    {
                        Console.WriteLine("You see here: " + string.Join(", ", player.CurrentRoom.ItemsInRoom));
                    }

                    // 2. Get user command
                    Console.Write("> ");
                    string command = Console.ReadLine().ToLower().Trim();

                    // 3. Process the command
                    if (command == "go north")
                    {
                        if (player.CurrentRoom.North != null)
                        {
                            player.CurrentRoom = player.CurrentRoom.North;
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
                        // Locked door logic
                        if (player.CurrentRoom == darkPassage && !player.Inventory.Contains("a rusty key"))
                        {
                            Console.WriteLine("A heavy stone door blocks the way. It seems to have a rusty lock.");
                        }
                        else if (player.CurrentRoom.East != null)
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
                    else if (command == "look")
                    {
                        continue;
                    }
                    else if (command == "help")
                    {
                        Console.WriteLine("--- Available Commands ---");
                        Console.WriteLine("go [north, south, east, west] - Move between rooms.");
                        Console.WriteLine("look - Look around your current room again.");
                        Console.WriteLine("inventory - Check your items.");
                        Console.WriteLine("take [item name] - Pick up an item.");
                        Console.WriteLine("drop [item name] - Drop an item from your inventory.");
                        Console.WriteLine("quit / exit - Exit the game.");
                    }
                    else if (command == "inventory")
                    {
                        if (player.Inventory.Count == 0)
                        {
                            Console.WriteLine("Your inventory is empty.");
                        }
                        else
                        {
                            Console.WriteLine("You are carrying: " + string.Join(", ", player.Inventory));
                        }
                    }
                    else if (command.StartsWith("take "))
                    {
                        string itemToSearchFor = command.Substring(5).Trim();

                        string itemFound = player.CurrentRoom.ItemsInRoom
                                            .FirstOrDefault(item => item.Contains(itemToSearchFor));

                        if (itemFound != null)
                        {
                            player.CurrentRoom.ItemsInRoom.Remove(itemFound);
                            player.Inventory.Add(itemFound);
                            Console.WriteLine("You picked up " + itemFound + ".");

                            if (itemFound == "the ancient treasure")
                            {
                                Console.WriteLine("\n\n*** CONGRATULATIONS! YOU HAVE FOUND THE TREASURE AND WON THE GAME! ***");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no '" + itemToSearchFor + "' here.");
                        }
                    } 
                    else if (command.StartsWith("drop "))
                    {
                        string itemToDrop = command.Substring(5).Trim();
                        if (player.Inventory.Contains(itemToDrop))
                        {
                            player.Inventory.Remove(itemToDrop);
                            player.CurrentRoom.ItemsInRoom.Add(itemToDrop);
                            Console.WriteLine("You dropped " + itemToDrop + ".");
                        }
                        else
                        {
                            Console.WriteLine("You are not carrying '" + itemToDrop + "'.");
                        }
                    }
                    else if (command == "quit" || command == "exit")
                    {
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I don't understand that command.");
                    }
                }
                else if (command.StartsWith("drop "))
                {
                    string itemToDrop = command.Substring(5).Trim();
                    if (player.Inventory.Contains(itemToDrop))
                    {
                        player.Inventory.Remove(itemToDrop);
                        player.CurrentRoom.ItemsInRoom.Add(itemToDrop);
                        Console.WriteLine("You dropped " + itemToDrop + ".");
                    }
                    else
                    {
                        Console.WriteLine("You are not carrying '" + itemToDrop + "'.");
                    }
                }
                else if (command == "quit" || command == "exit")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
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
    public List<string> ItemsInRoom { get; set; } = new List<string>();
}

public class Player
{
    public Room CurrentRoom { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();
}



