using System;
using System.Linq;

class SearchAlgorithm
{
    static void Main(string[] args)
    {
        string[] imageNames = { "cat.png", "computer.png", "pizza.png", "milk tea.png", "shes.png" };
        string[,] tags = {
            {"pet", "animal", "cute", "mammal", "furry"},
            {"gadget", "technology", "device", "hardware", "software"},
            {"food", "snack", "italian", "bread", "cheese"},
            {"drink", "dessert", "beverage", "sweet", "cold"},
            {"rubber", "footwear", "leather", "comfort", "fashion"}
        };
        int[] points = new int[imageNames.Length];

        bool continueProgram = true;

        while (continueProgram)
        {
            Console.Write("Enter your search type: ");
            string userInput = Console.ReadLine();

            string[] searchTerms = userInput.ToLower().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            Array.Clear(points, 0, points.Length);

            for (int i = 0; i < imageNames.Length; i++)
            {
                for (int j = 0; j < tags.GetLength(1); j++)
                {
                    if (searchTerms.Any(term => tags[i, j].ToLower().Contains(term)))
                    {
                        points[i]++;
                    }
                }
            }

            Console.WriteLine("\nSorted Images: ");
            SortImagesByPoints(imageNames, points);

            Console.Write("\nDo you want to continue? (y/n): ");
            string choice = Console.ReadLine().ToLower();

            if (choice != "y")
            {
                continueProgram = false;
            }
        }
    }

    static void SortImagesByPoints(string[] imageNames, int[] points)
    {
        int n = imageNames.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = points[i];
            string imageNameKey = imageNames[i];
            int j = i - 1;

            while (j >= 0 && points[j] < key)
            {
                points[j + 1] = points[j];
                imageNames[j + 1] = imageNames[j];
                j = j - 1;
            }

            points[j + 1] = key;
            imageNames[j + 1] = imageNameKey;
        }

        for (int i = 0; i < imageNames.Length; i++)
        {
            Console.WriteLine($"{imageNames[i]}: {points[i]}pts");
        }
    }
}
