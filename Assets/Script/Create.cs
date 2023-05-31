using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : InteractableItemBase
{
    private bool mIsOpen = false;

    public override void OnInteract()
    {
        InteractText = "Click on it";

        mIsOpen = !mIsOpen;

        InteractText += mIsOpen ? "to close" : "to open";

        GetComponent<Animator>().SetBool("open", mIsOpen);
    }
}
