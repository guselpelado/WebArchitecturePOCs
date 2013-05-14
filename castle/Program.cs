using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace castle
{
    class Program
    {
        static void Main(string[] args)
        {

            // CREATE A WINDSOR CONTAINER OBJECT AND REGISTER THE INTERFACES, AND THEIR CONCRETE IMPLEMENTATIONS.
            var container = new WindsorContainer();
            //   container.AddComponent("main", typeof(main));
            //   container.AddComponent("Dependency1", typeof(IDependency1), typeof(dependency1));
            //   container.AddComponent("Dependency2", typeof(IDependency2), typeof(dependency2));


            container.Register(Component.For(typeof(IDependency1)).ImplementedBy(typeof(dependency1)));
            container.Register(Component.For(typeof(IDependency2)).ImplementedBy(typeof(dependency2)));
            container.Register(Component.For(typeof(main)));
            // CREATE THE MAIN OBJECT AND INVOKE ITS METHOD(S) AS DESIRED.
            var MainThing = container.Resolve<main>();
            MainThing.DoSomething();
        }
    }


    public interface IDependency1
    {
        object SomeObject { get; set; }
    }

    public interface IDependency2
    {
        object SomeOtherObject { get; set; }
    }
    public class dependency1 : IDependency1
    {
        public object SomeObject { get; set; }
    }

    public class dependency2 : IDependency2
    {
        public object SomeOtherObject { get; set; }
    }

    public class main
    {
        private IDependency1 object1;
        private IDependency2 object2;

        public main(IDependency1 dependency1, IDependency2 dependency2)
        {
            object1 = dependency1;
            object2 = dependency2;
        }


        public void DoSomething()
        {
            object1.SomeObject = "Hello World";
            object2.SomeOtherObject = "Hello Mars";
        }
    }
}
