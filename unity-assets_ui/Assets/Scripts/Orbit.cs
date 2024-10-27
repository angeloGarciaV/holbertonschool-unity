using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    const float G = 10f;
    
    public static List<Orbit> Orbits;
    public Rigidbody rb;

    void FixedUpdate()
    {
        foreach (Orbit orbit in Orbits)
        {
            if(orbit != this)
                Attract(orbit);
        }

        if(this.gameObject.transform.position.z > 500 || this.gameObject.transform.position.z < -500
            || this.gameObject.transform.position.x > 500 || this.gameObject.transform.position.x < -500)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void OnEnable ()
    {
        if(Orbits == null)
            Orbits = new List<Orbit>();

        Orbits.Add(this);
    }

    void OnDisable ()
    {
        Orbits.Remove(this);
    }

    void Attract (Orbit objToAttract)
    {
        Rigidbody rbToAttract= objToAttract.rb;
        
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.sqrMagnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distance;
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
