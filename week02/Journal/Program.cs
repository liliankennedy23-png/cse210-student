using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n🌟 Journal Menu 🌟");
            Console.ResetColor();

            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. View journal statistics");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"❓ {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response, mood));
                    Console.WriteLine("✅ Entry added!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    Console.WriteLine("💾 Journal saved.\n");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    Console.WriteLine("📂 Journal loaded.\n");
                    break;

                case "5":
                    journal.DisplayStats();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("👋 Goodbye!");
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice. Try again.\n");
                    break;
            }
        }
    }
}
