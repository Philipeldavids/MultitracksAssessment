using Microsoft.AspNetCore.Mvc;
using Multitracks.Interface;
using Multitracks.Models;
using Multitracks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multitracks.Services
{
    

    public class SongService: ISongService
    {
        private readonly ISongRepository _songRepository;
        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;    
        }    

        public PagedResponse<List<Song>> GetAllSongs([FromQuery] PaginationFilter filter)
        {
           
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedsongs = _songRepository.GetAllSongs()
                                .OrderBy(x => x.SongId)
                                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                .Take(validFilter.PageSize)
                                .ToList();

                return new PagedResponse<List<Song>>(pagedsongs, validFilter.PageNumber, validFilter.PageSize);
     
        }
    }
}
