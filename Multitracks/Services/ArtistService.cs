using Multitracks.Interface;
using Multitracks.Models;
using Multitracks.Repository;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Multitracks.Services
{

    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Artist> GetArtistByName(string name)
        {
            var artist = await _artistRepository.GetArtistByName(name);
            return artist;
        }

        public async Task<bool> AddArtist(Artist artist)
        {
            var result = await _artistRepository.AddArtist(artist);
            return result;
        }
    }
}
