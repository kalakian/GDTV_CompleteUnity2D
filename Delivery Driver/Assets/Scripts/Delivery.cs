using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float packageDestroyDelay = 1.0f;
    [SerializeField] Color32 normalColour = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 hasPackageColour = new Color32(1, 1, 1, 1);

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = normalColour;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;

            Destroy(collision.gameObject, packageDestroyDelay);
        }
        else if(collision.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = normalColour;
        }
    }
}
