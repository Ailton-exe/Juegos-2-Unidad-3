using UnityEngine;

public class OpenUrl : MonoBehaviour

{
    public void Openurl(string UrlName)
    {
        Application.OpenURL(UrlName);
    }
}