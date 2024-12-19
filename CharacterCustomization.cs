using System;
using System.Collections.Generic;
using System.Threading;
using System.Data.SqlClient;

namespace CookingSystem
{
    public class CharacterCustomization : Customization
    {
        private struct CharacterAttributes
        {
            public string CharacName;
            public string Gender;
            public string Age;
            public string SkinTone;
            public string Height;
            public string BodyType;
            public string HairTexture;
            public string HairStyle;
            public string HairColor;
            public string EyeColor;
            public string OutfitStyle;
            public bool HasTattoo;
            public bool HasGlasses;
        }
        private CharacterAttributes _characterAttributes;
        public CharacterCustomization()
        {

            this._characterAttributes = new CharacterAttributes
            {
                CharacName = "Default Name",
                Gender = "Male",
                Age = "Adult",
                SkinTone = "Fair",
                Height = "Average",
                BodyType = "Slim",
                HairTexture = "Wavy",
                HairStyle = "Short",
                HairColor = "Black",
                EyeColor = "Brown",
                OutfitStyle = "Casual",
                HasTattoo = false,
                HasGlasses = false
            };
        }

        public string CharacName
        {
            get { return this._characterAttributes.CharacName; }
            set { this._characterAttributes.CharacName = value; }
        }

        public string Gender
        {
            get { return this._characterAttributes.Gender; }
            set { this._characterAttributes.Gender = value; }
        }

        public string Age
        {
            get { return this._characterAttributes.Age; }
            set { this._characterAttributes.Age = value; }
        }

        public string SkinTone
        {
            get { return this._characterAttributes.SkinTone; }
            set { this._characterAttributes.SkinTone = value; }
        }

        public string Height
        {
            get { return this._characterAttributes.Height; }
            set { this._characterAttributes.Height = value; }
        }

        public string BodyType
        {
            get { return this._characterAttributes.BodyType; }
            set { this._characterAttributes.BodyType = value; }
        }

        public string HairTexture
        {
            get { return this._characterAttributes.HairTexture; }
            set { this._characterAttributes.HairTexture = value; }
        }

        public string HairStyle
        {
            get { return this._characterAttributes.HairStyle; }
            set { this._characterAttributes.HairStyle = value; }
        }

        public string HairColor
        {
            get { return this._characterAttributes.HairColor; }
            set { this._characterAttributes.HairColor = value; }
        }

        public string EyeColor
        {
            get { return this._characterAttributes.EyeColor; }
            set { this._characterAttributes.EyeColor = value; }
        }

        public string OutfitStyle
        {
            get { return this._characterAttributes.OutfitStyle; }
            set { this._characterAttributes.OutfitStyle = value; }
        }

        public bool HasTattoo
        {
            get { return this._characterAttributes.HasTattoo; }
            set { this._characterAttributes.HasTattoo = value; }
        }

        public bool HasGlasses
        {
            get { return this._characterAttributes.HasGlasses; }
            set { this._characterAttributes.HasGlasses = value; }
        }

        public override void Customize()
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("               Customize your character!              ");
            Console.WriteLine("══════════════════════════════════════════════════════\n");

            this.CharacName = ChooseUser("Enter your character's username:");

            this.Gender = ChooseOption("Please select your gender", new Dictionary<int, string>
            {
                { 1, "Male" },
                { 2, "Female" },
                { 3, "Non-Binary" },
                { 4, "Prefer not to say" }
            });
            this.Age = ChooseOption("Please select your age category", new Dictionary<int, string>
            {
                { 1, "Young" },
                { 2, "Adult" },
                { 3, "Middle-Aged" },
                { 4, "Senior" }
            });
            this.SkinTone = ChooseOption("Please select your skin tone", new Dictionary<int, string>
            {
                { 1, "Fair" },
                { 2, "Light" },
                { 3, "Medium" },
                { 4, "Tan" },
                { 5, "Dark" }
            });
            this.Height = ChooseOption("Please select your height category", new Dictionary<int, string>
            {
                { 1, "Short" },
                { 2, "Average" },
                { 3, "Tall" },
                { 4, "Very Tall" },
                { 5, "Petite" }
            });
            this.BodyType = ChooseOption("Please select a body type", new Dictionary<int, string>
            {
                { 1, "Slim" },
                { 2, "Athletic" },
                { 3, "Curvy" },
                { 4, "Stocky" }
            });
            this.HairTexture = ChooseOption("Please select your hair texture", new Dictionary<int, string>
            {
                { 1, "Wavy" },
                { 2, "Curly" },
                { 3, "Coiled" },
                { 4, "Straight" }
            });
            this.HairStyle = ChooseOption("Please select your hair style", new Dictionary<int, string>
            {
                { 1, "Long" },
                { 2, "Short" },
                { 3, "Ponytail" },
                { 4, "Buzz Cut" }
            });
            this.HairColor = ChooseOption("Please select your hair color", new Dictionary<int, string>
            {
                { 1, "Black" },
                { 2, "Brown" },
                { 3, "Blonde" },
                { 4, "Red" }
            });
            this.EyeColor = ChooseOption("Please select your eye color", new Dictionary<int, string>
            {
                { 1, "Black" },
                { 2, "Brown" },
                { 3, "Blue" },
                { 4, "Green" },
                { 5, "Hazel" }
            });
            this.OutfitStyle = ChooseOption("Please select an outfit style", new Dictionary<int, string>
            {
                { 1, "Chef Uniform" },
                { 2, "Casual Apron" },
                { 3, "Formal Suit" },
                { 4, "Athletic Wear" }
            });
            this.HasTattoo = ChooseFlag("Does your character have tattoos?", new Dictionary<int, bool>
            {
                { 1, false },
                { 2, true }
            }, defaultValue: false);
            this.HasGlasses = ChooseFlag("Does your character wear glasses?", new Dictionary<int, bool>
            {
                { 1, true },
                { 2, false }
            }, defaultValue: false);
        }
    }
}
