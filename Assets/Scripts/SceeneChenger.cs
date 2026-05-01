using UnityEngine;
using UnityEngine.SceneManagement;

public class SceeneChenger : MonoBehaviour
{

    [SerializeField] string NextSceene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        if (NextSceene != null)
        {
            //Click‚³‚ê‚½‚çƒV[ƒ“ˆÚ“®
            SceneManager.LoadScene(NextSceene);
        }
    }
}
