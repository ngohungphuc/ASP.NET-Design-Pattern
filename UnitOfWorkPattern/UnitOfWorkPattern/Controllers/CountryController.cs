using System.Web.Mvc;
using UnitOfWorkPattern.Model;
using UnitOfWorkPattern.Service;

namespace UnitOfWorkPattern.Controllers
{
    public class CountryController : Controller
    {
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)

        {
            _countryService = countryService;
        }

        // GET: Country
        public ActionResult Index()
        {
            return View(_countryService.GetAll());
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Create(country);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = _countryService.GetById(id);
            _countryService.Delete(country);
            return RedirectToAction("Index");
        }
    }
}