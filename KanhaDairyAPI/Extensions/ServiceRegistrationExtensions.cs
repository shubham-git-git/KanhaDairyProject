using KanhaDairy.BAL.Interfaces;
using KanhaDairy.BAL.Services;

namespace KanhaDairyAPI.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        /// <summary>
        /// ✅ Add All BLL Services here
        /// </summary>
        /// <param name="services"></param>
        public static void AddBALServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IReturnService, ReturnService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ILogisticService, LogisticService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
        }
    }
}
