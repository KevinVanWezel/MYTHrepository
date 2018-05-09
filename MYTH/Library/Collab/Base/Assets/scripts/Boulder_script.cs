using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder_script : MonoBehaviour {
    [SerializeField]
    private Grid _grid;

	// Use this for initialization
	void Start () {
        
      
	}
	
	// Update is called once per frame
	void Update () {
    print(    _grid.findSelf(gameObject));
       
        EmptyUnder();

        EmptySide();

        BoulderSlide();

        PlayerSide();

        PlayerUnder();
        

	}
    void EmptyUnder()
    {
        //looks if there is a empty block under the boulder
    }

    void EmptySide()
    {

        //looks if there is a empty bolck on the side of him
    }

    void BoulderSlide()
    {
        //checks if there is a boulder under him, empyt side of him, empty under left and right
    }

    void PlayerSide()
    {

        // looks if there is a player on the side
    }

    void PlayerUnder()
    {

        //looks if there is a player under him
    }
}
