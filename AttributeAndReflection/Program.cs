using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AttributeAndReflection
{
    // 1.  make a class and call it TestAttribute
    // which must inherit from Attribute

    class TestAttribute : Attribute { }

    // 2. We can use TestAttribute by putting it on top of the class/property/method
    [TestAttribute]
    class MyTestSuite { }

    [TestAttribute]
    class YourTestSuite { }


    // 3. This Program.cs file has 3 types 
    // TestAttributes, MyTestSuite and Program class
    // To look inside this assembly and get all the type objects

    class Program
    {
        static void Main()
        {



            // Using Linq 
            var testSuites = from type in Assembly.GetExecutingAssembly().GetTypes()
                             where type.GetCustomAttributes().Any(a => a is TestAttribute)
                             select type;
            foreach (var t in testSuites)
            {
                Console.WriteLine(t.Name);
            }
            Console.ReadKey();
        }
    }
}
