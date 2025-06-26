using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking.Core.Entities;
using Parking.Core.Interfaces.Repositories;
using Raven.Client.Documents;

namespace Parking.Infrastructure.Database.Raven;

public class DocumentParkingAreaRepository : IParkingAreaRepository
{
    private readonly IDocumentStore _store;

    public DocumentParkingAreaRepository()
    {
        _store = DocumentStoreHolder.Store;
    }

    public async Task<IEnumerable<ParkingArea>> GetAllAsync()
    {
        using var session = _store.OpenAsyncSession();
        return await session.Query<ParkingArea>().ToListAsync();
    }

    public async Task AddAsync(ParkingArea parkingArea)
    {
        using var session = _store.OpenAsyncSession();
        await session.StoreAsync(parkingArea);
        await session.SaveChangesAsync();
    }

    public async Task UpdateAsync(ParkingArea parkingArea)
    {
        using var session = _store.OpenAsyncSession();
        var existingRecord = await session.LoadAsync<ParkingArea>(parkingArea.Id.ToString());
        existingRecord = parkingArea;
        await session.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        var existingRecord = await session.LoadAsync<ParkingArea>(id);
        if (existingRecord is null)
        {
            return;
        }
        session.Delete(existingRecord);
        await session.SaveChangesAsync();
    }
}