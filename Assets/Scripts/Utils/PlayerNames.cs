
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Helperclass to get pplayernames
/// </summary>
public static class PlayerNames
{
    public static List<string> HanoverNames = new List<string>() { "Hendrik Weydandt", "Louis Schaub", "Ron-Robert Zieler", "Leo Weinkauf", "Toni Stahl",
        "Phil Neumann", "Julian Börner", "Luka Krajnc", "Derrick Köhn", "Ekin Celebi", "Sei Muroya", "Jannik Dehm", "Fabian Kunze", "Gaël Ondoua", "Tim Walbrecht",
        "Eric Uhlmann", "Max Besuschkow", "Antonio Foti", "Enzo Leopold", "Sebastian Kerk", "Sebastian Ernst", "Franck Evina", "Sebastian Stolze",
        "Maximilian Beier", "Havard Nielsen", "Cedric Teuchert", "Nicolo Tresoldi"};

    public static List<string> HamburgNames = new List<string>() { "Daniel Heuer Fernandes", "Marko Johansson", "Matheo Raab", "Leo Oppermann", "Tom Mickel",
        "Mario Vuskovic", "Sebastian Schonlau", "Jonas David", "Stephan Ambrosius", "Valon Zumberi", "Tim Leibold", "Miro Muheim", "Bent Andresen", "Moritz Heyer", "Jonas Meffert",
        "Maximilian Rohr", "Elijah Krahn", "László Bénes", "Ludovit Reis", "Anssi Suhonen", "Sonny Kittel", "Filip Bilbija", "Aaron Opoku",
        "Ogechika Heil", "Bakery Jatta", "Xavier Amaechi", "Robert Glatzel", "Ransford-Yeboah Königsdörffer"};

    public static List<string> BremenNames = new List<string>() { "Mio Backhaus", "Eduardo Dos Santos Haesler", "Jiri Pavlenka", "Michael Zetterer", "Felix Agu",
        "Lee Buchanan", "Fabio Chiarodia", "Marco Friedl", "Anthony Jung", "Amos Pieper", " Niklas Stark", "Milos Veljkovic", "Mitchell Weiser", " Leonardo Bittencourt", "Benjamin Goller",
        "Christian Groß", "Ilia Gruev", "Jean-Manuel Mbom", "Abdenego Nankishi", "Nicolai Rapp", "Dikeni Salifou", "Romano Schmid", "Niklas Schmidt",
        "Jens Stage", "Oliver Burke", "Eren Dinkci", "Marvin Ducksch", "Niclas Füllkrug", "Nick Woltemade"};

    public static List<string> BayernNames = new List<string>() { "Manuel Neuer", "Sven Ulreich", "Johannes Schenk", "Matthijs de Ligt", "Lucas Hernández",
        "Dayot Upamecano", "Tanguy Nianzou", "Alphonso Davies", "Benjamin Pavard", "Noussair Mazraoui", "Josip Stanisic", "Bouna Sarr", "Joshua Kimmich", "Adrian Fein", "Leon Goretzka",
        "Ryan Gravenberch", "Marcel Sabitzer", "Jamal Musiala", "Paul Wanner", "Sadio Mané", "Leroy Sané", "Serge Gnabry", "Kingsley Coman",
        "Thomas Müller", "Gabriel Vidovic", "Joshua Zirkzee", "Eric Maxim Choupo-Moting", "Mathys Tel"};

    public static List<string> FrankfurtNames = new List<string>() { "Kevin Trapp", "Diant Ramaj", "Matteo Bignetti", "Jens Grahl", "Evan Ndicka",
        "Tuta", "Jérôme Onguéné", "Almamy Touré", "Hrvoje Smolcic", "Christopher Lenz", "Jan Schröder", "Aurélio Buta", "Timothy Chandler", "Kristijan Jakic", "Makoto Hasebe",
        "Djibril Sow", "Ajdin Hrustic", "Sebastian Rode", "Mehdi Loune", "Filip Kostic", "Daichi Kamada", "Jesper Lindström", "Mario Götze",
        "Marcel Wenig", "Faride Alidou", "Ansgar Knauff", "Jens Petter Hauge", "Rafael Borré", "Randal Kolo Muani", "Lucas Alario", "Gonçalo Paciência", "Ali Akman"};

    /// <summary>
    /// Get a random name from the team hanover
    /// </summary>
    /// <returns>string</returns>
    public static string GetRandomHanoverName()
    {
        return HanoverNames[Random.Range(0, HanoverNames.Count)];
    }
    /// <summary>
    /// Get a random name from the team hamburg
    /// </summary>
    /// <returns>string</returns>
    public static string GetRandomHamburgName()
    {
        return HamburgNames[Random.Range(0, HamburgNames.Count)];
    }
    /// <summary>
    /// Get a random name from the team bremen
    /// </summary>
    /// <returns>string</returns>
    public static string GetRandomBremenName()
    {
        return BremenNames[Random.Range(0, BremenNames.Count)];
    }
    /// <summary>
    /// Get a random name from the team bayern
    /// </summary>
    /// <returns>string</returns>
    public static string GetRandomBayernName()
    {
        return BayernNames[Random.Range(0, BayernNames.Count)];
    }
    /// <summary>
    /// Get a random name from the team frankfurt
    /// </summary>
    /// <returns>string</returns>
    public static string GetRandomFrankfurtName()
    {
        return FrankfurtNames[Random.Range(0, FrankfurtNames.Count)];
    }
}
