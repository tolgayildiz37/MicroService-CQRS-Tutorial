namespace Tutorial.Products.Settings
{
    public interface IProductDatabaseSettings
    {
        //AppSettings içerisinde okunuyor
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
