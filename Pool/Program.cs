namespace Pool_10;

class Program
{
    static void Main(string[] args){
		int n = 7;
		Pool<SpaceShip> spaceShipPool = new Pool<SpaceShip>(n);
		using(PoolGuard<SpaceShip> poolGuard = new PoolGuard<SpaceShip>(spaceShipPool)){
			SpaceShip spaceShip = poolGuard.TakeObj;
		}
    }
}
