namespace DatabaseAndDaos.Entities
{
    public class Product
    {
        private int Id;
        private string Name;

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int GetId() { return Id; }
        public void SetId(int id) {  Id = id; }
        public string GetName() { return Name; }
        public void SetName(string name) {  Name = name; }
        public override string ToString() { return "Product [Id = " + Id + " , Nome = " + Name +  "]"; }
    }
}