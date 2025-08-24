using HarmonyLib;
using System;
using System.Collections;
using UnityEngine;

namespace SorrysAdditionsNS
{
    public class SorrysAdditions : Mod
    {
        public override void Ready()
        {
            WorldManager.instance.GameDataLoader.AddCardToSetCardBag(SetCardBagType.CookingIdea, "sorrysadditions_blueprint_golden_berry", 1);
            Logger.Log("Ready!");
        }
    }
}