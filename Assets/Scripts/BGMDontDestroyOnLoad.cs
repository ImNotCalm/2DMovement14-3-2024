using UnityEngine;

public class BGMDontDestroyOnLoad : MonoBehaviour
{
    private BGMDontDestroyOnLoad Instance;

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
}
