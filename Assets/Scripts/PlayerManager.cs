using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script created as a singleton to give enemy a reference to a player
//will work only because we do not spawn player
public class PlayerManager : MonoBehaviour {

    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public GameObject player;
}
