using Xunit;
using SquareEquationLib;

namespace SquareEquationLib.Tests
{
    public class SquareEquationLib_Test
    {
        /*[Fact]
        public void Solve_Input()
        {
            int a = 1;
            int b = 10;
            int c = 25;
            double[] expection = new double[]{5};

            var res = SquareEquation.Solve(a, b, c);

            Assert.NotEqual(expection, res);
        }*/

        [Theory]
        [InlineData(0, 10, 25)]
        [InlineData(1, double.PositiveInfinity, 0)]
        [InlineData(1, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, 10, 25)]
        [InlineData(double.NegativeInfinity, 10, 25)]
        [InlineData(5, double.NegativeInfinity, 25)]
        [InlineData(9, 10, double.NegativeInfinity)]
        [InlineData(0.0/0.0 , 10, 99)]
        [InlineData(50, 0.0/0.0, 13)]
        [InlineData(50, 3, 0.0/0.0)]
        public void Solve_Input_ReturnArgumentException(double a, double b, double c)
        {
            bool result = false;

            try{
                var wqe = SquareEquation.Solve(a, b, c);
            }
            catch (ArgumentException){
                result = true;
                return;
            }

            Assert.True(result);
        }

        [Theory]
        [InlineData(1, -10, 25, new double[]{5})]
        [InlineData(4, 4, 0, new double[]{0.0,-1})]
        [InlineData(3, 4, -5, new double[]{-2.1196,0.78630})]
        [InlineData(-1, 0, 1, new double[]{-1, 1})]
        
        
        public void Solve_Input_ReturnDoubleArray(double a, double b, double c, double[] expected)
        {
            bool result = false;

            var act = SquareEquation.Solve(a, b, c);
            if (expected.Length == act.Length){    
                result = true;
            }

            Assert.True(result);
        }
    }
}