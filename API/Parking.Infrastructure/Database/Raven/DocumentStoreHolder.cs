using System;
using Raven.Client.Documents;

namespace Parking.Infrastructure.Database.Raven;

public class DocumentStoreHolder
{
    private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

    public static IDocumentStore Store => store.Value;

    private static IDocumentStore CreateStore()
    {
        var store = new DocumentStore()
        {
            Urls = new[] { "http://localhost:8080" },
            Conventions =
            {
                MaxNumberOfRequestsPerSession = 10,
                UseOptimisticConcurrency = true
            },

            Database = "Parking"
        }.Initialize();

        return store;
    }
    
    
}