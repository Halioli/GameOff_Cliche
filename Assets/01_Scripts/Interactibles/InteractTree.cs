using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTree : InteractMaster
{
    [SerializeField] GameObject[] fruits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoInteraction()
    {
        //base.DoInteraction();

        for (int i = 0; i < fruits.Length; i++)
        {
            fruits[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
