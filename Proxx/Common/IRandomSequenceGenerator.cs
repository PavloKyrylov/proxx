namespace Proxx.Common;

public interface IRandomSequenceGenerator
{
    IEnumerable<int> NextSequence(int maxValue, int sequenceLength, int[] elementsToExclude);
}
