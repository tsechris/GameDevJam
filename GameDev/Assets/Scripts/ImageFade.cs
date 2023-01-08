using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class ImageFade : MonoBehaviour {
 
    // the image you want to fade, assign in inspector
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    private bool fadeOut = true; 
   
    public void OnButtonClick()
    {
        // fades the image out when you click
        fadeOut = !fadeOut; 
        StartCoroutine(FadeImage(fadeOut, img1));
        StartCoroutine(FadeImage(fadeOut, img2));
        StartCoroutine(FadeImage(fadeOut, img3));
        StartCoroutine(FadeImage(fadeOut, img4));

    }
 
    IEnumerator FadeImage(bool fadeAway, Image img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime * 2)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime * 2)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
 