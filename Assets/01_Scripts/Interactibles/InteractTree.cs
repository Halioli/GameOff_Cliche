using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractTree : InteractMaster
{
    [SerializeField] Transform tree;
    [SerializeField] GameObject[] fruits;

    public override void DoInteraction(PlayerManager playerManager)
    {
        //base.DoInteraction();
        tree.DOShakePosition(0.2f, 0.2f);

        for (int i = 0; i < fruits.Length; i++)
        {
            fruits[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
