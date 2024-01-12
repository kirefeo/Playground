using Playground.CartesianProduct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.CartesianProduct
{
    class CartesianProductCreator
    {
        //public static void Create()
        //{
        //    var letters = new string[] { "A", "B" };
        //    var numbers = new[] { 1, 2, 3 };
        //    var symbols = new[] { '@', '#' };



        //    var abcsList = Enum.GetValues(typeof(ABC)).ToList();

        //    var list = (from abcs in Enum.GetValues(typeof(ABC)).ToList()
        //                from ijs in Enum.GetValues(typeof(IJ))
        //                from xys in Enum.GetValues(typeof(XYZ))
        //                select new { abcs, ijs, xys }).ToList();
        //}

        //public static IList<Tuple<string, int, char>> GetCartesianProduct(string[] strings, int[] ints, char[] chars)
        //{
        //    return (
        //        from stringItem in strings 
        //        from intItem in ints 
        //        from charItem in chars 
        //        select Tuple.Create(stringItem, intItem, charItem)).ToList();
        //}

        //private static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> input)
        //{
        //    foreach (T item in input)
        //        yield return new T[] { item };
        //}
    }
}
