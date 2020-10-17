using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//把此脚本挂到Camera上， 可以让相机跟随一个指定GameObject 
//运行此脚本需要：
//          1. 在外部（unity editor里）指定此脚本的followObject
public class cameraFollow : MonoBehaviour
{
    public GameObject followObject;
    private Transform target;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        target = followObject.transform;
        offset = target.position - this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position - offset;
    }
}
