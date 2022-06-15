using UnityEngine;

public class FrameFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetResolution();   
    }

    // Update is called once per frame
    public void SetResolution()
    {
        int setWidth = 1920;
        int setHeight = 1080;

        Screen.SetResolution(setWidth, setHeight, true);
    }
}
