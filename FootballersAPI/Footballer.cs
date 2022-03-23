namespace FootballersAPI
{
    public class Footballer
    {
        public Footballer(int id, string firstName, string lastName, string nationality, string playersClub)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            PlayersClub = playersClub;
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string PlayersClub { get; set; } = string.Empty;
    }
}
