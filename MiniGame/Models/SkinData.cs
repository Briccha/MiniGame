using System.Collections.Generic;
using System.Drawing;

namespace WinFormsGame.Models
{
    public class SkinData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }

        public static List<SkinData> GetAllSkins()
        {
            return new List<SkinData>
            {
                new SkinData { Id = 0, Name = "Default", Cost = 0,
                    PrimaryColor = Color.RoyalBlue, SecondaryColor = Color.LightBlue },
                new SkinData { Id = 1, Name = "Fire", Cost = 10,
                    PrimaryColor = Color.OrangeRed, SecondaryColor = Color.Yellow },
                new SkinData { Id = 2, Name = "Forest", Cost = 20,
                    PrimaryColor = Color.ForestGreen, SecondaryColor = Color.LightGreen },
                new SkinData { Id = 3, Name = "Shadow", Cost = 30,
                    PrimaryColor = Color.Purple, SecondaryColor = Color.MediumPurple }
            };
        }
    }
}