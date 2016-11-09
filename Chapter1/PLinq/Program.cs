using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PLinq
{
    class Program
    {
        static void Main( string [ ] args )
        {
            string yen = Path.Combine(@"c:\windows", "aho.txt");


            var del = new Derived();
            del.method1();
            return;




            MoveableOject mover = new MoveableOject();
            

            ILeft left = new MoveableOject();
            left.Move();

            ICenter center = (ICenter)left;
            center.Hover();

            IAnimal animal = new Dog();
            animal.Move();


            var numbers = Enumerable.Range( 0, 100 );
            var parallelResult = numbers.AsParallel( ).AsOrdered()
                .Where( i => i % 2 == 0 )
                .ToArray( );

            //foreach( int i in parallelResult)
            //{
            //    Console.WriteLine( i );
            //}

            var parallelResult2 = numbers.AsParallel( ).AsOrdered( )
                .Where( i => i % 2 == 0 );

            parallelResult2.ForAll( e => Console.WriteLine( e ) );

            Console.WriteLine( "------------------------------" );

            //var result = numbers
            //    .Where( i => i % 2 == 0 )
            //    .ToArray( );

            //foreach ( int i in result )
            //{
            //    Console.WriteLine( i );
            //}

            int a = 1;

            if ( a == 1 )
            {

                // エラー	2	ローカルの変数 'a' をこのスコープで宣言することはできません。これは、'親またはカレント' スコープで別の意味を持つ 'a' の意味が変更されるのを避けるためです。
                
                //int a = 100;
                //Console.WriteLine( a.ToString( ) );

                //foreach( int a in new [] {1,2,3})
                //{
                //  ;
                //}
            }


            CreateAndRaise() ;
        }


        static public void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += (sender, e) => Console.WriteLine("Event raised: { 0}", e.Value);
            p.Raise();
        }

    }



    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }

    public class Pub
    {
        public event EventHandler<MyArgs> OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }

    interface ILeft
    {
        void Move();
    }
    interface IRight
    {
        void Move();
        void Stop();

    }
    interface ICenter
    {
        void Hover();
    }
    class MoveableOject : ILeft, IRight,ICenter
    {
        void ILeft.Move()
        {
            Debug.Write("左です");
        }
        void IRight.Move()
        {
            Debug.Write("右です");
        }
        void IRight.Stop()
        {
        }
        public void Hover()
        {
        }
    }

    interface IAnimal
    {
        void Move();
    }
    class Dog : IAnimal,ICenter
    {
        public void Move() { }
        public void Bark() { }
        public void Hover()
        {
        }
    }


}



