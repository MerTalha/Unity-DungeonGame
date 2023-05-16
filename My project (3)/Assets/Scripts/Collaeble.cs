using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collaeble : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxcollider;
    private Collider2D[] hits = new Collider2D[10];
    protected virtual void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        boxcollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            onCollide(hits[i]);
            //Array'in temizlenmesi gerekiyor ve elle yapýyoruz
            hits[i] = null; 
        }
    }
    protected virtual void onCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
