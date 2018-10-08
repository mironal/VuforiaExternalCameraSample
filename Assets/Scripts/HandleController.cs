using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleController : MonoBehaviour {
    private const string NO_COLLISION = "No collision";
    public TextMeshPro textMeshPro;

    private void Start()
    {
        textMeshPro.SetText(NO_COLLISION);
    }
    void Update()
    {
        if(Camera.current == null)
        {
            return;
        }

        textMeshPro.transform.rotation = Quaternion.LookRotation(textMeshPro.transform.position - Camera.current.transform.position);
    }

    public void OnTriggerObject(Collider other)
    {
        var next = other.gameObject.tag.ToString() + other.gameObject.transform.position.ToString();
        textMeshPro.SetText(next);
        Debug.Log("OnTriggerObject" + next, other);
        other.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnExitObject(Collider other)
    {
        textMeshPro.SetText(NO_COLLISION);
        Debug.Log("OnExitObject" + other.gameObject.tag.ToString(), other);
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
