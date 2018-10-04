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


    // 3. This Program.cs file has 3 types 
    // TestAttributes, MyTestSuite and Program class
    // To look inside this assembly and get all the type objects

    class Program
    {
        static void Main()
        {


            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                // To find out about Type object inside foreach above we click it and press F12
                // In programs like c++ once we compile code these info gets vapourized.
                

                // To find out the name of your custom attribues 
                // we put false to exclude inheritted attributes

                // Attribues are Metadata that does not do anything unless we specify something.
                foreach (Attribute a in type.GetCustomAttributes(false))
                {
                    if (a is TestAttribute)
                    {
                        Console.WriteLine($"{type.Name} is a test suite");
                    }
                }
                Console.WriteLine(type.Name);
            }
            Console.ReadKey();
        }
    }
}
