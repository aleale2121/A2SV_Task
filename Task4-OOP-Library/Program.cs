using System;

class Program
{
    public static void Main(){

        Library library = new Library("AAU Library", "Algeria St");

        library.AddBook(new Book("Book 1", "Author A", "ISBN-1", 2019));
        library.AddBook(new Book("Book 2", "Author B", "ISBN-2", 2018));
        library.AddMediaItem(new MediaItem("Movie test 1", "DVD", 120));
        library.AddMediaItem(new MediaItem("Music Album test 1", "CD", 45));

        while (true){
            Console.WriteLine("\n Choose from the Options:");
            Console.WriteLine("1. Print Library Catalog");
            Console.WriteLine("2. Search for Books");
            Console.WriteLine("3. Search for Media Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice)){
                switch (choice){
                    case 1:
                        Console.WriteLine("\nLibrary Catalog:");
                        library.PrintCatalog();
                        break;
                    case 2:
                        Console.Write("Enter search query for books: ");
                        string bookQuery = Console.ReadLine();
                        var bookResults = library.SearchBooks(bookQuery);
                        if (bookResults.Count == 0)
                            Console.WriteLine("No books found.");
                        else
                            PrintSearchResults(bookResults);
                        break;
                    case 3:
                        Console.Write("Enter search query for media items: ");
                        string mediaQuery = Console.ReadLine();
                        var mediaResults = library.SearchMediaItems(mediaQuery);
                        if (mediaResults.Count == 0)
                            Console.WriteLine("No media items");
                        else
                            PrintSearchResults(mediaResults);
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.Enter a correct option");
                        break;
                }
            }else{
                Console.WriteLine("Invalid input. Please enter a correct choice.");
            }
        }
    }

    static void PrintSearchResults(System.Collections.IEnumerable results){
        foreach (var result in results){
            Console.WriteLine(result.ToString());
        }
    }
}
