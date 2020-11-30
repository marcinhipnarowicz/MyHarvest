using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHarvest.Models;

namespace MyHarvest.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Kamil Nowak", Description="Koszenie pola w miejscowości X, powierzchnia 0.5 ha." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Beata Sadło", Description="Koszenie pola w miejscowości Warszawa, powierzchnia 10 ha." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Michał Kowalski", Description="Koszenie pola w miejscowości Opole, powierzchnia 5.5 ha." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Test", Description="xxxxxxxxxxxxxxxxxxxxxx" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Test1", Description="yyyyyyyyyyyyyyyy" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Test2", Description="coś" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}