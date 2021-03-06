﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class Composite_Structural
    {
        public static void Run()
        {
            Console.WriteLine("This structural code demonstrates the Composite pattern which allows the creation of a tree structure in which individual nodes are accessed uniformly whether they are leaf nodes or branch (composite) nodes.");
            Composite root1 = new Composite("root");
            root1.Add(new Leaf("Leaf A"));
            root1.Add(new Leaf("Leaf B"));

            Composite comp1 = new Composite("Composite X");
            comp1.Add(new Leaf("Leaf XA"));
            comp1.Add(new Leaf("Leaf XB"));

            root1.Add(comp1);
            root1.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root1.Add(leaf);
            root1.Remove(leaf);

            root1.Display(1);
            /*
            -root
            ---Leaf A
            ---Leaf B
            ---Composite X
            -----Leaf XA
            -----Leaf XB
            ---Leaf C             
             */
        }

        abstract class Component
        {
            protected string name;

            public Component(string name)
            {
                this.name = name;
            }

            public abstract void Add(Component c);
            public abstract void Remove(Component c);
            public abstract void Display(int depth);
        }

        class Composite : Component
        {
            private List<Component> _children = new List<Component>();

            public Composite(string name) : base(name) { }

            public override void Add(Component component)
            {
                _children.Add(component);
            }
            public override void Remove(Component c)
            {
                _children.Remove(c);
            }
            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + name);

                foreach (Component component in _children)
                {
                    component.Display(depth + 2);
                }
            }
        }

        class Leaf : Component
        {
            public Leaf(string name) : base(name) { }

            public override void Add(Component c)
            {
                Console.WriteLine("Cannot add to a leaf");
            }

            public override void Remove(Component c)
            {
                Console.WriteLine("Cannot remove from a leaf");
            }
            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + name);
            }
        }


    }
}
