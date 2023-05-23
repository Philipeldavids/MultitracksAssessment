using Microsoft.AspNetCore.Mvc;
using Multitracks.Models;
using System.Collections.Generic;

namespace Multitracks.Interface
{
    public interface ISongService
    {
        PagedResponse<List<Song>> GetAllSongs([FromQuery] PaginationFilter filter);
    }
}
