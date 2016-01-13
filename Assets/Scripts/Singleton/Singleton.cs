public class Singleton<T>  where T : Updateable, new()  {
    private static object threadLock = new object();
    private static T instance;

    protected Singleton() {
    }

    public static T Instance {
        get {
            return InstanceCreation();
        }
    }
    public static T InstanceCreation() {
        if (instance == null) {
            lock (threadLock) {
                if (instance == null) {
                    instance = new T();
                    instance.RegisterForUpdates();
                }
            }
        }
        return instance; 
    }
}
