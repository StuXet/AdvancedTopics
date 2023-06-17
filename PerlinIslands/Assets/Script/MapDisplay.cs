using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textRend;

    public void DrawTexture(Texture2D texture)
    {
        textRend.sharedMaterial.mainTexture = texture;
        textRend.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
