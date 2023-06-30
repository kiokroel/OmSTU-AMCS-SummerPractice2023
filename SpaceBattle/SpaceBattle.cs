namespace SpaceBattleLib;

public class SpaceBattle
{
    public static double[] Movement(double[] SpaceshipCoordinates, double[] SpaceshipSpeed, bool relocate)
    {
        foreach(double x in SpaceshipCoordinates.Concat(SpaceshipSpeed).ToArray()){
            if (double.IsNaN(x) | double.IsInfinity(x)) throw new System.Exception();
        }
        if (relocate == false) throw new System.Exception();

        for (int i = 0; i < SpaceshipCoordinates.Length;i++){
            SpaceshipCoordinates[i] += SpaceshipSpeed[i];
        }

        return  SpaceshipCoordinates;
    }
}