using Newtonsoft.Json;

namespace AttendanceTracker
{
    public class Setting
    {
        private string _initialValue = default;

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonIgnore]
        public bool Changed => _initialValue != Value;

        public Setting() : this(default)
        {
            // Do nothing;
        }

        public Setting(string initialValue)
        {
            _initialValue = initialValue;
            Value         = initialValue;
        }

        public void Reset()
        {
            Value = _initialValue;
        }

        public void Save()
        {
            _initialValue = Value;
        }
    }
}
