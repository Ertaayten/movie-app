using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Abstracts;
using MovieApp.Models;
using MovieApp.Models.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repository;
        private readonly IDirectorRepository _directorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IMovieCategoryRepository _movieCategoryRepository;
        private readonly IMovieActorRepository _movieActorRepository;

        public MoviesController(IMovieRepository repository, IDirectorRepository directorRepository, ICategoryRepository categoryRepository, IMovieCategoryRepository movieCategoryRepository, IMovieActorRepository movieActorRepository, IActorRepository actorRepository)
        {
            _repository = repository;
            _directorRepository = directorRepository;
            _categoryRepository = categoryRepository;
            _movieCategoryRepository = movieCategoryRepository;
            _movieActorRepository = movieActorRepository;
            _actorRepository = actorRepository;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await _repository.GetAllWithNavigationAsync();
            return View(movies);
        }

        // GET: Movies/ /5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repository.GetAllWithNavigationAsync(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie.First());
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_directorRepository.GetAll(), "Id", "Name");
            ViewData["Categories"] = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            ViewData["Actors"] = new SelectList(_actorRepository.GetAll(), "Id", "Name");

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Language,Time,AgeLimit,DirectorId,Id,Categories,Actors")] MovieCreateViewModel movieCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                movieCreateViewModel.Id = Guid.NewGuid();
                await _repository.Add(movieCreateViewModel);
                foreach (var item in movieCreateViewModel.Categories)
                {
                    var movieCategory = new MovieCategory()
                    {
                        MovieId = movieCreateViewModel.Id,
                        CategoryId = item
                    };
                    await _movieCategoryRepository.Add(movieCategory);
                }
                foreach (var item in movieCreateViewModel.Actors)
                {
                    var movieActor = new MovieActor()
                    {
                        MovieId = movieCreateViewModel.Id,
                        ActorId = item
                    };
                    await _movieActorRepository.Add(movieActor);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(_directorRepository.GetAll(), "Id", "Id", movieCreateViewModel.DirectorId);
            return View(movieCreateViewModel);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repository.GetAsync(x=> x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_directorRepository.GetAll(), "Id", "Id", movie.DirectorId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Language,Time,AgeLimit,DirectorId,Id")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(movie, id);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(_directorRepository.GetAll(), "Id", "Id", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _repository.GetWithNavigationAsync(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
