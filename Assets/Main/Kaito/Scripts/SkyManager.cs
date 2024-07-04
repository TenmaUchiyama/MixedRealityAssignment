using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public string skymode;

    void Start()
    {
        skymode = "day";
    }

    public void SkymodeChangeTo(string toSkymode)
    {
        if (skymode ==  toSkymode)
        {
            return;
        }

        SkyChanger skyChanger = GetComponent<SkyChanger>();
        skyChanger.skychangeTo(toSkymode);
        skymode = toSkymode;
    }
}