using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AssertTest : MonoBehaviour
{
    GameObject playerGo;
    void Start()
    {
        GameObject go = GameObject.Find("Player");
        Assert.IsNull(go);
    }
    private void Update()
    {
        Assert.AreEqual("Player", playerGo.tag);
        Assert.AreApproximatelyEqual(0f, transform.position.x, 0.5f);
    }



}
