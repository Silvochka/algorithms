namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Stabtility - maintain the relative order of records with equal keys (values)
    /// Adaptability - whether or not the presortedness of the input affects the running time
    /// In-place - transforms input without additional data structures, only additional flat variables. Input usually overwrittern by output.
    /// 
    /// Binary search tree:
    /// 1. Depth D or D-1
    /// 2. Value in vertex less (or less or equals) than its leafs
    /// Implementation in array: 
    /// A[i] >= A[2i + 1]
    /// A[i] >= A[2i + 2], 0 <= i <= n/2
    /// </summary>
    public interface ISorter
    {
        int sort(int[] array);
    }
}
