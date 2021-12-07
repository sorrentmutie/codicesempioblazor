namespace BlazorApp1.Shared
{
    public class AppState
    {
        public bool Visibile { get; set; }
        public event Action? OnChange;

        public void SetVisibility(bool visibility)
        {
            Visibile = visibility;
            Notify();
        }

        private void Notify() => OnChange?.Invoke();
    }
}
