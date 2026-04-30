using UnityEngine;

public class TriggerCsound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CsoundUnity CsoundSource;
    
    
    public void Start()
    {
        CsoundSource = GetComponent<CsoundUnity>();
        CsoundSource.SendScoreEvent("i 1 0");
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wind"))
        {
            CsoundSource.SetChannel("Wind", 1f);
        }
        
        else if (other.gameObject.CompareTag("Thunder"))
        {
            CsoundSource.SetChannel("Thunder", 1f);
        }
        
        else if (other.gameObject.CompareTag("Rain"))
        {
            CsoundSource.SetChannel("Rain", 1f);
        }
        
        else if (other.gameObject.CompareTag("StopWind"))
        {
            CsoundSource.SetChannel("Wind", 0f);
        }
        else if (other.gameObject.CompareTag("StopThunder"))
        {
            CsoundSource.SetChannel("Thunder", 0f);
        }
        else if (other.gameObject.CompareTag("StopRain"))
        {
            CsoundSource.SetChannel("Rain", 0f);
        }
        //wind intensity. controls layers + levels of the wind instrument
        else if (other.gameObject.name == "wind_soft")
        {
            CsoundSource.SetChannel("WindLayers", 1f);
            CsoundSource.SetChannel("WindLev", 0.20f);
        }
        else if (other.gameObject.name == "wind_med")
        {
            CsoundSource.SetChannel("WindLayers", 5f);
            CsoundSource.SetChannel("WindLev", 0.40f);
        }
        else if (other.gameObject.name == "wind_strong")
        {
            CsoundSource.SetChannel("WindLayers", 10f);
            CsoundSource.SetChannel("WindLev", 0.70f);
        }
        
        //thunder distance
        else if (other.gameObject.name == "thunder_far")
        {
            CsoundSource.SetChannel("ThunderDist", 0.10f);
            CsoundSource.SetChannel("ThunderLev", 0.30f);
        }
        else if (other.gameObject.name == "thunder_med")
        {
            CsoundSource.SetChannel("ThunderDist", 0.50f);
            CsoundSource.SetChannel("ThunderLev", 0.50f);
        }
        else if (other.gameObject.name == "thunder_near")
        {
            CsoundSource.SetChannel("ThunderDist", 1f);
            CsoundSource.SetChannel("ThunderLev", 1f);
        }
        
        //rain strength
        else if (other.gameObject.name == "rain_soft")
        {
            CsoundSource.SetChannel("RainLev", 1f);
            CsoundSource.SetChannel("RainMix", 0.15f);
            CsoundSource.SetChannel("RainDens", 0.19f);
        }
        else if (other.gameObject.name == "rain_med")
        {
            CsoundSource.SetChannel("RainLev", 1f);
            CsoundSource.SetChannel("RainMix", 0.46f);
            CsoundSource.SetChannel("RainDens", 0.64f);
        }
        
        else if (other.gameObject.name == "rain_strong")
        {
            CsoundSource.SetChannel("RainLev", 1f);
            CsoundSource.SetChannel("RainMix", 1f);
            CsoundSource.SetChannel("RainDens", 1f);
        }
        
    }
    
}
