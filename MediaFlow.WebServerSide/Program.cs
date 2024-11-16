using MediaFlow.Business.Abstract;
using MediaFlow.Business.Concrete;
using MediaFlow.Core.Abstract;
using MediaFlow.Core.Concrete;
using MediaFlow.DataAccess;
using MediaFlow.DataAccess.Abstract;
using MediaFlow.DataAccess.Concrete;
using MediaFlow.WebServerSide.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ISocialMediaPlatformDal, SocialMediaPlatformDal>();
builder.Services.AddScoped<ISocialMediaPlatformService, SocialMediaPlatformService>();

builder.Services.AddScoped<IUserSocialMediaAccountDal, UserSocialMediaAccountDal>();
builder.Services.AddScoped<IUserSocialMediaAccountService, UserSocialMediaAccountService>();

builder.Services.AddScoped<IPostTypeDal, PostTypeDal>();
builder.Services.AddScoped<IPostTypeService, PostTypeService>();

builder.Services.AddScoped<IContentPostDal, ContentPostDal>();
builder.Services.AddScoped<IContentPostService, ContentPostService>();

builder.Services.AddScoped<IScheduledPostDal, ScheduledPostDal>();
builder.Services.AddScoped<IScheduledPostService, ScheduledPostService>();

builder.Services.AddScoped<IPostHistoryDal, PostHistoryDal>();
builder.Services.AddScoped<IPostHistoryService, PostHistoryService>();

builder.Services.AddScoped<IAnalyticsDal, AnalyticsDal>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

builder.Services.AddScoped<INotificationDal, NotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationService>();


var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MediaFlowDbContext>(opt => opt.UseSqlServer(conn));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();
