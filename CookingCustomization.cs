using System;
using System.Collections.Generic;

namespace CookingSystem
{
    public class CookingCustomization : Customization
    { 
        private struct CookingData
        {
            public string CookingStyle;
            public string CookingExperience;
            public string Homeland;
            public Dictionary<string, int> CuisineStyle;
            public string Specialty;
            public string FavoriteIngredients;
            public string Personality;
            public string VoiceType;
            public string CookingTool;
            public string Mood;
        }

        private CookingData _cookingData;

        public CookingCustomization()
        {
            this._cookingData = new CookingData
            {
                CookingStyle = "Traditional",
                CookingExperience = "Beginner",
                Homeland = "Unknown",
                CuisineStyle = new Dictionary<string, int> {
                    { "Asian", 0 },
                    { "Mediterranean", 0 },
                    { "French", 0 },
                    { "Latin American", 0 },
                    { "Fusion", 10 }
                },
                Specialty = "Pasta",
                FavoriteIngredients = "Garlic",
                Personality = "Friendly",
                VoiceType = "Calm",
                CookingTool = "Knife",
                Mood = "Happy"
            };
        }

        public string CookingStyle
        {
            get => _cookingData.CookingStyle;
            set => _cookingData.CookingStyle = value;
        }

        public string CookingExperience
        {
            get => _cookingData.CookingExperience;
            set => _cookingData.CookingExperience = value;
        }

        public string Homeland
        {
            get => _cookingData.Homeland;
            set => _cookingData.Homeland = value;
        }

        public Dictionary<string, int> CuisineStyle
        {
            get => _cookingData.CuisineStyle;
            set => _cookingData.CuisineStyle = value;
        }


        public string Specialty
        {
            get => _cookingData.Specialty;
            set => _cookingData.Specialty = value;
        }

        public string FavoriteIngredients
        {
            get => _cookingData.FavoriteIngredients;
            set => _cookingData.FavoriteIngredients = value;
        }

        public string Personality
        {
            get => _cookingData.Personality;
            set => _cookingData.Personality = value;
        }

        public string VoiceType
        {
            get => _cookingData.VoiceType;
            set => _cookingData.VoiceType = value;
        }

        public string CookingTool
        {
            get => _cookingData.CookingTool;
            set => _cookingData.CookingTool = value;
        }

        public string Mood
        {
            get => _cookingData.Mood;
            set => _cookingData.Mood = value;
        }

        public override void Customize()
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("                Customize your cooking!               ");
            Console.WriteLine("══════════════════════════════════════════════════════\n");

            this.CookingStyle = ChooseOption("Please select your cooking style", new Dictionary<int, string>
            {
                { 1, "Precise" },
                { 2, "Messy" },
                { 3, "Artistic" }
            });

            this.CookingExperience = ChooseOption("What is your cooking experience level?", new Dictionary<int, string>
            {
                { 1, "Beginner" },
                { 2, "Intermediate" },
                { 3, "Master" }
            });

            this.Homeland = ChooseOption("Where is your character from?", new Dictionary<int, string>
            {
                { 1, "Italy" },
                { 2, "Japan" },
                { 3, "Mexico" },
                { 4, "France" },
                { 5, "India" }
            });

            CuisineStyle = AllocatePoints("What type of food does your character like to cook?", new Dictionary<int, string>
            {
                { 1, "Asian" },
                { 2, "Mediterranean" },
                { 3, "French" },
                { 4, "Latin American" },
                { 5, "Fusion" }
            }, 10);

            this.Specialty = ChooseOption("What is your character really good at cooking?", new Dictionary<int, string>
            {
                { 1, "Sushi" },
                { 2, "BBQ" },
                { 3, "Pasta" },
                { 4, "Pastries" },
                { 5, "Stews" }
            });

            this.FavoriteIngredients = ChooseOption("What ingredients does your character like to use the most?", new Dictionary<int, string>
            {
                { 1, "Spices" },
                { 2, "Fresh Herbs" },
                { 3, "Seafood" },
                { 4, "Meats" },
                { 5, "Vegetables" }
            });

            this.Personality = ChooseOption("What is your character’s personality in the kitchen?", new Dictionary<int, string>
            {
                { 1, "Perfectionist" },
                { 2, "Creative" },
                { 3, "Competitive" },
                { 4, "Humorous" },
                { 5, "Calm" }
            });

            this.VoiceType = ChooseOption("What type of voice does your character have?", new Dictionary<int, string>
            {
                { 1, "Calm" },
                { 2, "Energetic" },
                { 3, "Quirky" },
                { 4, "Deep" },
                { 5, "Soft" }
            });

            this.CookingTool = ChooseOption("What is your character's preferred cooking tool?", new Dictionary<int, string>
            {
                { 1, "Knife" },
                { 2, "Whisk" },
                { 3, "Wok" },
                { 4, "Rolling Pin" },
                { 5, "Grill" }
            });

            this.Mood = ChooseOption("How does your character feel while cooking?", new Dictionary<int, string>
            {
                { 1, "Relaxed" },
                { 2, "Energetic" },
                { 3, "Focused" },
                { 4, "Excited" },
                { 5, "Frustrated" }
            });
        }
    }
}
