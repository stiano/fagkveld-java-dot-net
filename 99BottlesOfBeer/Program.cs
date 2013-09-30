namespace _99BottlesOfBeer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Basert på: http://www.99-bottles-of-beer.net/language-csharp-2549.html
    /// 
    /// Modifisert for bedre lesbarhet.
    /// 
    /// For å kjøre:
    /// * Høyreklikk på prosjekt -> Set as startup project
    /// * Trykk F5 for å starte debuggeren.
    /// * "Enter" for å avslutte.
    /// 
    /// TODO 1: sett countOfBottles fra innkommende arguments variabel.
    /// 
    ///     Tips:
    ///     google: visual studio console application set arguments when debugging
    /// 
    /// TODO 2: Kjør applikasjonen fra cmd.exe med egen inputverdi
    /// 
    ///     Tips:
    ///     google: run console application from command prompt
    /// 
    /// TODO 3: sett countOfBottles i appSettings i app.config
    /// 
    ///     Tips:
    ///     google: read appsettings from app.config c#
    /// 
    /// TODO 4: endre appconfig i 99BottlesOfBeer.exe.config før du kjører fra cmd.exe
    /// 
    ///     Tips: Open project folder in File Explorer > bin > Debug
    /// 
    /// TODO 5: Fiks slutten på applikasjonen om du har lyst :)
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] arguments)
        {
            var countOfBottles = 10;

            var lineTemplate = "{X} bottles of beer on the wall, {X} bottles of beer. Take one down and pass it around, {Y} bottles of beer on the wall.";
            var lastLine = "No more bottles of beer on the wall, no more bottles of beer.Go to the store and buy some more, {X} bottles of beer on the wall.";
            var noMoreBeersLine = " No more bottles of beer on the wall.";
            
            var songLines = new List<string>();
            
            Enumerable.Range(1, countOfBottles)
                .Reverse()
                .ToList()
                .ForEach(c => songLines.Add(
                    lineTemplate
                        .Replace("{X}", c.ToString())
                        .Replace("{Y}", (c - 1) != 0 ? (c - 1).ToString() : noMoreBeersLine)));

            //Add the last line
            songLines.Add(lastLine.Replace("{X}", countOfBottles.ToString()));

            // Print to screen
            songLines.ForEach(Console.WriteLine);

            // Avoid termination of window
            Console.ReadLine();
        }
    }
}
