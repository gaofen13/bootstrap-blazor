using BootstrapBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor
{
    public partial class BootstrapPagination : BootstrapComponentBase
    {
        private int _index = 1;
        private int _size = 10;
        private int _total = 1;

        private string Classname =>
          new ClassBuilder("pagination")
            .AddClass($"justify-content-{Position}")
            .AddClass(Class)
            .Build();


        private bool PrevDisabled => PageIndex <= 1 || Total <= 0;

        private bool NexDisabled => PageIndex == Total || Total <= 0;

        [Parameter]
        public HorizontalPosition Position { get; set; } = HorizontalPosition.start;

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public int Total
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _total;
            set
            {
                if (value < 1)
                {
                    throw new NotSupportedException("The Value parameter should be Larger than 1");
                }
                _total = value;
            }
        }

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public int PageSize
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _size;
            set
            {
                if (value < 1)
                {
                    throw new NotSupportedException("The Value parameter should be Larger than 1");
                }
                if (_size != value)
                {
                    _size = value;
                    PageSizeChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<int> PageSizeChanged { get; set; }

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public int PageIndex
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _index;
            set
            {
                if (value < 1 || value > Total)
                {
                    throw new NotSupportedException("The Value parameter should be between 1 and Total pagenumber");
                }
                if (_index != value)
                {
                    _index = value;
                    PageIndexChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<int> PageIndexChanged { get; set; }

        private void OnClickPrev()
        {
            if (PageIndex > 1)
            {
                PageIndex--;
            }
        }

        private void OnClickNex()
        {
            if (PageIndex < Total)
            {
                PageIndex++;
            }
        }

        private void OnClickPager(int pager)
        {
            PageIndex = pager;
        }
    }
}
