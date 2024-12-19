using System;
using System.Data.SqlClient;
using System.Threading;

namespace CookingSystem
{
    class GameMenu : IMenu
    {
        public static string CurrentCharacterName { get; private set; } = "";
        private CharacterCustomization characterCustomization;
        private CookingCustomization cookingCustomization;
        private ApronCustomization apronCustomization;
        private InteractionCustomization interactionCustomization;

        private string _connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog=""D:\School\source\repos\CookingSystem\Database1.mdf"";Integrated Security = True";
        public void CreateCharacter()
        {
            characterCustomization = new CharacterCustomization();
            characterCustomization.Customize();

            cookingCustomization = new CookingCustomization();
            cookingCustomization.Customize();

            apronCustomization = new ApronCustomization();
            apronCustomization.Customize();

            interactionCustomization = new InteractionCustomization();
            interactionCustomization.Customize();

            List<Overview> overviews = new List<Overview>
            {
                new OverviewCharacter(),
                new OverviewCooking(),
                new OverviewApron(),
                new OverviewInteract()
            };

            overviews[0].Display(characterCustomization);
            overviews[1].Display(cookingCustomization);
            overviews[2].Display(apronCustomization);
            overviews[3].Display(interactionCustomization);

            SaveCustomizations();
        }

        public void SaveCustomizations()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO CompleteCustomizations (
                        CharacName, Age, Gender, SkinTone, Height, BodyType, HairTexture, 
                        HairStyle, HairColor, EyeColor, OutfitStyle, HasTattoo, HasGlasses, 
                        CookingStyle, CookingExperience, Homeland, ASIAN, MEDITERRENEAN, 
                        FRENCH, LATINAMERICAN, FUSION, Specialty, FavoriteIngredients, 
                        Personality, VoiceType, CookingTool, Mood, Style, Color, Pattern, 
                        VoiceLines, SignatureGesture, CulinaryPartner, ThemeMusic)
                    VALUES (@CharacName, @Age, @Gender, @SkinTone, @Height, @BodyType, @HairTexture, 
                            @HairStyle, @HairColor, @EyeColor, @OutfitStyle, @HasTattoo, @HasGlasses, 
                            @CookingStyle, @CookingExperience, @Homeland, @ASIAN, @MEDITERRENEAN, 
                            @FRENCH, @LATINAMERICAN, @FUSION, @Specialty, @FavoriteIngredients, 
                            @Personality, @VoiceType, @CookingTool, @Mood, @Style, @Color, @Pattern, 
                            @VoiceLines, @SignatureGesture, @CulinaryPartner, @ThemeMusic)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CharacName", characterCustomization.CharacName);
                    command.Parameters.AddWithValue("@Age", characterCustomization.Age);
                    command.Parameters.AddWithValue("@Gender", characterCustomization.Gender);
                    command.Parameters.AddWithValue("@SkinTone", characterCustomization.SkinTone);
                    command.Parameters.AddWithValue("@Height", characterCustomization.Height);
                    command.Parameters.AddWithValue("@BodyType", characterCustomization.BodyType);
                    command.Parameters.AddWithValue("@HairTexture", characterCustomization.HairTexture);
                    command.Parameters.AddWithValue("@HairStyle", characterCustomization.HairStyle);
                    command.Parameters.AddWithValue("@HairColor", characterCustomization.HairColor);
                    command.Parameters.AddWithValue("@EyeColor", characterCustomization.EyeColor);
                    command.Parameters.AddWithValue("@OutfitStyle", characterCustomization.OutfitStyle);
                    command.Parameters.AddWithValue("@HasTattoo", characterCustomization.HasTattoo);
                    command.Parameters.AddWithValue("@HasGlasses", characterCustomization.HasGlasses);

                    command.Parameters.AddWithValue("@CookingStyle", cookingCustomization.CookingStyle);
                    command.Parameters.AddWithValue("@CookingExperience", cookingCustomization.CookingExperience);
                    command.Parameters.AddWithValue("@Homeland", cookingCustomization.Homeland);

