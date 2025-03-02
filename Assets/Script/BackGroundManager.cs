using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private MeshRenderer render;

    private float offset;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * Speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
