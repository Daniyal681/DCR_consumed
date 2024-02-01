using DAL.EntityModels;
using DCR.ViewModel.IRepos;
using DCRWebApi.Seeding;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.IRepos;
using Repository.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var provider = builder.Services.BuildServiceProvider();
var config = provider.GetService<IConfiguration>();

builder.Services.AddScoped<IAccountRepos,AccountRepos>();
builder.Services.AddScoped<IBranchRepos,BranchRepos>();
builder.Services.AddScoped<IContactPersonRepos,ContactPersonRepos>();
builder.Services.AddScoped<ICustomerRepos,CustomerRepos>();
builder.Services.AddScoped<IDistributorRepos,DistributorRepos>();
builder.Services.AddScoped<IIMEIRepos,IMEIRepos>();
builder.Services.AddScoped<IInventoryRepos,InventoryRepos>();
builder.Services.AddScoped<IMenuListRepos,MenuListRepos>();
builder.Services.AddScoped<IPaymentRepos,PaymentRepos>();
builder.Services.AddScoped<IProductRepos,ProductRepos>();
builder.Services.AddScoped<IPurchaseOrderDetailRepos,PurchaseOrderDetailRepos>();
builder.Services.AddScoped<IPurchaseOrderline,PurchaseOrderLineRepos>();
builder.Services.AddScoped<IPurchaseOrderRepos,PurchaseOrderRepos>();
builder.Services.AddScoped<IReceiveRepos,ReceiveRepos>();
builder.Services.AddScoped<IRetailorRepos,RetailorRepos>();
builder.Services.AddScoped<IRoleRepos,RoleRepos>();
builder.Services.AddScoped<ISaleOrderLineRepos,SaleOrderLineRepos>();
builder.Services.AddScoped<ISaleOrderRepos,SaleOrderRepos>();
builder.Services.AddScoped<ISalesOrderDetail,SalesOrderDetailRepos>();
builder.Services.AddScoped<IUserProfileRepos,UserProfileRepos>();
builder.Services.AddScoped<IVendorRepos,VendorRepos>();
builder.Services.AddScoped<IWarehouseRepos,WarehouseRepos>();
builder.Services.AddScoped<IDistributorIMEIRepos,DistributorImeiRepos>();
builder.Services.AddScoped<IUserRolesRepos,UserRoleRepos>();
builder.Services.AddScoped<IProductWarehouseRepos,ProductWarehouseRepos>();
builder.Services.AddScoped<IMenuPermissionsAsignRepos,MenuPermissionsAsignRepos>();
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddDbContext<EMS_ITCContext>(item => item.UseSqlServer(config.GetConnectionString("DC")));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedfactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedfactory.CreateScope())
    { 
    var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