                    //new kuisin code
                    command.Parameters.AddWithValue("@ASIAN", cookingCustomization.CuisineStyle.ContainsKey("Asian") ? cookingCustomization.CuisineStyle["Asian"] : 0);
                    command.Parameters.AddWithValue("@MEDITERRENEAN", cookingCustomization.CuisineStyle.ContainsKey("Mediterranean") ? cookingCustomization.CuisineStyle["Mediterranean"] : 0);
                    command.Parameters.AddWithValue("@FRENCH", cookingCustomization.CuisineStyle.ContainsKey("French") ? cookingCustomization.CuisineStyle["French"] : 0);
                    command.Parameters.AddWithValue("@LATINAMERICAN", cookingCustomization.CuisineStyle.ContainsKey("Latin American") ? cookingCustomization.CuisineStyle["Latin American"] : 0);
                    command.Parameters.AddWithValue("@FUSION", cookingCustomization.CuisineStyle.ContainsKey("Fusion") ? cookingCustomization.CuisineStyle["Fusion"] : 0);

                    command.Parameters.AddWithValue("@Specialty", cookingCustomization.Specialty);
                    command.Parameters.AddWithValue("@FavoriteIngredients", cookingCustomization.FavoriteIngredients);
                    command.Parameters.AddWithValue("@Personality", cookingCustomization.Personality);
                    command.Parameters.AddWithValue("@VoiceType", cookingCustomization.VoiceType);
                    command.Parameters.AddWithValue("@CookingTool", cookingCustomization.CookingTool);
                    command.Parameters.AddWithValue("@Mood", cookingCustomization.Mood);

                    command.Parameters.AddWithValue("@Style", apronCustomization.ApronStyle);
                    command.Parameters.AddWithValue("@Color", apronCustomization.ApronColor);
                    command.Parameters.AddWithValue("@Pattern", apronCustomization.ApronPattern);

                    command.Parameters.AddWithValue("@VoiceLines", interactionCustomization.VoiceLines);
                    command.Parameters.AddWithValue("@SignatureGesture", interactionCustomization.SignatureGesture);
                    command.Parameters.AddWithValue("@CulinaryPartner", interactionCustomization.CulinaryPartner);
                    command.Parameters.AddWithValue("@ThemeMusic", interactionCustomization.ThemeMusic);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void LoadGame()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════════════════════");
            Console.WriteLine("                     Load Game");
            Console.WriteLine("══════════════════════════════════════════════════════\n");

            Console.WriteLine("[1] View all characters\n[2] View a specific character\n[3] Delete a character\n[4] Go back to main menu");
            int choices = 0;
            bool validChoice = false;

