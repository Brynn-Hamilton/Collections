// Create an initial collection of items to stock in the inventory with the following starter items:
// Broccoli, Tomatoes, Zucchini

List<string> inventory = new List<string>();
inventory.Add("broccoli");
inventory.Add("tomatoes");
inventory.Add("zucchini");


// Present the user with a menu of the following options
// 1) Add Items
// 2) Remove an Item
// 3) View Inventory
DisplayMenu();

MenuExecution();

// Add Items
// If the user chooses to add items ask how many new items they would like to add to the collection
// Based on the number of items the user chooes, prompt them that many times to enter an item and add it to the collection
// Ask the user if they want to return to the menu
// If so, present them with the menu again. If not, bid them farewell and end the application

// Remove an Item
// If the user chooses to remove an item, prompt them for the name and remove the item from the collection
// Inform the user the item was successfully removed
// Ask if they want to remove another item. If they choose yes, loop back through the previous steps & ask if no, ask the user if they want to return to the menu.
// If so, present them with the menu again. If not, bid them farewell and end the application

// View inventory
// If the user chooses to view inventory, iterate through the collection and print each item to the console
// Ask they user if they want to return to the menu. If so, present them with the menu again. If not, bid them farewell and end the application





/*******************************************************************************************************
                                    // Inventory Methods //
*******************************************************************************************************/

// Method - display menu for items, remove items, view inventory
void DisplayMenu()
{
    Console.WriteLine("[1] Add Items [2] Remove an Item [3] View Inventory:");
}

// Method - 1) add items
void AddToInventory(string userInput)
{
    inventory.Add(userInput);
}

// Method - 2) remove items
bool RemoveFromInventory(string userInput)
{
    return inventory.Remove(userInput);
}

// Method - 3) display inventory list/view inventory
void DisplayInventory()
{
    int inventoryNum = 1;
    for (int i = 0; i < inventory.Count; i++)
    {
        Console.WriteLine($" {inventoryNum++}: {inventory[i]}");
    }
}

// Method - menu execution
void MenuExecution()
{
    // Error handling
    // When selecting from the menu, prompt the user again if they enter anything but 1, 2, or 3
    bool validMenu = false;
    while (!validMenu)
    {
        Console.WriteLine("Please enter 1, 2, or 3.");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int validInput))
        {
            if (validInput == 1)
            {
                Console.WriteLine("Number of items to add:");
                int itemsToAdd = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= itemsToAdd; i++)
                {
                    Console.Write($"Item {i}: ");
                    string newItem = Console.ReadLine().ToLower();
                    AddToInventory(newItem);
                }
                ReturnToMenu();
                validMenu = true;
            }
            else if (validInput == 2)
            {
                bool removeAnotherItem = true;
                while(removeAnotherItem)
                {
                    Console.WriteLine("Item to remove:");
                    string removeItem = Console.ReadLine().ToLower();
                    bool successfullyRemoved = RemoveFromInventory(removeItem);
                    if (successfullyRemoved)
                    {
                        Console.WriteLine($"{removeItem} was successfully removed from inventory.");
                        Console.WriteLine("Would you like to remove another item? (y/n)");
                        string removeAgainInput = Console.ReadLine().ToLower();
                        if (removeAgainInput == "y" || removeAgainInput == "yes")
                        {
                            removeAnotherItem = true;
                        }
                        else if(removeAgainInput == "n" || removeAgainInput == "no")
                        {
                            removeAnotherItem = false;
                            ReturnToMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, {removeItem} was not in the inventory.");
                        removeAnotherItem = false;
                        ReturnToMenu();
                    }
                }
                validMenu = true;
            }
            else if (validInput == 3)
            {
                DisplayInventory();
                ReturnToMenu();
                validMenu = true;
            }
            else
            {
                Console.WriteLine("You have entered an invalid value. Returning to menu.");
                validMenu = false;
            }
        }
        else
        {
            Console.WriteLine("You have entered an invalid value. Returning to menu.");
            validMenu = false;
        }
    }
}

// Error handling
// When asking if they user wants to return to the menu, prompt them again if they enter anything but 'y' or 'n'

// Method - Return to the menu
void ReturnToMenu()
{
    bool validEntry = false;
    while (!validEntry)
    {
        Console.WriteLine("Return to the menu (y/n): ");
        string input = Console.ReadLine().ToLower();

        if (input == "y" || input == "yes")
        {
            DisplayMenu();
            MenuExecution();
            validEntry = true;
        }
        else if (input == "n" || input == "no")
        {
            Console.WriteLine("Goodbye!");
            validEntry = true;
        }
        else
        {
            Console.WriteLine("You have entered an invalid value. Please enter (y/n) to return to the menu or exit the program.");
        }
    }    
}
