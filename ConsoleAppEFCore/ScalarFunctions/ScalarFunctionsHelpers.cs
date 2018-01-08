using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppEFCore2.ScalarFunctions
{
    public static class ScalarFunctionsHelpers
    {
        [DbFunction("ufnGetStock", "dbo")]
        public static int GetProductStock(int productId)
        {
            throw new NotImplementedException();
        }
    }

    public static class ScalarFunctionsExtentions
    {
        [DbFunction("ufnGetStock", "dbo")]
        public static int GetProductStock(this Product product, int productId)
        {
            throw new NotImplementedException();
        }
    }
}