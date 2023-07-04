namespace Pool;

public class SpaceShip
{

}

public class Pool<T>
{
	public PoolSlot<T> TakeSlot() {} // операция "взять из пула"
	public void Release(PoolSlot<T> slot) {} // операция "вернуть в пул"
	
	/* ... */
	
	// методы для переопределения:
	protected abstract T ObjectConstructor(); // создание нового объекта, готового для использования
	protected virtual void CleanUp(T item) {} // очистка использованного объекта, вызываемая автоматически
}

public class PoolGuard
{

}

class Program
{
    static void Main(string[] args){

    }
}
