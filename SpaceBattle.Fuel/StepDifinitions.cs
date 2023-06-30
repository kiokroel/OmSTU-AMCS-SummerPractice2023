namespace SpaceBattle.Fuel;
using TechTalk.SpecFlow;
using SpaceBattleLib;

 [Binding]
public class StepDefinitions
{
    private double fuelAmount = double.NaN;
    private double fuelConsumption = double.NaN;
    private Exception actualException = new Exception();
    private double actualResult = double.NaN; 

	[Given(@"^космический корабль имеет топливо в объеме (.*) ед")]
    public void КоординатыКорабляВТочке(double fuelAm)
    { 
        fuelAmount = fuelAm; 
    }

    [Given(@"^имеет скорость расхода топлива при движении (.*) ед")]
    public void СкоростьКорабля(double fuelCons)
    { 
        fuelConsumption = fuelCons;  
    }

    [When(@"^происходит прямолинейное равномерное движение без деформации")]
    public void ДвижениеКорабля(){
        try{
            actualResult = ShipFuel.Movement(fuelAmount, fuelConsumption);
        }
        catch(Exception e){
            actualException = e;
        }
    }

    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void КосмическийКорабльПеремещаетсяВТочкуПространства(double expectedResult)
    {
        Assert.Equal(expectedResult, actualResult, 6);
    }

    [Then(@"возникает ошибка Exception")]
    public void ВозникаетОшибка()
    {
        Assert.ThrowsAsync<Exception>(() => throw actualException);
    }
}
