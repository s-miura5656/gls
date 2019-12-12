using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRawImageAspect : MonoBehaviour
{
    [SerializeField] private RawImage rawImage = null;
    private Vector2 default_size;
    // Start is called before the first frame update
    void Start()
    {
        default_size = rawImage.rectTransform.rect.size;
        rawImage.FixAspect(default_size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
