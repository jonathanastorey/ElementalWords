using static Preloaded.Elements;

// These imports are only here to allow copy/paste into the attempt Solution 
using System.Collections.Generic;
using System.Linq;
using System; 

namespace Kata;

public class ElementalWords
{
    public static string[][] ElementalForms(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return new string[0][];
        
        var matches = new List<List<string>>();
        
        CheckCurrentLocationForNextMatches(-1, word, new List<string>(), matches);

        return ConvertListResultsToArrays(matches);

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
        var match = ELEMENTS.FirstOrDefault(x => x.Key.Equals(word, StringComparison.InvariantCultureIgnoreCase));
        return match.Value is not null ? $"{match.Value} ({match.Key})" : string.Empty;
    }

    private static void CheckCurrentLocationForNextMatches(int currentLocation, string word,
        List<string> currentMatchedElements, List<List<string>> matchedAndCompleted)
    {

        if (word.Length == currentLocation + 1)
            AddCompletedElementMatchToResults(currentMatchedElements, matchedAndCompleted);
        
        CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements,1,matchedAndCompleted);
        
        CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements,2,matchedAndCompleted);
        
        CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements,3,matchedAndCompleted);

    }

    private static void AddCompletedElementMatchToResults(List<string> currentMatchedElements, List<List<string>> matchedAndCompleted)
    {
        matchedAndCompleted.Add(currentMatchedElements);
    }

    private static void CheckForMatchingElementAndContinue(int currentLocation, string word, List<string> currentMatchedElements, int elementLengthToCheck , List<List<string>> matchedAndCompleted)
    {
        var locationToStartSubStringSearchFrom = currentLocation+1;
        var locationToEndSubStringSearchFrom = locationToStartSubStringSearchFrom+elementLengthToCheck;

        if(word.Length < locationToEndSubStringSearchFrom)
            return;
        
        var elementToCheckFor = word[locationToStartSubStringSearchFrom..locationToEndSubStringSearchFrom];

        var matchingValue = ElementExists(elementToCheckFor);
        if (!string.IsNullOrWhiteSpace(matchingValue))
        {
            currentLocation += elementLengthToCheck;
            currentMatchedElements = CreateNewListAndAppendMatchedElement(currentMatchedElements, matchingValue);
            CheckCurrentLocationForNextMatches(currentLocation, word, currentMatchedElements, matchedAndCompleted);
        }
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