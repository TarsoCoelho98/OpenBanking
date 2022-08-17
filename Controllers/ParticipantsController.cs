using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBanking.Data;
using OpenBanking.Services;

namespace OpenBanking.Controllers
{
    public class ParticipantsController : Controller
    {
        readonly DataContext _context;
        readonly ParticipantService _service;
        public ParticipantsController(DataContext context)
        {
            _context = context;
            _service = new ParticipantService();
        }

        public ActionResult Index()
        {
            UpdateData();
            return View(_context.Participant);
        }

        public void UpdateData()
        {
            _context.Database.ExecuteSqlRaw(_service.truncateCommand);
            _context.Participant.AddRange(_service.GetUpdatedData());
            _context.SaveChanges();
        }
    }
}
