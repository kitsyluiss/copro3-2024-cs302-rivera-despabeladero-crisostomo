using System;

namespace CookingSystem
{
    class OverviewCooking : Overview
    {
        public override void Display(object customization)
        {
            if (customization is CookingCustomization cookingCustomization)
            {
                Console.WriteLine("\n═══════ Cooking Customization ═══════");
                Console.WriteLine("Cooking Style: " + cookingCustomization.CookingStyle);
                Console.WriteLine("Cooking Experience: " + cookingCustomization.CookingExperience);
                Console.WriteLine("Homeland: " + cookingCustomization.Homeland);

                Console.WriteLine("\nCuisine Style Allocations:");
                Console.WriteLine("\nCuisine Style Allocations:");
                foreach (var style in cookingCustomization.CuisineStyle)
                {
                    Console.WriteLine(style.Key + ": " + style.Value + " points");
                }

                Console.WriteLine("\nSpecialty: " + cookingCustomization.Specialty);
                Console.WriteLine("Favorite Ingredients: " + cookingCustomization.FavoriteIngredients);
                Console.WriteLine("Personality: " + cookingCustomization.Personality);
                Console.WriteLine("Voice Type: " + cookingCustomization.VoiceType);
                Console.WriteLine("Cooking Tool: " + cookingCustomization.CookingTool);
                Console.WriteLine("Mood: " + cookingCustomization.Mood);
            }
        }
    }
}
