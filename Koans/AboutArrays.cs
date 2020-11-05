using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using DotNetCoreKoans.Engine;


namespace DotNetCoreKoans.Koans
{
    public class AboutArrays : Koan
    {
        [Step(1)]
        public void CreatingArrays()
        {
            var empty_array = new object[] { };
            Assert.Equal(typeof(object[]), empty_array.GetType());

            //Note that you have to explicitly check for subclasses
            Assert.True(typeof(Array).IsAssignableFrom(empty_array.GetType()));

            Assert.Equal(0, empty_array.Length);
        }

        [Step(2)]
        public void ArrayLiterals()
        {
            //You don't have to specify a type if the arguments can be inferred
            var array = new[] { 42 };
            Assert.Equal(typeof(int[]), array.GetType());
            Assert.Equal(new int[] { 42 }, array);

            //Are arrays 0-based or 1-based?
            Assert.Equal(42, array[0]);

            //This is important because...
            Assert.True(array.IsFixedSize);

            //...it means we can't do this: array[1] = 13;
<<<<<<< HEAD
            Assert.Throws(typeof(FillMeIn), delegate () { array[1] = 13; });
=======
            Assert.Throws(typeof(IndexOutOfRangeException), delegate () { array[1] = 13; });
>>>>>>> 730e1bf (aboutArrays)

            //This is because the array is fixed at length 1. You could write a function
            //which created a new array bigger than the last, copied the elements over, and
            //returned the new array. Or you could do this:
            List<int> dynamicArray = new List<int>();
            dynamicArray.Add(42);
            Assert.Equal(array, dynamicArray.ToArray());

            dynamicArray.Add(13);
<<<<<<< HEAD
            Assert.Equal((new int[] { 42, FILL_ME_IN }), dynamicArray.ToArray());
=======
            Assert.Equal((new int[] { 42, 13 }), dynamicArray.ToArray());
>>>>>>> 730e1bf (aboutArrays)
        }

        [Step(3)]
        public void AccessingArrayElements()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

<<<<<<< HEAD
            Assert.Equal(FILL_ME_IN, array[0]);
            Assert.Equal(FILL_ME_IN, array[3]);
=======
            Assert.Equal("peanut", array[0]);
            Assert.Equal("jelly", array[3]);
>>>>>>> 730e1bf (aboutArrays)

            //This doesn't work: Assert.Equal(FILL_ME_IN, array[-1]);
            // thx from python user
        }

        [Step(4)]
        public void SlicingArrays()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

<<<<<<< HEAD
            Assert.Equal(new string[] { FILL_ME_IN, FILL_ME_IN }, array.Take(2).ToArray());
            Assert.Equal(new string[] { FILL_ME_IN, FILL_ME_IN }, array.Skip(1).Take(2).ToArray());
=======
            Assert.Equal(new string[] { "peanut", "butter" }, array.Take(2).ToArray());
            Assert.Equal(new string[] { "butter", "and" }, array.Skip(1).Take(2).ToArray());
>>>>>>> 730e1bf (aboutArrays)
        }

        [Step(5)]
        public void PushingAndPopping()
        {
            var array = new[] { 1, 2 };
            var stack = new Stack(array);
            stack.Push("last");
            // wow, stack is reversed
            // i guess it's because it does
            // foreach i in array.count()
            //   new_stack.push(array[i]) 
            Assert.Equal(new object[] { 1, 2, "last" }.Reverse(), stack.ToArray());
            var poppedValue = stack.Pop();
            Assert.Equal("last", poppedValue);
            // still reversed
            Assert.Equal(new object[] { 1, 2 }.Reverse(), stack.ToArray());
        }

        [Step(6)]
        public void Shifting()
        {
            // Shift == Remove First Element
            // Unshift == Insert Element at Beginning
            // C# doesn't provide this natively. You have a couple
            // of options, but we'll use the LinkedList<T> to implement
            var array = new[] { "Hello", "World" };
            var list = new LinkedList<string>(array);

            list.AddFirst("Say");
            Assert.Equal(new string[] { "Say", "Hello", "World" }, list.ToArray());

            list.RemoveLast();
            Assert.Equal(new string[] { "Say", "Hello" }, list.ToArray());

            list.RemoveFirst();
            Assert.Equal(new string[] { "Hello" }, list.ToArray());

            list.AddAfter(list.Find("Hello"), "World");
            Assert.Equal(new[] { "Hello", "World" }, list.ToArray());
        }

    }
}