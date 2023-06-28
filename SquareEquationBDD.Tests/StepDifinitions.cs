namespace SquareEquationBDD.Tests;
using TechTalk.SpecFlow;
using SquareEquationLib;

[Binding]
public class StepDefinitions
{
    private double a, b, c;
    private double[] actionResult = new double[0]; 
    private Exception actualException = new Exception();

	[Given(@"^Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void КвадратноеУравнение(string p0, string p1, string p2)
    {
        string[] coefficients = new string[]{p0, p1, p2};
        double[] coefficientsDouble = new double[coefficients.Length];
        for (int i=0; i < coefficients.Length; i++){
            if(coefficients[i] == "NaN"){
                coefficientsDouble[i] = double.NaN;
            }
            else if(coefficients[i] == "Double.NegativeInfinity"){
                coefficientsDouble[i] = double.NegativeInfinity;
            }
            else if(coefficients[i] == "Double.PositiveInfinity"){
                coefficientsDouble[i] = double.PositiveInfinity;
            }
            else{
                coefficientsDouble[i] = double.Parse(coefficients[i]);
            }
        } 
        a = coefficientsDouble[0]; b = coefficientsDouble[1]; c = coefficientsDouble[2];
    }

    [When(@"^вычисляются корни квадратного уравнения")]
    public void НахождениеКорней(){
        try{
            actionResult = SquareEquation.Solve(a, b, c);
        }
        catch(Exception e){
            actualException = e;
        }
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(double r1, double r2)
    {
        double[] expectedResult = new double[]{r1, r2};

        Array.Sort(expectedResult); Array.Sort(actionResult);
        for (int i = 0; i < expectedResult.Length;i++){
                Assert.Equal(expectedResult[i], actionResult[i], 6);
            }
    }

    [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
    public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва(double expectedRoot)
    {
        double[] expectedResult = new double[]{expectedRoot};

        Array.Sort(expectedResult); Array.Sort(actionResult);
        for (int i = 0; i < expectedResult.Length;i++){
                Assert.Equal(expectedResult[i], actionResult[i], 6);
            }
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void ТоКвадратноеУравнениеНеИмеетКорней()
    {
        Assert.Empty(actionResult);
    }

    [Then(@"выбрасывается исключение ArgumentException")]
    public void ТоВыбрасываетсяИсключениеArgumentException()
    {
        Assert.ThrowsAsync<ArgumentException>(() => throw actualException);
    }
}
