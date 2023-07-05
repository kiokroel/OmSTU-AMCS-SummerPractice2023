namespace Pool_10;

public class SpaceShip
{
    public static double[] Movement(double[] spaceshipCoordinates, double[] spaceshipSpeed, bool relocate)
    {
        foreach(double x in spaceshipCoordinates.Concat(spaceshipSpeed).ToArray()){
            if (double.IsNaN(x) | double.IsInfinity(x)) throw new System.Exception();
        }
        if (relocate == false) throw new System.Exception();

        for (int i = 0; i < spaceshipCoordinates.Length;i++){
            spaceshipCoordinates[i] += spaceshipSpeed[i];
        }

        return  spaceshipCoordinates;
    }

    public static double Rotation(double inclination, double rotationalSpeed, bool rotation){
        foreach(double x in new double[]{inclination, rotationalSpeed}){
            if (double.IsNaN(x) | double.IsInfinity(x)) throw new System.Exception();
        }
        if (rotation == false) throw new System.Exception();

        return inclination + rotationalSpeed;
    }

    public static double Movement(double fuelAmount, double fuelConsumption){
        if (fuelConsumption > fuelAmount) throw new System.Exception();

        return fuelAmount - fuelConsumption;
    }
}
