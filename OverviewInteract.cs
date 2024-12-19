using System;

namespace CookingSystem
{
    class OverviewInteract : Overview
    {
        public override void Display(object customization)
        {
            if (customization is InteractionCustomization interactionCustomization)
            {
                Console.WriteLine("\n═══════ Interaction Customization ═══════");
                Console.WriteLine("Voice Lines: " + interactionCustomization.VoiceLines);
                Console.WriteLine("Signature Gesture: " + interactionCustomization.SignatureGesture);
                Console.WriteLine("Culinary Partner: " + interactionCustomization.CulinaryPartner);
                Console.WriteLine("Theme Music: " + interactionCustomization.ThemeMusic);

                Console.WriteLine("\nCharacter customization complete!\n");
            }
        }
    }
}
