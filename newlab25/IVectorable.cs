namespace newlab25
{
    public interface IVectorable : IComparable, ICloneable
    {
        int this[int index] { get; set; }
        int Length { get; }
        double GetNorm();
    }
}
