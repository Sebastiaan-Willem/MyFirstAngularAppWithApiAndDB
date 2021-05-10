namespace MyFirstAPI
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsProfilePicture { get; set; }

        
        //Foreign Key for DB
        public int AppUserId { get; set; }
        //photo has ONE user, Many to one relation
        public AppUser User { get; set; }
    }
}