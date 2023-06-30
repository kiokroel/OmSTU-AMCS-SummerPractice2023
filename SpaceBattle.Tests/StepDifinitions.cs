namespace SpaceBattle.Tests;
using TechTalk.SpecFlow;
using SpaceBattleLib;

[Binding]
public class StepDefinitions
{
    private double[] spaceshipCoordinates = new double[]{double.NaN, double.NaN};
    private double[] spaceshipSpeed = new double[]{double.NaN, double.NaN};
    private double[] actualResult = new double[]{double.NaN, double.NaN};
    private bool relocate = true;
    private Exception actualException = new Exception();

	[Given(@"^космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void КоординатыКорабляВТочке(double x, double y)
    { 
        spaceshipCoordinates[0] = x;
        spaceshipCoordinates[1] = y;    
    }

    [Given(@"^космический корабль, положение в пространстве которого невозможно определить")]
    public void КоординатыКорабляОпределитьНевозможно(){}

    [Given(@"^имеет мгновенную скорость \((.*), (.*)\)")]
    public void СкоростьКорабля(double x, double y)
    { 
        spaceshipSpeed[0] = x;
        spaceshipSpeed[1] = y;    
    }

    [Given(@"^скорость корабля определить невозможно")]
    public void СкоростьКорабля(){}

    [Given(@"^изменить положение в пространстве космического корабля невозможно")]
    public void ПерещениеНевозможно()
    { 
        relocate = false;    
    }

    [When(@"^происходит прямолинейное равномерное движение без деформации")]
    public void ДвижениеКорабля(){
        try{
            actualResult = SpaceBattle.Movement(spaceshipCoordinates, spaceshipSpeed, relocate);
        }
        catch(Exception e){
            actualException = e;
        }
    }

    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void КосмическийКорабльПеремещаетсяВТочкуПространства(double x, double y)
    {
        double[] expectedResult = new double[]{x, y};

        for (int i = 0; i < expectedResult.Length;i++){
                Assert.Equal(expectedResult[i], actualResult[i], 6);
            }
    }

    [Then(@"возникает ошибка Exception")]
    public void ВозникаетОшибка()
    {
        Assert.ThrowsAsync<Exception>(() => throw actualException);
    }
}