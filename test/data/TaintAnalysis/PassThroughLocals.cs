using System;

namespace TaintTrackingTests
{
    class TaintedAttribute : Attribute
    {
    }
	
    class FilterAttribute : Attribute
    {
    }
	
    class SinkAttribute : Attribute
    {
    }

    class Program
    {
        [Tainted] 
        public int A;
		
        [Filter]
        private int Filter(int a)
        {
            return a;
        }
		
        [Sink]
        private void Sink(int a)
        {
        }

        static void Main(string[] args)
        {
            Program a = new Program(); 
			
            var b = a.A;
            var c = b;
            var d = a.Filter(b);
            var e = a.Filter(c);
			
            a.Sink(b);
            a.Sink(c);
            a.Sink(d);
            a.Sink(e); 
        }
    }
}