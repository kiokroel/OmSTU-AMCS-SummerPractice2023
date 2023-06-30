namespace SpaceBattle.Rotation;
using TechTalk.SpecFlow;
using SpaceBattleLib;

 [Binding]
public class StepDefinitions
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
