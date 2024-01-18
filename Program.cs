using System;
using System.ComponentModel;

public class SuccessorCardinal
{
    private int k;
    private bool isfinite;//If finite then k is just number, if not then it denotes alephs notation N_{k}

    public SuccessorCardinal(int k, bool isfinite)
    {
        if (k < 0)
            throw new Exception("Invalid input");
        this.k = k;
        this.isfinite = isfinite;
    }

    public int K
    {
        get { return k; }
        set { k = value; }
    }

    public bool Isfinite {  
        get { return isfinite; }
        set { isfinite = value; }
    }

    public SuccessorCardinal Add(SuccessorCardinal other)
    {
        if (isfinite == true && other.isfinite == true)//finite addition
            return new SuccessorCardinal(k + other.k, true);
        else if (isfinite == false && other.isfinite == true)//One of them infinite
            return new SuccessorCardinal(k, false);
        else if (isfinite == true && other.isfinite == false)
            return new SuccessorCardinal(other.k, false);
        else if (k >= other.k)//Both infinite
            return new SuccessorCardinal(k, false);
        else
            return new SuccessorCardinal(other.k, false);
    }

    public SuccessorCardinal Multiply(SuccessorCardinal other)
    {
        if (isfinite == true && other.isfinite == true)//finite multiplication
            return new SuccessorCardinal(k * other.k, true);
        else if ((isfinite == true && k == 0)|| (other.isfinite == true && other.k == 0))//multiply by 0 case
            return new SuccessorCardinal(0, true);
        else if (isfinite == false && other.isfinite == true)//One of them infinite
            return new SuccessorCardinal(k, false);
        else if (isfinite == true && other.isfinite == false)
            return new SuccessorCardinal(other.k, false);
        else if (k >= other.k)//Both infinite
            return new SuccessorCardinal(k, false);
        else
            return new SuccessorCardinal(other.k, false);
    }

    public SuccessorCardinal Pow(SuccessorCardinal other)//Exponentiation assume GCH
    {
        if (isfinite == true && other.isfinite == true)//finite exponentiation
            return new SuccessorCardinal( (int)Math.Pow(k, other.k), true);
        else if ((isfinite == true && k == 0))//0 to any power is 0
            return new SuccessorCardinal(0, true);
        else if ((isfinite == true && k == 1))//1 to any power is 1
            return new SuccessorCardinal(1, true);
        else if ((other.isfinite == true && other.k == 0))//anything to 0th power is 1
            return new SuccessorCardinal(1, true);
        else if ((other.isfinite == true && other.k == 1))//anything to power 1 is itself
            return new SuccessorCardinal(k, isfinite);
        else if (isfinite == false && other.isfinite == true)
            return new SuccessorCardinal(k, false);
        else if (isfinite == true && other.isfinite == false)
            return new SuccessorCardinal(other.k + 1, false);
        else if (k > other.k)//Both infinite
            return new SuccessorCardinal(k, false);
        else
            return new SuccessorCardinal(other.k + 1, false);
    }

}