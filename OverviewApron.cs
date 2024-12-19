using System;

namespace CookingSystem
{
    class OverviewApron : Overview
    {
        public override void Display(object customization)
        {
            if (customization is ApronCustomization apronCustomization)
            {
                Console.WriteLine("\n═══════ Apron Customization ═══════");
                Console.WriteLine("Apron Style: " + apronCustomization.ApronStyle);
                Console.WriteLine("Apron Color: " + apronCustomization.ApronColor);
                Console.WriteLine("Apron Pattern: " + apronCustomization.ApronPattern);
            }
        }
    }
}
