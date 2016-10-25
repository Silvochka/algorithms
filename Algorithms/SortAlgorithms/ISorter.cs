namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// O            upper limit             accurate assessment is unknown      less or equals
    /// o            upper limit             not an accurate assessment          less
    /// Theta        upper, bottom limit                                         equals
    /// Omega big    bottom limit            accurate assessment is unknown      greater or equals
    /// Omega small  bottom limit            not an accurate assessment         greater
    /// 
    /// Stabtility - maintain the relative order of records with equal keys (values)
    /// Adaptability - whether or not the presortedness of the input affects the running time
    /// In-place - transforms input without additional data structures, only additional flat variables. Input usually overwrittern by output.
    /// 
    /// Binary search tree:
    /// 1. Depth D or D-1
    /// 2. Value in vertex greater or equals than its leafs
    /// Implementation in array: 
    /// A[i] >= A[2i + 1]
    /// A[i] >= A[2i + 2], 0 <= i <= n/2
    /// </summary>
    /// <typeparam name="T">Type of array's elements</typeparam>
    public interface ISorter<T>
    {
        void sort(T[] array);
    }
}
