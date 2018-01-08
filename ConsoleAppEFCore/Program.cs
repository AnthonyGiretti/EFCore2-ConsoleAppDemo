using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ConsoleAppEFCore2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pluralize WorkOrder  :" + Inflector.Inflector.Pluralize("WorkOrder"));
            Console.WriteLine("Singularize Products  :" + Inflector.Inflector.Singularize("Products"));

            //setup our DI
            var serviceProvider = new ServiceCollection()
            .AddDbContextPool<AdventureWorksContextDI>(
                                                        options =>
                                                        {
                                                            options.UseSqlServer(@const.connectionString);
                                                            //options.UseInMemoryDatabase("AdventureWorks");
                                                            var lf = new LoggerFactory();
                                                            lf.AddProvider(new MyLoggerProvider());
                                                            options.UseLoggerFactory(lf);
                                                        }
                                                    )
            .AddScoped<IEfQueriesDI, EfQueriesDI>()
            .BuildServiceProvider();

            var efqueriesService1 = serviceProvider.GetService<IEfQueriesDI>();
            var efqueriesService2 = serviceProvider.GetService<IEfQueriesDI>();


            //var test = efqueriesService1.GetProductsByNameLike("%a%");
            //var test = efqueriesService1.GetPersons();
            var test = efqueriesService1.GetProductsWithDetails();

            Console.ReadLine();
        }
    }
}
