using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCannonball : MonoBehaviour
{
    public Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(rb2.gameObject, 2f);
    }

}
