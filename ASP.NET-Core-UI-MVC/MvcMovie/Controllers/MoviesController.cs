using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Data;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieSqlServerContext _context;

        public MoviesController(MvcMovieSqlServerContext context)
        {
            _context = context;
        }

        // GET: Movies

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString, int? minYear)
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MvcMovieSqlServerContext.Movie' is null.");
            }

            // Get all available genres.
    var genreQuery = _context.Movie
        .Select(m => m.Genre)
        .Distinct()
        .OrderBy(g => g);

    // Get all available release years.
    var yearQuery = _context.Movie
        .Select(m => m.ReleaseDate.Year)
        .Distinct()
        .OrderByDescending(y => y);

    // Get all movies.
    var movies = _context.Movie.AsQueryable();

    // Filter movies by title.
    if (!string.IsNullOrWhiteSpace(searchString))
    {
        var search = searchString.Trim().ToLower();

        movies = movies.Where(m =>
            m.Title != null &&
            m.Title.ToLower().Contains(search));
    }

    // Filter movies by genre.
    if (!string.IsNullOrEmpty(movieGenre))
    {
        movies = movies.Where(m => m.Genre == movieGenre);
    }

    // Filter movies from the selected year or later.
    if (minYear.HasValue)
    {
        var startDate = new DateTime(minYear.Value, 1, 1);

        movies = movies.Where(m => m.ReleaseDate >= startDate);
    }

    // Create the ViewModel.
    var movieGenreVM = new MovieGenreViewModel
    {
        Genres = new SelectList(await genreQuery.ToListAsync()),
        Years = new SelectList(await yearQuery.ToListAsync()),
        Movies = await movies.ToListAsync(),
        MovieGenre = movieGenre,
        SearchString = searchString,
        MinYear = minYear
    };

            return View(movieGenreVM);
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(movie.Rating))
                {
                    movie.Rating = movie.Rating.Trim().ToUpperInvariant();
                }
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(movie.Rating))
                    {
                        movie.Rating = movie.Rating.Trim().ToUpperInvariant();
                    }
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
