using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour {

    [System.Serializable]
    public class ColliderEvent : UnityEvent<Collider> { }


    public ColliderEvent onTriggerStay = new ColliderEvent();
    public ColliderEvent onTriggerExit = new ColliderEvent();
	

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other); 
    }


    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke(other);
    }
}
