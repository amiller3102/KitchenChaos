using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObect;

    [SerializeField] private KitchenObjectSO KitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // Player is not carrying anything
            KitchenObject.SpawnKitchenObject(KitchenObjectSO, player);

            OnPlayerGrabbedObect?.Invoke(this, EventArgs.Empty);
        }
    } 
}
