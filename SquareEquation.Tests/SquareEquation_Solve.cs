using Xunit;
using SquareEquationLib;

namespace SquareEquationLib.Tests
{
    public class SquareEquationLib_Test
    {
        [Theory]
        [InlineData(0, 10, 25)]
        [InlineData(1, double.PositiveInfinity, 0)]
        [InlineData(1, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, 10, 25)]
        public void Solve_Input_ReturnArgumentException(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }

        [Theory]
        [InlineData(1, -10, 25, new double[]{5})]
        [InlineData(1,0,-1, new double[] {-1, 1})]
        [InlineData(10, 2, 10, new double[] {})]
        [InlineData(1,5,6, new double[] {-2, -3})]
        [InlineData(1, 0, 1, new double[]{})]
        [InlineData(1, 4, 5, new double[]{})]
        public void Solve_Input_ReturnDoubleArray(double a, double b, double c, double[] expected)
        {
            var act = SquareEquation.Solve(a, b, c);
            
            Array.Sort(act);
            Array.Sort(expected);

            if (act.Length != expected.Length) Assert.Fail("The number of roots does not match");
        
            for (int i = 0; i < act.Length;i++){
                Assert.Equal(expected[i], act[i], 6);
            }
        }
    }
}