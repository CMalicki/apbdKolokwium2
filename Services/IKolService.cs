using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Entities.Models;

namespace kolokwium2.Services
{
    public interface IKolService
    {
        IQueryable<Album> GetAllAlbums();
        IQueryable<Album> GetAlbumById(int id);
        IQueryable<MusicLabel> GetMusicLabelById(int id);
        Task CreateAsync<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}