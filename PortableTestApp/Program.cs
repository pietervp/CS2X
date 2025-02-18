﻿using System;
using System.Collections;
//using System.Collections.Generic;

namespace PortableTestApp
{
	namespace MyNamespace
	{
		enum MyEnum
		{
			A, B, C
		}
	}

	interface MyInterface
	{
		void MyVirtMethod();
		void MyFoo();
	}

	abstract class MyAbstractClass : MyInterface
	{
		public abstract void MyVirtMethod();
		public void MyFoo()
		{
			Console.Write("MyAbstractClass::MyFoo");
		}
	}

	sealed class MyBaseClass : MyAbstractClass
	{
        public int b, c, d;

		public override void MyVirtMethod()
		{
			Console.Write("MyBaseClass::MyVirtMethod");
		}
	}

	enum MyEnum
	{
		A, B, C
	}

	static class MyExtensions
	{
		public static string Name(this MyEnum e)
		{
			if (e == MyEnum.A) return "A";
			return "TODO";
		}

		public static string Name2(this Program e)
		{
			return "TODO";
		}
	}

	class Program
	{
		public string Name2(){ return null;}

		public int abc = 99;
		public static int abcStatic;

		public int MyAutoProp { get; private set; }
		public static int MyAutoPropStatic { get; private set; }

		private int _MyProp;
		public int MyProp
		{
			get { return _MyProp; }
			set { _MyProp = value; }
		}

		private static int _MyPropStatic;
		public static int MyPropStatic
		{
			get { return _MyPropStatic; }
			set { _MyPropStatic = value; }
		}

		private static string value;
		private static MyEnum myEnum;

		void Foo2()
		{
			MyProp = 123;
			int i = MyProp;

			MyPropStatic = 321;
			int i2 = MyPropStatic;
		}

		void Foo(Program p)
		{
			p.Name2();
			MyExtensions.Name2(p);
			MyAutoProp = 123;
			int i2 = 55;
			{
				var i = abc + i2;
			}
			{
				var i = i2 + p.abc;
			}
		}

		static Program()
		{
			MyAutoPropStatic = 555;
			var en = MyEnum.A;
			string e = en.Name();
		}

		unsafe static void Main()//string[] args)
		{
			//var m = new MyBaseClass();
			//m.MyVirtMethod();
			//var m2 = (MyAbstractClass)m;
			//m2.MyVirtMethod();
			//m.MyFoo();
			//return;

			//Console.WriteLine("Hello World!");
            //Console.WriteLine("Hello World!2");
            //return;

			//string value = typeof(int).ToString();
			//Console.WriteLine(value);

			//Program.MyAutoPropStatic = 0;
			//var v = "Hello World!";
			//v = MyAutoPropStatic.ToString();
			////v = myEnum.ToString();// TODO
			//v = GetValue(v.GetType().ToString());
			//Console.WriteLine("Hello World!" + value);

			//foreach (var i in "asdfas")// requires method System.String::get_Chars(int32)
			var a = new int[5] {1, 2, 3, 4, 5};
			if (a.GetType() == typeof(int[])) Console.WriteLine(a.GetType().FullName);
			//a[0] = new int[3];
			//int b = a.Length;
			//int c = a[0].Length;
            foreach (var aa in a)
            {
                Console.Write("^");
                if (aa == 88) break;
            }

            i2 = new MyBaseClass()
            {
                b = 44,
                c = 33,
                d = 66
            };

            var i = new MyBaseClass()
            {
                b = 44,
                c = 33,
                d = 66
            };

			var a2 = stackalloc byte[3] { 1, 2, 3 };

   //         for (int i = 0, i2 = 0; i != a.Length && i2 != 4; ++i, i2 += 2)
			//{
			//	if (i == i2) Console.Write("*");
			//}

			//for (int i = 0; i != a.Length; ++i)
			//{
			//	Console.Write("$");
			//}

            /*var es = new MyE();
            foreach (var e in es)
            {

            }*/
			float[] sldkfj;
			float[] sldkfj2;
			//MyG<short[]>[] myGArray;
			MyG<int> myG = new MyG<int>();
			int myGI = myG.DoStuff();
			int myGI2 = myG.DoStuff2<int>(123);
			int myGI3 = myG.DoStuff3<int,float>(55f, 123, 55);
			var myGIS = MyG<Vec3>.DoStuffStatic(true);
			Console.WriteLine(myG.GetType().FullName);
			try
			{
				FooThrow(new MyBaseClass());
				//FooThrow(null);// should be a compile time error
			}
			catch (NotSupportedException e)
			{
				Console.WriteLine("NotSupportedException: " + e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		static void FooThrow(MyInterface value)
		{
			throw new NotSupportedException("My Exception!");
		}

        static MyBaseClass i2;
		static double[] Ya()
		{
			return null;
		}

		static string GetValue(object o)
		{
			return o.GetType().FullName;
		}
	}

	class MyG<T> where T : struct
	{
		public T g;

		public T DoStuff()
		{
			return g;
		}

		public static T DoStuffStatic(bool value)
		{
			if (value) return default;
			else return default(T);
		}

		public E DoStuff2<E>(E value)
		{
			return value;
		}

		public E DoStuff3<E,E2>(E2 value2, E value, T value3)
		{
			if (typeof(E2) == typeof(E) && typeof(E) == typeof(T)) return value;
			return value;
		}
	}

	struct Vec3
	{
		public float x, y, z;
	}

	//struct MyS<T>
	//{
	//	public T s;
	//}

	/*class MyE : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }

    struct MyEnumerator : IEnumerator<int>
    {
        private int i;
        private int[] collection;

        public MyEnumerator(int[] collection)
        {
            i = 0;
            this.collection = collection;
        }

        public void Dispose() { }

        public int Current
        {
            get
            {
                return collection[i];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return null;
            }
        }

        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {

        }
    }*/
}