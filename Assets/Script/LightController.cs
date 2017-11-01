using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

    public Light lt;
	
    void Start() {
        lt = GetComponent<Light>();
    }
	
    void Update() { 
	        lt.intensity -= 0.0005f;
    }
}
