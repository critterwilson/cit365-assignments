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
    public class MeetingsController : Controller
    {
        private readonly SacramentContext _context;

        public MeetingsController(SacramentContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            var sacramentContext = _context.Meeting
                .Include(m => m.ClosingHymn)
                .Include(m => m.ClosingPrayer)
                .Include(m => m.Conducting)
                .Include(m => m.IntermediateHymn)
                .Include(m => m.OpeningHymn)
                .Include(m => m.OpeningPrayer)
                .Include(m => m.SacramentHymn);
            
            return View(await sacramentContext.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.ClosingHymn)
                .Include(m => m.ClosingPrayer)
                .Include(m => m.Conducting)
                .Include(m => m.IntermediateHymn)
                .Include(m => m.OpeningHymn)
                .Include(m => m.OpeningPrayer)
                .Include(m => m.SacramentHymn)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["ClosingPrayerID"] = new SelectList(_context.Member, "ID", "FirstName");
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "FirstName");
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            ViewData["OpeningPrayerID"] = new SelectList(_context.Member, "ID", "FirstName");
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID");
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MeetingDate,ConductingID,OpeningHymnID,OpeningPrayerID,SacramentHymnID,IntermediateHymnID,ClosingHymnID,ClosingPrayerID")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.ClosingHymnID);
            ViewData["ClosingPrayerID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.ClosingPrayerID);
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.ConductingID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.OpeningHymnID);
            ViewData["OpeningPrayerID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.OpeningPrayerID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.SacramentHymnID);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.ClosingHymnID);
            ViewData["ClosingPrayerID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.ClosingPrayerID);
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.ConductingID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.OpeningHymnID);
            ViewData["OpeningPrayerID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.OpeningPrayerID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.SacramentHymnID);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MeetingDate,ConductingID,OpeningHymnID,OpeningPrayerID,SacramentHymnID,IntermediateHymnID,ClosingHymnID,ClosingPrayerID")] Meeting meeting)
        {
            if (id != meeting.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.ID))
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
            ViewData["ClosingHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.ClosingHymnID);
            ViewData["ClosingPrayerID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.ClosingPrayerID);
            ViewData["ConductingID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.ConductingID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.OpeningHymnID);
            ViewData["OpeningPrayerID"] = new SelectList(_context.Member, "ID", "FirstName", meeting.OpeningPrayerID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Hymn, "ID", "ID", meeting.SacramentHymnID);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.ClosingHymn)
                .Include(m => m.ClosingPrayer)
                .Include(m => m.Conducting)
                .Include(m => m.IntermediateHymn)
                .Include(m => m.OpeningHymn)
                .Include(m => m.OpeningPrayer)
                .Include(m => m.SacramentHymn)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
