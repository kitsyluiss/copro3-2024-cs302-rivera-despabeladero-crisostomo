using System;
using System.Collections.Generic;

namespace CookingSystem
{
    public class InteractionCustomization : Customization
    {
        private struct InteractionData
        {
            public string VoiceLines;
            public string SignatureGesture;
            public string CulinaryPartner;
            public string ThemeMusic;
        }

        private InteractionData _interactionData;

        public InteractionCustomization()
        {
            this._interactionData = new InteractionData
            {
                VoiceLines = "Motivational Quotes",
                SignatureGesture = "Thumbs-Up",
                CulinaryPartner = "Cat",
                ThemeMusic = "Classical"
            };
        }

        public string VoiceLines
        {
            get => this._interactionData.VoiceLines;
            set => this._interactionData.VoiceLines = value;
        }

        public string SignatureGesture
        {
            get => this._interactionData.SignatureGesture;
            set => this._interactionData.SignatureGesture = value;
        }

        public string CulinaryPartner
        {
            get => this._interactionData.CulinaryPartner;
            set => this._interactionData.CulinaryPartner = value;
        }

        public string ThemeMusic
        {
            get => this._interactionData.ThemeMusic;
            set => this._interactionData.ThemeMusic = value;
        }

        public override void Customize()
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("              Customize your interaction!             ");
            Console.WriteLine("══════════════════════════════════════════════════════\n");

            this.VoiceLines = ChooseOption("Please select your character's voice line expression", new Dictionary<int, string>
            {
                { 1, "Motivational Quotes" },
                { 2, "Funny Puns" },
                { 3, "Professional Commands" },
                { 4, "Excited Cheers" },
                { 5, "Calm Remarks" }
            });

            this.SignatureGesture = ChooseOption("Please select your signature gesture", new Dictionary<int, string>
            {
                { 1, "Thumbs-Up" },
                { 2, "Chef's Kiss" },
                { 3, "Victory Pose" },
                { 4, "Salute" },
                { 5, "Wink" }
            });

            this.CulinaryPartner = ChooseOption("Please select your culinary partner/pet companion", new Dictionary<int, string>
            {
                { 1, "Cat" },
                { 2, "Dog" },
                { 3, "Robot" },
                { 4, "Parrot" },
                { 5, "None" }
            });

            this.ThemeMusic = ChooseOption("Please select your theme music", new Dictionary<int, string>
            {
                { 1, "Classical" },
                { 2, "Jazzy" },
                { 3, "Upbeat" },
                { 4, "Lo-Fi Beats" },
                { 5, "Rock" }
            });
        }
    }
}
