namespace Proxx.Common;

public class RandomSequenceGenerator
{
    private readonly Func<int, int> _nextInt;

    public RandomSequenceGenerator(Func<int, int> nextInt)
    {
        _nextInt = nextInt;
    }

    public IEnumerable<int> NextSequence(int maxValue, int sequenceLength, int[] elementsToExclude)
    {
        EnsureParametersAreValid(maxValue, sequenceLength, elementsToExclude);

        var notAvailableNumbers = new HashSet<int>(elementsToExclude);
        for (int i = 0; i < sequenceLength; i++)
        {
            var number = _nextInt(maxValue - notAvailableNumbers.Count);
            notAvailableNumbers.Add(FindAvailableNumber(number, maxValue, notAvailableNumbers));
        }
        return notAvailableNumbers
            .Where(x => !elementsToExclude.Contains(x))
            .ToArray();
    }

    private void EnsureParametersAreValid(int maxValue, int sequenceLength, int[] elementsToExclude)
    {
        if (maxValue <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        }
        if (sequenceLength <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sequenceLength));
        }
        if (elementsToExclude.Any(x => x >= maxValue))
        {
            throw new ArgumentOutOfRangeException(nameof(elementsToExclude));
        }
        if (maxValue < sequenceLength + elementsToExclude.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        }
    }

    private int FindAvailableNumber(int currentNumber, int sequenceLength, HashSet<int> notAvailableNumbers)
    {
        while (notAvailableNumbers.Contains(currentNumber % sequenceLength))
        {
            currentNumber++;
        }
        return currentNumber % sequenceLength;
    }
}
