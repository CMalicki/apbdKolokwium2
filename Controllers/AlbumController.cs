using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kolokwium2.Services;
using kolokwium2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IKolService _service;

        public AlbumController(IKolService service)
        {
            _service = service;
        }

        [HttpPost("{albumId}")]
        // public async Task<IActionResult> Create(int albumID, AlbumPost body)
        // {

        //     if (!ModelState.IsValid)
        //         return BadRequest("Niepoprawne ciało żądania!");

        //     if (await _service.GetAlbumById(albumID).FirstOrDefaultAsync() is null)
        //         return NotFound("Nie znaleziono klienta o podanym id");

        //     if (await _service.GetMusicLabelById(body.IdMusicLabel).FirstOrDefaultAsync() is null)
        //         return NotFound("Nie znaleziono pracownika o podanymn id");

        //     using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //     {
        //         try
        //         {
        //             var zamowienie = new Zamowienie
        //             {
        //                 DataPrzyjecia = body.DataPrzyjecia,
        //                 Uwagi = body.Uwagi,
        //                 IdKlient = clientId,
        //                 IdPracownik = body.IdPracownik
        //             };
        //             await _service.CreateAsync(zamowienie);
        //             await _service.SaveChangesAsync();

        //             foreach (var wyrob in body.Wyroby)
        //             {
        //                 if (await _service.GetConfectioneryById(wyrob.IdWyrobu).FirstOrDefaultAsync().ConfigureAwait(false) is null)
        //                     return NotFound($"Nie znaleziono wyrobu -- ID: {wyrob.IdWyrobu}");

        //                 await _service.CreateAsync(new ZamowienieWyrobCukierniczy
        //                 {
        //                     IdWyrobuCukierniczego = wyrob.IdWyrobu,
        //                     IdZamowienia = zamowienie.IdZamowienia,
        //                     Ilosc = wyrob.Ilosc,
        //                     Uwagi = wyrob.Uwagi
        //                 });
        //             }

        //             scope.Complete();

        //         }
        //         catch (Exception)
        //         {
        //             return Problem("Nieoczekiwany błąd serwera");
        //         }
        //     }
        //     await _service.SaveChangesAsync();

        //     return NoContent();
        // }
        public async Task<IActionResult> Get(int albumId)
        {
            return Ok(
                await _service.GetAlbumById(albumId)
                .Select(e =>
                new AlbumGet
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    Tracks = e.Tracks.Select(e => new Tracks
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration,
                    }).ToList()
                }).ToListAsync()
            );
        }
    }
}