using HarmonyLib;
using System;
using System.Collections;
using UnityEngine;

namespace SorrysAdditionsNS
{
  // Cheese Processor
public class CheeseProcessor : CardData
{
	public override bool DetermineCanHaveCardsWhenIsRoot => true;

	public override bool CanHaveCardsWhileHasStatus()
	{
		return true;
	}

	protected override bool CanHaveCard(CardData otherCard)
	{
		if (otherCard.Id == "milk")
		{
			return true;
		}
		return base.CanHaveCard(otherCard);
	}
}


    // create a class called RedPanda which extends the Animal class
  public class RedPanda : Animal
  {
    // this method decides whether a card should stack onto this one
    protected override bool CanHaveCard(CardData otherCard)
    {
      if (otherCard.Id == "apple")
        return true; // if the other card is an apple, we will let it stack
      return base.CanHaveCard(otherCard); // otherwise, we will let Animal.CanHaveCard decide
    }

    // this method is called every frame, it is the CardData equivalent of the Update method
    public override void UpdateCard()
    {
      // the ChildrenMatchingPredicate method will return all child cards (cards stacked on the current one) that match a given predicate function
      // the given function checks if the card is an apple, so the apples variable will be a list of the apple cards on the red panda
      var apples = ChildrenMatchingPredicate(childCard => childCard.Id == "apple");
      if (apples.Count > 0) // if there are any apples on the red panda
      {
        int healed = 0; // create a variable to keep track of how much health the red panda gained
        foreach (CardData apple in apples) // for each apple on the red panda
        {
          apple.MyGameCard.DestroyCard(); // destroy the apple card
          HealthPoints += 2; // increase the red pandas health by 2
          healed += 2; // keep track of how much it healed in total
        }
        AudioManager.me.PlaySound(AudioManager.me.Eat, Position); // play the eating sound at the red pandas position
        WorldManager.instance.CreateSmoke(Position); // create smoke particles at the red pandas position
        CreateHitText($"+{healed}", PrefabManager.instance.HealHitText); // create a heal text that displays how much it healed in total
      }
      base.UpdateCard(); // call the Animal.UpdateCard method
    }
  }
    public class SorrysAdditions : Mod
    {
        public override void Ready()
        {
            WorldManager.instance.GameDataLoader.AddCardToSetCardBag(SetCardBagType.CookingIdea, "sorrysadditions_blueprint_golden_berry", 1);
            Logger.Log("Ready!");
        }
    }
}