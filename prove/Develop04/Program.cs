using System;
using System.Threading;

// Base class for mindfulness activities
public class MindfulnessActivity
{
    // Member variables
    private string _activityName;
    private string _description;
    protected int _duration;

    // Constructor
    public MindfulnessActivity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    // Method to start the activity
    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {_activityName} activity...");
        Console.WriteLine(_description);
        Console.WriteLine($"Please set the duration for {_activityName} activity (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Prepare to begin {_activityName} activity...");
        Thread.Sleep(3000); // Pause for 3 seconds before starting
    }

    // Method to end the activity
    public virtual void EndActivity()
    {
        Console.WriteLine($"Congratulations! You've completed the {_activityName} activity.");
        Console.WriteLine($"You've spent {_duration} seconds on {_activityName}.");
        Thread.Sleep(3000); // Pause for 3 seconds before finishing
    }

    // Method to display animation and pause
    protected void DisplayAnimationAndPause(string message, int durationInSeconds)
    {
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.Write(message);
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("\b \b"); // Erase the message
        }
    }
}

// Breathing activity class
public class BreathingActivity : MindfulnessActivity
{
    // Constructor
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Method to start the breathing activity
    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Let's begin the breathing activity...");
        DisplayBreathingAnimation();
    }

    // Method to display breathing animation
    private void DisplayBreathingAnimation()
    {
        Console.WriteLine("Get ready to breathe in...");
        int breathingCycleDuration = _duration / 4; // Split the total duration into four quarters for smoother breathing
        for (int i = 0; i < 2; i++) // Repeat for two full breath cycles
        {
            Console.WriteLine("Breathe in...");
            DisplayAnimationAndPause("Breathe in...   ", breathingCycleDuration);
            Console.WriteLine("\nHold...");
            DisplayAnimationAndPause("Hold...   ", breathingCycleDuration);
            Console.WriteLine("\nBreathe out...");
            DisplayAnimationAndPause("Breathe out...   ", breathingCycleDuration);
        }
    }
}

// Reflection activity class
public class ReflectionActivity : MindfulnessActivity
{
    // Reflection prompts
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // Reflection questions
    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructor
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    // Method to start the reflection activity
    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Let's begin the reflection activity...");
        DisplayReflectionPrompts();
    }

    // Method to display reflection prompts and questions
    private void DisplayReflectionPrompts()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(3000); // Pause for 3 seconds

        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine(); // Wait for Enter key press
        }
    }
}

// Listing activity class
public class ListingActivity : MindfulnessActivity
{
    // Listing prompts
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.")
    {
    }

    // Method to start the listing activity
    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("Let's begin the listing activity...");
        DisplayListingPrompts();
    }

    // Method to display listing prompts
    private void DisplayListingPrompts()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine($"You have {_duration} seconds to start listing...");
        DateTime startTime = DateTime.Now;
        int elapsedTime = 0;

        do
        {
            Console.WriteLine("Enter a respond to the prompt (or 'exit' to stop listing): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
                break;
            elapsedTime = (int)(DateTime.Now - startTime).TotalSeconds;
        } while (elapsedTime < _duration);

        Console.WriteLine("Time's up!");
    }
}

// Main class
class Program
{
    // Method to clear the console and display the main menu
    static void DisplayMainMenu()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Share the program to friends and families.");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Choose an activity (eg). 1, 2, 3, 4:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
    }

    static void Main(string[] args)
    {
        // Create instances of each activity
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();

        int choice;
        do
        {
            DisplayMainMenu();
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    breathingActivity.StartActivity();
                    breathingActivity.EndActivity();
                    break;
                case 2:
                    reflectionActivity.StartActivity();
                    reflectionActivity.EndActivity();
                    break;
                case 3:
                    listingActivity.StartActivity();
                    listingActivity.EndActivity();
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }

            // Pause before clearing console and displaying menu again
            if (choice != 4)
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

            // Clear the console before displaying the menu again
        } while (choice != 4);
    }
}
