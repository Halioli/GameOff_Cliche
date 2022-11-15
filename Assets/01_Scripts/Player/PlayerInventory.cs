using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int fruits;

    void Start()
    {
        fruits = 0;
    }

    public int GetFruits() { return fruits; }
    public void SetFruits(int _val) { fruits = _val; }

    public void AddFruits(int _val) { fruits += _val; }
}
