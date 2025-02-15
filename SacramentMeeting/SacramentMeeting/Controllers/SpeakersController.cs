using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeeting.Data;
using SacramentMeeting.Models;

namespace SacramentMeeting.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly SacramentContext _context;

        public SpeakersController(SacramentContext context)
        {
            _context = context;
        }

        // GET: Speakers
        public async Task<IActionResult> Index()
        {
            var sacramentContext = _context.Speaker
                .Include(s => s.Meeting)
                .Include(s => s.Member);
            return View(await sacramentContext.ToListAsync());
        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .Include(s => s.Meeting)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        public IActionResult Create()
        {
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "MeetingIdentifier");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MemberID,Topic,MeetingID")] Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "ID", speaker.MeetingID);
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FirstName", speaker.MemberID);
            return View(speaker);
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }
            ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "MeetingIdentifier", speaker.MeetingID);
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName", speaker.MemberID);
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MemberID,Topic,MeetingID")] Speaker speaker)
        {
            if (id != speaker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.ID))
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

            ViewData["MeetingID"] = new SelectList(_context.Meeting, "ID", "ID", speaker.MeetingID);
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName", speaker.MemberID);
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker
                .Include(s => s.Meeting)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speaker = await _context.Speaker.FindAsync(id);
            _context.Speaker.Remove(speaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.ID == id);
        }
    }
}
