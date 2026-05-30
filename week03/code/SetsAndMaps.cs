using System.Runtime.ExceptionServices;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // List of the results
        List<string> result = new List<string>();
        // to iterate over all the words in the list

        // we need to have a hash set that checks if the word is already in the set
        HashSet<string> seenWords = new HashSet<string>();

        for (int i = 0; i < words.Count(); i++)
        {
            string currentWord = words[i]; 
            string reversed = "" + currentWord[1] + currentWord[0];
            if (seenWords.Contains(reversed))
            {
                result.Add($"{reversed} & {currentWord}");
            }
            else
            {
                // add to the set if the word is not seen yet
                seenWords.Add(currentWord); 
            }

        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // dictionary of degrees
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string keyDegree = fields[3]; 
            // if the dictionary contains the key
            if (degrees.ContainsKey(keyDegree))
            {
                degrees[keyDegree] += 1; 
            }else
            {
                degrees[keyDegree] = 1; 
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // check for the length of all the strings
        string cleanString1 = word1.ToLower().Replace(" ", "");
        string cleanString2 = word2.ToLower().Replace(" ", "");

        if (cleanString1.Length != cleanString2.Length)
        {
            return false;
        }

        // count the frequency of the letters
        // dictionary to keep track count of the letters
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();
        

        for (int i = 0; i < cleanString1.Length; i++)
        {
            char c = cleanString1[i];
            if (letterCounts.ContainsKey(c))
            {
                letterCounts[c] += 1; 
            }else
            {
                letterCounts[c] = 1; 
            }
        }

        // compare and decrement frequencies using the second word
        for (int i = 0; i < cleanString2.Length; i++)
        {
            char c = cleanString2[i];

            if (!letterCounts.ContainsKey(c) || letterCounts[c] == 0)
            {
                return false;
            }

            letterCounts[c]--;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}