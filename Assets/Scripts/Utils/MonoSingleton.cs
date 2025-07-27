using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<T>();
                    if (instance == null)
                    {
                        SetupInstance();
                    }
                }
                return instance;
            }
        }

        public virtual void Awake()
        {
            RemoveDuplicates();
        }

        public static void SetupInstance()
        {
            GameObject newObject = new()
            {
                name = typeof(T).Name
            };
            instance = newObject.AddComponent<T>();
            DontDestroyOnLoad(newObject);
        }

        private void RemoveDuplicates()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
