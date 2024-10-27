using static Preloaded.Elements;

namespace Kata;

public class ElementalWords
{
    public static string[][] ElementalForms(string word)
    {
        // Requirements:
        // Each element in the dictionary has 1 to 3 letters
        // Ignore case
        // Returns an array of arrays
        // Sub array order doesn't matter but array strings need to be in order
        
        // Split word into 1,2,3 letters
        // check if letters exist
        // Check for next split 1,2,3 letters 
        // Create matched list
        // return matches

        if (string.IsNullOrWhiteSpace(word))
            return [];
        
        var matches = new List<List<string>>();
        
        CheckCurrentLocationForNextMatches(-1, word, new List<string>(), matches);

        return [];

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
            matchedAndCompleted.Add(currentMatchedElements);
        
        CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements,1,matchedAndCompleted);
        
        CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements,2,matchedAndCompleted);
        
        //CheckForMatchingElementAndContinue(currentLocation, word, currentMatchedElements,3,matchedAndCompleted);

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