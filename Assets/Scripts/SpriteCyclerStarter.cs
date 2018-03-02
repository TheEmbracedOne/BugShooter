using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCyclerStarter : MonoBehaviour {

    private SpriteAction sa;

    void Update()
    {
        sa = this.GetComponent<SpriteAction>();
        if(!sa.IsEnabled())
        {
            sa.SetState(true);
        }
    }
}
