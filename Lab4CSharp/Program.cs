/*
using System;

class ITriangle
{
    private int a; 
    private int b; 
    private int color; 

    public int A
    {
        get { return a; }
        set { a = value; }
    }

    public int B
    {
        get { return b; }
        set { b = value; }
    }

    public int Color
    {
        get { return color; }
        set { color = value; }
    }

    public ITriangle(int a, int b, int color)
    {
        A = a;
        B = b;
        Color = color;
    }

    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return A;
                case 1:
                    return B;
                case 2:
                    return Color;
                default:
                    throw new IndexOutOfRangeException("Invalid index. Use 0 for side a, 1 for side b, 2 for color.");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    A = value;
                    break;
                case 1:
                    B = value;
                    break;
                case 2:
                    Color = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid index. Use 0 for side a, 1 for side b, 2 for color.");
            }
        }
    }

    public static ITriangle operator ++(ITriangle triangle)
    {
        triangle.A++;
        triangle.B++;
        return triangle;
    }

    public static ITriangle operator --(ITriangle triangle)
    {
        triangle.A--;
        triangle.B--;
        return triangle;
    }

    public static bool operator true(ITriangle triangle)
    {
        return triangle.IsValid();
    }

    public static bool operator false(ITriangle triangle)
    {
        return !triangle.IsValid();
    }


    public static ITriangle operator *(ITriangle triangle, int scalar)
    {
        triangle.A *= scalar;
        triangle.B *= scalar;
        return triangle;
    }

    public override string ToString()
    {
        return $"ITriangle: a = {A}, b = {B}, color = {Color}";
    }

    public static explicit operator ITriangle(string s)
    {
        string[] parts = s.Split(',');
        if (parts.Length != 3)
        {
            throw new ArgumentException("Invalid string format. Expected format: 'a, b, color'");
        }

        if (!int.TryParse(parts[0], out int a) || !int.TryParse(parts[1], out int b) || !int.TryParse(parts[2], out int color))
        {
            throw new ArgumentException("Invalid values in string.");
        }

        return new ITriangle(a, b, color);
    }

    private bool IsValid()
    {
        return (A + B > Color) && (A + Color > B) && (B + Color > A);
    }

    public void Show()
    {
        Console.WriteLine($"ITriangle: a = {A}, b = {B}, color = {Color}");
    }
}

class Program
{
    static void Main()
    {
        ITriangle triangle1 = new ITriangle(3, 4, 5);
        ITriangle triangle2 = new ITriangle(2, 2, 3);

        Console.WriteLine("Triangle 1:");
        triangle1.Show();
        Console.WriteLine($"Triangle 1 is valid: {triangle1}");

        Console.WriteLine("\nTriangle 2:");
        triangle2.Show();
        Console.WriteLine($"Triangle 2 is valid: {triangle2}");

        Console.WriteLine("\nIncrementing sides of Triangle 1:");
        triangle1++;
        triangle1.Show();

        Console.WriteLine("\nMultiplying sides of Triangle 2 by 2:");
        triangle2 *= 2;
        triangle2.Show();

        string input = "6, 6, 8";
        ITriangle triangleFromString = (ITriangle)input;
        Console.WriteLine($"\nTriangle from string: {triangleFromString}");
    }
}

using System;

public class Vector
{
    protected double[] ArrayDouble;
    protected uint num;
    protected int codeError;
    protected static uint num_vec;

    public Vector()
    {
        ArrayDouble = new double[1];
        num = 1;
        codeError = 0;
        num_vec++;
    }

    public Vector(uint size)
    {
        ArrayDouble = new double[size];
        num = size;
        codeError = 0;
        num_vec++;
    }

    public Vector(uint size, double initValue)
    {
        ArrayDouble = new double[size];
        num = size;
        for (uint i = 0; i < size; i++)
        {
            ArrayDouble[i] = initValue;
        }
        codeError = 0;
        num_vec++;
    }

    ~Vector()
    {
        Console.WriteLine("Destructor for Vector called");
    }

    public void Input()
    {
        for (uint i = 0; i < num; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            if (!double.TryParse(Console.ReadLine(), out double val))
            {
                Console.WriteLine("Invalid input. Please enter a valid double value.");
                codeError = -1;
                return;
            }
            ArrayDouble[i] = val;
        }
        codeError = 0;
    }

    public void Display()
    {
        for (uint i = 0; i < num; i++)
        {
            Console.Write($"{ArrayDouble[i]} ");
        }
        Console.WriteLine();
    }

    public void SetValue(double value)
    {
        for (uint i = 0; i < num; i++)
        {
            ArrayDouble[i] = value;
        }
    }

    public static uint GetNumVec()
    {
        return num_vec;
    }

    public uint Size
    {
        get { return num; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public double this[uint index]
    {
        get
        {
            if (index < num)
            {
                codeError = 0;
                return ArrayDouble[index];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (index < num)
            {
                codeError = 0;
                ArrayDouble[index] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    public static Vector operator +(Vector vec1, Vector vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        Vector result = new Vector(maxSize);
        for (uint i = 0; i < maxSize; i++)
        {
            double val1 = i < vec1.Size ? vec1[i] : 0;
            double val2 = i < vec2.Size ? vec2[i] : 0;
            result[i] = val1 + val2;
        }
        return result;
    }

    public static Vector operator -(Vector vec1, Vector vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        Vector result = new Vector(maxSize);
        for (uint i = 0; i < maxSize; i++)
        {
            double val1 = i < vec1.Size ? vec1[i] : 0;
            double val2 = i < vec2.Size ? vec2[i] : 0;
            result[i] = val1 - val2;
        }
        return result;
    }

    public static Vector operator *(Vector vec1, double scalar)
    {
        Vector result = new Vector(vec1.Size);
        for (uint i = 0; i < vec1.Size; i++)
        {
            result[i] = vec1[i] * scalar;
        }
        return result;
    }

    public static bool operator ==(Vector vec1, Vector vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (uint i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] != vec2[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(Vector vec1, Vector vec2)
    {
        return !(vec1 == vec2);
    }

    public static bool operator >(Vector vec1, Vector vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (uint i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] <= vec2[i])
                return false;
        }
        return true;
    }

    public static bool operator <(Vector vec1, Vector vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (uint i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] >= vec2[i])
                return false;
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }
}

public class VectorDecimal : Vector
{
    public VectorDecimal() : base()
    {
    }

    public VectorDecimal(uint size) : base(size)
    {
    }

    public VectorDecimal(uint size, double initValue) : base(size, initValue)
    {
    }
}

public class Program
{
    public static void Main()
    {
        VectorDecimal vec1 = new VectorDecimal(3, 2.5);
        VectorDecimal vec2 = new VectorDecimal(3, 1.5);

        Console.WriteLine("Vector 1:");
        vec1.Display();

        Console.WriteLine("Vector 2:");
        vec2.Display();

        VectorDecimal sum = (VectorDecimal)(vec1 + vec2);
        Console.WriteLine("Sum:");
        sum.Display();

        VectorDecimal difference = (VectorDecimal)(vec1 - vec2);
        Console.WriteLine("Difference:");
        difference.Display();

        VectorDecimal scalarProduct = (VectorDecimal)(vec1 * 2.0);
        Console.WriteLine("Scalar Product:");
        scalarProduct.Display();

        Console.WriteLine("Number of Vectors: " + Vector.GetNumVec());
    }
}
*/

using System;

public class Matrix
{
    protected decimal[,] DCArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_mf;

    public Matrix(uint n, uint m)
    {
        DCArray = new decimal[n, m];
        this.n = n;
        this.m = m;
        codeError = 0;
        num_mf++;
    }

    public void EnterElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Enter element at position ({i},{j}): ");
                DCArray[i, j] = Convert.ToDecimal(Console.ReadLine());
            }
        }
    }

    public void DisplayElements()
    {
        Console.WriteLine("Matrix elements:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{DCArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public static int CountMatrices()
    {
        return num_mf;
    }
}

public class DecimalMatrix : Matrix
{
    public DecimalMatrix(uint n, uint m) : base(n, m) { }

    public DecimalMatrix(uint n, uint m, decimal initialValue) : base(n, m)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                DCArray[i, j] = initialValue;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating a new DecimalMatrix...");
        DecimalMatrix decimalMatrix = new DecimalMatrix(3, 3);

        Console.WriteLine("Enter elements of the matrix:");
        decimalMatrix.EnterElements();

        Console.WriteLine("Displaying elements of the matrix:");
        decimalMatrix.DisplayElements();

        Console.WriteLine($"Number of matrices created: {Matrix.CountMatrices()}");
    }
}
