

using System.Text.Json.Serialization;

namespace Password_Generator_V2.Logic
{
    public class ServiceItem {
        public ServiceItem(string name) {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class EmojiLookup {
        public List<EmojiItem> lookup { get; set; }
    }

    public class  EmojiItem {
        public string Emoji { get; set; }
        public string Alias { get; set; }
    }

}
