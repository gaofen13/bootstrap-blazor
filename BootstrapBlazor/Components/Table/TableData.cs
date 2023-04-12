namespace BootstrapBlazor
{
    public class TableData<TItem>
    {
        public int Total { get; set; }

        public IEnumerable<TItem>? Data { get; set; }
    }
}
