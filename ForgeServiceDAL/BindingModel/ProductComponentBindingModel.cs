using System.Collections.Generic;


namespace ForgeServiceDAL.BindingModel
{
    public class ProductComponentBindingModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
