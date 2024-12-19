using System;

namespace CookingSystem
{
    class OverviewCharacter : Overview
    {
        public override void Display(object customization)
        {
            if (customization is CharacterCustomization characterCustomization)
            {
                Console.WriteLine("\nCongrats! You have successfully created a character!\n");

                Console.WriteLine("═══════ Character Attributes ═══════");
                Console.WriteLine("Character Name: " + characterCustomization.CharacName);
                Console.WriteLine("Gender: " + characterCustomization.Gender);
                Console.WriteLine("Age: " + characterCustomization.Age);
                Console.WriteLine("Skin Tone: " + characterCustomization.SkinTone);
                Console.WriteLine("Height: " + characterCustomization.Height);
                Console.WriteLine("Body Type: " + characterCustomization.BodyType);
                Console.WriteLine("Hair Texture: " + characterCustomization.HairTexture);
                Console.WriteLine("Hair Style: " + characterCustomization.HairStyle);
                Console.WriteLine("Hair Color: " + characterCustomization.HairColor);
                Console.WriteLine("Eye Color: " + characterCustomization.EyeColor);
                Console.WriteLine("Outfit Style: " + characterCustomization.OutfitStyle);
                Console.WriteLine("Has Tattoo: " + characterCustomization.HasTattoo);
                Console.WriteLine("Has Glasses: " + characterCustomization.HasGlasses);
            }
        }
    }
}
