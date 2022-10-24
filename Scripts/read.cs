using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/read")]

public class read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (ReadToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "There is no " + noun + " here!";
    }

    private bool ReadToItem(GameController controller, List<Item> items, string noun)
    {

        foreach (Item item in items)
        {
            if (item.itemName == noun && item.itemEnabled)
            {
                if (controller.player.ReadToItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "The " + noun + " doesn't readeble";
                return true;
            }

        }
        return false;

    }

}
