using static Preloaded.Elements;

// These imports are only here to allow copy/paste into the attempt Solution 
using System.Collections.Generic;
using System.Linq;
using System; 

namespace Kata;

public class ElementalWords
{
    
    private static int MaxElementLength { get; set; }
    
    private static List<List<string>> MatchedWordsToElements { get; set; }
    
    public static string[][] ElementalForms(string word)
    {
        MatchedWordsToElements = new List<List<string>>();
        
        if (string.IsNullOrWhiteSpace(word))
            return new string[0][];
        
        if(ELEMENTS == null)
            return new string[0][];
        
        // Get the max length of the element symbol
        MaxElementLength = ELEMENTS.Keys.OrderByDescending(e=>e.Length).FirstOrDefault()?.Length ?? 0;

        CheckCurrentLocationForNextMatches(word);

        return ConvertListResultsToArrays(MatchedWordsToElements);

    }

    private static string[][] ConvertListResultsToArrays(List<List<string>> matches)
    {
        var result = new string[matches.Count][];

        for (var i = 0; i < matches.Count; i++)
        {
            result[i] = matches[i].ToArray();
        }

        return result;
    }

    private static string ElementExists(string word)
    {
        var match = ELEMENTS?.FirstOrDefault(x => x.Key.Equals(word, StringComparison.InvariantCultureIgnoreCase));
        return match != null && !string.IsNullOrWhiteSpace(match.Value.Key) ? $"{match.Value.Value} ({match.Value.Key})" : string.Empty;
    }

    private static void CheckCurrentLocationForNextMatches(string word, List<string>? currentMatchedElements = null, int currentLocation = -1)
    {
        if(currentMatchedElements == null)
            currentMatchedElements = new List<string>();
        
        if (word.Length == currentLocation + 1)
            AddCompletedElementMatchToResults(currentMatchedElements);

        // Use the max lenght of the element symbols (requirements suggest only 1,2 or 3) but scope for more  
        for (var lengthToCheck = 1; lengthToCheck < MaxElementLength; lengthToCheck++)
        {
            CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements, lengthToCheck);
        }
    }

    private static void AddCompletedElementMatchToResults(List<string> currentMatchedElements)
    {
        MatchedWordsToElements.Add(currentMatchedElements);
    }

    private static void CheckForMatchingElementAndContinue(int currentLocation, string word, List<string> currentMatchedElements, int elementLengthToCheck)
    {
        
        var locationToStartSubStringSearchFrom = currentLocation + 1;
        var locationToEndSubStringSearchFrom = locationToStartSubStringSearchFrom + elementLengthToCheck;

        if(word.Length < locationToEndSubStringSearchFrom)
            return;
        
        var elementToCheckFor = word[locationToStartSubStringSearchFrom..locationToEndSubStringSearchFrom];

        var matchingValue = ElementExists(elementToCheckFor);
        
        if (string.IsNullOrWhiteSpace(matchingValue)) return;
        
        currentLocation += elementLengthToCheck;
        currentMatchedElements = CreateNewListAndAppendMatchedElement(currentMatchedElements, matchingValue);
        CheckCurrentLocationForNextMatches(word, currentMatchedElements,currentLocation);
    }

    private static List<string> CreateNewListAndAppendMatchedElement(List<string> currentMatchedElements, string elementMatched)
    {
        var newCurrentMatchedElements = new List<string>();
        
        if(currentMatchedElements.Any())
            newCurrentMatchedElements.AddRange(currentMatchedElements);
        newCurrentMatchedElements.Add(elementMatched);
        return newCurrentMatchedElements;
    }
}