﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodsOrderAPI.Models;

namespace FoodsOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FoodItemsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItem()
        {
            return await _context.FoodItem.ToListAsync();
        }

        // GET: api/FoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(int id)
        {
            var foodItem = await _context.FoodItem.FindAsync(id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return foodItem;
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(int id, FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(id))
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

        // POST: api/FoodItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItem foodItem)
        {
            _context.FoodItem.Add(foodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodItem", new { id = foodItem.Id }, foodItem);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodItem>> DeleteFoodItem(int id)
        {
            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItem.Remove(foodItem);
            await _context.SaveChangesAsync();

            return foodItem;
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItem.Any(e => e.Id == id);
        }
    }
}