            while (!validChoice)
            {
                try
                {
                    choices = Convert.ToInt32(Console.ReadLine());
                    if (choices >= 1 && choices <= 5)
                    {
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please choose a number between 1 and 5.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }

            switch (choices)
            {
                case 1:
                    Console.Clear();
                    LoadAllCharacter();
                    break;
                case 2:
                    Console.Clear();
                    LoadSpecific();
                    break;
                case 3:
                    Console.Clear();
                    DeletePermanently();
                    break;
                case 4:
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void LoadSpecific()
        {
         try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT CharacName FROM CompleteCustomizations ORDER BY Id ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> availableUsernames = new List<string>();
                        while (reader.Read())
                        {
                            availableUsernames.Add(reader["CharacName"].ToString());
                        }

                        if (availableUsernames.Count == 0)
                        {
                            Console.WriteLine("No saved characters found in the database.");
                            return;
                        }

                        Console.WriteLine("Select a saved character:");

                        for (int i = 0; i < availableUsernames.Count; i++)
                        {
                            Console.WriteLine("[" + (i + 1) + "] " + availableUsernames[i]);
                        }

                        Console.Write("\nEnter the number of the character you want to load: ");
                        int selectedIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (selectedIndex >= 0 && selectedIndex < availableUsernames.Count)
                        {
                            CurrentCharacterName = availableUsernames[selectedIndex];
                            LoadCharacterData(CurrentCharacterName);
                            Console.WriteLine("Character " + CurrentCharacterName + " loaded successfully.\n");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error occurred: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private void DeletePermanently()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT CharacName FROM CompleteCustomizations ORDER BY Id ASC";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> availableUsernames = new List<string>();
                    while (reader.Read())
                    {
                        availableUsernames.Add(reader["CharacName"].ToString());
                    }

                    if (availableUsernames.Count == 0)
                    {
                        Console.WriteLine("No saved characters found in the database.");
                        return;
                    }

                    Console.WriteLine("Select a saved character:");

                    for (int i = 0; i < availableUsernames.Count; i++)
                    {
                        Console.WriteLine("[" + (i + 1) + "] " + availableUsernames[i]);
                    }

                    Console.Write("\nEnter the number of the character you want to delete: ");
                    int selectedIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (selectedIndex >= 0 && selectedIndex < availableUsernames.Count)
                    {
                        CurrentCharacterName = availableUsernames[selectedIndex];
                        Console.Write("\nDo you really want to delete this character? (y/n): ");
                        string deleteChoice = Console.ReadLine().ToLower();

                        if (deleteChoice == "y")
                        {
                            DeleteCharacter(CurrentCharacterName);
                        }
                        else
                        {
                            Console.WriteLine("\nCharacter not deleted.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
            }
        }

        private void DeleteCharacter(string characterName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM CompleteCustomizations WHERE CharacName = @CharacName";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CharacName", characterName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            CurrentCharacterName = null;
                            Console.WriteLine("Character deleted successfully.\n");
                        }
                        else
                        {
                            Console.WriteLine("Character could not be found or deleted.\n");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error occurred while deleting: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred while deleting: " + ex.Message);
            }
        }

        private void LoadAllCharacter()
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("                      Character Stats");
            Console.WriteLine("══════════════════════════════════════════════════════");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM CompleteCustomizations ORDER BY CharacName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var characterCustomization = new CharacterCustomization
                            {
                                CharacName = reader["CharacName"].ToString(),
                                Age = reader["Age"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                SkinTone = reader["SkinTone"].ToString(),
                                Height = reader["Height"].ToString(),
                                BodyType = reader["BodyType"].ToString(),
                                HairTexture = reader["HairTexture"].ToString(),
                                HairStyle = reader["HairStyle"].ToString(),
                                HairColor = reader["HairColor"].ToString(),
                                EyeColor = reader["EyeColor"].ToString(),
                                OutfitStyle = reader["OutfitStyle"].ToString(),
                                HasTattoo = Convert.ToBoolean(reader["HasTattoo"]),
                                HasGlasses = Convert.ToBoolean(reader["HasGlasses"]),
                            };

                            var cookingCustomization = new CookingCustomization
                            {
                                CookingStyle = reader["CookingStyle"].ToString(),
                                CookingExperience = reader["CookingExperience"].ToString(),
                                Homeland = reader["Homeland"].ToString(),
                                Specialty = reader["Specialty"].ToString(),
                                FavoriteIngredients = reader["FavoriteIngredients"].ToString(),
                                Personality = reader["Personality"].ToString(),
                                VoiceType = reader["VoiceType"].ToString(),
                                CookingTool = reader["CookingTool"].ToString(),
                                Mood = reader["Mood"].ToString(),
                            };

                            var cuisineStyleDict = new Dictionary<string, int>
                            {
                                { "Asian", Convert.ToInt32(reader["ASIAN"]) },
                                { "Mediterranean", Convert.ToInt32(reader["MEDITERRENEAN"]) },
                                { "French", Convert.ToInt32(reader["FRENCH"]) },
                                { "Latin American", Convert.ToInt32(reader["LATINAMERICAN"]) },
                                { "Fusion", Convert.ToInt32(reader["FUSION"]) }
                            };
                            cookingCustomization.CuisineStyle = cuisineStyleDict;

                            var apronCustomization = new ApronCustomization
                            {
                                ApronStyle = reader["Style"].ToString(),
                                ApronColor = reader["Color"].ToString(),
                                ApronPattern = reader["Pattern"].ToString(),
                            };

                            var interactionCustomization = new InteractionCustomization
                            {
                                VoiceLines = reader["VoiceLines"].ToString(),
                                SignatureGesture = reader["SignatureGesture"].ToString(),
                                CulinaryPartner = reader["CulinaryPartner"].ToString(),
                                ThemeMusic = reader["ThemeMusic"].ToString(),
                            };
                            DisplayCharacterStats(characterCustomization, cookingCustomization, apronCustomization, interactionCustomization);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error occurred: " + sqlEx.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                Console.WriteLine("Invalid operation: " + invOpEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private void DisplayCharacterStats(CharacterCustomization characterCustomization, CookingCustomization cookingCustomization, ApronCustomization apronCustomization, InteractionCustomization interactionCustomization)
        {

            Console.WriteLine("\nCharacter Name: " + characterCustomization.CharacName);
            Console.WriteLine("Age: " + characterCustomization.Age);
            Console.WriteLine("Gender: " + characterCustomization.Gender);
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

            Console.WriteLine("\nCooking Stats:");
            Console.WriteLine("Cooking Style: " + cookingCustomization.CookingStyle);
            Console.WriteLine("Cooking Experience: " + cookingCustomization.CookingExperience);
            Console.WriteLine("Homeland: " + cookingCustomization.Homeland);
            Console.WriteLine("Specialty: " + cookingCustomization.Specialty);
            Console.WriteLine("Favorite Ingredients: " + cookingCustomization.FavoriteIngredients);
            Console.WriteLine("Personality: " + cookingCustomization.Personality);
            Console.WriteLine("Voice Type: " + cookingCustomization.VoiceType);
            Console.WriteLine("Cooking Tool: " + cookingCustomization.CookingTool);
            Console.WriteLine("Mood: " + cookingCustomization.Mood);

            Console.WriteLine("\nCuisine Style Allocations:");
            foreach (var style in cookingCustomization.CuisineStyle)
            {
                Console.WriteLine(style.Key + ": " + style.Value + " points");
            }

            Console.WriteLine("\nApron Stats:");
            Console.WriteLine("Apron Style: " + apronCustomization.ApronStyle);
            Console.WriteLine("Apron Color: " + apronCustomization.ApronColor);
            Console.WriteLine("Apron Pattern: " + apronCustomization.ApronPattern);

            Console.WriteLine("\nInteraction Stats:");
            Console.WriteLine("Voice Lines: " + interactionCustomization.VoiceLines);
            Console.WriteLine("Signature Gesture: " + interactionCustomization.SignatureGesture);
            Console.WriteLine("Culinary Partner: " + interactionCustomization.CulinaryPartner);
            Console.WriteLine("Theme Music: " + interactionCustomization.ThemeMusic);

            Console.WriteLine("\n══════════════════════════════════════════════════════");
        }




        private void LoadCharacterData(string characterName)
        {
            Console.WriteLine($"\nLoading data for {characterName}...\n");

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT TOP 1 * FROM CompleteCustomizations WHERE CharacName = @CharacName ORDER BY Id DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CharacName", characterName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                characterCustomization = new CharacterCustomization
                                {
                                    CharacName = reader["CharacName"].ToString(),
                                    Age = reader["Age"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    SkinTone = reader["SkinTone"].ToString(),
                                    Height = reader["Height"].ToString(),
                                    BodyType = reader["BodyType"].ToString(),
                                    HairTexture = reader["HairTexture"].ToString(),
                                    HairStyle = reader["HairStyle"].ToString(),
                                    HairColor = reader["HairColor"].ToString(),
                                    EyeColor = reader["EyeColor"].ToString(),
                                    OutfitStyle = reader["OutfitStyle"].ToString(),
                                    HasTattoo = Convert.ToBoolean(reader["HasTattoo"]),
                                    HasGlasses = Convert.ToBoolean(reader["HasGlasses"]),
                                };

                                cookingCustomization = new CookingCustomization
                                {
                                    CookingStyle = reader["CookingStyle"].ToString(),
                                    CookingExperience = reader["CookingExperience"].ToString(),
                                    Homeland = reader["Homeland"].ToString(),
                                    Specialty = reader["Specialty"].ToString(),
                                    FavoriteIngredients = reader["FavoriteIngredients"].ToString(),
                                    Personality = reader["Personality"].ToString(),
                                    VoiceType = reader["VoiceType"].ToString(),
                                    CookingTool = reader["CookingTool"].ToString(),
                                    Mood = reader["Mood"].ToString(),
                                };

                                var cuisineStyleDict = new Dictionary<string, int>
                                {
                                    { "Asian", reader["ASIAN"] != DBNull.Value ? Convert.ToInt32(reader["ASIAN"]) : 0 },
                                    { "Mediterranean", reader["MEDITERRENEAN"] != DBNull.Value ? Convert.ToInt32(reader["MEDITERRENEAN"]) : 0 },
                                    { "French", reader["FRENCH"] != DBNull.Value ? Convert.ToInt32(reader["FRENCH"]) : 0 },
                                    { "Latin American", reader["LATINAMERICAN"] != DBNull.Value ? Convert.ToInt32(reader["LATINAMERICAN"]) : 0 },
                                    { "Fusion", reader["FUSION"] != DBNull.Value ? Convert.ToInt32(reader["FUSION"]) : 0 }
                                };
                                cookingCustomization.CuisineStyle = cuisineStyleDict;


                                apronCustomization = new ApronCustomization
                                {
                                    ApronStyle = reader["Style"].ToString(),
                                    ApronColor = reader["Color"].ToString(),
                                    ApronPattern = reader["Pattern"].ToString(),
                                };

                                interactionCustomization = new InteractionCustomization
                                {
                                    VoiceLines = reader["VoiceLines"].ToString(),
                                    SignatureGesture = reader["SignatureGesture"].ToString(),
                                    CulinaryPartner = reader["CulinaryPartner"].ToString(),
                                    ThemeMusic = reader["ThemeMusic"].ToString(),
                                };

                                DisplayCharacterStats();
                            }
                            else
                            {
                                Console.WriteLine("No saved data found for this user.");
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error occurred: " + sqlEx.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                Console.WriteLine("Invalid operation: " + invOpEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private void DisplayCharacterStats()
        {
            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("                      Character Stats");
            Console.WriteLine("══════════════════════════════════════════════════════");

            Console.WriteLine("\nCharacter Name: " + characterCustomization.CharacName);
            Console.WriteLine("Age: " + characterCustomization.Age);
            Console.WriteLine("Gender: " + characterCustomization.Gender);
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

            Console.WriteLine("\nCooking Stats:");
            Console.WriteLine("Cooking Style: " + cookingCustomization.CookingStyle);
            Console.WriteLine("Cooking Experience: " + cookingCustomization.CookingExperience);
            Console.WriteLine("Homeland: " + cookingCustomization.Homeland);
            Console.WriteLine("Specialty: " + cookingCustomization.Specialty);
            Console.WriteLine("Favorite Ingredients: " + cookingCustomization.FavoriteIngredients);
            Console.WriteLine("Personality: " + cookingCustomization.Personality);
            Console.WriteLine("Voice Type: " + cookingCustomization.VoiceType);
            Console.WriteLine("Cooking Tool: " + cookingCustomization.CookingTool);
            Console.WriteLine("Mood: " + cookingCustomization.Mood);

            Console.WriteLine("\nCuisine Style Allocations:");
            foreach (var style in cookingCustomization.CuisineStyle)
            {
                Console.WriteLine(style.Key + ": " + style.Value + " points");
            }

            Console.WriteLine("\nApron Stats:");
            Console.WriteLine("Apron Style: " + apronCustomization.ApronStyle);
            Console.WriteLine("Apron Color: " + apronCustomization.ApronColor);
            Console.WriteLine("Apron Pattern: " + apronCustomization.ApronPattern);

            Console.WriteLine("\nInteraction Stats:");
            Console.WriteLine("Voice Lines: " + interactionCustomization.VoiceLines);
            Console.WriteLine("Signature Gesture: " + interactionCustomization.SignatureGesture);
            Console.WriteLine("Culinary Partner: " + interactionCustomization.CulinaryPartner);
            Console.WriteLine("Theme Music: " + interactionCustomization.ThemeMusic);

            Console.WriteLine("\n══════════════════════════════════════════════════════");
        }

        public void CampaignMode()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════════════════════");
            Console.WriteLine("                     Campaign Mode");
            Console.WriteLine("══════════════════════════════════════════════════════\n");

            try
            {
                if (CurrentCharacterName == null)
                {
                    throw new CharacterNotCreatedException("Please select/create a character first");
                }

            string[] story = new string[] {
                "My name is " + CurrentCharacterName + ", and I am just a home cook.",
                "I enjoy making food for my partner after their long workdays,",
                "and every meal I cook for them, they always enjoy.",
                "They always compliment me, saying I should be a chef for being good at cooking.",
                "\nBut one night, while frying the chicken, a bright light suddenly filled the kitchen.",
                "Before I knew it, I was taken away and woke up in a strange cage with many other chefs.",
                "They looked serious and said they were famous, but I didn’t understand why I was there with them.",
                "\nLater, we were taken to a large room, and a person called the greatest chef in the world explained why we had been chosen.",
                "They said the world was in danger because of hungry gods.",
                "If they didn’t get the best food, they would destroy everything.",
                "The chefs were supposed to make dishes so amazing that the gods would be happy.",
                "I was confused because I wasn’t a great chef like the others. I just cooked for my partner at home.",
                "\nThen, a stranger looked at me and said, “You are the one who can save us.”",
                "I was shocked and didn’t know what they meant.",
                "They said that my cooking skills were special and could reach the hearts of the gods.",
                "I didn’t believe them at first; I doubted every single word they said because I was just a chill person who cooks for my partner.",
                "But something inside me said I had to try.",
                "If my cooking could save the world, I would have to do my best, even if I were just a simple, chill home cook."
            };

                foreach (var line in story)
                {
                    foreach (var letter in line)
                    {
                        Console.Write(letter);
                        Thread.Sleep(25);
                    }
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
            catch (CharacterNotCreatedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n══════════════════════════════════════════════════════");
            Console.WriteLine("               Press any key to continue...\n");
            Console.ReadKey();
        }

        public void Credits()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════════════════════");
            Console.WriteLine("                        CREDITS                       ");
            Console.WriteLine("══════════════════════════════════════════════════════");
            Console.WriteLine("\nThis game was created by:");
            Console.WriteLine("\nRivera, Luis - Coder: Responsible for implementing the game mechanics and logic.");
            Console.WriteLine("Despabeladero, Alexis - Member: Nasiraan ng pc.");
            Console.WriteLine("Crisostomo, Rafael Lorenz - Member: thirst trap.");
            Console.WriteLine("\nWe all share a love for anime, and we’re still recovering from the fact that we named this game so long it could be its own anime episode title xD\n");
        }


        public void Exit()
        {
            Console.WriteLine("\nThank you for playing, game will exit shortly.");
            Thread.Sleep(1500);
        }
    }

    public class CharacterNotCreatedException : Exception
    {
        public CharacterNotCreatedException(string message) : base(message) { }
    }

}
