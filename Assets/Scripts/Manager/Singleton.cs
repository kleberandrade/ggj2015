using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
 
	private static object _lock = new object();
 
	public static T Instance
	{
		get
		{
			if (applicationIsQuitting) {
				Debug.LogWarning("[Singleton] Instance '"+ typeof(T) +
					"' already destroyed on application quit." +
					" Won't create again - returning null.");
				return null;
			}
 
			lock(_lock)
			{
				if (instance == null)
				{
					instance = (T) FindObjectOfType(typeof(T));
 
					if ( FindObjectsOfType(typeof(T)).Length > 1 )
					{
						Debug.LogError("[Singleton] Something went really wrong " +
							" - there should never be more than 1 singleton!" +
							" Reopenning the scene might fix it.");
						return instance;
					}
 
					if (instance == null)
					{
						GameObject singleton = new GameObject();
						instance = singleton.AddComponent<T>();
						singleton.name = "[Singleton] " + typeof(T).ToString();
                        DontDestroyOnLoad(singleton);
 
						Debug.Log("[Singleton] An instance of " + typeof(T) + 
							" is needed in the scene, so '" + singleton +
							"' was created with DontDestroyOnLoad.");
					} else {
						Debug.Log("[Singleton] Using instance already created: " +
							instance.gameObject.name);
					}
				}
 
				return instance;
			}
		}
	}
 
	private static bool applicationIsQuitting = false;

	public void OnDestroy () {
		applicationIsQuitting = true;
	}
}