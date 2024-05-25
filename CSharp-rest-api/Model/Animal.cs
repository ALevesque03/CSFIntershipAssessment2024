namespace Model
{
    //The animal entity to access project data from JSON API search
    public class Animal
    {
        public string Name { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public List<string> Locations { get; set; }
        public Characteristics Characteristics { get; set; }

    }
}