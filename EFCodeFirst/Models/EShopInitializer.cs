using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
    public class EShopInitializer : DropCreateDatabaseIfModelChanges<EShopV10>
    {
        protected override void Seed(EShopV10 dbc)
        {
            dbc.Categories.Add(new Category
            {
                Name = "1",
                NameVN = "mot"
            });

            dbc.Categories.Add(new Category
            {
                Name = "1",
                NameVN = "hai"
            });

            dbc.Categories.Add(new Category
            {
                Name = "1",
                NameVN = "ba"
            });
        }
    }
}