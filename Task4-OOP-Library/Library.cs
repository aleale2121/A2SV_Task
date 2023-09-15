using System;
using System.Collections.Generic;

class Library{
    public string Name {get; set;}
    public string Address {get; set;}
    public List<Book> Books {get; private set;}
    public List<MediaItem> MediaItems {get; private set;}

    public Library(string name, string address){
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book){
        Books.Add(book);
    }

    public void RemoveBook(Book book){
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item){
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item){
        MediaItems.Remove(item);
    }

    public void PrintCatalog(){
        Console.WriteLine($"Library <----> :{Name}");
        Console.WriteLine("\nBooks:");
        foreach (var book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Publication Year: {book.PublicationYear}");
        }

        Console.WriteLine("\nMedia Items:");
        foreach (var mediaItem in MediaItems)
        {
            Console.WriteLine($"Title: {mediaItem.Title}, Type: {mediaItem.MediaType}, Duration (minutes): {mediaItem.Duration}");
        }
    }

    public List<Book> SearchBooks(string keyword){
        return Books.Where(book => book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                           book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                           book.ISBN.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<MediaItem> SearchMediaItems(string keyword){
        return MediaItems.Where(item => item.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                           item.MediaType.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
