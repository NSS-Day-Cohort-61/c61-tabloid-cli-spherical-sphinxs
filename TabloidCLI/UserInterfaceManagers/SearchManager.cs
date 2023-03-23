using System;
using System.Xml.Serialization;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class SearchManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private TagRepository _tagRepository;

        public SearchManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Search Menu");
            Console.WriteLine(" 1) Search Blogs");
            Console.WriteLine(" 2) Search Authors");
            Console.WriteLine(" 3) Search Posts");
            Console.WriteLine(" 4) Search All");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchBlogs();
                    return this;
                case "2":
                    SearchAuthors();
                    return this;
                case "3":
                    SearchPosts();
                    return this;
                case "4":
                    SearchAll();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void SearchAuthors()
        {
            Console.Write("Enter Tag name for Authors: ");
            string tagName = Console.ReadLine();

            SearchResults<Author> results = _tagRepository.SearchAuthors(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }
        private void SearchBlogs()
        {
            Console.Write("Enter Tag name for Blogs: ");
            string tagName = Console.ReadLine();

            SearchResults<Blog> results = _tagRepository.SearchBlogs(tagName);

            if (results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchPosts()
        {
            Console.Write("Enter Tag name for Posts: ");
            string tagName = Console.ReadLine();

            SearchResults<Post> results = _tagRepository.SearchPosts(tagName);

            if (results.NoResultsFound) 
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }

        private void SearchAll()
        {
            Console.Write("Enter tag name for All: ");
            string tagName = Console.ReadLine();

            SearchResults<Object> results = _tagRepository.SearchAll(tagName);

            if ( results.NoResultsFound)
            {
                Console.WriteLine($"No results for {tagName}");
            }
            else
            {
                results.Display();
            }
        }
    }
}