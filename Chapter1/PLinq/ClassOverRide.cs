using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLinq
{
    //[DebuggerDisplay("Name = {FirstName}.{LastName}")]
    [DebuggerDisplay("{FirstName}.{LastName}", Name = "名前={Name}", Type = "ベースクラス" )]
    abstract class BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BaseClass()
        {
            this.FirstName = "Hiro";
            this.LastName = "Koba";
        }


        public virtual void method1()
        {
            Debug.Print("Base:Method1");
        }

        protected abstract void method2();

    }

    class Derived : BaseClass
    {
        public override void method1()
        {
            base.method1();
            Debug.Print("Derived:Method1");
        }

        protected override void method2()
        {
        }
    }
}
