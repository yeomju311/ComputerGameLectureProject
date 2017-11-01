using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	
	static Singleton current = null;
	static GameObject container = null;
	
	public static Singleton Instance {
		get {
			if(current == null){
				container = new GameObject();
				container.name = "Singleton";
				current = container.AddComponent(typeof(Singleton)) as Singleton;
				DontDestroyOnLoad(current);
			}
			return current;
		}
	}
	
	public float recTime = 0.0f;
	public float bestTime = 1000.0f;
}