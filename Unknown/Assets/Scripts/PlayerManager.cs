using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    //private vp_PlayerItemDropper _itemDropper;

    // Start is called before the first frame update
    void Start()
    {
        //_itemDropper = GetComponent<vp_PlayerItemDropper>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyUp(KepCode.B))
        {
            _itemDropper.TryDropCurrentWeapon();
        }*/
    }
}
