using System;
using System.Data.SqlClient;

namespace CookingSystem
{
    public class DatabaseHandler
    {
        private string _connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog=""D:\School\source\repos\CookingSystem\Database1.mdf"";Integrated Security = True";

        public void InsertCharacter(CharacterCustomization character, CookingCustomization cooking, ApronCustomization apron, InteractionCustomization interact)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    INSERT INTO [dbo].[CompleteCustomizations]
                    ([CharacterName], [Age], [Gender], [SkinTone], [Height], [BodyType], [HairTexture], [HairStyle], [HairColor], [EyeColor], 
                    [OutfitStyle], [HasTattoo], [HasGlasses], [CookingStyle], [CookingExperience], [Homeland], [CuisineStyle], 
                    [Specialty], [FavoriteIngredients], [Personality], [VoiceType], [CookingTool], [Mood], 
                    [Style], [Color], [Pattern], [VoiceLines], [SignatureGesture], [CulinaryPartner], [ThemeMusic])
                    VALUES 
                    (@CharacterName, @Age, @Gender, @SkinTone, @Height, @BodyType, @HairTexture, @HairStyle, @HairColor, @EyeColor, 
                    @OutfitStyle, @HasTattoo, @HasGlasses, @CookingStyle, @CookingExperience, @Homeland, @CuisineStyle, 
                    @Specialty, @FavoriteIngredients, @Personality, @VoiceType, @CookingTool, @Mood, 
                    @Style, @Color, @Pattern, @VoiceLines, @SignatureGesture, @CulinaryPartner, @ThemeMusic);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Character customization
                    command.Parameters.AddWithValue("@CharacterName", character.CharacName);
                    command.Parameters.AddWithValue("@Age", character.Age);
                    command.Parameters.AddWithValue("@Gender", character.Gender);
                    command.Parameters.AddWithValue("@SkinTone", character.SkinTone);
                    command.Parameters.AddWithValue("@Height", character.Height);
                    command.Parameters.AddWithValue("@BodyType", character.BodyType);
                    command.Parameters.AddWithValue("@HairTexture", character.HairTexture);
                    command.Parameters.AddWithValue("@HairStyle", character.HairStyle);
                    command.Parameters.AddWithValue("@HairColor", character.HairColor);
                    command.Parameters.AddWithValue("@EyeColor", character.EyeColor);
                    command.Parameters.AddWithValue("@OutfitStyle", character.OutfitStyle);
                    command.Parameters.AddWithValue("@HasTattoo", character.HasTattoo);
                    command.Parameters.AddWithValue("@HasGlasses", character.HasGlasses);

                    // Cooking customization
                    command.Parameters.AddWithValue("@CookingStyle", cooking.CookingStyle);
                    command.Parameters.AddWithValue("@CookingExperience", cooking.CookingExperience);
                    command.Parameters.AddWithValue("@Homeland", cooking.Homeland);
                    command.Parameters.AddWithValue("@CuisineStyle", string.Join(",", cooking.CuisineStyle));
                    command.Parameters.AddWithValue("@Specialty", cooking.Specialty);
                    command.Parameters.AddWithValue("@FavoriteIngredients", cooking.FavoriteIngredients);
                    command.Parameters.AddWithValue("@Personality", cooking.Personality);
                    command.Parameters.AddWithValue("@VoiceType", cooking.VoiceType);
                    command.Parameters.AddWithValue("@CookingTool", cooking.CookingTool);
                    command.Parameters.AddWithValue("@Mood", cooking.Mood);

                    // Apron customization
                    command.Parameters.AddWithValue("@Style", apron.ApronStyle);
                    command.Parameters.AddWithValue("@Color", apron.ApronColor);
                    command.Parameters.AddWithValue("@Pattern", apron.ApronPattern); 

                    // Interaction customization
                    command.Parameters.AddWithValue("@VoiceLines", interact.VoiceLines);
                    command.Parameters.AddWithValue("@SignatureGesture", interact.SignatureGesture);
                    command.Parameters.AddWithValue("@CulinaryPartner", interact.CulinaryPartner);
                    command.Parameters.AddWithValue("@ThemeMusic", interact.ThemeMusic);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} record(s) inserted.");
                }
            }
        }
    }
}
