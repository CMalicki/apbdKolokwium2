using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Entities;
using kolokwium2.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace kolokwium2.Services 
{
    public class KolService : IKolService
    {

        private readonly KolokwiumContext _repository;

        public KolService(KolokwiumContext repository) {
            _repository = repository;
        }
        public IQueryable<Album> GetAllAlbums() {
            return _repository.Album
            .Include(e => e.Tracks)
            .Include(e => e.MusicLabel);
        }

        public IQueryable<Album> GetAlbumById(int id) {
            return _repository.Album.Where(e => e.IdAlbum == id)
            .Include(e => e.Tracks)
            .Include(e => e.MusicLabel);
        }

        public IQueryable<MusicLabel> GetMusicLabelById(int id)
        {
            return _repository.MusicLabel.Where(e => e.IdMusicLabel == id);
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _repository.Set<T>().AddAsync(entity);
        }
        public async Task SaveChangesAsync() {
            await _repository.SaveChangesAsync();
        }
    }
}