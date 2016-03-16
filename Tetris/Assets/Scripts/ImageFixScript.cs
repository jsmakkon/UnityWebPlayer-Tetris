using UnityEngine;
using System.Collections;

public class ImageFixScript : MonoBehaviour {

    // Fix width and height of background image in menus
	void Start () {
        RectTransform childRect = transform.FindChild("DarkBackground").GetComponent<RectTransform>();
        RectTransform canvasRect = GetComponent<RectTransform>();
        childRect.sizeDelta = new Vector2(canvasRect.sizeDelta.x, canvasRect.sizeDelta.y);
        gameObject.SetActive(false);
    }
}
