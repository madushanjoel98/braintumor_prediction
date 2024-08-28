namespace AuthApp.model.bra
{
    public class Braintu_Model
    {
        // Properties with validation if needed
        public string Location { get; set; }
        public float Size__cm_ { get; set; }
        public string? Grade { get; set; }
        public float Patient_Age { get; set; }
        public string Gender { get; set; }

        // Make the Type property nullable
        public string? Type { get; set; }
    }
}
