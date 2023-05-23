using Multitracks.Models;
using System.Threading.Tasks;

namespace Multitracks.Interface
{
    public interface IArtistService
    {
        Task<Artist> GetArtistByName(string name);
        Task<bool> AddArtist(Artist artist);
    }
}
