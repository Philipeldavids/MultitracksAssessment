using Multitracks.Models;
using System.Collections.Generic;

namespace Multitracks.Interface
{
    public interface ISongRepository
    {
        List<Song> GetAllSongs();
    }
}
