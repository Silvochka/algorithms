namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Stabtility - maintain the relative order of records with equal keys (values)
    /// Adaptability - whether or not the presortedness of the input affects the running time
    /// </summary>
    public interface ISorter
    {
        int sort(int[] array);
    }
}
