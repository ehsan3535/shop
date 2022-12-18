namespace Shop.Entities.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string weight { get; set; }
        public string Detail { get; set; }
        public string Test { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string mojod { get; set; }
        public int Count { get; set; }

        //public Guid SameProduct1Id { get; set; }
        //public Product SameProduct1 { get; set; }
        //public Guid SameProduct2Id { get; set; }
        //public Product SameProduct2 { get; set; }
        //public Guid SameProduct3Id { get; set; }
        //public Product SameProduct3 { get; set; }
        public string Rate { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }



    }
}
