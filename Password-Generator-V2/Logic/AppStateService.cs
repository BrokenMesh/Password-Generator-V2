using System.Net.NetworkInformation;

namespace Password_Generator_V2.Logic
{
    public class AppStateService
    {
        public event Func<Task>? ServiceItemsChanged;
        public List<ServiceItem> ServiceItems { get; private set; }

        public event Func<Task>? V1SeedChanged;
        public string V1Seed { get; private set; }

        private string ServiceItemsKey = "ServiceItems";
        private readonly StorageService storageService;

        public AppStateService(StorageService _storageService) {
            storageService = _storageService;

            ServiceItems = new List<ServiceItem>();
            V1Seed = "";
            Task.Run(LoadServiceItems);
        }

        public void AddService(string _name) {
            ServiceItems.Add(new ServiceItem(_name));
            ServiceItemsChanged?.Invoke();
            Task.Run(StoreServiceItems);
        } 

        public void RemoveService(ServiceItem _item) {
            ServiceItems.Remove(_item);
            ServiceItemsChanged?.Invoke();
            Task.Run(StoreServiceItems);
        }

        public void ClearServices() {
            ServiceItems.Clear();
            ServiceItemsChanged?.Invoke();
            Task.Run(StoreServiceItems);
        }

        public void SetV1Key(string _key) {
            V1Seed = _key;
            V1SeedChanged?.Invoke();
        }

        private async Task StoreServiceItems() {
            await storageService.SetItemAsync(ServiceItemsKey, ServiceItems);
        }

        private async Task LoadServiceItems() {
            var storedItems = await storageService.GetItemAsync<List<ServiceItem>>(ServiceItemsKey);
            if (storedItems != null) {
                ServiceItems = storedItems!;
                ServiceItemsChanged?.Invoke();
            }
        }
    }
}
