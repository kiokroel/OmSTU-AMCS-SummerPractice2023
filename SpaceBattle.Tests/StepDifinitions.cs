namespace SpaceBattle.Tests;
using TechTalk.SpecFlow;
using SpaceBattleLib;

[Binding, Scope(Feature = "Движение корабля")]
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
            actualResult = ShipMove.Movement(spaceshipCoordinates, spaceshipSpeed, relocate);
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

[Binding, Scope(Feature = "Движение при достаточном количестве топлива")]
public class StepDefinitions2
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

[Binding, Scope(Feature = "Разворот")]
public class StepDefinitions3
{
    private double inclination = double.NaN;
    private double rotationalSpeed = double.NaN;
    private double actualResult = double.NaN;
    private bool rotation = true;
    private Exception actualException = new Exception();

	[Given(@"^космический корабль имеет угол наклона (.*) град к оси OX")]
    public void УголНаклона(double incl)
    { 
        inclination = incl;
    }

    [Given(@"^космический корабль, угол наклона которого невозможно определить")]
    public void УголНаклонаОпределитьНевозможно(){}

    [Given(@"^имеет мгновенную угловую скорость (.*) град")]
    public void УгловаяСкорость(double rotSpeed)
    { 
        rotationalSpeed = rotSpeed;
    }

    [Given(@"^мгновенную угловую скорость невозможно определить")]
    public void СкоростьВращения(){}

    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
         public void НевозможноИзменитьУголдНаклонаКОсиOXКосмическогоКорабля()
         {
            rotation = false;
         }

    [When(@"^происходит вращение вокруг собственной оси")]
    public void Вращение(){
        try{
            actualResult = ShipRotation.Rotation(inclination, rotationalSpeed, rotation);
        }
        catch(Exception e){
            actualException = e;
        }
    }

    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void УголНаклонаСтановится(double expectedResult)
    {
        Assert.Equal(expectedResult, actualResult, 6);
    }

    [Then(@"возникает ошибка Exception")]
    public void ВозникаетОшибка()
    {
        Assert.ThrowsAsync<Exception>(() => throw actualException);
    }
}

