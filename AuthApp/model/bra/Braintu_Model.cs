namespace AuthApp.model.bra
{
    public class Braintu_Model
    {

        //Load sample data
        private string location;
        private float size__cm_;
        private string grade;
        private float patient_Age;
        private string gender;

        public string Location { get => location; set => location = value; }
        public float Size__cm_ { get => size__cm_; set => size__cm_ = value; }
        public string Grade { get => grade; set => grade = value; }
        public float Patient_Age { get => patient_Age; set => patient_Age = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
