using System;
using UnityEngine;

public class SitObject : MonoBehaviour,IIdProvider
{
    [SerializeField]
    public int chairId;
    public Transform[] position;
    public void SetId(int id)
    {
        chairId = id;
    }

    public void SendSit()
    {
    }
}
