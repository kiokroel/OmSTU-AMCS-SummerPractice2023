namespace Pool_10;

public class Pool<T> where T : new()
{
	public Queue<T> pool;

	public Pool(int countObj){
		pool = new Queue<T>(countObj);
		for (int i = 0;i<countObj;i++){
			pool.Enqueue(new T());
		}
	}

	public T Get() {
		if (pool.Count > 0){
			return pool.Dequeue();
		}
		return new T();
	}

	public void Release(T obj) {
		pool.Enqueue(obj);
	}
}

public class PoolGuard<T> : IDisposable where T : new()  
{
	private Pool<T> pool;
	private T obj;

    public PoolGuard(Pool<T> pool){
		this.pool = pool;
		obj = pool.Get();
	}

    public void Dispose()
    {
        pool.Release(obj);
    }

	public T TakeObj => pool.Get();
}