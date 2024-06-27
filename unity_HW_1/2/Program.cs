// See https://aka.ms/new-console-template for more information

using System;

class Base
{
    public void BaseMethod()
    {}
}

class Derived : Base
{
    public void BaseMethod()
    {
        base.BaseMethod();
    }
}

