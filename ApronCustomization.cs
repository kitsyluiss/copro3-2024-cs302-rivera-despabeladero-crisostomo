using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CookingSystem
{
    public class ApronCustomization : Customization
    {
        private struct ApronData
        {
            public string Style;
            public string Color;
            public string Pattern;
        }

        private ApronData _apronData;

        public ApronCustomization()
        {
            this._apronData = new ApronData
            {
                Style = "Classic",
                Color = "White",
                Pattern = "Solid"
            };
        }

        public string ApronStyle
        {
            get => this._apronData.Style;
            set => this._apronData.Style = value;
        }

        public string ApronColor
        {
            get => this._apronData.Color;
            set => this._apronData.Color = value;
        }

        public string ApronPattern
        {
            get => this._apronData.Pattern;
            set => this._apronData.Pattern = value;
        }

        public override void Customize()
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("                 Customize your apron!                ");
            Console.WriteLine("══════════════════════════════════════════════════════\n");

            this.ApronStyle = ChooseOption("What style of apron does your character wear?", new Dictionary<int, string>
            {
                { 1, "Classic" },
                { 2, "Bib" },
                { 3, "Waist" },
                { 4, "Pinafore" },
                { 5, "Apron Dress" }
            });

            this.ApronColor = ChooseOption("What color is your character’s apron?", new Dictionary<int, string>
            {
                { 1, "White" },
                { 2, "Black" },
                { 3, "Red" },
                { 4, "Blue" },
                { 5, "Green" }
            });

            this.ApronPattern = ChooseOption("What pattern is on your character’s apron?", new Dictionary<int, string>
            {
                { 1, "Solid" },
                { 2, "Stripes" },
                { 3, "Checkered" },
                { 4, "Floral" },
                { 5, "Graphic" }
            });
        }
    }
}
