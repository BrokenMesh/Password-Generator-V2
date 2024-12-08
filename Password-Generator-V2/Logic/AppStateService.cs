using System.Net.NetworkInformation;

namespace Password_Generator_V2.Logic
{
    public class AppStateService
    {
        private readonly StorageService storageService;
        
        public List<ServiceItem> ServiceItems;
        
        private string ServiceItemsKey = "ServiceItems";

        public AppStateService(StorageService _storageService) {
            storageService = _storageService;

            ServiceItems = new List<ServiceItem>();
            Task.Run(LoadServiceItems);
        }

        public void AddService(string _name) {
            ServiceItems.Add(new ServiceItem(_name));
            Task.Run(StoreServiceItems);
        }

        private async Task StoreServiceItems() {
            await storageService.SetItemAsync(ServiceItemsKey, ServiceItems);
        }

        private async Task LoadServiceItems() {
            var storedItems = await storageService.GetItemAsync<List<ServiceItem>>(ServiceItemsKey);
            if (storedItems != null) {
                ServiceItems = storedItems!;
            }
        }
    }
}
