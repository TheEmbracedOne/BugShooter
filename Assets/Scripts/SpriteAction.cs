using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpriteAction {

    void SetState(bool s); //enable this spriteAction
    bool IsEnabled();
}
