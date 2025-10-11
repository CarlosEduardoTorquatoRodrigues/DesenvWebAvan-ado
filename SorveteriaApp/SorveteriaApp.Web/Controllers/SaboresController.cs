using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SorveteriaApp.Application.DTOs;
using SorveteriaApp.Application.Interfaces;

namespace SorveteriaApp.Web.Controllers
{
    public class SaboresController : Controller
    {
        private readonly ISaborService _saborService;

        public SaboresController(ISaborService saborService)
        {
            _saborService = saborService;
        }

        // GET: Sabores
        public async Task<IActionResult> Index()
        {
            var sabores = await _saborService.GetAllSaboresAsync();
            return View(sabores);
        }

        // GET: Sabores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _saborService.GetSaborByIdAsync(id.Value);
            if (sabor == null)
            {
                return NotFound();
            }

            return View(sabor);
        }

        // GET: Sabores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sabores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaborCreateDto saborDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _saborService.CreateSaborAsync(saborDto);
                    TempData["SuccessMessage"] = "Sabor cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("CodigoProduto", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao cadastrar sabor: {ex.Message}");
                }
            }
            return View(saborDto);
        }

        // GET: Sabores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _saborService.GetSaborByIdAsync(id.Value);
            if (sabor == null)
            {
                return NotFound();
            }

            var saborUpdateDto = new SaborUpdateDto
            {
                Id = sabor.Id,
                Nome = sabor.Nome,
                Categoria = sabor.Categoria,
                CodigoProduto = sabor.CodigoProduto,
                PrecoPorKg = sabor.PrecoPorKg,
                Disponivel = sabor.Disponivel
            };

            return View(saborUpdateDto);
        }

        // POST: Sabores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaborUpdateDto saborDto)
        {
            if (id != saborDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _saborService.UpdateSaborAsync(saborDto);
                    TempData["SuccessMessage"] = "Sabor atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("CodigoProduto", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar sabor: {ex.Message}");
                }
            }
            return View(saborDto);
        }

        // GET: Sabores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sabor = await _saborService.GetSaborByIdAsync(id.Value);
            if (sabor == null)
            {
                return NotFound();
            }

            return View(sabor);
        }

        // POST: Sabores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _saborService.DeleteSaborAsync(id);
                TempData["SuccessMessage"] = "Sabor excluído com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir sabor: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}