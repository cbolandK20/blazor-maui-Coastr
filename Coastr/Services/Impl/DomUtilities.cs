
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Coastr.Services.Impl
{
    public class DomUtilities : IDomUtilities, IDisposable
    {
        private readonly IJSRuntime _jsRuntime;


        public DomUtilities(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }


        public void Dispose() { }

        public async Task<Tuple<int, int>> getDimensionsAsync(string cssSelector)
        {
            var ret = await _jsRuntime.InvokeAsync<int[]>("coastr.getDimensionFromSelector", cssSelector);
            return ret == null ? null : new Tuple<int, int>(ret[0], ret[1]);

        }

        public async Task<Tuple<int, int>> getDimensionsAsync(ElementReference element)
        {
            var ret = await _jsRuntime.InvokeAsync<int[]>("coastr.getDimensionFromSelector", element);
            return ret == null ? null : new Tuple<int, int>(ret[0], ret[1]);
        }

    }
}
