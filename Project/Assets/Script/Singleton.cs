namespace Game
{
    public class Singleton<T> where  T : new ()
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
        
        private static T _instance;


        public virtual void Awake()
        {
            
        }
        public virtual void Update()
        {
            
        }

    }
}