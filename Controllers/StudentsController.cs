#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.DataAcces;
using UniversityApiBackend.Models;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityContext _context;
        // inyectamos el servicio
        private readonly IStudentServices _studentServices;
        public StudentsController(UniversityContext context, IStudentServices studentServices)
        {
            _context = context;
            _studentServices = studentServices;
        }
        //Get: api/users/ https://localhost:7201/api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET ID
        [HttpGet("(id)")]
        public async Task<ActionResult<Student>> GetStudents(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // PUT
        [HttpPut("(id)")]
        public async Task<IActionResult> PutStudents(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Course>> PostStudents(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = student.Id }, student);
        }

        // DELETE
        [HttpDelete("(id)")]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
