using System.Collections;

namespace newlab24
{
    public class VectorAscComparer : IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            if (obj1 is IVectorable vector1 && obj2 is IVectorable vector2)
            {
                return vector1.GetNorm().CompareTo(vector2.GetNorm());
            }
            return -1;
        }
    }
}


// namespace newlab24
// {
//     public class VectorAscComparer : IComparer<IVectorable>
//     {
//         public int Compare(IVectorable? vector1, IVectorable? vector2)
//         {
//             if (vector1 == null || vector2 == null)
//             {
//                 return -1;
//             }
//             return vector1.GetNorm().CompareTo(vector2.GetNorm());
//         }
//     }
// }