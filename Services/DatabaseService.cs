using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Computer_Parts_Store.Data;
using Computer_Parts_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Parts_Store.Services
{
    public class DatabaseService : IDisposable
    {
        private readonly Computer_Parts_StoreContext _context;
        private bool _disposed = false;

        public DatabaseService()
        {
            _context = new Computer_Parts_StoreContext();
        }

        #region CRUD Operations

        public async Task<List<Product>> GetProductsAsync() =>
            await _context.Products.Include(p => p.Category).AsNoTracking().ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id) =>
            await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId) =>
            await _context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).ToListAsync();

        public async Task<List<Product>> SearchProductsAsync(string searchTerm) =>
            await _context.Products
                .Where(p => p.Name.Contains(searchTerm) || p.Article.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .Include(p => p.Category)
                .ToListAsync();

        public async Task<List<Category>> GetCategoriesAsync() =>
            await _context.Categories.AsNoTracking().ToListAsync();

        public async Task<Category> GetCategoryByIdAsync(int id) =>
            await _context.Categories.FindAsync(id);

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetCustomersAsync() =>
            await _context.Customers.AsNoTracking().ToListAsync();

        public async Task<Customer> GetCustomerByIdAsync(int id) =>
            await _context.Customers.FindAsync(id);

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersAsync() =>
            await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Order> GetOrderByIdAsync(int id) =>
            await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddOrderAsync(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    item.UnitPrice = product.Price;

                    product.StockQuantity -= item.Quantity;
                    if (product.StockQuantity < 0)
                        throw new InvalidOperationException($"Недостатня кількість товару: {product.Name}");
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate) =>
            await _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

        public async Task<List<PrebuiltComputer>> GetPrebuiltComputersAsync() =>
            await _context.PrebuiltComputers.Include(pc => pc.Products).ThenInclude(p => p.Category).AsNoTracking().ToListAsync();

        public async Task<PrebuiltComputer> GetPrebuiltComputerByIdAsync(int id) =>
            await _context.PrebuiltComputers.Include(pc => pc.Products).ThenInclude(p => p.Category).FirstOrDefaultAsync(pc => pc.Id == id);

        public async Task AddPrebuiltComputerAsync(PrebuiltComputer computer)
        {
            _context.PrebuiltComputers.Add(computer);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Business Logic Methods

        public async Task<decimal> GetTotalProfitAsync(DateTime startDate, DateTime endDate)
        {
            var orders = await _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate && o.Status != "Скасоване")
                .Include(o => o.OrderItems)
                .ToListAsync();

            return orders.Sum(o => o.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice));
        }

        public async Task<List<Product>> GetTopSellingProductsAsync(int topCount = 10)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .ThenInclude(p => p.Category)
                .GroupBy(oi => oi.Product)
                .Select(g => new { Product = g.Key, TotalSold = g.Sum(oi => oi.Quantity) })
                .OrderByDescending(x => x.TotalSold)
                .Take(topCount)
                .Select(x => x.Product)
                .ToListAsync();
        }

        public async Task<bool> CheckProductAvailabilityAsync(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            return product != null && product.StockQuantity >= quantity;
        }

        public async Task UpdateProductStockAsync(int productId, int quantityChange)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.StockQuantity += quantityChange;
                if (product.StockQuantity < 0)
                    throw new InvalidOperationException("Кількість товару не може бути від'ємною");

                await _context.SaveChangesAsync();
            }
        }

        #endregion

        #region Utility Methods

        public async Task<int> GetCountAsync<T>() where T : class => await _context.Set<T>().CountAsync();

        public void ClearContextCache()
        {
            foreach (var entry in _context.ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                return await _context.Database.CanConnectAsync();
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion
    }
}