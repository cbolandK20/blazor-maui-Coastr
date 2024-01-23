
using Microsoft.AspNetCore.Components;

namespace Coastr.Services
{
    public interface IDomUtilities : IDisposable
    {
        public Task<Tuple<int, int>> getDimensionsAsync(string cssSelector);

        public Task<Tuple<int, int>> getDimensionsAsync(ElementReference element);
    }
}
