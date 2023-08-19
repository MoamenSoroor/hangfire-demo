namespace TestingHangfire.Data
{
    public class TestingRepo : ITestingRepo
    {
        public List<string> GetNames()
        {
            return new List<string>()
            {
                "Ahmed", "Ali", "Amina", "Amira", "Basma", "Dalia", "Eman", "Fatima", "Gamal", "Hala",
                "Hassan", "Heba", "Ibrahim", "Karim", "Laila", "Maha", "Mahmoud", "Mariam", "Mohamed", "Mona",
                "Nadia", "Nour", "Omar", "Rania", "Reem", "Sara", "Tarek", "Yasmin", "Youssef", "Zainab"
            };
        }
    }
}